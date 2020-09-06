namespace Fable.Import
open System
open System.Text.RegularExpressions
open Fable.Core
open Node

module rec ws =
    type Error = System.Exception

    module WebSocket =
        type VerifyClientCallbackSync =
            Func<obj, bool>

        and VerifyClientCallbackAsync =
            Func<obj, Func<bool, unit>, unit>

        and [<AllowNullLiteral>] IClientOptions =
            abstract protocol: string option with get, set
            abstract agent: obj option with get, set
            abstract headers: obj option with get, set
            abstract protocolVersion: obj option with get, set
            abstract host: string option with get, set
            abstract origin: string option with get, set
            abstract pfx: obj option with get, set
            abstract key: obj option with get, set
            abstract passphrase: string option with get, set
            abstract cert: obj option with get, set
            abstract ca: ResizeArray<obj> option with get, set
            abstract ciphers: string option with get, set
            abstract rejectUnauthorized: bool option with get, set

        and [<AllowNullLiteral>] IPerMessageDeflateOptions =
            abstract serverNoContextTakeover: bool option with get, set
            abstract clientNoContextTakeover: bool option with get, set
            abstract serverMaxWindowBits: float option with get, set
            abstract clientMaxWindowBits: float option with get, set
            abstract memLevel: float option with get, set

        and [<AllowNullLiteral>] IServerOptions =
            abstract host: string option with get, set
            abstract port: float option with get, set
            abstract server: obj option with get, set
            abstract verifyClient: U2<VerifyClientCallbackAsync, VerifyClientCallbackSync> option with get, set
            abstract handleProtocols: obj option with get, set
            abstract path: string option with get, set
            abstract noServer: bool option with get, set
            abstract disableHixie: bool option with get, set
            abstract clientTracking: bool option with get, set
            abstract perMessageDeflate: U2<bool, IPerMessageDeflateOptions> option with get, set

        and [<AllowNullLiteral>] [<Import("WebSocket.Server","ws")>] Server(?options: IServerOptions, ?callback: Function) =
            member __.options with get(): IServerOptions = jsNative and set(v: IServerOptions): unit = jsNative
            member __.path with get(): string = jsNative and set(v: string): unit = jsNative
            member __.clients with get(): ResizeArray<WebSocket> = jsNative and set(v: ResizeArray<WebSocket>): unit = jsNative
            member __.close(?cb: Func<unit, obj>): unit = jsNative
            member __.handleUpgrade(request: obj, socket: Net.Sockets.Socket, upgradeHead: Buffer, callback: Func<WebSocket, unit>): unit = jsNative
            [<Emit("$0.on('error',$1...)")>] member __.on_error(cb: Func<Error, unit>): obj = jsNative
            [<Emit("$0.on('headers',$1...)")>] member __.on_headers(cb: Func<ResizeArray<string>, unit>): obj = jsNative
            [<Emit("$0.on('connection',$1...)")>] member __.on_connection(cb: Func<WebSocket, unit>): obj = jsNative
            member __.on(``event``: string, listener: Func<unit, unit>): obj = jsNative
            [<Emit("$0.addListener('error',$1...)")>] member __.addListener_error(cb: Func<Error, unit>): obj = jsNative
            [<Emit("$0.addListener('headers',$1...)")>] member __.addListener_headers(cb: Func<ResizeArray<string>, unit>): obj = jsNative
            [<Emit("$0.addListener('connection',$1...)")>] member __.addListener_connection(cb: Func<WebSocket, unit>): obj = jsNative
            member __.addListener(``event``: string, listener: Func<unit, unit>): obj = jsNative

        type [<Import("WebSocket","ws")>] Globals =
            static member createServer(?options: IServerOptions, ?connectionListener: Func<WebSocket, unit>): Server = jsNative
            static member connect(address: string, ?openListener: Function): unit = jsNative
            static member createConnection(address: string, ?openListener: Function): unit = jsNative

    type [<AllowNullLiteral>] [<Import("default","ws")>] WebSocket(address: string, ?protocols: U2<string, ResizeArray<string>>, ?options: WebSocket.IClientOptions) =
        member __.CONNECTING with get(): float = jsNative and set(v: float): unit = jsNative
        member __.OPEN with get(): float = jsNative and set(v: float): unit = jsNative
        member __.CLOSING with get(): float = jsNative and set(v: float): unit = jsNative
        member __.CLOSED with get(): float = jsNative and set(v: float): unit = jsNative
        member __.bytesReceived with get(): float = jsNative and set(v: float): unit = jsNative
        member __.readyState with get(): float = jsNative and set(v: float): unit = jsNative
        member __.protocolVersion with get(): string = jsNative and set(v: string): unit = jsNative
        member __.url with get(): string = jsNative and set(v: string): unit = jsNative
        member __.supports with get(): obj = jsNative and set(v: obj): unit = jsNative
        member __.upgradeReq with get(): obj = jsNative and set(v: obj): unit = jsNative
        member __.protocol with get(): string = jsNative and set(v: string): unit = jsNative
        member __.onopen with get(): Func<obj, unit> = jsNative and set(v: Func<obj, unit>): unit = jsNative
        member __.onerror with get(): Func<Error, unit> = jsNative and set(v: Func<Error, unit>): unit = jsNative
        member __.onclose with get(): Func<obj, unit> = jsNative and set(v: Func<obj, unit>): unit = jsNative
        member __.onmessage with get(): Func<obj, unit> = jsNative and set(v: Func<obj, unit>): unit = jsNative
        member __.close(?code: float, ?data: obj): unit = jsNative
        member __.pause(): unit = jsNative
        member __.resume(): unit = jsNative
        member __.ping(?data: obj, ?options: obj, ?dontFail: bool): unit = jsNative
        member __.pong(?data: obj, ?options: obj, ?dontFail: bool): unit = jsNative
        member __.send(data: obj, ?cb: Func<Error, unit>): unit = jsNative
        member __.send(data: obj, options: obj, ?cb: Func<Error, unit>): unit = jsNative
        member __.stream(options: obj, ?cb: Func<Error, bool, unit>): unit = jsNative
        member __.stream(?cb: Func<Error, bool, unit>): unit = jsNative
        member __.terminate(): unit = jsNative
        [<Emit("$0.addEventListener('message',$1...)")>] member __.addEventListener_message(?cb: Func<obj, unit>): unit = jsNative
        [<Emit("$0.addEventListener('close',$1...)")>] member __.addEventListener_close(?cb: Func<obj, unit>): unit = jsNative
        [<Emit("$0.addEventListener('error',$1...)")>] member __.addEventListener_error(?cb: Func<Error, unit>): unit = jsNative
        [<Emit("$0.addEventListener('open',$1...)")>] member __.addEventListener_open(?cb: Func<obj, unit>): unit = jsNative
        member __.addEventListener(``method``: string, ?listener: Func<unit, unit>): unit = jsNative
        [<Emit("$0.on('error',$1...)")>] member __.on_error(cb: Func<Error, unit>): obj = jsNative
        [<Emit("$0.on('close',$1...)")>] member __.on_close(cb: Func<float, string, unit>): obj = jsNative
        [<Emit("$0.on('message',$1...)")>] member __.on_message(cb: Func<obj, obj, unit>): obj = jsNative
        [<Emit("$0.on('ping',$1...)")>] member __.on_ping(cb: Func<obj, obj, unit>): obj = jsNative
        [<Emit("$0.on('pong',$1...)")>] member __.on_pong(cb: Func<obj, obj, unit>): obj = jsNative
        [<Emit("$0.on('open',$1...)")>] member __.on_open(cb: Func<unit, unit>): obj = jsNative
        member __.on(``event``: string, listener: Func<unit, unit>): obj = jsNative
        [<Emit("$0.addListener('error',$1...)")>] member __.addListener_error(cb: Func<Error, unit>): obj = jsNative
        [<Emit("$0.addListener('close',$1...)")>] member __.addListener_close(cb: Func<float, string, unit>): obj = jsNative
        [<Emit("$0.addListener('message',$1...)")>] member __.addListener_message(cb: Func<obj, obj, unit>): obj = jsNative
        [<Emit("$0.addListener('ping',$1...)")>] member __.addListener_ping(cb: Func<obj, obj, unit>): obj = jsNative
        [<Emit("$0.addListener('pong',$1...)")>] member __.addListener_pong(cb: Func<obj, obj, unit>): obj = jsNative
        [<Emit("$0.addListener('open',$1...)")>] member __.addListener_open(cb: Func<unit, unit>): obj = jsNative
        member __.addListener(``event``: string, listener: Func<unit, unit>): obj = jsNative
