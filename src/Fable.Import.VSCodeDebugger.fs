namespace Fable.Import
open Fable.Core

module DebugProtocol =
    type [<AllowNullLiteral>] ProtocolMessage =
        abstract seq: float with get, set
        abstract ``type``: string with get, set

    and [<AllowNullLiteral>] Request =
        inherit ProtocolMessage
        abstract command: string with get, set
        abstract arguments: obj option with get, set

    and [<AllowNullLiteral>] Event =
        inherit ProtocolMessage
        abstract ``event``: string with get, set
        abstract body: obj option with get, set

    and [<AllowNullLiteral>] Response =
        inherit ProtocolMessage
        abstract request_seq: float with get, set
        abstract success: bool with get, set
        abstract command: string with get, set
        abstract message: string option with get, set
        abstract body: obj option with get, set

    and [<AllowNullLiteral>] InitializedEvent =
        inherit Event


    and [<AllowNullLiteral>] StoppedEvent =
        inherit Event
        abstract body: obj with get, set

    and [<AllowNullLiteral>] ContinuedEvent =
        inherit Event
        abstract body: obj with get, set

    and [<AllowNullLiteral>] ExitedEvent =
        inherit Event
        abstract body: obj with get, set

    and [<AllowNullLiteral>] TerminatedEvent =
        inherit Event
        abstract body: obj option with get, set

    and [<AllowNullLiteral>] ThreadEvent =
        inherit Event
        abstract body: obj with get, set

    and [<AllowNullLiteral>] OutputEvent =
        inherit Event
        abstract body: obj with get, set

    and [<AllowNullLiteral>] BreakpointEvent =
        inherit Event
        abstract body: obj with get, set

    and [<AllowNullLiteral>] ModuleEvent =
        inherit Event
        abstract body: obj with get, set

    and [<AllowNullLiteral>] RunInTerminalRequest =
        inherit Request
        abstract arguments: RunInTerminalRequestArguments with get, set

    and [<AllowNullLiteral>] RunInTerminalRequestArguments =
        abstract kind: (* TODO StringEnum integrated | external *) string option with get, set
        abstract title: string option with get, set
        abstract cwd: string with get, set
        abstract args: ResizeArray<string> with get, set
        abstract env: obj option with get, set

    and [<AllowNullLiteral>] RunInTerminalResponse =
        inherit Response
        abstract body: obj with get, set

    and [<AllowNullLiteral>] ErrorResponse =
        inherit Response
        abstract body: obj with get, set

    and [<AllowNullLiteral>] InitializeRequest =
        inherit Request
        abstract arguments: InitializeRequestArguments with get, set

    and [<AllowNullLiteral>] InitializeRequestArguments =
        abstract adapterID: string with get, set
        abstract linesStartAt1: bool option with get, set
        abstract columnsStartAt1: bool option with get, set
        abstract pathFormat: string option with get, set
        abstract supportsVariableType: bool option with get, set
        abstract supportsVariablePaging: bool option with get, set
        abstract supportsRunInTerminalRequest: bool option with get, set

    and [<AllowNullLiteral>] InitializeResponse =
        inherit Response
        abstract body: Capabilities option with get, set

    and [<AllowNullLiteral>] ConfigurationDoneRequest =
        inherit Request
        abstract arguments: ConfigurationDoneArguments option with get, set

    and [<AllowNullLiteral>] ConfigurationDoneArguments =
        interface end

    and [<AllowNullLiteral>] ConfigurationDoneResponse =
        inherit Response


    and [<AllowNullLiteral>] LaunchRequest =
        inherit Request
        abstract arguments: LaunchRequestArguments with get, set

    and [<AllowNullLiteral>] LaunchRequestArguments =
        abstract noDebug: bool option with get, set

    and [<AllowNullLiteral>] LaunchResponse =
        inherit Response


    and [<AllowNullLiteral>] AttachRequest =
        inherit Request
        abstract arguments: AttachRequestArguments with get, set

    and [<AllowNullLiteral>] AttachRequestArguments =
        interface end

    and [<AllowNullLiteral>] AttachResponse =
        inherit Response


    and [<AllowNullLiteral>] RestartRequest =
        inherit Request
        abstract arguments: RestartArguments option with get, set

    and [<AllowNullLiteral>] RestartArguments =
        interface end

    and [<AllowNullLiteral>] RestartResponse =
        inherit Response


    and [<AllowNullLiteral>] DisconnectRequest =
        inherit Request
        abstract arguments: DisconnectArguments option with get, set

    and [<AllowNullLiteral>] DisconnectArguments =
        interface end

    and [<AllowNullLiteral>] DisconnectResponse =
        inherit Response


    and [<AllowNullLiteral>] SetBreakpointsRequest =
        inherit Request
        abstract arguments: SetBreakpointsArguments with get, set

    and [<AllowNullLiteral>] SetBreakpointsArguments =
        abstract source: Source with get, set
        abstract breakpoints: ResizeArray<SourceBreakpoint> option with get, set
        abstract lines: ResizeArray<float> option with get, set
        abstract sourceModified: bool option with get, set

    and [<AllowNullLiteral>] SetBreakpointsResponse =
        inherit Response
        abstract body: obj with get, set

    and [<AllowNullLiteral>] SetFunctionBreakpointsRequest =
        inherit Request
        abstract arguments: SetFunctionBreakpointsArguments with get, set

    and [<AllowNullLiteral>] SetFunctionBreakpointsArguments =
        abstract breakpoints: ResizeArray<FunctionBreakpoint> with get, set

    and [<AllowNullLiteral>] SetFunctionBreakpointsResponse =
        inherit Response
        abstract body: obj with get, set

    and [<AllowNullLiteral>] SetExceptionBreakpointsRequest =
        inherit Request
        abstract arguments: SetExceptionBreakpointsArguments with get, set

    and [<AllowNullLiteral>] SetExceptionBreakpointsArguments =
        abstract filters: ResizeArray<string> with get, set
        abstract exceptionOptions: ResizeArray<ExceptionOptions> option with get, set

    and [<AllowNullLiteral>] SetExceptionBreakpointsResponse =
        inherit Response


    and [<AllowNullLiteral>] ContinueRequest =
        inherit Request
        abstract arguments: ContinueArguments with get, set

    and [<AllowNullLiteral>] ContinueArguments =
        abstract threadId: float with get, set

    and [<AllowNullLiteral>] ContinueResponse =
        inherit Response
        abstract body: obj with get, set

    and [<AllowNullLiteral>] NextRequest =
        inherit Request
        abstract arguments: NextArguments with get, set

    and [<AllowNullLiteral>] NextArguments =
        abstract threadId: float with get, set

    and [<AllowNullLiteral>] NextResponse =
        inherit Response


    and [<AllowNullLiteral>] StepInRequest =
        inherit Request
        abstract arguments: StepInArguments with get, set

    and [<AllowNullLiteral>] StepInArguments =
        abstract threadId: float with get, set
        abstract targetId: float option with get, set

    and [<AllowNullLiteral>] StepInResponse =
        inherit Response


    and [<AllowNullLiteral>] StepOutRequest =
        inherit Request
        abstract arguments: StepOutArguments with get, set

    and [<AllowNullLiteral>] StepOutArguments =
        abstract threadId: float with get, set

    and [<AllowNullLiteral>] StepOutResponse =
        inherit Response


    and [<AllowNullLiteral>] StepBackRequest =
        inherit Request
        abstract arguments: StepBackArguments with get, set

    and [<AllowNullLiteral>] StepBackArguments =
        abstract threadId: float with get, set

    and [<AllowNullLiteral>] StepBackResponse =
        inherit Response


    and [<AllowNullLiteral>] ReverseContinueRequest =
        inherit Request
        abstract arguments: ReverseContinueArguments with get, set

    and [<AllowNullLiteral>] ReverseContinueArguments =
        abstract threadId: float with get, set

    and [<AllowNullLiteral>] ReverseContinueResponse =
        inherit Response


    and [<AllowNullLiteral>] RestartFrameRequest =
        inherit Request
        abstract arguments: RestartFrameArguments with get, set

    and [<AllowNullLiteral>] RestartFrameArguments =
        abstract frameId: float with get, set

    and [<AllowNullLiteral>] RestartFrameResponse =
        inherit Response


    and [<AllowNullLiteral>] GotoRequest =
        inherit Request
        abstract arguments: GotoArguments with get, set

    and [<AllowNullLiteral>] GotoArguments =
        abstract threadId: float with get, set
        abstract targetId: float with get, set

    and [<AllowNullLiteral>] GotoResponse =
        inherit Response


    and [<AllowNullLiteral>] PauseRequest =
        inherit Request
        abstract arguments: PauseArguments with get, set

    and [<AllowNullLiteral>] PauseArguments =
        abstract threadId: float with get, set

    and [<AllowNullLiteral>] PauseResponse =
        inherit Response


    and [<AllowNullLiteral>] StackTraceRequest =
        inherit Request
        abstract arguments: StackTraceArguments with get, set

    and [<AllowNullLiteral>] StackTraceArguments =
        abstract threadId: float with get, set
        abstract startFrame: float option with get, set
        abstract levels: float option with get, set
        abstract format: StackFrameFormat option with get, set

    and [<AllowNullLiteral>] StackTraceResponse =
        inherit Response
        abstract body: obj with get, set

    and [<AllowNullLiteral>] ScopesRequest =
        inherit Request
        abstract arguments: ScopesArguments with get, set

    and [<AllowNullLiteral>] ScopesArguments =
        abstract frameId: float with get, set

    and [<AllowNullLiteral>] ScopesResponse =
        inherit Response
        abstract body: obj with get, set

    and [<AllowNullLiteral>] VariablesRequest =
        inherit Request
        abstract arguments: VariablesArguments with get, set

    and [<AllowNullLiteral>] VariablesArguments =
        abstract variablesReference: float with get, set
        abstract filter: (* TODO StringEnum indexed | named *) string option with get, set
        abstract start: float option with get, set
        abstract count: float option with get, set
        abstract format: ValueFormat option with get, set

    and [<AllowNullLiteral>] VariablesResponse =
        inherit Response
        abstract body: obj with get, set

    and [<AllowNullLiteral>] SetVariableRequest =
        inherit Request
        abstract arguments: SetVariableArguments with get, set

    and [<AllowNullLiteral>] SetVariableArguments =
        abstract variablesReference: float with get, set
        abstract name: string with get, set
        abstract value: string with get, set

    and [<AllowNullLiteral>] SetVariableResponse =
        inherit Response
        abstract body: obj with get, set

    and [<AllowNullLiteral>] SourceRequest =
        inherit Request
        abstract arguments: SourceArguments with get, set

    and [<AllowNullLiteral>] SourceArguments =
        abstract sourceReference: float with get, set

    and [<AllowNullLiteral>] SourceResponse =
        inherit Response
        abstract body: obj with get, set

    and [<AllowNullLiteral>] ThreadsRequest =
        inherit Request


    and [<AllowNullLiteral>] ThreadsResponse =
        inherit Response
        abstract body: obj with get, set

    and [<AllowNullLiteral>] ModulesRequest =
        inherit Request
        abstract arguments: ModulesArguments with get, set

    and [<AllowNullLiteral>] ModulesArguments =
        abstract startModule: float option with get, set
        abstract moduleCount: float option with get, set

    and [<AllowNullLiteral>] ModulesResponse =
        inherit Response
        abstract body: obj with get, set

    and [<AllowNullLiteral>] EvaluateRequest =
        inherit Request
        abstract arguments: EvaluateArguments with get, set

    and [<AllowNullLiteral>] EvaluateArguments =
        abstract expression: string with get, set
        abstract frameId: float option with get, set
        abstract context: string option with get, set
        abstract format: ValueFormat option with get, set

    and [<AllowNullLiteral>] EvaluateResponse =
        inherit Response
        abstract body: obj with get, set

    and [<AllowNullLiteral>] StepInTargetsRequest =
        inherit Request
        abstract arguments: StepInTargetsArguments with get, set

    and [<AllowNullLiteral>] StepInTargetsArguments =
        abstract frameId: float with get, set

    and [<AllowNullLiteral>] StepInTargetsResponse =
        inherit Response
        abstract body: obj with get, set

    and [<AllowNullLiteral>] GotoTargetsRequest =
        inherit Request
        abstract arguments: GotoTargetsArguments with get, set

    and [<AllowNullLiteral>] GotoTargetsArguments =
        abstract source: Source with get, set
        abstract line: float with get, set
        abstract column: float option with get, set

    and [<AllowNullLiteral>] GotoTargetsResponse =
        inherit Response
        abstract body: obj with get, set

    and [<AllowNullLiteral>] CompletionsRequest =
        inherit Request
        abstract arguments: CompletionsArguments with get, set

    and [<AllowNullLiteral>] CompletionsArguments =
        abstract frameId: float option with get, set
        abstract text: string with get, set
        abstract column: float with get, set
        abstract line: float option with get, set

    and [<AllowNullLiteral>] CompletionsResponse =
        inherit Response
        abstract body: obj with get, set

    and [<AllowNullLiteral>] Capabilities =
        abstract supportsConfigurationDoneRequest: bool option with get, set
        abstract supportsFunctionBreakpoints: bool option with get, set
        abstract supportsConditionalBreakpoints: bool option with get, set
        abstract supportsHitConditionalBreakpoints: bool option with get, set
        abstract supportsEvaluateForHovers: bool option with get, set
        abstract exceptionBreakpointFilters: ResizeArray<ExceptionBreakpointsFilter> option with get, set
        abstract supportsStepBack: bool option with get, set
        abstract supportsSetVariable: bool option with get, set
        abstract supportsRestartFrame: bool option with get, set
        abstract supportsGotoTargetsRequest: bool option with get, set
        abstract supportsStepInTargetsRequest: bool option with get, set
        abstract supportsCompletionsRequest: bool option with get, set
        abstract supportsModulesRequest: bool option with get, set
        abstract additionalModuleColumns: ResizeArray<ColumnDescriptor> option with get, set
        abstract supportedChecksumAlgorithms: ResizeArray<ChecksumAlgorithm> option with get, set
        abstract supportsRestartRequest: bool option with get, set
        abstract supportsExceptionOptions: bool option with get, set
        abstract supportsValueFormattingOptions: bool option with get, set

    and [<AllowNullLiteral>] ExceptionBreakpointsFilter =
        abstract filter: string with get, set
        abstract label: string with get, set
        abstract ``default``: bool option with get, set

    and [<AllowNullLiteral>] Message =
        abstract id: float with get, set
        abstract format: string with get, set
        abstract variables: obj option with get, set
        abstract sendTelemetry: bool option with get, set
        abstract showUser: bool option with get, set
        abstract url: string option with get, set
        abstract urlLabel: string option with get, set

    and [<AllowNullLiteral>] Module =
        abstract id: U2<float, string> with get, set
        abstract name: string with get, set
        abstract path: string option with get, set
        abstract isOptimized: bool option with get, set
        abstract isUserCode: bool option with get, set
        abstract version: string option with get, set
        abstract symbolStatus: string option with get, set
        abstract symbolFilePath: string option with get, set
        abstract dateTimeStamp: string option with get, set
        abstract addressRange: string option with get, set

    and [<AllowNullLiteral>] ColumnDescriptor =
        abstract attributeName: string with get, set
        abstract label: string with get, set
        abstract format: string option with get, set
        abstract ``type``: (* TODO StringEnum string | number | boolean | unixTimestampUTC *) string option with get, set
        abstract width: float option with get, set

    and [<AllowNullLiteral>] ModulesViewDescriptor =
        abstract columns: ResizeArray<ColumnDescriptor> with get, set

    and [<AllowNullLiteral>] Thread =
        abstract id: float with get, set
        abstract name: string with get, set

    and [<AllowNullLiteral>] Source =
        abstract name: string option with get, set
        abstract path: string option with get, set
        abstract sourceReference: float option with get, set
        abstract origin: string option with get, set
        abstract adapterData: obj option with get, set
        abstract checksums: ResizeArray<Checksum> option with get, set

    and [<AllowNullLiteral>] StackFrame =
        abstract id: float with get, set
        abstract name: string with get, set
        abstract source: Source option with get, set
        abstract line: float with get, set
        abstract column: float with get, set
        abstract endLine: float option with get, set
        abstract endColumn: float option with get, set
        abstract moduleId: U2<float, string> option with get, set

    and [<AllowNullLiteral>] Scope =
        abstract name: string with get, set
        abstract variablesReference: float with get, set
        abstract namedVariables: float option with get, set
        abstract indexedVariables: float option with get, set
        abstract expensive: bool with get, set
        abstract source: Source option with get, set
        abstract line: float option with get, set
        abstract column: float option with get, set
        abstract endLine: float option with get, set
        abstract endColumn: float option with get, set

    and [<AllowNullLiteral>] Variable =
        abstract name: string with get, set
        abstract value: string with get, set
        abstract ``type``: string option with get, set
        abstract kind: string option with get, set
        abstract evaluateName: string option with get, set
        abstract variablesReference: float with get, set
        abstract namedVariables: float option with get, set
        abstract indexedVariables: float option with get, set

    and [<AllowNullLiteral>] SourceBreakpoint =
        abstract line: float with get, set
        abstract column: float option with get, set
        abstract condition: string option with get, set
        abstract hitCondition: string option with get, set

    and [<AllowNullLiteral>] FunctionBreakpoint =
        abstract name: string with get, set
        abstract condition: string option with get, set
        abstract hitCondition: string option with get, set

    and [<AllowNullLiteral>] Breakpoint =
        abstract id: float option with get, set
        abstract verified: bool with get, set
        abstract message: string option with get, set
        abstract source: Source option with get, set
        abstract line: float option with get, set
        abstract column: float option with get, set
        abstract endLine: float option with get, set
        abstract endColumn: float option with get, set

    and [<AllowNullLiteral>] StepInTarget =
        abstract id: float with get, set
        abstract label: string with get, set

    and [<AllowNullLiteral>] GotoTarget =
        abstract id: float with get, set
        abstract label: string with get, set
        abstract line: float with get, set
        abstract column: float option with get, set
        abstract endLine: float option with get, set
        abstract endColumn: float option with get, set

    and [<AllowNullLiteral>] CompletionItem =
        abstract label: string with get, set
        abstract text: string option with get, set
        abstract ``type``: CompletionItemType option with get, set
        abstract start: float option with get, set
        abstract length: float option with get, set

    and  [<StringEnum>] CompletionItemType =
        | Method | Function | Constructor | Field | Variable | Class | Interface | Module | Property | Unit | Value | Enum | Keyword | Snippet | Text | Color | File | Reference | Customcolor

    and [<StringEnum>] ChecksumAlgorithm =
        | [<CompiledName("MD5")>] MD5 | [<CompiledName("SHA1")>] SHA1 | [<CompiledName("SHA256")>] SHA256 | [<CompiledName("SHA1Normalized")>] SHA1Normalized | [<CompiledName("SHA256Normalized")>] SHA256Normalized | Timestamp

    and [<AllowNullLiteral>] Checksum =
        abstract algorithm: ChecksumAlgorithm with get, set
        abstract checksum: string with get, set

    and [<AllowNullLiteral>] ValueFormat =
        abstract hex: bool option with get, set

    and [<AllowNullLiteral>] StackFrameFormat =
        inherit ValueFormat
        abstract parameters: bool option with get, set
        abstract parameterTypes: bool option with get, set
        abstract parameterNames: bool option with get, set
        abstract parameterValues: bool option with get, set
        abstract line: bool option with get, set
        abstract ``module``: bool option with get, set

    and [<AllowNullLiteral>] ExceptionOptions =
        abstract path: ResizeArray<ExceptionPathSegment> option with get, set
        abstract breakMode: ExceptionBreakMode with get, set

    and [<StringEnum>] ExceptionBreakMode =
        | Never | Always | Unhandled | UserUnhandled

    and [<AllowNullLiteral>] ExceptionPathSegment =
        abstract negate: bool option with get, set
        abstract names: ResizeArray<string> with get, set

