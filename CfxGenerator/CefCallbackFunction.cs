// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class CefCallbackFunction  {

    public string Name { get; private set; }

    public readonly Signature Signature;
    public readonly CefStructType Parent;

    public CommentNode Comments { get; private set; }

    private CfxCallMode m_callMode;
    public CefConfigNode CefConfig { get; private set; }

    public bool IsProperty;

    public int ApiIndex;

    public int ClientCallbackIndex;

    private string cppApiName {
        get {
            if(CefConfig != null) {
                return CefConfig.CppApiName;
            } else {
                return null;
            }
        }
    }

    public CefCallbackFunction(CefStructType parent, StructCategory category, string name, CefConfigNode cefConfig, Parser.SignatureNode sd, ApiTypeBuilder api, CommentNode comments) {
        Name = name;
        this.Parent = parent;
        this.Comments = comments;
        if(cefConfig == null)
            CefConfig = new CefConfigNode();
        else
            CefConfig = cefConfig;

        if(category == StructCategory.Client) {
            m_callMode = CfxCallMode.Callback;
            this.Signature = Signature.Create(SignatureType.ClientCallback, CefName, CefConfig, CallMode, sd, api);
        } else {
            m_callMode = CfxCallMode.FunctionCall;
            this.Signature = Signature.Create(SignatureType.LibraryCall, CefName, CefConfig, CallMode, sd, api);
        }
        
    }

    public ApiType NativeReturnType {
        get { return Signature.ReturnType; }
    }

    public ApiType PublicReturnType {
        get { return Signature.PublicReturnType; }
    }

    public ApiType RemoteReturnType {
        get { return Signature.RemoteReturnType; }
    }

    public string PublicName {
        get {
            if(cppApiName != null) {
                if(Parent.ClassBuilder.Category == StructCategory.Client) {
                    // can't overload event names, so return the styled c-api name instead
                    return CSharp.ApplyStyle(Name);
                }
                return cppApiName;
            } else {
                return CSharp.ApplyStyle(Name);
            }
        }
    }

    public string RemoteCallClassName {
        get { return CSharp.ApplyStyle(Name); }
    }

    public bool IsPropertyGetter(ref bool isBoolean) {
        var retval = IsPropertyGetterPrivate(ref isBoolean);
        if(retval)
            m_callMode = CfxCallMode.PropertyGetter;
        return retval;
    }

    private bool IsPropertyGetterPrivate(ref bool isBoolean) {
        if(Signature.PublicReturnType.IsVoid)
            return false;
        if(Signature.PublicReturnType.IsStringCollectionType)
            return false;

        if(Signature.ManagedParameters.Length != 1)
            return false;

        if(Name.StartsWith("has_")) { isBoolean = true; return true; }
        if(Name.StartsWith("is_")) { isBoolean = true; return true; }
        if(Name.StartsWith("can_")) { isBoolean = true; return true; }

        if(Name.StartsWith("get_")) {
            if(Signature.PublicReturnType.Name == "cef_string_userfree_t") {
                if(Name == "get_error") {
                    return false;
                }
            }
            return true;
        }

        return false;
    }

    public bool IsPropertySetterFor(CefCallbackFunction getter) {
        var retval = IsPropertySetterForPrivate(getter);
        if(retval)
            m_callMode = CfxCallMode.PropertySetter;
        return retval;
    }

    public bool IsPropertySetterForPrivate(CefCallbackFunction getter) {
        if(!Signature.PublicReturnType.IsVoid)
            return false;
        if(!(Signature.ManagedParameters.Count() == 2))
            return false;
        if(!Signature.ManagedParameters[1].ParameterType.Equals(getter.Signature.PublicReturnType)) {
            if(!(getter.Signature.PublicReturnType.Name == "cef_string_userfree_t" && Signature.ManagedParameters[1].ParameterType.IsCefStringPtrTypeConst))
                return false;
        }
        if(!Name.Substring(1).Equals(getter.Name.Substring(1)))
            return false;
        return true;
    }

    public string NativeCallbackName {
        get { return string.Concat(Parent.CfxName, "_", Name); }
    }

    public string EventName { get; set; }

    public bool IsBasicEvent {
        get { return EventName == null; }
    }

    public string RemoteCallName {
        get {
            return Parent.ClassName + PublicName;
        }
    }

    public string EventHandlerName {
        get {
            if(IsBasicEvent)
                return "CfxEventHandler";
            return EventName + "EventHandler";
        }
    }

    public string RemoteEventHandlerName {
        get { return "Cfr" + EventHandlerName.Substring(3); }
    }

    public string PublicEventArgsClassName {
        get {
            if(IsBasicEvent)
                return "CfxEventArgs";
            return EventName + "EventArgs";
        }
    }

    public string RemoteEventArgsClassName {
        get { return "Cfr" + PublicEventArgsClassName.Substring(3); }
    }

    public CfxCallMode CallMode {
        get { return this.m_callMode; }
    }

    public string CefName {
        get { return Parent.Name + "::" + Name; }
    }

    public string CfxApiFunctionName {
        get { return string.Concat(Parent.CfxName, "_", Name); }
    }

    public string PublicFunctionName {
        get { return PublicName; }
    }

    public string PublicPropertyName { get; set; }

    public string PropertyName {
        get { return PublicPropertyName; }
    }

    public string RemoteCallId {
        get {
            if(Parent.ClassBuilder.Category == StructCategory.Client) {
                return Parent.ClassName + RemoteCallClassName + "RemoteClientCall";
            } else {
                return Parent.ClassName + RemoteCallClassName + "RemoteCall";
            }
        }
    }

    public string PublicClassName {
        get { return Parent.ClassName; }
    }

    public override string ToString() {
        return Name;
    }
}
