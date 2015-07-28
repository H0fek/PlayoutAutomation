﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TAS.Server;
using System.Windows;
using System.Reflection;
using TAS.Common;
using System.ComponentModel;
using System.Runtime.Remoting.Messaging;
using System.Windows.Input;

namespace TAS.Client.ViewModels
{
    public class EventEditViewmodel : ViewmodelBase, IDataErrorInfo
    {
        private readonly Engine _engine;
        private readonly EngineViewmodel _engineViewModel;
        public EventEditViewmodel(EngineViewmodel engineViewModel)
        {
            _engineViewModel = engineViewModel;
            _engine = engineViewModel.Engine;
            Modified = false;
            CommandSaveEdit = new SimpleCommand() { ExecuteDelegate = _save, CanExecuteDelegate = _canSave };
            CommandCancelEdit = new SimpleCommand() { ExecuteDelegate = _load, CanExecuteDelegate = o => Modified };
            CommandDelete = new SimpleCommand() { ExecuteDelegate = _delete, CanExecuteDelegate = _canDelete };
            CommandReschedule = new SimpleCommand() { ExecuteDelegate = _reschedule, CanExecuteDelegate = _canReschedule };
            CommandAddGraphics = new SimpleCommand() { ExecuteDelegate = _addGraphics, CanExecuteDelegate = _canAddGraphics };
            CommandRemoveSubItems = new SimpleCommand() { ExecuteDelegate = _removeSubItems, CanExecuteDelegate = _canRemoveSubitems };
            CommandAddAnimation = new SimpleCommand() { ExecuteDelegate = _addAnimation, CanExecuteDelegate = _canAddGraphics };
            CommandAddNextMovie = new SimpleCommand() { ExecuteDelegate = _addNextMovie, CanExecuteDelegate = _canAddNextEvent };
            CommandAddNextEmptyMovie = new SimpleCommand() { ExecuteDelegate = _addNextEmptyMovie, CanExecuteDelegate = _canAddNextEvent };
            CommandAddNextRundown = new SimpleCommand() { ExecuteDelegate = _addNextRundown, CanExecuteDelegate = _canAddNextEvent };
            CommandAddNextLive = new SimpleCommand() { ExecuteDelegate = _addNextLive, CanExecuteDelegate = _canAddNextEvent };
            CommandAddSubMovie = new SimpleCommand() { ExecuteDelegate = _addSubMovie, CanExecuteDelegate = _canAddSubMovie };
            CommandAddSubRundown = new SimpleCommand() { ExecuteDelegate = _addSubRundown, CanExecuteDelegate = _canAddSubRundown };
            CommandAddSubLive = new SimpleCommand() { ExecuteDelegate = _addSubLive, CanExecuteDelegate = _canAddSubMovie };
            CommandChangeMovie = new SimpleCommand() { ExecuteDelegate = _changeMovie, CanExecuteDelegate = _canChangeMovie };
            CommandGetTCInTCOut = new SimpleCommand() { ExecuteDelegate =_getTCInTCOut, CanExecuteDelegate = _canGetTcInTcOut};
            CommandToggleEnabled = new SimpleCommand() { ExecuteDelegate = _toggleEnabled, CanExecuteDelegate = o => !_canReschedule(o) };
            CommandToggleHold = new SimpleCommand() { ExecuteDelegate = _toggleHold, CanExecuteDelegate = o => !_canReschedule(o) };
            CommandMoveUp = new SimpleCommand() { ExecuteDelegate = _moveUp, CanExecuteDelegate = _canMoveUp };
            CommandMoveDown = new SimpleCommand() { ExecuteDelegate = _moveDown, CanExecuteDelegate = _canMoveDown };
        }

        protected override void OnDispose()
        {
            if (_event != null)
                Event = null;
        }

