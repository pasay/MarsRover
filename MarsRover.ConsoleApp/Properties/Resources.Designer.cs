﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MarsRover.ConsoleApp.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MarsRover.ConsoleApp.Properties.Resources", typeof(Resources).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Would you like to add a new one? ([Y/N]): .
        /// </summary>
        internal static string AddNewLabel {
            get {
                return ResourceManager.GetString("AddNewLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Exit signal detected. The application quits..
        /// </summary>
        internal static string ExitSignalDetected {
            get {
                return ResourceManager.GetString("ExitSignalDetected", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [Move] movement data ([L/R/M]): .
        /// </summary>
        internal static string MoveListInputLabel {
            get {
                return ResourceManager.GetString("MoveListInputLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The input value is incorrect. Input value can be &quot;([L/R/M])&quot;..
        /// </summary>
        internal static string MoveListInputValueError {
            get {
                return ResourceManager.GetString("MoveListInputValueError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value can not be empty..
        /// </summary>
        internal static string NullOrEmpty {
            get {
                return ResourceManager.GetString("NullOrEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The input value is incorrect. Input value can be &quot;[NUMERIC NUMERIC (E/W/N/S)]&quot;..
        /// </summary>
        internal static string RectangleRoverInputValueError {
            get {
                return ResourceManager.GetString("RectangleRoverInputValueError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [Rover] coordinates and direction ([x y E/W/S/N]): .
        /// </summary>
        internal static string RoverInputLabel {
            get {
                return ResourceManager.GetString("RoverInputLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The [&quot;{0}&quot;] command is not use..
        /// </summary>
        internal static string StartCommandIsNotUse {
            get {
                return ResourceManager.GetString("StartCommandIsNotUse", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Would you like to try again? ([Y/N]): .
        /// </summary>
        internal static string TryAgain {
            get {
                return ResourceManager.GetString("TryAgain", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [Upper-right] coordinates of the plateau ([x y]): .
        /// </summary>
        internal static string UpperRightInputLabel {
            get {
                return ResourceManager.GetString("UpperRightInputLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The input value is incorrect. Input value can be &quot;[NUMERIC NUMERIC]&quot;..
        /// </summary>
        internal static string UpperRightInputValueError {
            get {
                return ResourceManager.GetString("UpperRightInputValueError", resourceCulture);
            }
        }
    }
}
