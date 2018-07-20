namespace Fable.Import
open System
open Fable.Core
open Fable.Import.JS
open Fable.Import.Node

module vscode =
    type [<Import("Disposable","vscode")>] Disposable(callOnDispose: Function) =
        static member from([<ParamArray>] disposableLikes: obj[]): Disposable = failwith "JS only"
        member __.dispose(): obj = failwith "JS only"

    and Event<'T> =
        [<Emit("$0($1...)")>] abstract Invoke: listener: Func<'T, obj> * ?thisArgs: obj * ?disposables: ResizeArray<Disposable> -> Disposable


    and [<Import("EventEmitter", "vscode")>] EventEmitter<'T>() =
        member __.addListener(``event``: string, listener: Function): Events.EventEmitter = failwith "JS only"
        member __.on(``event``: string, listener: Function): Events.EventEmitter = failwith "JS only"
        member __.once(``event``: string, listener: Function): Events.EventEmitter = failwith "JS only"
        member __.removeListener(``event``: string, listener: Function): Events.EventEmitter = failwith "JS only"
        member __.removeAllListeners(?``event``: string): Events.EventEmitter = failwith "JS only"
        member __.setMaxListeners(n: int): unit = failwith "JS only"
        member __.getMaxListeners(): int = failwith "JS only"
        member __.listeners(``event``: string): ResizeArray<Function> = failwith "JS only"
        member __.listenerCount(``type``: string): int = failwith "JS only"
        member __.emit(``event``: string, [<ParamArray>] args: obj[]): bool = failwith "JS only"
        member __.event with get (): Event<'T> = failwith "JS only"
        member __.fire(arg : 'T) : unit = failwith "JS only"

    type Command =
        abstract title: string with get, set
        abstract command: string with get, set
        abstract arguments: ResizeArray<obj> option with get, set

    and TextLine =
        abstract lineNumber: float with get, set
        abstract text: string with get, set
        abstract range: Range with get, set
        abstract rangeIncludingLineBreak: Range with get, set
        abstract firstNonWhitespaceCharacterIndex: float with get, set
        abstract isEmptyOrWhitespace: bool with get, set

    and TextDocument =
        abstract uri: Uri with get, set
        abstract fileName: string with get, set
        abstract isUntitled: bool with get, set
        abstract languageId: string with get, set
        abstract version: float with get, set
        abstract isDirty: bool with get, set
        abstract lineCount: float with get, set
        abstract save: unit -> Promise<bool>
        abstract lineAt: line: float -> TextLine
        abstract lineAt: position: Position -> TextLine
        abstract offsetAt: position: Position -> float
        abstract positionAt: offset: float -> Position
        abstract getText: ?range: Range -> string
        abstract getWordRangeAtPosition: position: Position -> Range
        abstract validateRange: range: Range -> Range
        abstract validatePosition: position: Position -> Position

    and [<Import("Position","vscode")>] Position(line: float, character: float) =
        member __.line with get(): float = failwith "JS only" and set(v: float): unit = failwith "JS only"
        member __.character with get(): float = failwith "JS only" and set(v: float): unit = failwith "JS only"
        member __.isBefore(other: Position): bool = failwith "JS only"
        member __.isBeforeOrEqual(other: Position): bool = failwith "JS only"
        member __.isAfter(other: Position): bool = failwith "JS only"
        member __.isAfterOrEqual(other: Position): bool = failwith "JS only"
        member __.isEqual(other: Position): bool = failwith "JS only"
        member __.compareTo(other: Position): float = failwith "JS only"
        member __.translate(?lineDelta: float, ?characterDelta: float): Position = failwith "JS only"
        member __.``with``(?line: float, ?character: float): Position = failwith "JS only"

    and [<Import("Range","vscode")>] Range(startLine: float, startCharacter: float, endLine: float, endCharacter: float) =
        member __.start with get(): Position = failwith "JS only" and set(v: Position): unit = failwith "JS only"
        member __.``end`` with get(): Position = failwith "JS only" and set(v: Position): unit = failwith "JS only"
        member __.isEmpty with get(): bool = failwith "JS only" and set(v: bool): unit = failwith "JS only"
        member __.isSingleLine with get(): bool = failwith "JS only" and set(v: bool): unit = failwith "JS only"
        member __.contains(positionOrRange: U2<Position, Range>): bool = failwith "JS only"
        member __.isEqual(other: Range): bool = failwith "JS only"
        member __.intersection(range: Range): Range = failwith "JS only"
        member __.union(other: Range): Range = failwith "JS only"
        member __.``with``(?start: Position, ?``end``: Position): Range = failwith "JS only"

    and [<Import("Selection","vscode")>] Selection(anchorLine: float, anchorCharacter: float, activeLine: float, activeCharacter: float) =
        inherit Range(anchorLine, anchorCharacter, activeLine, activeCharacter)
        member __.anchor with get(): Position = failwith "JS only" and set(v: Position): unit = failwith "JS only"
        member __.active with get(): Position = failwith "JS only" and set(v: Position): unit = failwith "JS only"
        member __.isReversed with get(): bool = failwith "JS only" and set(v: bool): unit = failwith "JS only"

    /// Represents sources that can cause selection change events.
    and TextEditorSelectionChangeKind =
        /// Selection changed due to typing in the editor.
        | Keyboard = 1
        /// Selection change due to clicking in the editor.
        | Mouse = 2
        /// Selection changed because a command ran.
        | Command = 3

    and TextEditorSelectionChangeEvent =
        abstract textEditor: TextEditor with get, set
        abstract selections: ResizeArray<Selection> with get, set
        /// The change kind which has triggered this event.
        abstract kind: TextEditorSelectionChangeKind option with get, set

    and TextEditorOptionsChangeEvent =
        abstract textEditor: TextEditor with get, set
        abstract options: TextEditorOptions with get, set

    and TextEditorOptions =
        abstract tabSize: float with get, set
        abstract insertSpaces: bool with get, set

    and TextEditorDecorationType =
        abstract key: string with get, set
        abstract dispose: unit -> unit

    and TextEditorRevealType =
        | Default = 0
        | InCenter = 1
        | InCenterIfOutsideViewport = 2

    and OverviewRulerLane =
        | Left = 1
        | Center = 2
        | Right = 4
        | Full = 7

    and DecorationRangeBehavior =
        /// The decoration's range will widen when edits occur at the start or end.
        | OpenOpen = 0
        /// The decoration's range will not widen when edits occur at the start of end.
        | ClosedClosed = 1
        /// The decoration's range will widen when edits occur at the start, but not at the end.
        | OpenClosed = 2
        /// The decoration's range will widen when edits occur at the end, but not at the start.
        | ClosedOpen = 3

    and [<Import("ThemeColor","vscode")>] ThemeColor(id: string) =
        class end

    and ThemableDecorationRenderOptions =
        abstract backgroundColor: U2<string, ThemeColor> option with get, set
        abstract outlineColor: U2<string, ThemeColor> option with get, set
        abstract outlineStyle: string option with get, set
        abstract outlineWidth: string option with get, set
        abstract borderColor: U2<string, ThemeColor> option with get, set
        abstract borderRadius: string option with get, set
        abstract borderSpacing: string option with get, set
        abstract borderStyle: string option with get, set
        abstract borderWidth: string option with get, set
        abstract textDecoration: string option with get, set
        abstract cursor: string option with get, set
        abstract color: U2<string, ThemeColor> option with get, set
        abstract gutterIconPath: string option with get, set
        abstract overviewRulerColor: U2<string, ThemeColor> option with get, set

    and DecorationRenderOptions =
        inherit ThemableDecorationRenderOptions
        abstract isWholeLine: bool option with get, set
        /// Customize the growing behavior of the decoration when edits occur at the edges of the decoration's range.
        /// Defaults to `DecorationRangeBehavior.OpenOpen`.
        abstract rangeBehavior: DecorationRangeBehavior option with get, set
        abstract overviewRulerLane: OverviewRulerLane option with get, set
        abstract light: ThemableDecorationRenderOptions option with get, set
        abstract dark: ThemableDecorationRenderOptions option with get, set

    and ThemableDecorationAttachmentRenderOptions =
        /// Defines a text content that is shown in the attachment. Either an icon or a text can be shown, but not both.
        abstract contentText: string option with get, set
        /// An **absolute path** or an URI to an image to be rendered in the attachment. Either an icon
        /// or a text can be shown, but not both.
        abstract contentIconPath: U2<string, Uri> option with get, set
        /// CSS styling property that will be applied to the decoration attachment.
        abstract border: string option with get, set
        /// CSS styling property that will be applied to text enclosed by a decoration.
        abstract borderColor: U2<string, ThemeColor> option with get, set
        /// CSS styling property that will be applied to the decoration attachment.
        abstract textDecoration: string option with get, set
        /// CSS styling property that will be applied to the decoration attachment.
        abstract color: U2<string, ThemeColor> option with get, set
        /// CSS styling property that will be applied to the decoration attachment.
        abstract backgroundColor: U2<string, ThemeColor> option with get, set
        /// CSS styling property that will be applied to the decoration attachment.
        abstract margin: string option with get, set
        /// CSS styling property that will be applied to the decoration attachment.
        abstract width: string option with get, set
        /// CSS styling property that will be applied to the decoration attachment.
        abstract height: string option with get, set

    and ThemableDecorationInstanceRenderOptions =
        abstract before: ThemableDecorationAttachmentRenderOptions option with get, set
        abstract after: ThemableDecorationAttachmentRenderOptions option with get, set

    and DecorationInstanceRenderOptions =
        inherit ThemableDecorationInstanceRenderOptions
        abstract light: ThemableDecorationInstanceRenderOptions option with get, set
        abstract dark: ThemableDecorationInstanceRenderOptions option with get, set

    and DecorationOptions =
        abstract range: Range with get, set
        abstract hoverMessage: U2<MarkedString, ResizeArray<MarkedString>> with get, set
        abstract renderOptions: DecorationInstanceRenderOptions option with get, set

    and TextEditor =
        abstract document: TextDocument with get, set
        abstract selection: Selection with get, set
        abstract selections: ResizeArray<Selection> with get, set
        abstract options: TextEditorOptions with get, set
        abstract edit: callback: Func<TextEditorEdit, unit> -> Promise<bool>
        abstract setDecorations: decorationType: TextEditorDecorationType * rangesOrOptions: U2<ResizeArray<Range>, ResizeArray<DecorationOptions>> -> unit
        abstract revealRange: range: Range * ?revealType: TextEditorRevealType -> unit
        abstract show: ?column: ViewColumn -> unit
        abstract hide: unit -> unit

    and TextEditorEdit =
        abstract replace: location: U3<Position, Range, Selection> * value: string -> unit
        abstract insert: location: Position * value: string -> unit
        abstract delete: location: U2<Range, Selection> -> unit

    and [<Import("Uri","vscode")>] Uri() =
        member __.scheme with get(): string = failwith "JS only" and set(v: string): unit = failwith "JS only"
        member __.authority with get(): string = failwith "JS only" and set(v: string): unit = failwith "JS only"
        member __.path with get(): string = failwith "JS only" and set(v: string): unit = failwith "JS only"
        member __.query with get(): string = failwith "JS only" and set(v: string): unit = failwith "JS only"
        member __.fragment with get(): string = failwith "JS only" and set(v: string): unit = failwith "JS only"
        member __.fsPath with get(): string = failwith "JS only" and set(v: string): unit = failwith "JS only"
        static member file(path: string): Uri = failwith "JS only"
        static member parse(value: string): Uri = failwith "JS only"
        member __.toString(): string = failwith "JS only"
        member __.toJSON(): obj = failwith "JS only"

    and CancellationToken =
        abstract isCancellationRequested: bool with get, set
        abstract onCancellationRequested: Event<obj> with get, set

    and [<Import("CancellationTokenSource","vscode")>] CancellationTokenSource() =
        member __.token with get(): CancellationToken = failwith "JS only" and set(v: CancellationToken): unit = failwith "JS only"
        member __.cancel(): unit = failwith "JS only"
        member __.dispose(): unit = failwith "JS only"


    and FileSystemWatcher =
        abstract from: [<ParamArray>] disposableLikes: obj[] -> Disposable
        abstract dispose: unit -> obj
        abstract ignoreCreateEvents: bool with get, set
        abstract ignoreChangeEvents: bool with get, set
        abstract ignoreDeleteEvents: bool with get, set
        abstract onDidCreate: Event<Uri> with get, set
        abstract onDidChange: Event<Uri> with get, set
        abstract onDidDelete: Event<Uri> with get, set

    and QuickPickItem =
        abstract label: string with get, set
        abstract description: string with get, set

    and QuickPickOptions =
        abstract matchOnDescription: bool option with get, set
        abstract placeHolder: string option with get, set

    and MessageItem =
        abstract title: string with get, set

    and InputBoxOptions =
        abstract value: string option with get, set
        abstract prompt: string option with get, set
        abstract placeHolder: string option with get, set
        abstract password: bool option with get, set

    and DocumentFilter =
        abstract language: string option with get, set
        abstract scheme: string option with get, set
        abstract pattern: string option with get, set

    and DocumentSelector =
        U3<string, DocumentFilter, ResizeArray<U2<string, DocumentFilter>>>

    and CodeActionContext =
        abstract diagnostics: ResizeArray<Diagnostic> with get, set

    and CodeActionProvider =
        abstract provideCodeActions: document: TextDocument * range: Range * context: CodeActionContext * token: CancellationToken -> U2<ResizeArray<Command>, Promise<ResizeArray<Command>>>

    and [<Import("CodeLens","vscode")>] CodeLens(range: Range, ?command: Command) =
        member __.range with get(): Range = failwith "JS only" and set(v: Range): unit = failwith "JS only"
        member __.command with get(): Command = failwith "JS only" and set(v: Command): unit = failwith "JS only"
        member __.isResolved with get(): bool = failwith "JS only" and set(v: bool): unit = failwith "JS only"

    and CodeLensProvider =
        abstract provideCodeLenses: document: TextDocument * token: CancellationToken -> U2<ResizeArray<CodeLens>, Promise<ResizeArray<CodeLens>>>
        abstract resolveCodeLens: codeLens: CodeLens * token: CancellationToken -> U2<CodeLens, Promise<CodeLens>>
        abstract onDidChangeCodeLenses : Event<unit>

    and Definition =
        U2<Location, ResizeArray<Location>>

    and DefinitionProvider =
        abstract provideDefinition: document: TextDocument * position: Position * token: CancellationToken -> U2<Definition, Promise<Definition>>

    and TypeDefinitionProvider =
        abstract provideTypeDefinition: document: TextDocument * position: Position * token: CancellationToken -> U2<Definition, Promise<Definition>>

    and [<Import("MarkdownString","vscode")>] MarkdownString(?value: string) =
        member __.value with get(): string = failwith "JS only" and set(v: string): unit = failwith "JS only"
        member __.isTrusted with get(): bool = failwith "JS only" and set(v: bool): unit = failwith "JS only"
        member __.appendText(value: string): MarkdownString = failwith "JS only"
        member __.appendMarkdown(value: string): MarkdownString = failwith "JS only"

    and MarkedString =
        U3<MarkdownString, string, obj>

    and [<Import("Hover","vscode")>] Hover(contents: U2<MarkedString, ResizeArray<MarkedString>>, ?range: Range) =
        member __.contents with get(): ResizeArray<MarkedString> = failwith "JS only" and set(v: ResizeArray<MarkedString>): unit = failwith "JS only"
        member __.range with get(): Range = failwith "JS only" and set(v: Range): unit = failwith "JS only"

    and HoverProvider =
        abstract provideHover: document: TextDocument * position: Position * token: CancellationToken -> U2<Hover, Promise<Hover>>

    and DocumentHighlightKind =
        | Text = 0
        | Read = 1
        | Write = 2

    and [<Import("DocumentHighlight","vscode")>] DocumentHighlight(range: Range, ?kind: DocumentHighlightKind) =
        member __.range with get(): Range = failwith "JS only" and set(v: Range): unit = failwith "JS only"
        member __.kind with get(): DocumentHighlightKind = failwith "JS only" and set(v: DocumentHighlightKind): unit = failwith "JS only"

    and DocumentHighlightProvider =
        abstract provideDocumentHighlights: document: TextDocument * position: Position * token: CancellationToken -> U2<ResizeArray<DocumentHighlight>, Promise<ResizeArray<DocumentHighlight>>>

    and SymbolKind =
        | File = 0
        | Module = 1
        | Namespace = 2
        | Package = 3
        | Class = 4
        | Method = 5
        | Property = 6
        | Field = 7
        | Constructor = 8
        | Enum = 9
        | Interface = 10
        | Function = 11
        | Variable = 12
        | Constant = 13
        | String = 14
        | Number = 15
        | Boolean = 16
        | Array = 17

    and [<Import("SymbolInformation","vscode")>] SymbolInformation(name: string, kind: SymbolKind, range: Range, ?uri: Uri, ?containerName: string) =
        member __.name with get(): string = failwith "JS only" and set(v: string): unit = failwith "JS only"
        member __.containerName with get(): string = failwith "JS only" and set(v: string): unit = failwith "JS only"
        member __.kind with get(): SymbolKind = failwith "JS only" and set(v: SymbolKind): unit = failwith "JS only"
        member __.location with get(): Location = failwith "JS only" and set(v: Location): unit = failwith "JS only"

    and DocumentSymbolProvider =
        abstract provideDocumentSymbols: document: TextDocument * token: CancellationToken -> U2<ResizeArray<SymbolInformation>, Promise<ResizeArray<SymbolInformation>>>

    and WorkspaceSymbolProvider =
        abstract provideWorkspaceSymbols: query: string * token: CancellationToken -> U2<ResizeArray<SymbolInformation>, Promise<ResizeArray<SymbolInformation>>>

    and ReferenceContext =
        abstract includeDeclaration: bool with get, set

    and ReferenceProvider =
        abstract provideReferences: document: TextDocument * position: Position * context: ReferenceContext * token: CancellationToken -> U2<ResizeArray<Location>, Promise<ResizeArray<Location>>>

    and [<Import("TextEdit","vscode")>] TextEdit(range: Range, newText: string) =
        member __.range with get(): Range = failwith "JS only" and set(v: Range): unit = failwith "JS only"
        member __.newText with get(): string = failwith "JS only" and set(v: string): unit = failwith "JS only"
        static member replace(range: Range, newText: string): TextEdit = failwith "JS only"
        static member insert(position: Position, newText: string): TextEdit = failwith "JS only"
        member __.delete(range: Range): TextEdit = failwith "JS only"

    and [<Import("WorkspaceEdit","vscode")>] WorkspaceEdit() =
        member __.size with get(): float = failwith "JS only" and set(v: float): unit = failwith "JS only"
        member __.replace(uri: Uri, range: Range, newText: string): unit = failwith "JS only"
        member __.insert(uri: Uri, position: Position, newText: string): unit = failwith "JS only"
        member __.delete(uri: Uri, range: Range): unit = failwith "JS only"
        member __.has(uri: Uri): bool = failwith "JS only"
        member __.set(uri: Uri, edits: ResizeArray<TextEdit>): unit = failwith "JS only"
        member __.get(uri: Uri): ResizeArray<TextEdit> = failwith "JS only"
        member __.entries(): ResizeArray<Uri * ResizeArray<TextEdit>> = failwith "JS only"

    and RenameProvider =
        abstract provideRenameEdits: document: TextDocument * position: Position * newName: string * token: CancellationToken -> U2<WorkspaceEdit, Promise<WorkspaceEdit>>

    and FormattingOptions =
        abstract tabSize: float with get, set
        abstract insertSpaces: bool with get, set
        [<Emit("$0[$1]{{=$2}}")>] abstract Item: key: string -> U3<bool, float, string> with get, set

    and DocumentFormattingEditProvider =
        abstract provideDocumentFormattingEdits: document: TextDocument * options: FormattingOptions * token: CancellationToken -> U2<ResizeArray<TextEdit>, Promise<ResizeArray<TextEdit>>>

    and DocumentRangeFormattingEditProvider =
        abstract provideDocumentRangeFormattingEdits: document: TextDocument * range: Range * options: FormattingOptions * token: CancellationToken -> U2<ResizeArray<TextEdit>, Promise<ResizeArray<TextEdit>>>

    and OnTypeFormattingEditProvider =
        abstract provideOnTypeFormattingEdits: document: TextDocument * position: Position * ch: string * options: FormattingOptions * token: CancellationToken -> U2<ResizeArray<TextEdit>, Promise<ResizeArray<TextEdit>>>

    and [<Import("ParameterInformation","vscode")>] ParameterInformation(label: string, ?documentation: U2<string, MarkdownString>) =
        member __.label with get(): string = failwith "JS only" and set(v: string): unit = failwith "JS only"
        member __.documentation with get(): U2<string, MarkdownString> = failwith "JS only" and set(v: U2<string, MarkdownString>): unit = failwith "JS only"

    and [<Import("SignatureInformation","vscode")>] SignatureInformation(label: string, ?documentation: U2<string, MarkdownString>) =
        member __.label with get(): string = failwith "JS only" and set(v: string): unit = failwith "JS only"
        member __.documentation with get(): U2<string, MarkdownString> = failwith "JS only" and set(v: U2<string, MarkdownString>): unit = failwith "JS only"
        member __.parameters with get(): ResizeArray<ParameterInformation> = failwith "JS only" and set(v: ResizeArray<ParameterInformation>): unit = failwith "JS only"

    and [<Import("SignatureHelp","vscode")>] SignatureHelp() =
        member __.signatures with get(): ResizeArray<SignatureInformation> = failwith "JS only" and set(v: ResizeArray<SignatureInformation>): unit = failwith "JS only"
        member __.activeSignature with get(): float = failwith "JS only" and set(v: float): unit = failwith "JS only"
        member __.activeParameter with get(): float = failwith "JS only" and set(v: float): unit = failwith "JS only"

    and SignatureHelpProvider =
        abstract provideSignatureHelp: document: TextDocument * position: Position * token: CancellationToken -> U2<SignatureHelp, Promise<SignatureHelp>>

    and CompletionItemKind =
        | Text = 0
        | Method = 1
        | Function = 2
        | Constructor = 3
        | Field = 4
        | Variable = 5
        | Class = 6
        | Interface = 7
        | Module = 8
        | Property = 9
        | Unit = 10
        | Value = 11
        | Enum = 12
        | Keyword = 13
        | Snippet = 14
        | Color = 15
        | File = 16
        | Reference = 17

    and [<Import("CompletionItem","vscode")>] CompletionItem(label: string) =
        member __.label with get(): string = failwith "JS only" and set(v: string): unit = failwith "JS only"
        member __.kind with get(): CompletionItemKind = failwith "JS only" and set(v: CompletionItemKind): unit = failwith "JS only"
        member __.detail with get(): string = failwith "JS only" and set(v: string): unit = failwith "JS only"
        member __.documentation with get(): U2<string, MarkdownString> = failwith "JS only" and set(v: U2<string, MarkdownString>): unit = failwith "JS only"
        member __.sortText with get(): string = failwith "JS only" and set(v: string): unit = failwith "JS only"
        member __.filterText with get(): string = failwith "JS only" and set(v: string): unit = failwith "JS only"
        member __.insertText with get(): string = failwith "JS only" and set(v: string): unit = failwith "JS only"
        member __.textEdit with get(): TextEdit = failwith "JS only" and set(v: TextEdit): unit = failwith "JS only"
        member __.additionalTextEdits with get(): TextEdit[] = failwith "JS only" and set(v: TextEdit[]): unit = failwith "JS only"


    and CompletionItemProvider =
        abstract provideCompletionItems: document: TextDocument * position: Position * token: CancellationToken -> U2<ResizeArray<CompletionItem>, Promise<ResizeArray<CompletionItem>>>
        abstract resolveCompletionItem: item: CompletionItem * token: CancellationToken -> U2<CompletionItem, Promise<CompletionItem>>

    and CharacterPair =
        string * string

    and CommentRule =
        abstract lineComment: string option with get, set
        abstract blockComment: CharacterPair option with get, set

    and IndentationRule =
        abstract decreaseIndentPattern: RegExp with get, set
        abstract increaseIndentPattern: RegExp with get, set
        abstract indentNextLinePattern: RegExp option with get, set
        abstract unIndentedLinePattern: RegExp option with get, set

    and IndentAction =
        | None = 0
        | Indent = 1
        | IndentOutdent = 2
        | Outdent = 3

    and EnterAction =
        abstract indentAction: IndentAction with get, set
        abstract appendText: string option with get, set
        abstract removeText: float option with get, set

    and OnEnterRule =
        abstract beforeText: RegExp with get, set
        abstract afterText: RegExp option with get, set
        abstract action: EnterAction with get, set

    and LanguageConfiguration =
        abstract comments: CommentRule option with get, set
        abstract brackets: ResizeArray<CharacterPair> option with get, set
        abstract wordPattern: RegExp option with get, set
        abstract indentationRules: IndentationRule option with get, set
        abstract onEnterRules: ResizeArray<OnEnterRule> option with get, set
        abstract ___electricCharacterSupport: obj option with get, set
        abstract ___characterPairSupport: obj option with get, set

    and WorkspaceConfiguration =
        [<Emit("$0[$1]{{=$2}}")>] abstract Item: key: string -> obj with get, set
        abstract get: section: string * ?defaultValue: 'T -> 'T
        abstract has: section: string -> bool
        abstract update: section: string * value: 'T * configurationTarget: bool -> Promise<unit>

    and [<Import("Location","vscode")>] Location(uri: Uri, rangeOrPosition: U2<Range, Position>) =
        member __.uri with get(): Uri = failwith "JS only" and set(v: Uri): unit = failwith "JS only"
        member __.range with get(): Range = failwith "JS only" and set(v: Range): unit = failwith "JS only"

    and DiagnosticSeverity =
        | Error = 0
        | Warning = 1
        | Information = 2
        | Hint = 3

    and [<RequireQualifiedAccess>] DiagnosticTag =
        | Unnecessary = 1

    and [<Import("Diagnostic","vscode")>] Diagnostic(range: Range, message: string, ?severity: DiagnosticSeverity) =
        member __.range with get(): Range = failwith "JS only" and set(v: Range): unit = failwith "JS only"
        member __.message with get(): string = failwith "JS only" and set(v: string): unit = failwith "JS only"
        member __.source with get(): string = failwith "JS only" and set(v: string): unit = failwith "JS only"
        member __.severity with get(): DiagnosticSeverity = failwith "JS only" and set(v: DiagnosticSeverity): unit = failwith "JS only"
        member __.code with get(): U2<string, float> = failwith "JS only" and set(v: U2<string, float>): unit = failwith "JS only"
        /// Additional metadata about the diagnostic.
        member __.tags with get() : ResizeArray<DiagnosticTag> = jsNative and set(v: ResizeArray<DiagnosticTag>) : unit = jsNative

    and DiagnosticCollection =
        abstract name: string with get, set
        abstract set: uri: Uri * diagnostics: ResizeArray<Diagnostic> -> unit
        abstract delete: uri: Uri -> unit
        abstract set: entries: ResizeArray<Uri * ResizeArray<Diagnostic>> -> unit
        abstract clear: unit -> unit
        abstract dispose: unit -> unit
        abstract get: uri: Uri -> ResizeArray<Diagnostic>

    and ViewColumn =
        | One = 1
        | Two = 2
        | Three = 3

    and OutputChannel =
        abstract name: string with get, set
        abstract append: value: string -> unit
        abstract appendLine: value: string -> unit
        abstract clear: unit -> unit
        abstract show: ?column: ViewColumn -> unit
        abstract hide: unit -> unit
        abstract dispose: unit -> unit

    and StatusBarAlignment =
        | Right = 0
        | Left = 1

    and StatusBarItem =
        abstract alignment: StatusBarAlignment with get, set
        abstract priority: float with get, set
        abstract text: string with get, set
        abstract tooltip: string with get, set
        abstract color: string with get, set
        abstract command: string with get, set
        abstract show: unit -> unit
        abstract hide: unit -> unit
        abstract dispose: unit -> unit

    and Terminal =
        abstract name: string with get
        abstract dispose : unit -> unit
        abstract hide : unit -> unit
        abstract show : ?prserveFocus : bool -> unit
        abstract sendText : text : string * ?addNewLine : bool -> unit
        abstract processId: Promise<int> with get

    and Extension<'T> =
        abstract id: string with get, set
        abstract extensionPath: string with get, set
        abstract isActive: bool with get, set
        abstract packageJSON: obj with get, set
        abstract exports: 'T with get, set
        abstract activate: unit -> Promise<'T>

    and ExtensionContext =
        abstract subscriptions: ResizeArray<obj> with get, set
        abstract workspaceState: Memento with get, set
        abstract globalState: Memento with get, set
        abstract extensionPath: string with get, set
        abstract asAbsolutePath: relativePath: string -> string
        abstract storagePath: string option with get, set

    and Memento =
        abstract get<'T> : key: string -> 'T option
        abstract get: key: string * ?defaultValue: 'T -> 'T
        abstract update: key: string * value: obj -> Promise<unit>

    and TextDocumentContentChangeEvent =
        abstract range: Range with get, set
        abstract rangeLength: float with get, set
        abstract text: string with get, set

    and TextDocumentChangeEvent =
        abstract document: TextDocument with get, set
        abstract contentChanges: ResizeArray<TextDocumentContentChangeEvent> with get, set

    and TextDocumentContentProvider =
        abstract provideTextDocumentContent : uri: Uri -> string

    and [<Import("DocumentLink","vscode")>] DocumentLink(range : Range, target: Uri) =
        member __.target with get(): Uri = failwith "JS only" and set(v: Uri): unit = failwith "JS only"
        member __.range with get(): Range = failwith "JS only" and set(v: Range): unit = failwith "JS only"

    and DocumentLinkProvider =
        abstract provideDocumentLinks : document : TextDocument * ct : CancellationToken ->  U2<DocumentLink[], Promise<DocumentLink[]>>

    and TreeDataProvider<'T> =
        abstract onDidChangeTreeData: Event<'T option> with get
        abstract getTreeItem: 'T -> TreeItem
        abstract getChildren: 'T -> ResizeArray<'T>
        abstract getParent: ('T -> 'T option) option with get

    and TreeIconPath =
        abstract light: U3<string, Uri, ThemeIcon> with get, set
        abstract dark: U3<string, Uri, ThemeIcon> with get, set

    and [<Import("ThemeIcon","vscode")>] ThemeIcon =
        static member File with get(): ThemeIcon = failwith "JS only"
        static member Folder with get(): ThemeIcon = failwith "JS only"
        member __.id with get(): string = jsNative

    and [<Import("TreeItem","vscode")>] TreeItem(label: string, ?collapsibleState: TreeItemCollapsibleState) =
        member __.label with get(): string option = jsNative and set(v: string option) = jsNative
        member __.id with get(): string option = jsNative and set(v: string option) = jsNative
        member __.iconPath with get(): U4<string, Uri, TreeIconPath, ThemeIcon> option = jsNative and set(v: U4<string, Uri, TreeIconPath, ThemeIcon> option) = jsNative
        member __.resourceUri with get(): Uri option = jsNative and set(v: Uri option) = jsNative
        member __.tooltip with get(): string option = jsNative and set(v: string option) = jsNative
        member __.command with get(): Command option = jsNative and set(v: Command option) = jsNative
        member __.contextValue with get(): string option = jsNative and set(v: string option) = jsNative
        member __.collapsibleState with get(): TreeItemCollapsibleState option = jsNative and set(v: TreeItemCollapsibleState option) = jsNative

    and TreeItemCollapsibleState =
        | None = 0
        | Collapsed = 1
        | Expanded = 2

    and ProgressLocation =
        | SourceControl = 1
        | Window = 10

    and ProgressOptions =
        abstract location: ProgressLocation with get, set
        abstract title : string option with get,set

    and ProgressMessage =
        abstract message: string with get,set

    and Progress<'T> =
        abstract report: 'T -> unit

    and DebugSession =
        abstract id: string with get,set
        abstract name: string with get,set
        abstract ``type``: string with get,set

    and DebugSessionCustomEvent =
        abstract body: obj option with get,set
        abstract event: string with get,set
        abstract session: DebugSession with get,set

    and WorkspaceFolder =
        abstract id: string with get,set
        abstract name: string with get,set
        abstract uri: Uri with get,set

    and SaveDialogOptions =
        abstract defaultUri: Uri option with get,set
        abstract filters: obj option with get,set
        abstract saveLabel: string option with get,set

    and OpenDialogOptions =
        abstract canSelectFiles: bool option with get,set
        abstract canSelectFolders: bool option with get, set
        abstract canSelectMany: bool option with get,set
        abstract defaultUri: Uri option with get,set
        abstract filters: obj option with get,set
        abstract openLabel: string option with get,set

    and CreateTreeViewOptions<'T> =
        abstract treeDataProvider: TreeDataProvider<'T> with get,set

    and TreeViewRevealOptions =
        abstract select: bool option with get,set

    and TreeView<'T> =
        abstract member reveal: element: 'T * ?options: TreeViewRevealOptions -> Promise<unit>
        abstract member dispose: unit -> obj

    let [<Import("version","vscode")>] version: string = failwith "JS only"

    type [<Import("commands","vscode")>] commands =
        static member registerCommand(command: string, callback: Func<obj, obj>, ?thisArg: obj): Disposable = failwith "JS only"
        static member registerCommand(command: string, callback: Func<obj, obj, obj>, ?thisArg: obj): Disposable = failwith "JS only"
        static member registerCommand(command: string, callback: Func<obj, obj, obj, obj>, ?thisArg: obj): Disposable = failwith "JS only"
        static member registerTextEditorCommand(command: string, callback: Func<TextEditor, TextEditorEdit, unit>, ?thisArg: obj): Disposable = failwith "JS only"
        static member executeCommand(command: string, [<ParamArray>] rest: obj[]): Promise<'T> = failwith "JS only"
        static member getCommands(?filterInternal: bool): Promise<ResizeArray<string>> = failwith "JS only"

    type [<Import("debug", "vscode")>] debug =
        static member activeDebugSession with get() : DebugSession = failwith "JS only"
        static member onDidChangeActiveDebugSession with get() : Event<DebugSession> = failwith "JS only"
        static member onDidReceiveDebugSessionCustomEvent with get() : Event<DebugSessionCustomEvent> = failwith "JS only"
        static member onDidTerminateDebugSession with get() : Event<DebugSession> = failwith "JS only"
        static member onDidStartDebugSession with get() : Event<DebugSession> = failwith "JS only"
        static member startDebugging(folder: WorkspaceFolder,  nameOrConfiguration: U2<string, obj>) : Promise<bool>= failwith "JS only"

    type [<Import("window","vscode")>] window =
        static member activeTextEditor with get(): TextEditor = failwith "JS only" and set(v: TextEditor): unit = failwith "JS only"
        static member visibleTextEditors with get(): ResizeArray<TextEditor> = failwith "JS only" and set(v: ResizeArray<TextEditor>): unit = failwith "JS only"
        static member onDidChangeActiveTextEditor with get(): Event<TextEditor> = failwith "JS only" and set(v: Event<TextEditor>): unit = failwith "JS only"
        static member onDidChangeVisibleTextEditors with get(): Event<ResizeArray<TextEditor>> = failwith "JS only" and set(v: Event<ResizeArray<TextEditor>>): unit = failwith "JS only"
        static member onDidChangeTextEditorSelection with get(): Event<TextEditorSelectionChangeEvent> = failwith "JS only" and set(v: Event<TextEditorSelectionChangeEvent>): unit = failwith "JS only"
        static member onDidChangeTextEditorOptions with get(): Event<TextEditorOptionsChangeEvent> = failwith "JS only" and set(v: Event<TextEditorOptionsChangeEvent>): unit = failwith "JS only"
        static member showTextDocument(document: TextDocument, ?column: ViewColumn): Promise<TextEditor> = failwith "JS only"
        static member createTextEditorDecorationType(options: DecorationRenderOptions): TextEditorDecorationType = failwith "JS only"
        static member showInformationMessage(message: string, [<ParamArray>] items: string[]): Promise<string> = failwith "JS only"
        static member showInformationMessage(message: string, [<ParamArray>] items: 'T[]): Promise<'T> = failwith "JS only"
        static member showWarningMessage(message: string, [<ParamArray>] items: string[]): Promise<string> = failwith "JS only"
        static member showWarningMessage(message: string, [<ParamArray>] items: 'T[]): Promise<'T> = failwith "JS only"
        static member showErrorMessage(message: string, [<ParamArray>] items: string[]): Promise<string> = failwith "JS only"
        static member showErrorMessage(message: string, [<ParamArray>] items: 'T[]): Promise<'T> = failwith "JS only"
        static member showQuickPick(items: U2<ResizeArray<string>, Promise<ResizeArray<string>>>, ?options: QuickPickOptions): Promise<string> = failwith "JS only"
        static member showQuickPick(items: U2<ResizeArray<'T>, Promise<ResizeArray<'T>>>, ?options: QuickPickOptions): Promise<'T> = failwith "JS only"
        static member showInputBox(?options: InputBoxOptions): Promise<string> = failwith "JS only"
        static member createOutputChannel(name: string): OutputChannel = failwith "JS only"
        static member setStatusBarMessage(text: string): Disposable = failwith "JS only"
        static member setStatusBarMessage(text: string, hideAfterTimeout: float): Disposable = failwith "JS only"
        static member setStatusBarMessage(text: string, hideWhenDone: Promise<obj>): Disposable = failwith "JS only"
        static member createStatusBarItem(?alignment: StatusBarAlignment, ?priority: float): StatusBarItem = failwith "JS only"
        static member createTerminal(?name : string, ?shellPath : string, ?shellArgs : string[]) : Terminal = failwith "JS only"
        static member onDidCloseTerminal with get(): Event<Terminal> = failwith "JS only"
        static member registerTreeDataProvider<'T>(viewId: string, provider: TreeDataProvider<'T>): Disposable = failwith "JS only"
        static member createTreeView<'T>(viewId: string, options: CreateTreeViewOptions<'T>): TreeView<'T> = failwith "JS only"
        static member withProgress(options : ProgressOptions, func: Progress<ProgressMessage> -> Promise<'T> ) : Promise<'T> = failwith "JS only"
        static member showOpenDialog(options: OpenDialogOptions) : Promise<Uri[]> = failwith "JS only"
        static member showSaveDialog(options : SaveDialogOptions) : Promise<Uri> = failwith "JS only"

    type ConfigurationChangeEvent =
        /// Returns `true` if the given section for the given resource (if provided) is affected.
        member __.affectsConfiguration(section: string, ?resource: Uri) : bool = failwith "JS only"

    type [<Import("workspace","vscode")>] workspace =
        static member rootPath with get(): string = failwith "JS only" and set(v: string): unit = failwith "JS only"
        static member workspaceFolders with get(): WorkspaceFolder[] = failwith "JS only"
        static member textDocuments with get(): ResizeArray<TextDocument> = failwith "JS only" and set(v: ResizeArray<TextDocument>): unit = failwith "JS only"
        static member onDidOpenTextDocument with get(): Event<TextDocument> = failwith "JS only" and set(v: Event<TextDocument>): unit = failwith "JS only"
        static member onDidCloseTextDocument with get(): Event<TextDocument> = failwith "JS only" and set(v: Event<TextDocument>): unit = failwith "JS only"
        static member onDidChangeTextDocument with get(): Event<TextDocumentChangeEvent> = failwith "JS only" and set(v: Event<TextDocumentChangeEvent>): unit = failwith "JS only"
        static member onDidSaveTextDocument with get(): Event<TextDocument> = failwith "JS only" and set(v: Event<TextDocument>): unit = failwith "JS only"
        static member onDidChangeConfiguration with get(): Event<ConfigurationChangeEvent> = failwith "JS only" and set(v: Event<ConfigurationChangeEvent>): unit = failwith "JS only"
        static member createFileSystemWatcher(globPattern: string, ?ignoreCreateEvents: bool, ?ignoreChangeEvents: bool, ?ignoreDeleteEvents: bool): FileSystemWatcher = failwith "JS only"
        static member asRelativePath(pathOrUri: U2<string, Uri>): string = failwith "JS only"
        static member findFiles(``include``: string, exclude: string, ?maxResults: float): Promise<ResizeArray<Uri>> = failwith "JS only"
        static member saveAll(?includeUntitled: bool): Promise<bool> = failwith "JS only"
        static member applyEdit(edit: WorkspaceEdit): Promise<bool> = failwith "JS only"
        static member openTextDocument(uri: Uri): Promise<TextDocument> = failwith "JS only"
        static member openTextDocument(fileName: string): Promise<TextDocument> = failwith "JS only"
        static member getConfiguration(?section: string, ?resource: Uri): WorkspaceConfiguration = failwith "JS only"
        static member registerTextDocumentContentProvider(selector : DocumentSelector, provider : TextDocumentContentProvider ) : Disposable = failwith "JS only"

    type [<Import("languages","vscode")>] languages =
        static member getLanguages(): Promise<ResizeArray<string>> = failwith "JS only"
        static member ``match``(selector: DocumentSelector, document: TextDocument): float = failwith "JS only"
        static member createDiagnosticCollection(?name: string): DiagnosticCollection = failwith "JS only"
        static member registerCompletionItemProvider(selector: DocumentSelector, provider: CompletionItemProvider, [<ParamArray>] triggerCharacters: string[]): Disposable = failwith "JS only"
        static member registerCodeActionsProvider(selector: DocumentSelector, provider: CodeActionProvider): Disposable = failwith "JS only"
        static member registerCodeLensProvider(selector: DocumentSelector, provider: CodeLensProvider): Disposable = failwith "JS only"
        static member registerDefinitionProvider(selector: DocumentSelector, provider: DefinitionProvider): Disposable = failwith "JS only"
        static member registerTypeDefinitionProvider(selector: DocumentSelector, provider: TypeDefinitionProvider): Disposable = failwith "JS only"
        static member registerHoverProvider(selector: DocumentSelector, provider: HoverProvider): Disposable = failwith "JS only"
        static member registerDocumentHighlightProvider(selector: DocumentSelector, provider: DocumentHighlightProvider): Disposable = failwith "JS only"
        static member registerDocumentSymbolProvider(selector: DocumentSelector, provider: DocumentSymbolProvider): Disposable = failwith "JS only"
        static member registerWorkspaceSymbolProvider(provider: WorkspaceSymbolProvider): Disposable = failwith "JS only"
        static member registerReferenceProvider(selector: DocumentSelector, provider: ReferenceProvider): Disposable = failwith "JS only"
        static member registerRenameProvider(selector: DocumentSelector, provider: RenameProvider): Disposable = failwith "JS only"
        static member registerDocumentFormattingEditProvider(selector: DocumentSelector, provider: DocumentFormattingEditProvider): Disposable = failwith "JS only"
        static member registerDocumentRangeFormattingEditProvider(selector: DocumentSelector, provider: DocumentRangeFormattingEditProvider): Disposable = failwith "JS only"
        static member registerOnTypeFormattingEditProvider(selector: DocumentSelector, provider: OnTypeFormattingEditProvider, firstTriggerCharacter: string, [<ParamArray>] moreTriggerCharacter: string[]): Disposable = failwith "JS only"
        static member registerSignatureHelpProvider(selector: DocumentSelector, provider: SignatureHelpProvider, [<ParamArray>] triggerCharacters: string[]): Disposable = failwith "JS only"
        static member registerDocumentLinkProvider(selector : DocumentSelector, provider : DocumentLinkProvider) : Disposable = failwith "JS only"
        static member setLanguageConfiguration(language: string, configuration: LanguageConfiguration): Disposable = failwith "JS only"

    type [<Import("extensions","vscode")>] extensions =
        static member all with get(): ResizeArray<Extension<obj>> = failwith "JS only" and set(v: ResizeArray<Extension<obj>>): unit = failwith "JS only"
        static member getExtension(extensionId: string): Extension<obj> = failwith "JS only"
        static member getExtension(extensionId: string): Extension<'T> = failwith "JS only"
