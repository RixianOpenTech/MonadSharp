﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace msc.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("using MsSystem;\r\nusing MsSystem.Extensions;\r\nusing System;\r\nusing System.Reactive" +
            ";\r\nusing System.Reactive.Linq;\r\nusing MS.Core;\r\n\r\n#pragma warning disable 0028\r\n" +
            "\r\nnamespace MsShellExe\r\n{\r\n    public static class ObservableExecutable\r\n    {")]
        public string ProgramShellStart {
            get {
                return ((string)(this["ProgramShellStart"]));
            }
            set {
                this["ProgramShellStart"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("    }\r\n}")]
        public string ProgramShellEnd {
            get {
                return ((string)(this["ProgramShellEnd"]));
            }
            set {
                this["ProgramShellEnd"] = value;
            }
        }
    }
}
