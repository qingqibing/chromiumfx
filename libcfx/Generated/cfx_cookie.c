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


// cef_cookie

#ifdef __cplusplus
extern "C" {
#endif

CFX_EXPORT cef_cookie_t* cfx_cookie_ctor() {
    return (cef_cookie_t*)calloc(1, sizeof(cef_cookie_t));
}

CFX_EXPORT void cfx_cookie_dtor(cef_cookie_t* ptr) {
    if(ptr->name.dtor) ptr->name.dtor(ptr->name.str);
    if(ptr->value.dtor) ptr->value.dtor(ptr->value.str);
    if(ptr->domain.dtor) ptr->domain.dtor(ptr->domain.str);
    if(ptr->path.dtor) ptr->path.dtor(ptr->path.str);
    free(ptr);
}

// cef_cookie_t->name
CFX_EXPORT void cfx_cookie_set_name(cef_cookie_t *self, char16 *name_str, int name_length) {
    cef_string_utf16_set(name_str, name_length, &(self->name), 1);
}
CFX_EXPORT void cfx_cookie_get_name(cef_cookie_t *self, char16 **name_str, int *name_length) {
    *name_str = self->name.str;
    *name_length = self->name.length;
}

// cef_cookie_t->value
CFX_EXPORT void cfx_cookie_set_value(cef_cookie_t *self, char16 *value_str, int value_length) {
    cef_string_utf16_set(value_str, value_length, &(self->value), 1);
}
CFX_EXPORT void cfx_cookie_get_value(cef_cookie_t *self, char16 **value_str, int *value_length) {
    *value_str = self->value.str;
    *value_length = self->value.length;
}

// cef_cookie_t->domain
CFX_EXPORT void cfx_cookie_set_domain(cef_cookie_t *self, char16 *domain_str, int domain_length) {
    cef_string_utf16_set(domain_str, domain_length, &(self->domain), 1);
}
CFX_EXPORT void cfx_cookie_get_domain(cef_cookie_t *self, char16 **domain_str, int *domain_length) {
    *domain_str = self->domain.str;
    *domain_length = self->domain.length;
}

// cef_cookie_t->path
CFX_EXPORT void cfx_cookie_set_path(cef_cookie_t *self, char16 *path_str, int path_length) {
    cef_string_utf16_set(path_str, path_length, &(self->path), 1);
}
CFX_EXPORT void cfx_cookie_get_path(cef_cookie_t *self, char16 **path_str, int *path_length) {
    *path_str = self->path.str;
    *path_length = self->path.length;
}

// cef_cookie_t->secure
CFX_EXPORT void cfx_cookie_set_secure(cef_cookie_t *self, int secure) {
    self->secure = secure;
}
CFX_EXPORT void cfx_cookie_get_secure(cef_cookie_t *self, int* secure) {
    *secure = self->secure;
}

// cef_cookie_t->httponly
CFX_EXPORT void cfx_cookie_set_httponly(cef_cookie_t *self, int httponly) {
    self->httponly = httponly;
}
CFX_EXPORT void cfx_cookie_get_httponly(cef_cookie_t *self, int* httponly) {
    *httponly = self->httponly;
}

// cef_cookie_t->creation
CFX_EXPORT void cfx_cookie_set_creation(cef_cookie_t *self, cef_time_t* creation) {
    self->creation = *(creation);
}
CFX_EXPORT void cfx_cookie_get_creation(cef_cookie_t *self, cef_time_t** creation) {
    *creation = &(self->creation);
}

// cef_cookie_t->last_access
CFX_EXPORT void cfx_cookie_set_last_access(cef_cookie_t *self, cef_time_t* last_access) {
    self->last_access = *(last_access);
}
CFX_EXPORT void cfx_cookie_get_last_access(cef_cookie_t *self, cef_time_t** last_access) {
    *last_access = &(self->last_access);
}

// cef_cookie_t->has_expires
CFX_EXPORT void cfx_cookie_set_has_expires(cef_cookie_t *self, int has_expires) {
    self->has_expires = has_expires;
}
CFX_EXPORT void cfx_cookie_get_has_expires(cef_cookie_t *self, int* has_expires) {
    *has_expires = self->has_expires;
}

// cef_cookie_t->expires
CFX_EXPORT void cfx_cookie_set_expires(cef_cookie_t *self, cef_time_t* expires) {
    self->expires = *(expires);
}
CFX_EXPORT void cfx_cookie_get_expires(cef_cookie_t *self, cef_time_t** expires) {
    *expires = &(self->expires);
}


#ifdef __cplusplus
} // extern "C"
#endif