module Protocol =
    type [<AllowNullLiteral>] [<Import("ProtocolServer","vscode-debugadapter")>] ProtocolServer() =
        // interface NodeJS.EventEmitter
        member __.TWO_CRLF with get(): obj = jsNative and set(v: obj): unit = jsNative
        member __._rawData with get(): obj = jsNative and set(v: obj): unit = jsNative
        member __._contentLength with get(): obj = jsNative and set(v: obj): unit = jsNative
        member __._sequence with get(): obj = jsNative and set(v: obj): unit = jsNative
        member __._writableStream with get(): obj = jsNative and set(v: obj): unit = jsNative
        member __._pendingRequests with get(): obj = jsNative and set(v: obj): unit = jsNative
        member __.start(inStream: Node.Stream.Readable<byte>, outStream: Node.Stream.Writable<byte>): unit = jsNative
        member __.stop(): unit = jsNative
        member __.sendEvent(``event``: DebugProtocol.Event): unit = jsNative
        member __.sendResponse(response: DebugProtocol.Response): unit = jsNative
        member __.sendRequest(command: string, args: obj, timeout: float, cb: (DebugProtocol.Response -> unit)): unit = jsNative
        member __.dispatchRequest(request: DebugProtocol.Request): unit = jsNative
        member __._emitEvent(``event``: obj): obj = jsNative
        member __._send(typ: obj, message: obj): obj = jsNative
        member __._handleData(data: obj): obj = jsNative



