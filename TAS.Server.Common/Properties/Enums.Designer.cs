﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TAS.Server.Common.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Enums {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Enums() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TAS.Server.Common.Properties.Enums", typeof(Enums).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Console.
        /// </summary>
        public static string AuthenticationSource_Console {
            get {
                return ResourceManager.GetString("AuthenticationSource_Console", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Station IP address.
        /// </summary>
        public static string AuthenticationSource_IpAddress {
            get {
                return ResourceManager.GetString("AuthenticationSource_IpAddress", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Windows credentials.
        /// </summary>
        public static string AuthenticationSource_WindowsCredentials {
            get {
                return ResourceManager.GetString("AuthenticationSource_WindowsCredentials", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Aborted.
        /// </summary>
        public static string FileOperationStatus_Aborted {
            get {
                return ResourceManager.GetString("FileOperationStatus_Aborted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed.
        /// </summary>
        public static string FileOperationStatus_Failed {
            get {
                return ResourceManager.GetString("FileOperationStatus_Failed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Finished.
        /// </summary>
        public static string FileOperationStatus_Finished {
            get {
                return ResourceManager.GetString("FileOperationStatus_Finished", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to In progress.
        /// </summary>
        public static string FileOperationStatus_InProgress {
            get {
                return ResourceManager.GetString("FileOperationStatus_InProgress", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Waiting.
        /// </summary>
        public static string FileOperationStatus_Waiting {
            get {
                return ResourceManager.GetString("FileOperationStatus_Waiting", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to None, enforce 16:9.
        /// </summary>
        public static string TAspectConversion_Force16_9 {
            get {
                return ResourceManager.GetString("TAspectConversion_Force16_9", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to None, enforce 4:3.
        /// </summary>
        public static string TAspectConversion_Force4_3 {
            get {
                return ResourceManager.GetString("TAspectConversion_Force4_3", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Letterbox (16:9-&gt;4:3).
        /// </summary>
        public static string TAspectConversion_Letterbox {
            get {
                return ResourceManager.GetString("TAspectConversion_Letterbox", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No conversion.
        /// </summary>
        public static string TAspectConversion_NoConversion {
            get {
                return ResourceManager.GetString("TAspectConversion_NoConversion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Pan&amp;Scan(16:9-&gt;4:3).
        /// </summary>
        public static string TAspectConversion_PanScan {
            get {
                return ResourceManager.GetString("TAspectConversion_PanScan", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to PillarBox (4:3-&gt;16:9).
        /// </summary>
        public static string TAspectConversion_PillarBox {
            get {
                return ResourceManager.GetString("TAspectConversion_PillarBox", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tilt&amp;Scan(4:3-&gt;16:9).
        /// </summary>
        public static string TAspectConversion_TiltScan {
            get {
                return ResourceManager.GetString("TAspectConversion_TiltScan", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to GPI trigger.
        /// </summary>
        public static string TAspectRatioControl_GPI {
            get {
                return ResourceManager.GetString("TAspectRatioControl_GPI", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Image resize and GPI.
        /// </summary>
        public static string TAspectRatioControl_GPIandImageResize {
            get {
                return ResourceManager.GetString("TAspectRatioControl_GPIandImageResize", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Image resize.
        /// </summary>
        public static string TAspectRatioControl_ImageResize {
            get {
                return ResourceManager.GetString("TAspectRatioControl_ImageResize", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to None.
        /// </summary>
        public static string TAspectRatioControl_None {
            get {
                return ResourceManager.GetString("TAspectRatioControl_None", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Dolby Digital.
        /// </summary>
        public static string TAudioChannelMapping_DolbyDigital {
            get {
                return ResourceManager.GetString("TAudioChannelMapping_DolbyDigital", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Dolby E.
        /// </summary>
        public static string TAudioChannelMapping_DolbyE {
            get {
                return ResourceManager.GetString("TAudioChannelMapping_DolbyE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DTS.
        /// </summary>
        public static string TAudioChannelMapping_Dts {
            get {
                return ResourceManager.GetString("TAudioChannelMapping_Dts", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Mono.
        /// </summary>
        public static string TAudioChannelMapping_Mono {
            get {
                return ResourceManager.GetString("TAudioChannelMapping_Mono", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SMPTE.
        /// </summary>
        public static string TAudioChannelMapping_Smpte {
            get {
                return ResourceManager.GetString("TAudioChannelMapping_Smpte", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Stereo.
        /// </summary>
        public static string TAudioChannelMapping_Stereo {
            get {
                return ResourceManager.GetString("TAudioChannelMapping_Stereo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unknown.
        /// </summary>
        public static string TAudioChannelMapping_Unknown {
            get {
                return ResourceManager.GetString("TAudioChannelMapping_Unknown", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tracks 1 i 2 -&gt; Mono.
        /// </summary>
        public static string TAudioChannelMappingConversion_Combine1plus2 {
            get {
                return ResourceManager.GetString("TAudioChannelMappingConversion_Combine1plus2", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tracks 3 i 4 -&gt; Mono.
        /// </summary>
        public static string TAudioChannelMappingConversion_Combine3plus4 {
            get {
                return ResourceManager.GetString("TAudioChannelMappingConversion_Combine3plus4", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Default (possible downmix).
        /// </summary>
        public static string TAudioChannelMappingConversion_Default {
            get {
                return ResourceManager.GetString("TAudioChannelMappingConversion_Default", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Track 1 -&gt; Mono.
        /// </summary>
        public static string TAudioChannelMappingConversion_FirstChannelOnly {
            get {
                return ResourceManager.GetString("TAudioChannelMappingConversion_FirstChannelOnly", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tracks 1 i 2 -&gt; Stereo.
        /// </summary>
        public static string TAudioChannelMappingConversion_FirstTwoChannels {
            get {
                return ResourceManager.GetString("TAudioChannelMappingConversion_FirstTwoChannels", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Track 2 -&gt; Mono.
        /// </summary>
        public static string TAudioChannelMappingConversion_SecondChannelOnly {
            get {
                return ResourceManager.GetString("TAudioChannelMappingConversion_SecondChannelOnly", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tracks 3 i 4 -&gt; Stereo.
        /// </summary>
        public static string TAudioChannelMappingConversion_SecondTwoChannels {
            get {
                return ResourceManager.GetString("TAudioChannelMappingConversion_SecondTwoChannels", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Animation.
        /// </summary>
        public static string TEventType_Animation {
            get {
                return ResourceManager.GetString("TEventType_Animation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Container.
        /// </summary>
        public static string TEventType_Container {
            get {
                return ResourceManager.GetString("TEventType_Container", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Live.
        /// </summary>
        public static string TEventType_Live {
            get {
                return ResourceManager.GetString("TEventType_Live", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Clip.
        /// </summary>
        public static string TEventType_Movie {
            get {
                return ResourceManager.GetString("TEventType_Movie", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Rundown.
        /// </summary>
        public static string TEventType_Rundown {
            get {
                return ResourceManager.GetString("TEventType_Rundown", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Graphics.
        /// </summary>
        public static string TEventType_StillImage {
            get {
                return ResourceManager.GetString("TEventType_StillImage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Bottom field first.
        /// </summary>
        public static string TFieldOrder_BFF {
            get {
                return ResourceManager.GetString("TFieldOrder_BFF", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Progressive scan.
        /// </summary>
        public static string TFieldOrder_Progressive {
            get {
                return ResourceManager.GetString("TFieldOrder_Progressive", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Top field first.
        /// </summary>
        public static string TFieldOrder_TFF {
            get {
                return ResourceManager.GetString("TFieldOrder_TFF", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Detect automatically.
        /// </summary>
        public static string TFieldOrder_Unknown {
            get {
                return ResourceManager.GetString("TFieldOrder_Unknown", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Watch folder with BMD&apos;s MediaExpress XML files.
        /// </summary>
        public static string TIngestDirectoryKind_BmdMediaExpressWatchFolder {
            get {
                return ResourceManager.GetString("TIngestDirectoryKind_BmdMediaExpressWatchFolder", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Simple watch folder.
        /// </summary>
        public static string TIngestDirectoryKind_WatchFolder {
            get {
                return ResourceManager.GetString("TIngestDirectoryKind_WatchFolder", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to XDCAM drive.
        /// </summary>
        public static string TIngestDirectoryKind_XDCAM {
            get {
                return ResourceManager.GetString("TIngestDirectoryKind_XDCAM", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ingest in progress.
        /// </summary>
        public static string TIngestStatus_InProgress {
            get {
                return ResourceManager.GetString("TIngestStatus_InProgress", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Not ingested yet.
        /// </summary>
        public static string TIngestStatus_NotReady {
            get {
                return ResourceManager.GetString("TIngestStatus_NotReady", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Already ingested.
        /// </summary>
        public static string TIngestStatus_Ready {
            get {
                return ResourceManager.GetString("TIngestStatus_Ready", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unknown.
        /// </summary>
        public static string TIngestStatus_Unknown {
            get {
                return ResourceManager.GetString("TIngestStatus_Unknown", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Commercial.
        /// </summary>
        public static string TMediaCategory_Commercial {
            get {
                return ResourceManager.GetString("TMediaCategory_Commercial", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Fill.
        /// </summary>
        public static string TMediaCategory_Fill {
            get {
                return ResourceManager.GetString("TMediaCategory_Fill", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Insert.
        /// </summary>
        public static string TMediaCategory_Insert {
            get {
                return ResourceManager.GetString("TMediaCategory_Insert", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Jingle.
        /// </summary>
        public static string TMediaCategory_Jingle {
            get {
                return ResourceManager.GetString("TMediaCategory_Jingle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Promo.
        /// </summary>
        public static string TMediaCategory_Promo {
            get {
                return ResourceManager.GetString("TMediaCategory_Promo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Show.
        /// </summary>
        public static string TMediaCategory_Show {
            get {
                return ResourceManager.GetString("TMediaCategory_Show", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sponsored.
        /// </summary>
        public static string TMediaCategory_Sponsored {
            get {
                return ResourceManager.GetString("TMediaCategory_Sponsored", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Uncategorized.
        /// </summary>
        public static string TMediaCategory_Uncategorized {
            get {
                return ResourceManager.GetString("TMediaCategory_Uncategorized", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Beige.
        /// </summary>
        public static string TMediaEmphasis_Beige {
            get {
                return ResourceManager.GetString("TMediaEmphasis_Beige", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Green.
        /// </summary>
        public static string TMediaEmphasis_Green {
            get {
                return ResourceManager.GetString("TMediaEmphasis_Green", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to According to category.
        /// </summary>
        public static string TMediaEmphasis_None {
            get {
                return ResourceManager.GetString("TMediaEmphasis_None", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Olive.
        /// </summary>
        public static string TMediaEmphasis_Olive {
            get {
                return ResourceManager.GetString("TMediaEmphasis_Olive", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Orange.
        /// </summary>
        public static string TMediaEmphasis_Orange {
            get {
                return ResourceManager.GetString("TMediaEmphasis_Orange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Pink.
        /// </summary>
        public static string TMediaEmphasis_Pink {
            get {
                return ResourceManager.GetString("TMediaEmphasis_Pink", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Blue.
        /// </summary>
        public static string TMediaEmphasis_SkyBlue {
            get {
                return ResourceManager.GetString("TMediaEmphasis_SkyBlue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Turquoise.
        /// </summary>
        public static string TMediaEmphasis_Turquoise {
            get {
                return ResourceManager.GetString("TMediaEmphasis_Turquoise", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Violet.
        /// </summary>
        public static string TMediaEmphasis_Violet {
            get {
                return ResourceManager.GetString("TMediaEmphasis_Violet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Yellow.
        /// </summary>
        public static string TMediaEmphasis_Yellow {
            get {
                return ResourceManager.GetString("TMediaEmphasis_Yellow", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to File missing.
        /// </summary>
        public static string TMediaErrorInfo_Missing {
            get {
                return ResourceManager.GetString("TMediaErrorInfo_Missing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to .
        /// </summary>
        public static string TMediaErrorInfo_NoError {
            get {
                return ResourceManager.GetString("TMediaErrorInfo_NoError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Clip too short.
        /// </summary>
        public static string TMediaErrorInfo_TooShort {
            get {
                return ResourceManager.GetString("TMediaErrorInfo_TooShort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Available.
        /// </summary>
        public static string TMediaStatus_Available {
            get {
                return ResourceManager.GetString("TMediaStatus_Available", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Copy finished.
        /// </summary>
        public static string TMediaStatus_Copied {
            get {
                return ResourceManager.GetString("TMediaStatus_Copied", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Copy error.
        /// </summary>
        public static string TMediaStatus_CopyError {
            get {
                return ResourceManager.GetString("TMediaStatus_CopyError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Copying.
        /// </summary>
        public static string TMediaStatus_Copying {
            get {
                return ResourceManager.GetString("TMediaStatus_Copying", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Copy pending.
        /// </summary>
        public static string TMediaStatus_CopyPending {
            get {
                return ResourceManager.GetString("TMediaStatus_CopyPending", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Deleted.
        /// </summary>
        public static string TMediaStatus_Deleted {
            get {
                return ResourceManager.GetString("TMediaStatus_Deleted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Required.
        /// </summary>
        public static string TMediaStatus_Required {
            get {
                return ResourceManager.GetString("TMediaStatus_Required", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unknown.
        /// </summary>
        public static string TMediaStatus_Unknown {
            get {
                return ResourceManager.GetString("TMediaStatus_Unknown", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Validation error.
        /// </summary>
        public static string TMediaStatus_ValidationError {
            get {
                return ResourceManager.GetString("TMediaStatus_ValidationError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Animation.
        /// </summary>
        public static string TMediaType_Animation {
            get {
                return ResourceManager.GetString("TMediaType_Animation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Flash animation.
        /// </summary>
        public static string TMediaType_AnimationFlash {
            get {
                return ResourceManager.GetString("TMediaType_AnimationFlash", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Audio.
        /// </summary>
        public static string TMediaType_Audio {
            get {
                return ResourceManager.GetString("TMediaType_Audio", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Clip.
        /// </summary>
        public static string TMediaType_Movie {
            get {
                return ResourceManager.GetString("TMediaType_Movie", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Graphics.
        /// </summary>
        public static string TMediaType_Still {
            get {
                return ResourceManager.GetString("TMediaType_Still", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unknown.
        /// </summary>
        public static string TMediaType_Unknown {
            get {
                return ResourceManager.GetString("TMediaType_Unknown", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 4 channels, 16 bits per sample.
        /// </summary>
        public static string TmXFAudioExportFormat_Channels4Bits16 {
            get {
                return ResourceManager.GetString("TmXFAudioExportFormat_Channels4Bits16", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 4 channels, 24 bits per sample.
        /// </summary>
        public static string TmXFAudioExportFormat_Channels4Bits24 {
            get {
                return ResourceManager.GetString("TmXFAudioExportFormat_Channels4Bits24", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 8 channels, 16 bits per sample.
        /// </summary>
        public static string TmXFAudioExportFormat_Channels8Bits16 {
            get {
                return ResourceManager.GetString("TmXFAudioExportFormat_Channels8Bits16", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Aborted.
        /// </summary>
        public static string TPlayState_Aborted {
            get {
                return ResourceManager.GetString("TPlayState_Aborted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Fading.
        /// </summary>
        public static string TPlayState_Fading {
            get {
                return ResourceManager.GetString("TPlayState_Fading", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Paused.
        /// </summary>
        public static string TPlayState_Paused {
            get {
                return ResourceManager.GetString("TPlayState_Paused", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Played.
        /// </summary>
        public static string TPlayState_Played {
            get {
                return ResourceManager.GetString("TPlayState_Played", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Playing.
        /// </summary>
        public static string TPlayState_Playing {
            get {
                return ResourceManager.GetString("TPlayState_Playing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to .
        /// </summary>
        public static string TPlayState_Scheduled {
            get {
                return ResourceManager.GetString("TPlayState_Scheduled", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CasparCG (main release).
        /// </summary>
        public static string TServerType_Caspar {
            get {
                return ResourceManager.GetString("TServerType_Caspar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CasparCG (TVP&apos;s fork).
        /// </summary>
        public static string TServerType_CasparTVP {
            get {
                return ResourceManager.GetString("TServerType_CasparTVP", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to After finish.
        /// </summary>
        public static string TStartType_After {
            get {
                return ResourceManager.GetString("TStartType_After", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Manual.
        /// </summary>
        public static string TStartType_Manual {
            get {
                return ResourceManager.GetString("TStartType_Manual", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can&apos;t start.
        /// </summary>
        public static string TStartType_None {
            get {
                return ResourceManager.GetString("TStartType_None", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to At fixed time.
        /// </summary>
        public static string TStartType_OnFixedTime {
            get {
                return ResourceManager.GetString("TStartType_OnFixedTime", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to With start of.
        /// </summary>
        public static string TStartType_WithParent {
            get {
                return ResourceManager.GetString("TStartType_WithParent", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to With end of.
        /// </summary>
        public static string TStartType_WithParentFromEnd {
            get {
                return ResourceManager.GetString("TStartType_WithParentFromEnd", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to NTSC (4:3).
        /// </summary>
        public static string TVideoFormat_NTSC {
            get {
                return ResourceManager.GetString("TVideoFormat_NTSC", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to NTSC (16:9).
        /// </summary>
        public static string TVideoFormat_NTSC_FHA {
            get {
                return ResourceManager.GetString("TVideoFormat_NTSC_FHA", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to PAL (4:3).
        /// </summary>
        public static string TVideoFormat_PAL {
            get {
                return ResourceManager.GetString("TVideoFormat_PAL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to PAL (16:9).
        /// </summary>
        public static string TVideoFormat_PAL_FHA {
            get {
                return ResourceManager.GetString("TVideoFormat_PAL_FHA", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to PAL (16:9) progressive.
        /// </summary>
        public static string TVideoFormat_PAL_FHA_P {
            get {
                return ResourceManager.GetString("TVideoFormat_PAL_FHA_P", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to PAL (4:3) progressive.
        /// </summary>
        public static string TVideoFormat_PAL_P {
            get {
                return ResourceManager.GetString("TVideoFormat_PAL_P", resourceCulture);
            }
        }
    }
}
