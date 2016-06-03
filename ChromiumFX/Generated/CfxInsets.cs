// Copyright (c) 2014-2015 Wolfgang Borgsmüller
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions 
// are met:
// 
// 1. Redistributions of source code must retain the above copyright 
//    notice, this list of conditions and the following disclaimer.
// 
// 2. Redistributions in binary form must reproduce the above copyright 
//    notice, this list of conditions and the following disclaimer in the 
//    documentation and/or other materials provided with the distribution.
// 
// 3. Neither the name of the copyright holder nor the names of its 
//    contributors may be used to endorse or promote products derived 
//    from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS 
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT 
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS 
// FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE 
// COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, 
// INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, 
// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS 
// OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND 
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR 
// TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
// USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure representing insets.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public sealed class CfxInsets : CfxStructure {

        static CfxInsets () {
            CfxApiLoader.LoadCfxInsetsApi();
        }

        internal static CfxInsets Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxInsets(nativePtr);
        }

        internal static CfxInsets WrapOwned(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxInsets(nativePtr, CfxApi.cfx_insets_dtor);
        }

        public CfxInsets() : base(CfxApi.cfx_insets_ctor, CfxApi.cfx_insets_dtor) {}
        internal CfxInsets(IntPtr nativePtr) : base(nativePtr) {}
        internal CfxInsets(IntPtr nativePtr, CfxApi.cfx_dtor_delegate cfx_dtor) : base(nativePtr, cfx_dtor) {}

        public int Top {
            get {
                int value;
                CfxApi.cfx_insets_get_top(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_insets_set_top(nativePtrUnchecked, value);
            }
        }

        public int Left {
            get {
                int value;
                CfxApi.cfx_insets_get_left(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_insets_set_left(nativePtrUnchecked, value);
            }
        }

        public int Bottom {
            get {
                int value;
                CfxApi.cfx_insets_get_bottom(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_insets_set_bottom(nativePtrUnchecked, value);
            }
        }

        public int Right {
            get {
                int value;
                CfxApi.cfx_insets_get_right(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_insets_set_right(nativePtrUnchecked, value);
            }
        }

    }
}