module DebugSession =

    type [<AllowNullLiteral>] [<Import("Source","vscode-debugadapter")>] Source(name: string, ?path: string, ?id: float, ?origin: string, ?data: obj) =
        // interface DebugProtocol.Source
        member __.name with get(): string = jsNative and set(v: string): unit = jsNative
        member __.path with get(): string = jsNative and set(v: string): unit = jsNative
        member __.sourceReference with get(): float = jsNative and set(v: float): unit = jsNative

    and [<AllowNullLiteral>] [<Import("Scope","vscode-debugadapter")>] Scope(name: string, reference: float, ?expensive: bool) =
        // interface DebugProtocol.Scope
        member __.name with get(): string = jsNative and set(v: string): unit = jsNative
        member __.variablesReference with get(): float = jsNative and set(v: float): unit = jsNative
        member __.expensive with get(): bool = jsNative and set(v: bool): unit = jsNative

    and [<AllowNullLiteral>] [<Import("StackFrame","vscode-debugadapter")>] StackFrame(i: float, nm: string, ?src: Source, ?ln: float, ?col: float) =
        // interface DebugProtocol.StackFrame
        member __.id with get(): float = jsNative and set(v: float): unit = jsNative
        member __.source with get(): Source = jsNative and set(v: Source): unit = jsNative
        member __.line with get(): float = jsNative and set(v: float): unit = jsNative
        member __.column with get(): float = jsNative and set(v: float): unit = jsNative
        member __.name with get(): string = jsNative and set(v: string): unit = jsNative

    and [<AllowNullLiteral>] [<Import("Thread","vscode-debugadapter")>] Thread(id: float, name: string) =
        // interface DebugProtocol.Thread
        member __.id with get(): float = jsNative and set(v: float): unit = jsNative
        member __.name with get(): string = jsNative and set(v: string): unit = jsNative

    and [<AllowNullLiteral>] [<Import("Variable","vscode-debugadapter")>] Variable(name: string, value: string, ?ref: float, ?indexedVariables: float, ?namedVariables: float) =
        // interface DebugProtocol.Variable
        member __.name with get(): string = jsNative and set(v: string): unit = jsNative
        member __.value with get(): string = jsNative and set(v: string): unit = jsNative
        member __.variablesReference with get(): float = jsNative and set(v: float): unit = jsNative

    and [<AllowNullLiteral>] [<Import("Breakpoint","vscode-debugadapter")>] Breakpoint(verified: bool, ?line: float, ?column: float, ?source: Source) =
        // interface DebugProtocol.Breakpoint
        member __.verified with get(): bool = jsNative and set(v: bool): unit = jsNative

    and [<AllowNullLiteral>] [<Import("Module","vscode-debugadapter")>] Module(id: U2<float, string>, name: string) =
        // interface DebugProtocol.Module
        member __.id with get(): U2<float, string> = jsNative and set(v: U2<float, string>): unit = jsNative
        member __.name with get(): string = jsNative and set(v: string): unit = jsNative

    and [<AllowNullLiteral>] [<Import("CompletionItem","vscode-debugadapter")>] CompletionItem(label: string, start: float, ?length: float) =
        // interface DebugProtocol.CompletionItem
        member __.label with get(): string = jsNative and set(v: string): unit = jsNative
        member __.start with get(): float = jsNative and set(v: float): unit = jsNative
        member __.length with get(): float = jsNative and set(v: float): unit = jsNative

    and [<AllowNullLiteral>] [<Import("StoppedEvent","vscode-debugadapter")>] StoppedEvent(reason: string, threadId: float, ?exception_text: string) =
        // interface DebugProtocol.StoppedEvent
        member __.body with get(): obj = jsNative and set(v: obj): unit = jsNative

    and [<AllowNullLiteral>] [<Import("ContinuedEvent","vscode-debugadapter")>] ContinuedEvent(threadId: float, ?allThreadsContinued: bool) =
        // interface DebugProtocol.ContinuedEvent
        member __.body with get(): obj = jsNative and set(v: obj): unit = jsNative

    and [<AllowNullLiteral>] [<Import("InitializedEvent","vscode-debugadapter")>] InitializedEvent() =
        // interface DebugProtocol.InitializedEvent
        member __.body with get(): obj = jsNative and set(v: obj): unit = jsNative



    and [<AllowNullLiteral>] [<Import("TerminatedEvent","vscode-debugadapter")>] TerminatedEvent(?restart: bool) =
        // interface DebugProtocol.TerminatedEvent
        member __.body with get(): obj = jsNative and set(v: obj): unit = jsNative


    and [<AllowNullLiteral>] [<Import("OutputEvent","vscode-debugadapter")>] OutputEvent(output: string, ?category: string, ?data: obj) =
        // interface DebugProtocol.OutputEvent
        member __.body with get(): obj = jsNative and set(v: obj): unit = jsNative

    and [<AllowNullLiteral>] [<Import("ThreadEvent","vscode-debugadapter")>] ThreadEvent(reason: string, threadId: float) =
        // interface DebugProtocol.ThreadEvent
        member __.body with get(): obj = jsNative and set(v: obj): unit = jsNative

    and [<AllowNullLiteral>] [<Import("BreakpointEvent","vscode-debugadapter")>] BreakpointEvent(reason: string, breakpoint: Breakpoint) =
        // interface DebugProtocol.BreakpointEvent
        member __.body with get(): obj = jsNative and set(v: obj): unit = jsNative

    and [<AllowNullLiteral>] [<Import("ModuleEvent","vscode-debugadapter")>] ModuleEvent(reason: (* TODO StringEnum new | changed | removed *) string, ``module``: Module) =
        // interface DebugProtocol.ModuleEvent
        member __.body with get(): obj = jsNative and set(v: obj): unit = jsNative

    and [<AllowNullLiteral>] [<Import("DebugSession","vscode-debugadapter")>] DebugSession(?obsolete_debuggerLinesAndColumnsStartAt1: bool, ?obsolete_isServer: bool) =
        inherit Protocol.ProtocolServer()
        member __._debuggerLinesStartAt1 with get(): obj = jsNative and set(v: obj): unit = jsNative
        member __._debuggerColumnsStartAt1 with get(): obj = jsNative and set(v: obj): unit = jsNative
        member __._debuggerPathsAreURIs with get(): obj = jsNative and set(v: obj): unit = jsNative
        member __._clientLinesStartAt1 with get(): obj = jsNative and set(v: obj): unit = jsNative
        member __._clientColumnsStartAt1 with get(): obj = jsNative and set(v: obj): unit = jsNative
        member __._clientPathsAreURIs with get(): obj = jsNative and set(v: obj): unit = jsNative
        member __._isServer with get(): obj = jsNative and set(v: obj): unit = jsNative
        member __._formatPIIRegexp with get(): obj = jsNative and set(v: obj): unit = jsNative
        member __.setDebuggerPathFormat(format: string): unit = jsNative
        member __.setDebuggerLinesStartAt1(enable: bool): unit = jsNative
        member __.setDebuggerColumnsStartAt1(enable: bool): unit = jsNative
        member __.setRunAsServer(enable: bool): unit = jsNative
        static member run(debugSession: obj): unit = jsNative
        member __.shutdown(): unit = jsNative
        member __.sendErrorResponse(response: DebugProtocol.Response, codeOrMessage: U2<float, DebugProtocol.Message>, ?format: string, ?variables: obj, ?dest: obj): unit = jsNative
        member __.runInTerminalRequest(args: DebugProtocol.RunInTerminalRequestArguments, timeout: float, cb: (DebugProtocol.RunInTerminalResponse -> unit)): unit = jsNative
        member __.dispatchRequest(request: DebugProtocol.Request): unit = jsNative
        member __.initializeRequest(response: DebugProtocol.InitializeResponse, args: DebugProtocol.InitializeRequestArguments): unit = jsNative
        member __.disconnectRequest(response: DebugProtocol.DisconnectResponse, args: DebugProtocol.DisconnectArguments): unit = jsNative
        member __.launchRequest(response: DebugProtocol.LaunchResponse, args: DebugProtocol.LaunchRequestArguments): unit = jsNative
        member __.attachRequest(response: DebugProtocol.AttachResponse, args: DebugProtocol.AttachRequestArguments): unit = jsNative
        member __.restartRequest(response: DebugProtocol.RestartResponse, args: DebugProtocol.RestartArguments): unit = jsNative
        member __.setBreakPointsRequest(response: DebugProtocol.SetBreakpointsResponse, args: DebugProtocol.SetBreakpointsArguments): unit = jsNative
        member __.setFunctionBreakPointsRequest(response: DebugProtocol.SetFunctionBreakpointsResponse, args: DebugProtocol.SetFunctionBreakpointsArguments): unit = jsNative
        member __.setExceptionBreakPointsRequest(response: DebugProtocol.SetExceptionBreakpointsResponse, args: DebugProtocol.SetExceptionBreakpointsArguments): unit = jsNative
        member __.configurationDoneRequest(response: DebugProtocol.ConfigurationDoneResponse, args: DebugProtocol.ConfigurationDoneArguments): unit = jsNative
        member __.continueRequest(response: DebugProtocol.ContinueResponse, args: DebugProtocol.ContinueArguments): unit = jsNative
        member __.nextRequest(response: DebugProtocol.NextResponse, args: DebugProtocol.NextArguments): unit = jsNative
        member __.stepInRequest(response: DebugProtocol.StepInResponse, args: DebugProtocol.StepInArguments): unit = jsNative
        member __.stepOutRequest(response: DebugProtocol.StepOutResponse, args: DebugProtocol.StepOutArguments): unit = jsNative
        member __.stepBackRequest(response: DebugProtocol.StepBackResponse, args: DebugProtocol.StepBackArguments): unit = jsNative
        member __.reverseContinueRequest(response: DebugProtocol.ReverseContinueResponse, args: DebugProtocol.ReverseContinueArguments): unit = jsNative
        member __.restartFrameRequest(response: DebugProtocol.RestartFrameResponse, args: DebugProtocol.RestartFrameArguments): unit = jsNative
        member __.gotoRequest(response: DebugProtocol.GotoResponse, args: DebugProtocol.GotoArguments): unit = jsNative
        member __.pauseRequest(response: DebugProtocol.PauseResponse, args: DebugProtocol.PauseArguments): unit = jsNative
        member __.sourceRequest(response: DebugProtocol.SourceResponse, args: DebugProtocol.SourceArguments): unit = jsNative
        member __.threadsRequest(response: DebugProtocol.ThreadsResponse): unit = jsNative
        member __.stackTraceRequest(response: DebugProtocol.StackTraceResponse, args: DebugProtocol.StackTraceArguments): unit = jsNative
        member __.scopesRequest(response: DebugProtocol.ScopesResponse, args: DebugProtocol.ScopesArguments): unit = jsNative
        member __.variablesRequest(response: DebugProtocol.VariablesResponse, args: DebugProtocol.VariablesArguments): unit = jsNative
        member __.setVariableRequest(response: DebugProtocol.SetVariableResponse, args: DebugProtocol.SetVariableArguments): unit = jsNative
        member __.evaluateRequest(response: DebugProtocol.EvaluateResponse, args: DebugProtocol.EvaluateArguments): unit = jsNative
        member __.stepInTargetsRequest(response: DebugProtocol.StepInTargetsResponse, args: DebugProtocol.StepInTargetsArguments): unit = jsNative
        member __.gotoTargetsRequest(response: DebugProtocol.GotoTargetsResponse, args: DebugProtocol.GotoTargetsArguments): unit = jsNative
        member __.completionsRequest(response: DebugProtocol.CompletionsResponse, args: DebugProtocol.CompletionsArguments): unit = jsNative
        member __.customRequest(command: string, response: DebugProtocol.Response, args: obj): unit = jsNative
        member __.convertClientLineToDebugger(line: float): float = jsNative
        member __.convertDebuggerLineToClient(line: float): float = jsNative
        member __.convertClientColumnToDebugger(column: float): float = jsNative
        member __.convertDebuggerColumnToClient(column: float): float = jsNative
        member __.convertClientPathToDebugger(clientPath: string): string = jsNative
        member __.convertDebuggerPathToClient(debuggerPath: string): string = jsNative
        static member path2uri(str: obj): obj = jsNative
        static member uri2path(url: obj): obj = jsNative
        static member formatPII(format: obj, excludePII: obj, args: obj): obj = jsNative


