namespace Fable.Import
open Fable.Core
open Fable.Core.JS

module Axios =
    type AxiosHttpBasicAuth =
        abstract username: string with get, set
        abstract password: string with get, set

    and AxiosProxyAuthConfig =
        abstract username: string with get, set
        abstract password: string with get, set

    and AxiosProxyConfig =
        abstract host: string with get, set
        abstract port: int with get, set
        abstract auth: AxiosProxyAuthConfig option with get, set

    and AxiosXHRConfigBase<'T> =
        abstract baseURL: string option with get, set
        abstract headers: obj option with get, set
        abstract ``params``: obj option with get, set
        abstract paramsSerializer: (obj -> string) option with get, set
        abstract timeout: float option with get, set
        abstract withCredentials: bool option with get, set
        abstract auth: AxiosHttpBasicAuth option with get, set
        abstract responseType: string option with get, set
        abstract xsrfCookieName: string option with get, set
        abstract xsrfHeaderName: string option with get, set
        abstract transformRequest: U2<('T -> 'U), ('T -> 'U)> option with get, set
        abstract transformResponse: ('T -> 'U) option with get, set
        abstract proxy: U2<AxiosProxyConfig, bool> option with get, set

    and AxiosXHRConfig<'T> =
        inherit AxiosXHRConfigBase<'T>
        abstract url: string with get, set
        abstract ``method``: string option with get, set
        abstract data: 'T option with get, set

    and AxiosXHR<'T> =
        abstract data: 'T with get, set
        abstract status: float with get, set
        abstract statusText: string with get, set
        abstract headers: obj with get, set
        abstract config: AxiosXHRConfig<'T> with get, set

    and Interceptor =
        abstract request: RequestInterceptor with get, set
        abstract response: ResponseInterceptor with get, set

    and InterceptorId =
        float

    and RequestInterceptor =
        abstract ``use``: fulfilledFn: (AxiosXHRConfig<'U> -> AxiosXHRConfig<'U>) -> InterceptorId
        abstract ``use``: fulfilledFn: (AxiosXHRConfig<'U> -> AxiosXHRConfig<'U>) * rejectedFn: (obj -> obj) -> InterceptorId
        abstract eject: interceptorId: InterceptorId -> unit

    and ResponseInterceptor =
        abstract ``use``: fulfilledFn: (AxiosXHR<'T> -> AxiosXHR<'T>) -> InterceptorId
        abstract ``use``: fulfilledFn: (AxiosXHR<'T> -> AxiosXHR<'T>) * rejectedFn: (obj -> obj) -> InterceptorId
        abstract eject: interceptorId: InterceptorId -> unit

    and AxiosInstance =
        abstract interceptors: Interceptor with get, set
        [<Emit("$0($1...)")>] abstract Invoke: config: AxiosXHRConfig<'T> -> Promise<AxiosXHR<'T>>
        [<Emit("new $0($1...)")>] abstract Create: config: AxiosXHRConfig<'T> -> Promise<AxiosXHR<'T>>
        abstract request: config: AxiosXHRConfig<'T> -> Promise<AxiosXHR<'T>>
        abstract all: values: U2<'T1, Promise<AxiosXHR<'T1>>> * U2<'T2, Promise<AxiosXHR<'T2>>> * U2<'T3, Promise<AxiosXHR<'T3>>> * U2<'T4, Promise<AxiosXHR<'T4>>> * U2<'T5, Promise<AxiosXHR<'T5>>> * U2<'T6, Promise<AxiosXHR<'T6>>> * U2<'T7, Promise<AxiosXHR<'T7>>> * U2<'T8, Promise<AxiosXHR<'T8>>> * U2<'T9, Promise<AxiosXHR<'T9>>> * U2<'T10, Promise<AxiosXHR<'T10>>> -> Promise<AxiosXHR<'T1> * AxiosXHR<'T2> * AxiosXHR<'T3> * AxiosXHR<'T4> * AxiosXHR<'T5> * AxiosXHR<'T6> * AxiosXHR<'T7> * AxiosXHR<'T8> * AxiosXHR<'T9> * AxiosXHR<'T10>>
        abstract all: values: U2<'T1, Promise<AxiosXHR<'T1>>> * U2<'T2, Promise<AxiosXHR<'T2>>> * U2<'T3, Promise<AxiosXHR<'T3>>> * U2<'T4, Promise<AxiosXHR<'T4>>> * U2<'T5, Promise<AxiosXHR<'T5>>> * U2<'T6, Promise<AxiosXHR<'T6>>> * U2<'T7, Promise<AxiosXHR<'T7>>> * U2<'T8, Promise<AxiosXHR<'T8>>> * U2<'T9, Promise<AxiosXHR<'T9>>> -> Promise<AxiosXHR<'T1> * AxiosXHR<'T2> * AxiosXHR<'T3> * AxiosXHR<'T4> * AxiosXHR<'T5> * AxiosXHR<'T6> * AxiosXHR<'T7> * AxiosXHR<'T8> * AxiosXHR<'T9>>
        abstract all: values: U2<'T1, Promise<AxiosXHR<'T1>>> * U2<'T2, Promise<AxiosXHR<'T2>>> * U2<'T3, Promise<AxiosXHR<'T3>>> * U2<'T4, Promise<AxiosXHR<'T4>>> * U2<'T5, Promise<AxiosXHR<'T5>>> * U2<'T6, Promise<AxiosXHR<'T6>>> * U2<'T7, Promise<AxiosXHR<'T7>>> * U2<'T8, Promise<AxiosXHR<'T8>>> -> Promise<AxiosXHR<'T1> * AxiosXHR<'T2> * AxiosXHR<'T3> * AxiosXHR<'T4> * AxiosXHR<'T5> * AxiosXHR<'T6> * AxiosXHR<'T7> * AxiosXHR<'T8>>
        abstract all: values: U2<'T1, Promise<AxiosXHR<'T1>>> * U2<'T2, Promise<AxiosXHR<'T2>>> * U2<'T3, Promise<AxiosXHR<'T3>>> * U2<'T4, Promise<AxiosXHR<'T4>>> * U2<'T5, Promise<AxiosXHR<'T5>>> * U2<'T6, Promise<AxiosXHR<'T6>>> * U2<'T7, Promise<AxiosXHR<'T7>>> -> Promise<AxiosXHR<'T1> * AxiosXHR<'T2> * AxiosXHR<'T3> * AxiosXHR<'T4> * AxiosXHR<'T5> * AxiosXHR<'T6> * AxiosXHR<'T7>>
        abstract all: values: U2<'T1, Promise<AxiosXHR<'T1>>> * U2<'T2, Promise<AxiosXHR<'T2>>> * U2<'T3, Promise<AxiosXHR<'T3>>> * U2<'T4, Promise<AxiosXHR<'T4>>> * U2<'T5, Promise<AxiosXHR<'T5>>> * U2<'T6, Promise<AxiosXHR<'T6>>> -> Promise<AxiosXHR<'T1> * AxiosXHR<'T2> * AxiosXHR<'T3> * AxiosXHR<'T4> * AxiosXHR<'T5> * AxiosXHR<'T6>>
        abstract all: values: U2<'T1, Promise<AxiosXHR<'T1>>> * U2<'T2, Promise<AxiosXHR<'T2>>> * U2<'T3, Promise<AxiosXHR<'T3>>> * U2<'T4, Promise<AxiosXHR<'T4>>> * U2<'T5, Promise<AxiosXHR<'T5>>> -> Promise<AxiosXHR<'T1> * AxiosXHR<'T2> * AxiosXHR<'T3> * AxiosXHR<'T4> * AxiosXHR<'T5>>
        abstract all: values: U2<'T1, Promise<AxiosXHR<'T1>>> * U2<'T2, Promise<AxiosXHR<'T2>>> * U2<'T3, Promise<AxiosXHR<'T3>>> * U2<'T4, Promise<AxiosXHR<'T4>>> -> Promise<AxiosXHR<'T1> * AxiosXHR<'T2> * AxiosXHR<'T3> * AxiosXHR<'T4>>
        abstract all: values: U2<'T1, Promise<AxiosXHR<'T1>>> * U2<'T2, Promise<AxiosXHR<'T2>>> * U2<'T3, Promise<AxiosXHR<'T3>>> -> Promise<AxiosXHR<'T1> * AxiosXHR<'T2> * AxiosXHR<'T3>>
        abstract all: values: U2<'T1, Promise<AxiosXHR<'T1>>> * U2<'T2, Promise<AxiosXHR<'T2>>> -> Promise<AxiosXHR<'T1> * AxiosXHR<'T2>>
        abstract spread: fn: ('T1 -> 'T2 -> 'U) -> ('T1 * 'T2 -> 'U)
        abstract get: url: string * ?config: AxiosXHRConfigBase<'T> -> Promise<AxiosXHR<'T>>
        abstract delete: url: string * ?config: AxiosXHRConfigBase<'T> -> Promise<AxiosXHR<'T>>
        abstract head: url: string * ?config: AxiosXHRConfigBase<'T> -> Promise<AxiosXHR<'T>>
        abstract post: url: string * ?data: obj * ?config: AxiosXHRConfigBase<'T> -> Promise<AxiosXHR<'T>>
        abstract put: url: string * ?data: obj * ?config: AxiosXHRConfigBase<'T> -> Promise<AxiosXHR<'T>>
        abstract patch: url: string * ?data: obj * ?config: AxiosXHRConfigBase<'T> -> Promise<AxiosXHR<'T>>

    and AxiosStatic =
        inherit AxiosInstance
        abstract create: config: AxiosXHRConfigBase<'T> -> AxiosInstance




type Globals =
    [<Global>] static member axios with get(): Axios.AxiosStatic = failwith "JS only" and set(v: Axios.AxiosStatic): unit = failwith "JS only"