        public ICommand CommandCancelEdit { get; private set; }
        public ICommand CommandSaveEdit { get; private set; }
        public ICommand CommandDelete { get; private set; } 
        public ICommand CommandReschedule { get; private set; }
        public ICommand CommandAddGraphics { get; private set; }
        public ICommand CommandAddAnimation { get; private set; }
        public ICommand CommandRemoveSubItems { get; private set; }
        public ICommand CommandAddNextMovie { get; private set; }
        public ICommand CommandAddNextEmptyMovie { get; private set; }
        public ICommand CommandAddNextRundown { get; private set; }
        public ICommand CommandAddNextLive { get; private set; }
        public ICommand CommandAddSubMovie { get; private set; }
        public ICommand CommandAddSubRundown { get; private set; }
        public ICommand CommandAddSubLive { get; private set; }
        public ICommand CommandChangeMovie { get; private set; }
        public ICommand CommandGetTCInTCOut { get; private set; }
        public ICommand CommandToggleEnabled { get; private set; }
        public ICommand CommandToggleHold { get; private set; }
        public ICommand CommandMoveUp { get; private set; }
        public ICommand CommandMoveDown { get; private set; }

        
        private Event _event;
        public Event Event
        {
            get { return _event; }
            set
            {
                Event ev = _event;
                if (ev != null && ev.Engine != _engine)
                    throw new InvalidOperationException("Edit event engine invalid");
                if (value != ev)
                {
                    if (Modified
                    && MessageBox.Show(Properties.Resources._query_SaveChangedData, Properties.Resources._caption_Confirmation, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        _save(null);
                    if (ev != null)
                    {
                        ev.PropertyChanged -= _eventPropertyChanged;
                        ev.SubEventChanged -= _onSubeventChanged;
                        ev.Relocated -= _onRelocated;
                    }
                    _event = value;
                    if (value != null)
                    {
                        value.PropertyChanged += _eventPropertyChanged;
                        value.SubEventChanged += _onSubeventChanged;
                        value.Relocated += _onRelocated;
                        var svm = _searchViewmodel;
                        if (svm != null)
                        {
                            svm.BaseEvent = value;
                            svm.NewEventStartType = TStartType.After;
                        }
                    }
                    _load(null);
                }
            }
        }

        void _save(object o)
        {
            Event e2Save = Event;
            try
            {
                if (Modified && e2Save != null)
                {
                    PropertyInfo[] copiedProperties = this.GetType().GetProperties();
                    foreach (PropertyInfo copyPi in copiedProperties)
                    {
                        PropertyInfo destPi = e2Save.GetType().GetProperty(copyPi.Name);
                        if (destPi != null)
                        {
                            if (destPi.GetValue(e2Save, null) != copyPi.GetValue(this, null)
                                && destPi.CanWrite)
                                destPi.SetValue(e2Save, copyPi.GetValue(this, null), null);
                        }
                    }
                    Modified = false;
                }
                if (e2Save != null && e2Save.Modified)
                {
                    e2Save.Save();
                    _load(null);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format(Properties.Resources._message_SaveError, e.Message), Properties.Resources._caption_Error, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        void _load(object o)
        {
            Event e2Load = _event;
            if (e2Load != null)
            {
                PropertyInfo[] copiedProperties = this.GetType().GetProperties();
                foreach (PropertyInfo copyPi in copiedProperties)
                {
                    PropertyInfo sourcePi = e2Load.GetType().GetProperty(copyPi.Name);
                    if (sourcePi != null)
                        copyPi.SetValue(this, sourcePi.GetValue(e2Load, null), null);
                }
            }
            else // _event is null
            {
                PropertyInfo[] zeroedProperties = this.GetType().GetProperties();
                foreach (PropertyInfo zeroPi in zeroedProperties)
                {
                    PropertyInfo sourcePi = typeof(Event).GetProperty(zeroPi.Name);
                    if (sourcePi != null)
                        zeroPi.SetValue(this, null, null);
                }
            }

            Modified = false;
            NotifyPropertyChanged(null);
        }

        private void _readProperty(string propertyName)
        {
            Event e2Read = _event;
            PropertyInfo writingProperty = this.GetType().GetProperty(propertyName);
            if (e2Read != null)
            {
                PropertyInfo sourcePi = e2Read.GetType().GetProperty(propertyName);
                if (sourcePi != null)
                    writingProperty.SetValue(this, sourcePi.GetValue(e2Read, null), null);
            }
            else
                writingProperty.SetValue(this, null, null);
        }

        protected override bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (base.SetField(ref field, value, propertyName))
            {
                Modified = true;
                return true;
            }
            return false;
        }

        public string Error
        {
            get { return String.Empty;}
        }

        public string this[string propertyName]
        {
            get
            {
                string validationResult = null;
                switch (propertyName)
                {
                    case "Duration":
                        validationResult = _validateDuration();
                        break;
                    case "ScheduledTC":
                        validationResult = _validateScheduledTC();
                        break;
                    case "ScheduledTime":
                        validationResult = _validateScheduledTime();
                        break;
                    case "TransitionTime":
                        validationResult = _validateTransitionTime();
                        break;
                }
                return validationResult;
            }
        }

        private string _validateScheduledTime()
        {
            Event ev = _event;
            if (ev != null && (_startType == TStartType.OnFixedTime || _startType == TStartType.Manual) && ev.PlayState == TPlayState.Scheduled && _scheduledTime < ev.Engine.CurrentTime)
                return Properties.Resources._validate_StartTimePassed;
            else 
                return string.Empty;
        }

        private string _validateScheduledTC()
        {
            string validationResult = string.Empty;
            Event ev = _event;
            if (ev != null)
            {
                Media media = _event.Media;
                if (ev.EventType == TEventType.Movie && media != null)
                {
                    if (_scheduledTC > media.Duration + media.TCStart)
                        validationResult = string.Format(Properties.Resources._validate_StartTCAfterFile, (media.Duration + media.TCStart).ToSMPTETimecodeString());
                    if (_scheduledTC < media.TCStart)
                        validationResult = string.Format(Properties.Resources._validate_StartTCBeforeFile, media.TCStart.ToSMPTETimecodeString());
                }
            }
            return validationResult;
        }

        private string _validateDuration()
        {
            string validationResult = string.Empty;
            Event ev = _event;
            if (ev != null)
            {
                Media media = _event.Media;
                if (ev.EventType == TEventType.Movie && media != null
                    && _duration + _scheduledTC > media.Duration + media.TCStart)
                    validationResult = Properties.Resources._validate_DurationInvalid;
            }
            return validationResult;
        }


        private string _validateTransitionTime()
        {
            string validationResult = string.Empty;
            if (_transitionTime > _duration)
                    validationResult = Properties.Resources._validate_TransitionTimeInvalid;
            return validationResult;
        }

        private MediaSearchViewmodel _searchViewmodel;

        private void _chooseMedia(TMediaType mediaType, Event baseEvent, TStartType startType, Action<MediaSearchEventArgs> executeOnChoose, TVideoFormat? videoFormat = null)
        {
            var svm = _searchViewmodel;
            if (svm == null)
            {
                svm = new MediaSearchViewmodel(_engineViewModel, mediaType, true, videoFormat);
                svm.BaseEvent = baseEvent;
                svm.NewEventStartType = startType;
                svm.MediaChoosen += _searchMediaChoosen;
                svm.SearchWindowClosed += _searchWindowClosed;
                svm.ExecuteAction = executeOnChoose;
                _searchViewmodel = svm;
            }
        }

        private void _searchMediaChoosen(object sender, MediaSearchEventArgs e)
        {
            if (((MediaSearchViewmodel)sender).ExecuteAction != null)
                ((MediaSearchViewmodel)sender).ExecuteAction(e);
        }

        private void _searchWindowClosed(object sender, EventArgs e)
        {
            MediaSearchViewmodel mvs = (MediaSearchViewmodel)sender;
            mvs.MediaChoosen -= _searchMediaChoosen;
            mvs.SearchWindowClosed -= _searchWindowClosed;
            _searchViewmodel.Dispose();
            _searchViewmodel = null;
        }        

        private void _delete(object o)
        {
            Event ev = _event;
            if (ev != null
                && MessageBox.Show(Properties.Resources._query_DeleteItem, Properties.Resources._caption_Confirmation, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {

                Modified = false;
                UiServices.SetBusyState();
                (new Action(() =>
                {
                    try
                    {
                        ev.Delete();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(string.Format(Properties.Resources._message_DeleteError, e.Message), Properties.Resources._caption_Error, MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            )).BeginInvoke(ar => ((Action)((AsyncResult)ar).AsyncDelegate).EndInvoke(ar), null);
            }
        }

        private Media _media;
        public Media Media
        {
            get { return _media; }
            set
            {
                SetField(ref _media, value, "Media");
            }
        }

        void _changeMovie(object o)
        {
            Event ev = _event;
            if (ev != null
                && ev.EventType == TEventType.Movie)
            {
                _chooseMedia(TMediaType.Movie, ev, ev.StartType, new Action<MediaSearchEventArgs>((e) =>
                    {
                        if (e.Media != null)
                        {
                            if (e.Media.MediaType == TMediaType.Movie)
                            {
                                Media = e.Media;
                                Duration = e.Duration;
                                ScheduledTC = e.TCIn;
                                AudioVolume = e.Media.AudioVolume;
                                EventName = e.MediaName;
                                _gpi = _setGPI(e.Media);
                                NotifyPropertyChanged("GPICanTrigger");
                                NotifyPropertyChanged("GPICrawl");
                                NotifyPropertyChanged("GPILogo");
                                NotifyPropertyChanged("GPIParental");
                            }
                        }
                    }));
            }
        }

        void _addSubLive(object o)
        {
            Event ev = _event;
            if (ev != null)
            {
                Event newEvent = new Event(ev.Engine);
                newEvent.EventType = TEventType.Live;
                newEvent.EventName = Properties.Resources._title_NewLive;
                newEvent.Duration = new TimeSpan(1, 0, 0);
                //newEvent.Save();
                ev.InsertUnder(newEvent);
            }
        }

        void _addSubRundown(object o)
        {
            Event ev = _event;
            if (ev != null)
            {
                Event newEvent = new Event(ev.Engine);
                newEvent.EventType = TEventType.Rundown;
                newEvent.EventName = Properties.Resources._title_NewRundown;
                if (ev.EventType == TEventType.Container)
                {
                    newEvent.StartType = TStartType.Manual;
                    newEvent.ScheduledTime = DateTime.Now.ToUniversalTime();
                }
                //newEvent.Save();
                ev.InsertUnder(newEvent);
            }
        }

        EventGPI _setGPI(Media media)
        {
            EventGPI GPI = new EventGPI();
            GPI.CanTrigger = false;
            GPI.Logo = (media != null
                && (media.MediaCategory == TMediaCategory.Fill || media.MediaCategory == TMediaCategory.Show || media.MediaCategory == TMediaCategory.Promo))
                ? TLogo.Normal : TLogo.NoLogo;
            GPI.Parental = media != null ? media.Parental : TParental.None;
            return GPI;
        }

        void _addSubMovie(object o)
        {
            Event ev = _event;
            var svm = _searchViewmodel;
            if (ev != null && svm == null)
            {
                svm = new MediaSearchViewmodel(_engineViewModel, TMediaType.Movie, false, null);
                svm.BaseEvent = ev;
                svm.NewEventStartType = TStartType.With;
                svm.MediaChoosen += _searchMediaChoosen;
                svm.SearchWindowClosed += _searchWindowClosed;
                svm.ExecuteAction = new Action<MediaSearchEventArgs>((e) =>
                {
                    if (e.Media != null)
                    {
                        Event newEvent = new Event(ev.Engine);
                        newEvent.EventType = TEventType.Movie;
                        newEvent.Media = e.Media;
                        newEvent.EventName = e.MediaName;
                        newEvent.ScheduledTC = e.TCIn;
                        newEvent.Duration = e.Duration;
                        newEvent.Layer = VideoLayer.Program;
                        newEvent.GPI = _setGPI(e.Media);
                        
                        //newEvent.Save();
                        if (svm.NewEventStartType == TStartType.After)
                            svm.BaseEvent.InsertAfter(newEvent);
                        if (svm.NewEventStartType == TStartType.With)
                            svm.BaseEvent.InsertUnder(newEvent);
                        ev = newEvent;
                        svm.NewEventStartType = TStartType.After;
                    }
                });
                _searchViewmodel = svm;
            }
        }

        void _addNextLive(object o)
        {
            Event ev = _event;
            if (ev != null)
            {
                Event newEvent = new Event(ev.Engine);
                newEvent.EventType = TEventType.Live;
                newEvent.EventName = Properties.Resources._title_NewLive;
                newEvent.Duration = new TimeSpan(1, 0, 0);
                //newEvent.Save();
                ev.InsertAfter(newEvent);
            }
        }

        void _addNextRundown(object o)
        {
            Event ev = _event;
            if (ev != null)
            {
                Event newEvent = new Event(ev.Engine);
                newEvent.EventType = TEventType.Rundown;
                newEvent.EventName = Properties.Resources._title_NewRundown;
                //newEvent.Save();
                ev.InsertAfter(newEvent);
            }
        }

        void _addNextEmptyMovie(object o)
        {
            Event ev = _event;
            if (ev != null)
            {
                Event newEvent = new Event(ev.Engine);
                newEvent.EventType = TEventType.Movie;
                newEvent.EventName = Properties.Resources._title_EmptyMovie;
                ev.InsertAfter(newEvent);
            }
        }

        void _addNextMovie(object o)
        {
            Event ev = _event;
            var svm = _searchViewmodel;
            if (ev != null && svm == null)
            {
                svm = new MediaSearchViewmodel(_engineViewModel, TMediaType.Movie, false, null);
                svm.BaseEvent = ev;
                svm.NewEventStartType = TStartType.After;
                svm.MediaChoosen += _searchMediaChoosen;
                svm.SearchWindowClosed += _searchWindowClosed;
                svm.ExecuteAction = new Action<MediaSearchEventArgs>((e) =>
                    {
                        if (e.Media != null)
                        {
                            Event newEvent = new Event(ev.Engine);
                            newEvent.EventType = TEventType.Movie;
                            newEvent.Media = e.Media;
                            newEvent.EventName = e.MediaName;
                            newEvent.ScheduledTC = e.TCIn;
                            newEvent.Duration = e.Duration;
                            newEvent.Layer = VideoLayer.Program;
                            newEvent.GPI = _setGPI(e.Media);

                            //newEvent.Save();
                            if (svm.NewEventStartType == TStartType.After)
                                svm.BaseEvent.InsertAfter(newEvent);
                            if (svm.NewEventStartType == TStartType.With)
                                svm.BaseEvent.InsertUnder(newEvent);
                            ev = newEvent;
                        }
                    });
                _searchViewmodel = svm;
            }
        }

        void _removeSubItems(object o)
        {
            Event aEvent = _event;
            if (aEvent != null
                && MessageBox.Show(Properties.Resources._query_DeleteAllGraphics, Properties.Resources._caption_Confirmation, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (Event ev in aEvent.SubEvents.ToList().Where(e => e.EventType == TEventType.StillImage || e.EventType == TEventType.AnimationFlash))
                    ev.Delete();
                NotifyPropertyChanged("HasSubItemOnLayer1");
                NotifyPropertyChanged("HasSubItemOnLayer2");
                NotifyPropertyChanged("HasSubItemOnLayer3");
            }
        }

        private void _addGraphics(object layer)
        {
            Event ev = _event;
            if (ev != null)
            {
                Event sle = ev.SubEvents.FirstOrDefault(e => e.Layer == (VideoLayer)int.Parse(layer as string) && e.EventType == TEventType.StillImage);
                if (sle == null)
                {
                    Media media = ev.Media;
                    TVideoFormat? format = media == null ? null : (TVideoFormat?)media.VideoFormat;
                    _chooseMedia(TMediaType.Still, this.Event, TStartType.With, new Action<MediaSearchEventArgs>((e) =>
                        {
                            var m = e.Media;
                            if (m != null)
                            {
                                Event newEvent = new Event(ev.Engine);
                                newEvent.EventType = TEventType.StillImage;
                                newEvent.Media = m;
                                newEvent.EventName = m.MediaName;
                                newEvent.Duration = ev.Duration;
                                newEvent.Layer = (VideoLayer)int.Parse(layer as string);
                                //newEvent.Save();
                                ev.InsertUnder(newEvent);
                            }

                        }), format);
                }
                else
                {
                    sle.Delete();
                }
                NotifyPropertyChanged("HasSubItemOnLayer1");
                NotifyPropertyChanged("HasSubItemOnLayer2");
                NotifyPropertyChanged("HasSubItemOnLayer3");
            }
        }

        void _addAnimation(object layer)
        {
            Event ev = _event;
            if (ev != null)
            {
                Event sle = ev.SubEvents.FirstOrDefault(e => e.Layer == (VideoLayer)int.Parse(layer as string) && e.EventType == TEventType.AnimationFlash);
                if (sle == null)
                {
                    _chooseMedia(TMediaType.AnimationFlash, this.Event, TStartType.With, new Action<MediaSearchEventArgs>((e) =>
                    {
                        var m = e.Media;
                        if (m != null)
                        {
                            Event newEvent = new Event(ev.Engine);
                            newEvent.EventType = TEventType.AnimationFlash;
                            newEvent.Media = m;
                            newEvent.EventName = m.MediaName;
                            newEvent.Duration = ev.Duration;
                            newEvent.Layer = (VideoLayer)int.Parse(layer as string);
                            //newEvent.Save();
                            ev.InsertUnder(newEvent);
                        }

                    }));
                }
                else
                {
                    sle.Delete();
                }
                NotifyPropertyChanged("HasAnimation");
            }
        }


        void _reschedule(object o)
        {
            Event ev = _event;
            if (ev != null)
                _engine.ReSchedule(ev);
        }

        void _getTCInTCOut(object o)
        {
            var pwm = _engineViewModel.PreviewViewmodel;
            if (pwm != null && pwm.IsLoaded)
            {
                ScheduledTC = pwm.TCIn;
                Duration = pwm.DurationSelection;
            }
        }

        void _toggleEnabled(object o)
        {
            Event ev = Event;
            if (ev != null)
            {
                ev.Enabled = !ev.Enabled;
                ev.Save();
            }
        }

        void _toggleHold(object o)
        {
            Event ev = Event;
            if (ev != null && ev._eventType != TEventType.Container)
            {
                ev.Hold = !ev.Hold;
                ev.Save();
            }
        }

        void _moveUp(object o)
        {
            Event ev = _event;
            if (ev != null)
                ev.MoveUp();
        }

        void _moveDown(object o)
        {
            Event ev = _event;
            if (ev != null)
                ev.MoveDown();
        }

        bool _canAddNextEvent(object o)
        {
            Event ev = _event;
            return ev != null
                && (ev.PlayState == TPlayState.Scheduled || ev.PlayState == TPlayState.Playing)
                && (ev.EventType == TEventType.Rundown || ev.EventType == TEventType.Movie || ev.EventType == TEventType.Live);
        }
        
        bool _canAddSubMovie(object o)
        {
            Event ev = _event;
            return ev != null
                && ev.PlayState == TPlayState.Scheduled
                && ev.EventType == TEventType.Rundown
                && ev.SubEvents.Count == 0;
        }

        bool _canAddSubRundown(object o)
        {
            Event ev = _event;
            return ev != null
                && ((ev.PlayState == TPlayState.Scheduled && ev.EventType == TEventType.Rundown && ev.SubEvents.Count == 0) || ev.EventType == TEventType.Container);
        }

        
        bool _canAddGraphics(object o)
        {
            Event ev = _event;
            return ev != null
                && (ev.PlayState == TPlayState.Scheduled || ev.PlayState == TPlayState.Paused || ev.PlayState == TPlayState.Playing || ev.PlayState == TPlayState.Fading)
                && (ev.EventType == TEventType.Movie || ev.EventType == TEventType.Live);
        }

        bool _canRemoveSubitems(object o)
        {
            Event ev = _event;
            return ev != null
                && ev.PlayState == TPlayState.Scheduled
                && ev.SubEvents.Any(e => e.EventType == TEventType.StillImage);
        }

        bool _canReschedule(object o)
        {
            Event ev = _event;
            return ev != null
                && (ev.PlayState == TPlayState.Played || ev.PlayState == TPlayState.Aborted);
        }
        bool _canDelete(object o)
        {
            Event ev = _event;
            return ev != null
                && (ev.PlayState == TPlayState.Played || ev.PlayState == TPlayState.Aborted || ev.PlayState == TPlayState.Scheduled);
        }
        bool _canChangeMovie(object o)
        {
            Event ev = _event;
            return ev != null
                && ev.PlayState == TPlayState.Scheduled && ev.EventType == TEventType.Movie;
        }
        bool _canSave(object o)
        {
            Event ev = _event;
            return ev != null
                && (Modified || ev.Modified);
        }
        bool _canGetTcInTcOut(object o)
        {
            Event ev = _event;
            var previewVm = _engineViewModel.PreviewViewmodel;
            var previewMedia = (previewVm != null) ? previewVm.LoadedMedia : null;
            return (ev != null)
                && previewMedia != null
                && ev.ServerMediaPRV == previewMedia;
        }
        bool _canMoveUp(object o)
        {
            Event ev = _event;
            Event prior = ev == null ? null : ev.Prior;
            return prior != null && prior.PlayState == TPlayState.Scheduled && ev.PlayState == TPlayState.Scheduled;
        }
        bool _canMoveDown(object o)
        {
            Event ev = _event;
            Event next = ev == null ? null : ev.Next;
            return next != null && next.PlayState == TPlayState.Scheduled && ev.PlayState == TPlayState.Scheduled;
        }

        private bool _modified;
        public bool Modified
        {
            get { return _modified; }
            private set
            {
                if (_modified != value)
                    _modified = value;
            }
        }

        private TEventType _eventType;
        public TEventType EventType
        {
            get { return _eventType; }
            set { SetField(ref _eventType, value, "EventType"); }
        }

        private string _eventName;
        public string EventName
        {
            get { return _eventName; }
            set { SetField(ref _eventName, value, "EventName"); }
        }

        public bool IsEditEnabled
        {
            get
            {
                var ev = _event;
                return ev != null && ev.PlayState == TPlayState.Scheduled;
            }
        }

        public bool IsMovieOrLive
        {
            get
            {
                var ev = _event;
                return ev != null 
                    && (ev.EventType == TEventType.Movie || ev.EventType == TEventType.Live);
            }
        }

        public bool IsMovie
        {
            get
            {
                var ev = _event;
                return ev != null 
                    && ev.EventType == TEventType.Movie;
            }
        }

        public bool IsTransitionPanelEnabled
        {
            get { 
                var ev = _event;
                return ev != null && !_hold && (ev.EventType == TEventType.Live || ev.EventType == TEventType.Movie);
                }
        }

        public bool IsNotContainer
        {
            get { 
                var ev = _event;
                return ev != null && ev.EventType != TEventType.Container;
                }
        }

        public bool CanHold { get { return _event != null && _event.Prior != null; } }

        private bool _enabled;
        public bool Enabled
        {
            get { return _enabled; }
            set { SetField(ref _enabled, value, "Enabled"); }
        }

        private bool _hold;
        public bool Hold
        {
            get { return _hold; }
            set
            {
                if (SetField(ref _hold, value, "Hold"))
                {
                    if (value)
                        TransitionTime = TimeSpan.Zero;
                    NotifyPropertyChanged("IsTransitionPanelEnabled");
                }
            }
        }

        private TStartType _startType;
        public TStartType StartType
        {
            get { return _startType; }
            set { SetField(ref _startType, value, "StartType"); }
        }

        public string BoundEventName
        {
            get
            {
                Event ev = Event;
                Event boundEvent = ev == null ? null : (ev._startType == TStartType.With) ? ev.Parent : (ev._startType == TStartType.After) ? ev.Prior : null;
                return boundEvent == null ? string.Empty : boundEvent.EventName;
            }
        }

        private TimeSpan _scheduledTC;
        public TimeSpan ScheduledTC
        {
            get { return _scheduledTC; }
            set { 
                SetField(ref _scheduledTC, value, "ScheduledTC");
                NotifyPropertyChanged("Duration");
            }
        }

        readonly Array _transitionTypes = Enum.GetValues(typeof(TTransitionType));
        public Array TransitionTypes { get { return _transitionTypes; } }

        private TTransitionType _transitionType;
        public TTransitionType TransitionType
        {
            get { return _transitionType; }
            set { SetField(ref _transitionType, value, "TransitionType"); }
        }

        private TimeSpan _transitionTime;
        public TimeSpan TransitionTime
        {
            get { return _transitionTime; }
            set { SetField(ref _transitionTime, value, "TransitionTime"); }
        }

        private decimal _audioVolume;
        public decimal AudioVolume
        {
            get { return _audioVolume; }
            set { SetField(ref _audioVolume, value, "AudioVolume"); }
        }

        private DateTime _scheduledTime;
        public DateTime ScheduledTime
        {
            get { return _scheduledTime; }
            set { SetField(ref _scheduledTime, value, "ScheduledTime"); }
        }

        private TimeSpan? _requestedStartTime;
        public TimeSpan? RequestedStartTime
        {
            get { return _requestedStartTime; }
            set { SetField(ref _requestedStartTime, value, "RequestedStartTime"); }
        }

        private TimeSpan _duration;
        public TimeSpan Duration
        {
            get { return _duration; }
            set
            {
                SetField(ref _duration, value, "Duration");
                NotifyPropertyChanged("ScheduledTC");
            }
        }

        private TimeSpan _scheduledDelay;
        public TimeSpan ScheduledDelay
        {
            get { return _scheduledDelay; }
            set { SetField(ref _scheduledDelay, value, "ScheduledDelay"); }
        }

        private sbyte _layer;
        public sbyte Layer
        {
            get { return _layer; }
            set { SetField(ref _layer, value, "Layer"); }
        }

        public bool HasSubItemOnLayer1
        {
            get
            {
                Event ev = Event;
                return (ev == null) ? false : (ev.EventType == TEventType.StillImage) ? ev.Layer == VideoLayer.CG1 : ev.SubEvents.ToList().Any(e => e.Layer == VideoLayer.CG1 && e.EventType == TEventType.StillImage);
            }
        }
        public bool HasSubItemOnLayer2
        {
            get
            {
                Event ev = Event;
                return (ev == null) ? false : (ev.EventType == TEventType.StillImage) ? ev.Layer == VideoLayer.CG2 : ev.SubEvents.ToList().Any(e => e.Layer == VideoLayer.CG2 && e.EventType == TEventType.StillImage);
            }
        }
        public bool HasSubItemOnLayer3
        {
            get
            {
                Event ev = Event;
                return (ev == null) ? false : (ev.EventType == TEventType.StillImage) ? ev.Layer == VideoLayer.CG3 : ev.SubEvents.ToList().Any(e => e.Layer == VideoLayer.CG3 && e.EventType == TEventType.StillImage);
            }
        }

        public bool HasSubItems
        {
            get
            {
                Event ev = Event;
                return (ev == null || ev.EventType == TEventType.Live || ev.EventType == TEventType.Movie) ? false : ev.SubEvents.ToList().Any(e => e.EventType == TEventType.StillImage);
            }
        }
        public bool HasAnimation
        {
            get
            {
                Event ev = Event;
                return (ev == null) ? false : (ev.EventType == TEventType.AnimationFlash) ? ev.Layer == 0 : ev.SubEvents.ToList().Any(e => e.Layer == 0 && e.EventType == TEventType.AnimationFlash);
            }
        }

        public bool IsScheduledTimeEnabled
        {
            get
            {
                Event ev = Event;
                return !((ev == null) || ev.StartType == TStartType.After || ev.StartType == TStartType.With);
            }
        }

        public bool IsDurationEnabled
        {
            get
            {
                Event ev = Event;
                return (ev != null) && ev.EventType != TEventType.Rundown;
            }
        }

        #region GPI
        private EventGPI _gpi;
        public EventGPI GPI { get { return _gpi; } set { _gpi = value; } }

        public bool GPICanTrigger
        {
            get { return _gpi.CanTrigger; }
            set { SetField(ref _gpi.CanTrigger, value, "GPICanTrigger"); }
        }

        readonly Array _gPIParentals = Enum.GetValues(typeof(TParental));
        public Array GPIParentals { get { return _gPIParentals; } }
        public TParental GPIParental
        {
            get { return _gpi.Parental; }
            set { SetField(ref _gpi.Parental, value, "GPIParental"); }
        }

        readonly Array _gPILogos = Enum.GetValues(typeof(TLogo));
        public Array GPILogos { get { return _gPILogos; } }
        public TLogo GPILogo
        {
            get { return _gpi.Logo; }
            set { SetField(ref _gpi.Logo, value, "GPILogo"); }
        }

        readonly Array _gPICrawls = Enum.GetValues(typeof(TCrawl));
        public Array GPICrawls { get { return _gPICrawls; } }
        public TCrawl GPICrawl
        {
            get { return _gpi.Crawl; }
            set { SetField(ref _gpi.Crawl, value, "GPICrawl"); }
        }

        #endregion // GPI

        internal void _previewPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Media")
                NotifyPropertyChanged("CommandGetTCInTCOut");
        }

        private void _eventPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "Position")
                Application.Current.Dispatcher.BeginInvoke((Action)delegate()
                {
                        bool oldModified = _modified;
                        PropertyInfo sourcePi = sender.GetType().GetProperty(e.PropertyName);
                        PropertyInfo destPi = this.GetType().GetProperty(e.PropertyName);
                        if (sourcePi != null && destPi != null)
                            destPi.SetValue(this, sourcePi.GetValue(sender, null), null);
                        _modified = oldModified;
                });
            if (e.PropertyName == "GPI")
            {
                NotifyPropertyChanged("GPICanTrigger");
                NotifyPropertyChanged("GPIParental");
                NotifyPropertyChanged("GPILogo");
                NotifyPropertyChanged("GPICrawl");
            }

            if (e.PropertyName == "PlayState")
            {
                NotifyPropertyChanged("IsEditEnabled");
                NotifyPropertyChanged("IsMovieOrLive");
                NotifyPropertyChanged("CommandAddAnimation");
                NotifyPropertyChanged("CommandAddGraphics");
                NotifyPropertyChanged("CommandAddNextEmptyMovie");
                NotifyPropertyChanged("CommandAddNextLive");
                NotifyPropertyChanged("CommandAddNextRundown");
                NotifyPropertyChanged("CommandAddSubLive");
                NotifyPropertyChanged("CommandAddSubMovie");
                NotifyPropertyChanged("CommandAddSubRundown");
                NotifyPropertyChanged("CommandRemoveSubItems");
                NotifyPropertyChanged("CommandReschedule");
                NotifyPropertyChanged("CommandToggleEnabled");
                NotifyPropertyChanged("CommandToggleHold");
            }
            if (e.PropertyName == "Next" || e.PropertyName == "Prior")
            {
                NotifyPropertyChanged("CommandMoveDown");
                NotifyPropertyChanged("CommandMoveUp");
            }
        }

        private void _onSubeventChanged(object o, CollectionOperationEventArgs<Event> e)
        {
            if (((o as Event).EventType == TEventType.Live || (o as Event).EventType == TEventType.Movie)
                && (e.Item.EventType == TEventType.StillImage || e.Item.EventType == TEventType.AnimationFlash))
            {

                switch (e.Item.Layer)
                {
                    case VideoLayer.CG1:
                        NotifyPropertyChanged("HasSubItemOnLayer1");
                        break;
                    case VideoLayer.CG2:
                        NotifyPropertyChanged("HasSubItemOnLayer2");
                        break;
                    case VideoLayer.CG3:
                        NotifyPropertyChanged("HasSubItemOnLayer3");
                        break;
                }
            }
        }

        private void _onRelocated(object o, EventArgs e)
        {
            NotifyPropertyChanged("StartType");
            NotifyPropertyChanged("BoundEventName");
            NotifyPropertyChanged("ScheduledTime");
        }

        //public void EventOperation(object sender, EventOperationEventArgs a)
        //{
        //    if (sender == _event && Application.Current != null)
        //    {
        //        //if (a.Operation == TEventOperation.Delete)
        //        //{
        //        //    Application.Current.Dispatcher.BeginInvoke((Action)delegate()
        //        //    {
        //        //        Event = null;
        //        //    });
        //        //}

        //        if (a.Operation == TEventOperation.PlayStateChanged || a.Operation == TEventOperation.Modify || a.Operation == TEventOperation.Save)
        //        {
        //            Application.Current.Dispatcher.BeginInvoke((Action)delegate() 
        //            {
        //                lock (this)
        //                    _setCommandsCanExecute();
        //            });
        //            NotifyPropertyChanged("IsEditEnabled");
        //        }
        //    }
        //}

    }

}
