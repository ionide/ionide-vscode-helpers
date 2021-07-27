// ts2fable 0.7.1
module rec Fable.Import.VSCode
open System
open Fable.Core
open Fable.Core.JS

type Array<'T> = System.Collections.Generic.IList<'T>
type Error = System.Exception
type Function = System.Action
type ReadonlyArray<'T> = System.Collections.Generic.IReadOnlyList<'T>
type RegExp = System.Text.RegularExpressions.Regex

let [<Import("*","vscode")>] vscode: Vscode.IExports = jsNative

module Vscode =
    let [<Import("tasks","vscode")>] tasks: Tasks.IExports = jsNative
    let [<Import("env","vscode")>] env: Env.IExports = jsNative
    let [<Import("commands","vscode")>] commands: Commands.IExports = jsNative
    let [<Import("window","vscode")>] window: Window.IExports = jsNative
    let [<Import("workspace","vscode")>] workspace: Workspace.IExports = jsNative
    let [<Import("languages","vscode")>] languages: Languages.IExports = jsNative
    let [<Import("notebooks","vscode")>] notebooks: Notebooks.IExports = jsNative
    let [<Import("scm","vscode")>] scm: Scm.IExports = jsNative
    let [<Import("debug","vscode")>] debug: Debug.IExports = jsNative
    let [<Import("extensions","vscode")>] extensions: Extensions.IExports = jsNative
    let [<Import("comments","vscode")>] comments: Comments.IExports = jsNative
    let [<Import("authentication","vscode")>] authentication: Authentication.IExports = jsNative

    type [<AllowNullLiteral>] IExports =
        abstract version: string
        abstract Position: PositionStatic
        abstract Range: RangeStatic
        abstract Selection: SelectionStatic
        abstract ThemeColor: ThemeColorStatic
        abstract ThemeIcon: ThemeIconStatic
        abstract Uri: UriStatic
        abstract CancellationTokenSource: CancellationTokenSourceStatic
        abstract CancellationError: CancellationErrorStatic
        abstract Disposable: DisposableStatic
        abstract EventEmitter: EventEmitterStatic
        abstract RelativePattern: RelativePatternStatic
        abstract CodeActionKind: CodeActionKindStatic
        abstract CodeAction: CodeActionStatic
        abstract CodeLens: CodeLensStatic
        abstract MarkdownString: MarkdownStringStatic
        abstract Hover: HoverStatic
        abstract EvaluatableExpression: EvaluatableExpressionStatic
        abstract InlineValueText: InlineValueTextStatic
        abstract InlineValueVariableLookup: InlineValueVariableLookupStatic
        abstract InlineValueEvaluatableExpression: InlineValueEvaluatableExpressionStatic
        abstract DocumentHighlight: DocumentHighlightStatic
        abstract SymbolInformation: SymbolInformationStatic
        abstract DocumentSymbol: DocumentSymbolStatic
        abstract TextEdit: TextEditStatic
        abstract WorkspaceEdit: WorkspaceEditStatic
        abstract SnippetString: SnippetStringStatic
        abstract SemanticTokensLegend: SemanticTokensLegendStatic
        abstract SemanticTokensBuilder: SemanticTokensBuilderStatic
        abstract SemanticTokens: SemanticTokensStatic
        abstract SemanticTokensEdits: SemanticTokensEditsStatic
        abstract SemanticTokensEdit: SemanticTokensEditStatic
        abstract ParameterInformation: ParameterInformationStatic
        abstract SignatureInformation: SignatureInformationStatic
        abstract SignatureHelp: SignatureHelpStatic
        abstract CompletionItem: CompletionItemStatic
        abstract CompletionList: CompletionListStatic
        abstract DocumentLink: DocumentLinkStatic
        abstract Color: ColorStatic
        abstract ColorInformation: ColorInformationStatic
        abstract ColorPresentation: ColorPresentationStatic
        abstract FoldingRange: FoldingRangeStatic
        abstract SelectionRange: SelectionRangeStatic
        abstract CallHierarchyItem: CallHierarchyItemStatic
        abstract CallHierarchyIncomingCall: CallHierarchyIncomingCallStatic
        abstract CallHierarchyOutgoingCall: CallHierarchyOutgoingCallStatic
        abstract LinkedEditingRanges: LinkedEditingRangesStatic
        abstract Location: LocationStatic
        abstract DiagnosticRelatedInformation: DiagnosticRelatedInformationStatic
        abstract Diagnostic: DiagnosticStatic
        abstract TerminalLink: TerminalLinkStatic
        abstract TerminalProfile: TerminalProfileStatic
        abstract FileDecoration: FileDecorationStatic
        abstract TaskGroup: TaskGroupStatic
        abstract ProcessExecution: ProcessExecutionStatic
        abstract ShellExecution: ShellExecutionStatic
        abstract CustomExecution: CustomExecutionStatic
        abstract Task: TaskStatic
        abstract FileSystemError: FileSystemErrorStatic
        abstract TreeItem: TreeItemStatic
        abstract QuickInputButtons: QuickInputButtonsStatic
        abstract NotebookRange: NotebookRangeStatic
        abstract NotebookCellOutputItem: NotebookCellOutputItemStatic
        abstract NotebookCellOutput: NotebookCellOutputStatic
        abstract NotebookCellData: NotebookCellDataStatic
        abstract NotebookData: NotebookDataStatic
        abstract NotebookCellStatusBarItem: NotebookCellStatusBarItemStatic
        abstract DebugAdapterExecutable: DebugAdapterExecutableStatic
        abstract DebugAdapterServer: DebugAdapterServerStatic
        abstract DebugAdapterNamedPipeServer: DebugAdapterNamedPipeServerStatic
        abstract DebugAdapterInlineImplementation: DebugAdapterInlineImplementationStatic
        abstract Breakpoint: BreakpointStatic
        abstract SourceBreakpoint: SourceBreakpointStatic
        abstract FunctionBreakpoint: FunctionBreakpointStatic

    /// Represents a reference to a command. Provides a title which
    /// will be used to represent a command in the UI and, optionally,
    /// an array of arguments which will be passed to the command handler
    /// function when invoked.
    type [<AllowNullLiteral>] Command =
        /// Title of the command, like `save`.
        abstract title: string with get, set
        /// The identifier of the actual command handler.
        abstract command: string with get, set
        /// A tooltip for the command, when represented in the UI.
        abstract tooltip: string option with get, set
        /// Arguments that the command handler should be
        /// invoked with.
        abstract arguments: ResizeArray<obj option> option with get, set

    /// Represents a line of text, such as a line of source code.
    /// 
    /// TextLine objects are __immutable__. When a {@link TextDocument document} changes,
    /// previously retrieved lines will not represent the latest state.
    type [<AllowNullLiteral>] TextLine =
        /// The zero-based line number.
        abstract lineNumber: float
        /// The text of this line without the line separator characters.
        abstract text: string
        /// The range this line covers without the line separator characters.
        abstract range: Range
        /// The range this line covers with the line separator characters.
        abstract rangeIncludingLineBreak: Range
        /// The offset of the first character which is not a whitespace character as defined
        /// by `/\s/`. **Note** that if a line is all whitespace the length of the line is returned.
        abstract firstNonWhitespaceCharacterIndex: float
        /// Whether this line is whitespace only, shorthand
        /// for {@link TextLine.firstNonWhitespaceCharacterIndex} === {@link TextLine.text TextLine.text.length}.
        abstract isEmptyOrWhitespace: bool

    /// Represents a text document, such as a source file. Text documents have
    /// {@link TextLine lines} and knowledge about an underlying resource like a file.
    type [<AllowNullLiteral>] TextDocument =
        /// The associated uri for this document.
        /// 
        /// *Note* that most documents use the `file`-scheme, which means they are files on disk. However, **not** all documents are
        /// saved on disk and therefore the `scheme` must be checked before trying to access the underlying file or siblings on disk.
        abstract uri: Uri
        /// The file system path of the associated resource. Shorthand
        /// notation for {@link TextDocument.uri TextDocument.uri.fsPath}. Independent of the uri scheme.
        abstract fileName: string
        /// Is this document representing an untitled file which has never been saved yet. *Note* that
        /// this does not mean the document will be saved to disk, use {@link Uri.scheme `uri.scheme`}
        /// to figure out where a document will be {@link FileSystemProvider saved}, e.g. `file`, `ftp` etc.
        abstract isUntitled: bool
        /// The identifier of the language associated with this document.
        abstract languageId: string
        /// The version number of this document (it will strictly increase after each
        /// change, including undo/redo).
        abstract version: float
        /// `true` if there are unpersisted changes.
        abstract isDirty: bool
        /// `true` if the document has been closed. A closed document isn't synchronized anymore
        /// and won't be re-used when the same resource is opened again.
        abstract isClosed: bool
        /// Save the underlying file.
        abstract save: unit -> Thenable<bool>
        /// The {@link EndOfLine end of line} sequence that is predominately
        /// used in this document.
        abstract eol: EndOfLine
        /// The number of lines in this document.
        abstract lineCount: float
        /// <summary>Returns a text line denoted by the line number. Note
        /// that the returned object is *not* live and changes to the
        /// document are not reflected.</summary>
        /// <param name="line">A line number in [0, lineCount).</param>
        abstract lineAt: line: float -> TextLine
        /// <summary>Returns a text line denoted by the position. Note
        /// that the returned object is *not* live and changes to the
        /// document are not reflected.
        /// 
        /// The position will be {@link TextDocument.validatePosition adjusted}.</summary>
        /// <param name="position">A position.</param>
        abstract lineAt: position: Position -> TextLine
        /// <summary>Converts the position to a zero-based offset.
        /// 
        /// The position will be {@link TextDocument.validatePosition adjusted}.</summary>
        /// <param name="position">A position.</param>
        abstract offsetAt: position: Position -> float
        /// <summary>Converts a zero-based offset to a position.</summary>
        /// <param name="offset">A zero-based offset.</param>
        abstract positionAt: offset: float -> Position
        /// <summary>Get the text of this document. A substring can be retrieved by providing
        /// a range. The range will be {@link TextDocument.validateRange adjusted}.</summary>
        /// <param name="range">Include only the text included by the range.</param>
        abstract getText: ?range: Range -> string
        /// <summary>Get a word-range at the given position. By default words are defined by
        /// common separators, like space, -, _, etc. In addition, per language custom
        /// [word definitions} can be defined. It
        /// is also possible to provide a custom regular expression.
        /// 
        /// * *Note 1:* A custom regular expression must not match the empty string and
        /// if it does, it will be ignored.
        /// * *Note 2:* A custom regular expression will fail to match multiline strings
        /// and in the name of speed regular expressions should not match words with
        /// spaces. Use {@link TextLine.text `TextLine.text`} for more complex, non-wordy, scenarios.
        /// 
        /// The position will be {@link TextDocument.validatePosition adjusted}.</summary>
        /// <param name="position">A position.</param>
        /// <param name="regex">Optional regular expression that describes what a word is.</param>
        abstract getWordRangeAtPosition: position: Position * ?regex: RegExp -> Range option
        /// <summary>Ensure a range is completely contained in this document.</summary>
        /// <param name="range">A range.</param>
        abstract validateRange: range: Range -> Range
        /// <summary>Ensure a position is contained in the range of this document.</summary>
        /// <param name="position">A position.</param>
        abstract validatePosition: position: Position -> Position

    /// Represents a line and character position, such as
    /// the position of the cursor.
    /// 
    /// Position objects are __immutable__. Use the {@link Position.with with} or
    /// {@link Position.translate translate} methods to derive new positions
    /// from an existing position.
    type [<AllowNullLiteral>] Position =
        /// The zero-based line value.
        abstract line: float
        /// The zero-based character value.
        abstract character: float
        /// <summary>Check if this position is before `other`.</summary>
        /// <param name="other">A position.</param>
        abstract isBefore: other: Position -> bool
        /// <summary>Check if this position is before or equal to `other`.</summary>
        /// <param name="other">A position.</param>
        abstract isBeforeOrEqual: other: Position -> bool
        /// <summary>Check if this position is after `other`.</summary>
        /// <param name="other">A position.</param>
        abstract isAfter: other: Position -> bool
        /// <summary>Check if this position is after or equal to `other`.</summary>
        /// <param name="other">A position.</param>
        abstract isAfterOrEqual: other: Position -> bool
        /// <summary>Check if this position is equal to `other`.</summary>
        /// <param name="other">A position.</param>
        abstract isEqual: other: Position -> bool
        /// <summary>Compare this to `other`.</summary>
        /// <param name="other">A position.</param>
        abstract compareTo: other: Position -> float
        /// <summary>Create a new position relative to this position.</summary>
        /// <param name="lineDelta">Delta value for the line value, default is `0`.</param>
        /// <param name="characterDelta">Delta value for the character value, default is `0`.</param>
        abstract translate: ?lineDelta: float * ?characterDelta: float -> Position
        /// <summary>Derived a new position relative to this position.</summary>
        /// <param name="change">An object that describes a delta to this position.</param>
        abstract translate: change: PositionTranslateChange -> Position
        /// <summary>Create a new position derived from this position.</summary>
        /// <param name="line">Value that should be used as line value, default is the {@link Position.line existing value}</param>
        /// <param name="character">Value that should be used as character value, default is the {@link Position.character existing value}</param>
        abstract ``with``: ?line: float * ?character: float -> Position
        /// <summary>Derived a new position from this position.</summary>
        /// <param name="change">An object that describes a change to this position.</param>
        abstract ``with``: change: PositionWithChange -> Position

    type [<AllowNullLiteral>] PositionTranslateChange =
        abstract lineDelta: float option with get, set
        abstract characterDelta: float option with get, set

    type [<AllowNullLiteral>] PositionWithChange =
        abstract line: float option with get, set
        abstract character: float option with get, set

    /// Represents a line and character position, such as
    /// the position of the cursor.
    /// 
    /// Position objects are __immutable__. Use the {@link Position.with with} or
    /// {@link Position.translate translate} methods to derive new positions
    /// from an existing position.
    type [<AllowNullLiteral>] PositionStatic =
        /// <param name="line">A zero-based line value.</param>
        /// <param name="character">A zero-based character value.</param>
        [<Emit "new $0($1...)">] abstract Create: line: float * character: float -> Position

    /// A range represents an ordered pair of two positions.
    /// It is guaranteed that {@link Range.start start}.isBeforeOrEqual({@link Range.end end})
    /// 
    /// Range objects are __immutable__. Use the {@link Range.with with},
    /// {@link Range.intersection intersection}, or {@link Range.union union} methods
    /// to derive new ranges from an existing range.
    type [<AllowNullLiteral>] Range =
        /// The start position. It is before or equal to {@link Range.end end}.
        abstract start: Position
        /// The end position. It is after or equal to {@link Range.start start}.
        abstract ``end``: Position
        /// `true` if `start` and `end` are equal.
        abstract isEmpty: bool with get, set
        /// `true` if `start.line` and `end.line` are equal.
        abstract isSingleLine: bool with get, set
        /// <summary>Check if a position or a range is contained in this range.</summary>
        /// <param name="positionOrRange">A position or a range.</param>
        abstract contains: positionOrRange: U2<Position, Range> -> bool
        /// <summary>Check if `other` equals this range.</summary>
        /// <param name="other">A range.</param>
        abstract isEqual: other: Range -> bool
        /// <summary>Intersect `range` with this range and returns a new range or `undefined`
        /// if the ranges have no overlap.</summary>
        /// <param name="range">A range.</param>
        abstract intersection: range: Range -> Range option
        /// <summary>Compute the union of `other` with this range.</summary>
        /// <param name="other">A range.</param>
        abstract union: other: Range -> Range
        /// <summary>Derived a new range from this range.</summary>
        /// <param name="start">A position that should be used as start. The default value is the {@link Range.start current start}.</param>
        /// <param name="end">A position that should be used as end. The default value is the {@link Range.end current end}.</param>
        abstract ``with``: ?start: Position * ?``end``: Position -> Range
        /// <summary>Derived a new range from this range.</summary>
        /// <param name="change">An object that describes a change to this range.</param>
        abstract ``with``: change: RangeWithChange -> Range

    type [<AllowNullLiteral>] RangeWithChange =
        abstract start: Position option with get, set
        abstract ``end``: Position option with get, set

    /// A range represents an ordered pair of two positions.
    /// It is guaranteed that {@link Range.start start}.isBeforeOrEqual({@link Range.end end})
    /// 
    /// Range objects are __immutable__. Use the {@link Range.with with},
    /// {@link Range.intersection intersection}, or {@link Range.union union} methods
    /// to derive new ranges from an existing range.
    type [<AllowNullLiteral>] RangeStatic =
        /// <summary>Create a new range from two positions. If `start` is not
        /// before or equal to `end`, the values will be swapped.</summary>
        /// <param name="start">A position.</param>
        /// <param name="end">A position.</param>
        [<Emit "new $0($1...)">] abstract Create: start: Position * ``end``: Position -> Range
        /// <summary>Create a new range from number coordinates. It is a shorter equivalent of
        /// using `new Range(new Position(startLine, startCharacter), new Position(endLine, endCharacter))`</summary>
        /// <param name="startLine">A zero-based line value.</param>
        /// <param name="startCharacter">A zero-based character value.</param>
        /// <param name="endLine">A zero-based line value.</param>
        /// <param name="endCharacter">A zero-based character value.</param>
        [<Emit "new $0($1...)">] abstract Create: startLine: float * startCharacter: float * endLine: float * endCharacter: float -> Range

    /// Represents a text selection in an editor.
    type [<AllowNullLiteral>] Selection =
        inherit Range
        /// The position at which the selection starts.
        /// This position might be before or after {@link Selection.active active}.
        abstract anchor: Position with get, set
        /// The position of the cursor.
        /// This position might be before or after {@link Selection.anchor anchor}.
        abstract active: Position with get, set
        /// A selection is reversed if {@link Selection.active active}.isBefore({@link Selection.anchor anchor}).
        abstract isReversed: bool with get, set

    /// Represents a text selection in an editor.
    type [<AllowNullLiteral>] SelectionStatic =
        /// <summary>Create a selection from two positions.</summary>
        /// <param name="anchor">A position.</param>
        /// <param name="active">A position.</param>
        [<Emit "new $0($1...)">] abstract Create: anchor: Position * active: Position -> Selection
        /// <summary>Create a selection from four coordinates.</summary>
        /// <param name="anchorLine">A zero-based line value.</param>
        /// <param name="anchorCharacter">A zero-based character value.</param>
        /// <param name="activeLine">A zero-based line value.</param>
        /// <param name="activeCharacter">A zero-based character value.</param>
        [<Emit "new $0($1...)">] abstract Create: anchorLine: float * anchorCharacter: float * activeLine: float * activeCharacter: float -> Selection

    type [<RequireQualifiedAccess>] TextEditorSelectionChangeKind =
        | Keyboard = 1
        | Mouse = 2
        | Command = 3

    /// Represents an event describing the change in a {@link TextEditor.selections text editor's selections}.
    type [<AllowNullLiteral>] TextEditorSelectionChangeEvent =
        /// The {@link TextEditor text editor} for which the selections have changed.
        abstract textEditor: TextEditor
        /// The new value for the {@link TextEditor.selections text editor's selections}.
        abstract selections: ResizeArray<Selection>
        /// The {@link TextEditorSelectionChangeKind change kind} which has triggered this
        /// event. Can be `undefined`.
        abstract kind: TextEditorSelectionChangeKind option

    /// Represents an event describing the change in a {@link TextEditor.visibleRanges text editor's visible ranges}.
    type [<AllowNullLiteral>] TextEditorVisibleRangesChangeEvent =
        /// The {@link TextEditor text editor} for which the visible ranges have changed.
        abstract textEditor: TextEditor
        /// The new value for the {@link TextEditor.visibleRanges text editor's visible ranges}.
        abstract visibleRanges: ResizeArray<Range>

    /// Represents an event describing the change in a {@link TextEditor.options text editor's options}.
    type [<AllowNullLiteral>] TextEditorOptionsChangeEvent =
        /// The {@link TextEditor text editor} for which the options have changed.
        abstract textEditor: TextEditor
        /// The new value for the {@link TextEditor.options text editor's options}.
        abstract options: TextEditorOptions

    /// Represents an event describing the change of a {@link TextEditor.viewColumn text editor's view column}.
    type [<AllowNullLiteral>] TextEditorViewColumnChangeEvent =
        /// The {@link TextEditor text editor} for which the view column has changed.
        abstract textEditor: TextEditor
        /// The new value for the {@link TextEditor.viewColumn text editor's view column}.
        abstract viewColumn: ViewColumn

    type [<RequireQualifiedAccess>] TextEditorCursorStyle =
        | Line = 1
        | Block = 2
        | Underline = 3
        | LineThin = 4
        | BlockOutline = 5
        | UnderlineThin = 6

    type [<RequireQualifiedAccess>] TextEditorLineNumbersStyle =
        | Off = 0
        | On = 1
        | Relative = 2

    /// Represents a {@link TextEditor text editor}'s {@link TextEditor.options options}.
    type [<AllowNullLiteral>] TextEditorOptions =
        /// The size in spaces a tab takes. This is used for two purposes:
        ///   - the rendering width of a tab character;
        ///   - the number of spaces to insert when {@link TextEditorOptions.insertSpaces insertSpaces} is true.
        /// 
        /// When getting a text editor's options, this property will always be a number (resolved).
        /// When setting a text editor's options, this property is optional and it can be a number or `"auto"`.
        abstract tabSize: U2<float, string> option with get, set
        /// When pressing Tab insert {@link TextEditorOptions.tabSize n} spaces.
        /// When getting a text editor's options, this property will always be a boolean (resolved).
        /// When setting a text editor's options, this property is optional and it can be a boolean or `"auto"`.
        abstract insertSpaces: U2<bool, string> option with get, set
        /// The rendering style of the cursor in this editor.
        /// When getting a text editor's options, this property will always be present.
        /// When setting a text editor's options, this property is optional.
        abstract cursorStyle: TextEditorCursorStyle option with get, set
        /// Render relative line numbers w.r.t. the current line number.
        /// When getting a text editor's options, this property will always be present.
        /// When setting a text editor's options, this property is optional.
        abstract lineNumbers: TextEditorLineNumbersStyle option with get, set

    /// Represents a handle to a set of decorations
    /// sharing the same {@link DecorationRenderOptions styling options} in a {@link TextEditor text editor}.
    /// 
    /// To get an instance of a `TextEditorDecorationType` use
    /// {@link window.createTextEditorDecorationType createTextEditorDecorationType}.
    type [<AllowNullLiteral>] TextEditorDecorationType =
        /// Internal representation of the handle.
        abstract key: string
        /// Remove this decoration type and all decorations on all text editors using it.
        abstract dispose: unit -> unit

    type [<RequireQualifiedAccess>] TextEditorRevealType =
        | Default = 0
        | InCenter = 1
        | InCenterIfOutsideViewport = 2
        | AtTop = 3

    type [<RequireQualifiedAccess>] OverviewRulerLane =
        | Left = 1
        | Center = 2
        | Right = 4
        | Full = 7

    type [<RequireQualifiedAccess>] DecorationRangeBehavior =
        | OpenOpen = 0
        | ClosedClosed = 1
        | OpenClosed = 2
        | ClosedOpen = 3

    /// Represents options to configure the behavior of showing a {@link TextDocument document} in an {@link TextEditor editor}.
    type [<AllowNullLiteral>] TextDocumentShowOptions =
        /// An optional view column in which the {@link TextEditor editor} should be shown.
        /// The default is the {@link ViewColumn.Active active}, other values are adjusted to
        /// be `Min(column, columnCount + 1)`, the {@link ViewColumn.Active active}-column is
        /// not adjusted. Use {@link ViewColumn.Beside `ViewColumn.Beside`} to open the
        /// editor to the side of the currently active one.
        abstract viewColumn: ViewColumn option with get, set
        /// An optional flag that when `true` will stop the {@link TextEditor editor} from taking focus.
        abstract preserveFocus: bool option with get, set
        /// An optional flag that controls if an {@link TextEditor editor}-tab will be replaced
        /// with the next editor or if it will be kept.
        abstract preview: bool option with get, set
        /// An optional selection to apply for the document in the {@link TextEditor editor}.
        abstract selection: Range option with get, set

    /// A reference to one of the workbench colors as defined in https://code.visualstudio.com/docs/getstarted/theme-color-reference.
    /// Using a theme color is preferred over a custom color as it gives theme authors and users the possibility to change the color.
    type [<AllowNullLiteral>] ThemeColor =
        interface end

    /// A reference to one of the workbench colors as defined in https://code.visualstudio.com/docs/getstarted/theme-color-reference.
    /// Using a theme color is preferred over a custom color as it gives theme authors and users the possibility to change the color.
    type [<AllowNullLiteral>] ThemeColorStatic =
        /// <summary>Creates a reference to a theme color.</summary>
        /// <param name="id">of the color. The available colors are listed in https://code.visualstudio.com/docs/getstarted/theme-color-reference.</param>
        [<Emit "new $0($1...)">] abstract Create: id: string -> ThemeColor

    /// A reference to a named icon. Currently, {@link ThemeIcon.File File}, {@link ThemeIcon.Folder Folder},
    /// and [ThemeIcon ids](https://code.visualstudio.com/api/references/icons-in-labels#icon-listing) are supported.
    /// Using a theme icon is preferred over a custom icon as it gives product theme authors the possibility to change the icons.
    /// 
    /// *Note* that theme icons can also be rendered inside labels and descriptions. Places that support theme icons spell this out
    /// and they use the `$(<name>)`-syntax, for instance `quickPick.label = "Hello World $(globe)"`.
    type [<AllowNullLiteral>] ThemeIcon =
        /// The id of the icon. The available icons are listed in https://code.visualstudio.com/api/references/icons-in-labels#icon-listing.
        abstract id: string
        /// The optional ThemeColor of the icon. The color is currently only used in {@link TreeItem}.
        abstract color: ThemeColor option

    /// A reference to a named icon. Currently, {@link ThemeIcon.File File}, {@link ThemeIcon.Folder Folder},
    /// and [ThemeIcon ids](https://code.visualstudio.com/api/references/icons-in-labels#icon-listing) are supported.
    /// Using a theme icon is preferred over a custom icon as it gives product theme authors the possibility to change the icons.
    /// 
    /// *Note* that theme icons can also be rendered inside labels and descriptions. Places that support theme icons spell this out
    /// and they use the `$(<name>)`-syntax, for instance `quickPick.label = "Hello World $(globe)"`.
    type [<AllowNullLiteral>] ThemeIconStatic =
        /// Reference to an icon representing a file. The icon is taken from the current file icon theme or a placeholder icon is used.
        abstract File: ThemeIcon
        /// Reference to an icon representing a folder. The icon is taken from the current file icon theme or a placeholder icon is used.
        abstract Folder: ThemeIcon
        /// <summary>Creates a reference to a theme icon.</summary>
        /// <param name="id">id of the icon. The available icons are listed in https://code.visualstudio.com/api/references/icons-in-labels#icon-listing.</param>
        /// <param name="color">optional `ThemeColor` for the icon. The color is currently only used in {@link TreeItem}.</param>
        [<Emit "new $0($1...)">] abstract Create: id: string * ?color: ThemeColor -> ThemeIcon

    /// Represents theme specific rendering styles for a {@link TextEditorDecorationType text editor decoration}.
    type [<AllowNullLiteral>] ThemableDecorationRenderOptions =
        /// Background color of the decoration. Use rgba() and define transparent background colors to play well with other decorations.
        /// Alternatively a color from the color registry can be {@link ThemeColor referenced}.
        abstract backgroundColor: U2<string, ThemeColor> option with get, set
        /// CSS styling property that will be applied to text enclosed by a decoration.
        abstract outline: string option with get, set
        /// CSS styling property that will be applied to text enclosed by a decoration.
        /// Better use 'outline' for setting one or more of the individual outline properties.
        abstract outlineColor: U2<string, ThemeColor> option with get, set
        /// CSS styling property that will be applied to text enclosed by a decoration.
        /// Better use 'outline' for setting one or more of the individual outline properties.
        abstract outlineStyle: string option with get, set
        /// CSS styling property that will be applied to text enclosed by a decoration.
        /// Better use 'outline' for setting one or more of the individual outline properties.
        abstract outlineWidth: string option with get, set
        /// CSS styling property that will be applied to text enclosed by a decoration.
        abstract border: string option with get, set
        /// CSS styling property that will be applied to text enclosed by a decoration.
        /// Better use 'border' for setting one or more of the individual border properties.
        abstract borderColor: U2<string, ThemeColor> option with get, set
        /// CSS styling property that will be applied to text enclosed by a decoration.
        /// Better use 'border' for setting one or more of the individual border properties.
        abstract borderRadius: string option with get, set
        /// CSS styling property that will be applied to text enclosed by a decoration.
        /// Better use 'border' for setting one or more of the individual border properties.
        abstract borderSpacing: string option with get, set
        /// CSS styling property that will be applied to text enclosed by a decoration.
        /// Better use 'border' for setting one or more of the individual border properties.
        abstract borderStyle: string option with get, set
        /// CSS styling property that will be applied to text enclosed by a decoration.
        /// Better use 'border' for setting one or more of the individual border properties.
        abstract borderWidth: string option with get, set
        /// CSS styling property that will be applied to text enclosed by a decoration.
        abstract fontStyle: string option with get, set
        /// CSS styling property that will be applied to text enclosed by a decoration.
        abstract fontWeight: string option with get, set
        /// CSS styling property that will be applied to text enclosed by a decoration.
        abstract textDecoration: string option with get, set
        /// CSS styling property that will be applied to text enclosed by a decoration.
        abstract cursor: string option with get, set
        /// CSS styling property that will be applied to text enclosed by a decoration.
        abstract color: U2<string, ThemeColor> option with get, set
        /// CSS styling property that will be applied to text enclosed by a decoration.
        abstract opacity: string option with get, set
        /// CSS styling property that will be applied to text enclosed by a decoration.
        abstract letterSpacing: string option with get, set
        /// An **absolute path** or an URI to an image to be rendered in the gutter.
        abstract gutterIconPath: U2<string, Uri> option with get, set
        /// Specifies the size of the gutter icon.
        /// Available values are 'auto', 'contain', 'cover' and any percentage value.
        /// For further information: https://msdn.microsoft.com/en-us/library/jj127316(v=vs.85).aspx
        abstract gutterIconSize: string option with get, set
        /// The color of the decoration in the overview ruler. Use rgba() and define transparent colors to play well with other decorations.
        abstract overviewRulerColor: U2<string, ThemeColor> option with get, set
        /// Defines the rendering options of the attachment that is inserted before the decorated text.
        abstract before: ThemableDecorationAttachmentRenderOptions option with get, set
        /// Defines the rendering options of the attachment that is inserted after the decorated text.
        abstract after: ThemableDecorationAttachmentRenderOptions option with get, set

    type [<AllowNullLiteral>] ThemableDecorationAttachmentRenderOptions =
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
        abstract fontStyle: string option with get, set
        /// CSS styling property that will be applied to the decoration attachment.
        abstract fontWeight: string option with get, set
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

    /// Represents rendering styles for a {@link TextEditorDecorationType text editor decoration}.
    type [<AllowNullLiteral>] DecorationRenderOptions =
        inherit ThemableDecorationRenderOptions
        /// Should the decoration be rendered also on the whitespace after the line text.
        /// Defaults to `false`.
        abstract isWholeLine: bool option with get, set
        /// Customize the growing behavior of the decoration when edits occur at the edges of the decoration's range.
        /// Defaults to `DecorationRangeBehavior.OpenOpen`.
        abstract rangeBehavior: DecorationRangeBehavior option with get, set
        /// The position in the overview ruler where the decoration should be rendered.
        abstract overviewRulerLane: OverviewRulerLane option with get, set
        /// Overwrite options for light themes.
        abstract light: ThemableDecorationRenderOptions option with get, set
        /// Overwrite options for dark themes.
        abstract dark: ThemableDecorationRenderOptions option with get, set

    /// Represents options for a specific decoration in a {@link TextEditorDecorationType decoration set}.
    type [<AllowNullLiteral>] DecorationOptions =
        /// Range to which this decoration is applied. The range must not be empty.
        abstract range: Range with get, set
        /// A message that should be rendered when hovering over the decoration.
        abstract hoverMessage: U3<MarkdownString, MarkedString, Array<U2<MarkdownString, MarkedString>>> option with get, set
        /// Render options applied to the current decoration. For performance reasons, keep the
        /// number of decoration specific options small, and use decoration types wherever possible.
        abstract renderOptions: DecorationInstanceRenderOptions option with get, set

    type [<AllowNullLiteral>] ThemableDecorationInstanceRenderOptions =
        /// Defines the rendering options of the attachment that is inserted before the decorated text.
        abstract before: ThemableDecorationAttachmentRenderOptions option with get, set
        /// Defines the rendering options of the attachment that is inserted after the decorated text.
        abstract after: ThemableDecorationAttachmentRenderOptions option with get, set

    type [<AllowNullLiteral>] DecorationInstanceRenderOptions =
        inherit ThemableDecorationInstanceRenderOptions
        /// Overwrite options for light themes.
        abstract light: ThemableDecorationInstanceRenderOptions option with get, set
        /// Overwrite options for dark themes.
        abstract dark: ThemableDecorationInstanceRenderOptions option with get, set

    /// Represents an editor that is attached to a {@link TextDocument document}.
    type [<AllowNullLiteral>] TextEditor =
        /// The document associated with this text editor. The document will be the same for the entire lifetime of this text editor.
        abstract document: TextDocument
        /// The primary selection on this text editor. Shorthand for `TextEditor.selections[0]`.
        abstract selection: Selection with get, set
        /// The selections in this text editor. The primary selection is always at index 0.
        abstract selections: ResizeArray<Selection> with get, set
        /// The current visible ranges in the editor (vertically).
        /// This accounts only for vertical scrolling, and not for horizontal scrolling.
        abstract visibleRanges: ResizeArray<Range>
        /// Text editor options.
        abstract options: TextEditorOptions with get, set
        /// The column in which this editor shows. Will be `undefined` in case this
        /// isn't one of the main editors, e.g. an embedded editor, or when the editor
        /// column is larger than three.
        abstract viewColumn: ViewColumn option
        /// <summary>Perform an edit on the document associated with this text editor.
        /// 
        /// The given callback-function is invoked with an {@link TextEditorEdit edit-builder} which must
        /// be used to make edits. Note that the edit-builder is only valid while the
        /// callback executes.</summary>
        /// <param name="callback">A function which can create edits using an {@link TextEditorEdit edit-builder}.</param>
        /// <param name="options">The undo/redo behavior around this edit. By default, undo stops will be created before and after this edit.</param>
        abstract edit: callback: (TextEditorEdit -> unit) * ?options: TextEditorEditOptions -> Thenable<bool>
        /// <summary>Insert a {@link SnippetString snippet} and put the editor into snippet mode. "Snippet mode"
        /// means the editor adds placeholders and additional cursors so that the user can complete
        /// or accept the snippet.</summary>
        /// <param name="snippet">The snippet to insert in this edit.</param>
        /// <param name="location">Position or range at which to insert the snippet, defaults to the current editor selection or selections.</param>
        /// <param name="options">The undo/redo behavior around this edit. By default, undo stops will be created before and after this edit.</param>
        abstract insertSnippet: snippet: SnippetString * ?location: U4<Position, Range, ResizeArray<Position>, ResizeArray<Range>> * ?options: TextEditorInsertSnippetOptions -> Thenable<bool>
        /// <summary>Adds a set of decorations to the text editor. If a set of decorations already exists with
        /// the given {@link TextEditorDecorationType decoration type}, they will be replaced. If
        /// `rangesOrOptions` is empty, the existing decorations with the given {@link TextEditorDecorationType decoration type}
        /// will be removed.</summary>
        /// <param name="decorationType">A decoration type.</param>
        /// <param name="rangesOrOptions">Either {@link Range ranges} or more detailed {@link DecorationOptions options}.</param>
        abstract setDecorations: decorationType: TextEditorDecorationType * rangesOrOptions: U2<ResizeArray<Range>, ResizeArray<DecorationOptions>> -> unit
        /// <summary>Scroll as indicated by `revealType` in order to reveal the given range.</summary>
        /// <param name="range">A range.</param>
        /// <param name="revealType">The scrolling strategy for revealing `range`.</param>
        abstract revealRange: range: Range * ?revealType: TextEditorRevealType -> unit
        /// <summary>Show the text editor.</summary>
        /// <param name="column">The {@link ViewColumn column} in which to show this editor.
        /// This method shows unexpected behavior and will be removed in the next major update.</param>
        abstract show: ?column: ViewColumn -> unit
        /// Hide the text editor.
        abstract hide: unit -> unit

    type [<AllowNullLiteral>] TextEditorEditOptions =
        abstract undoStopBefore: bool with get, set
        abstract undoStopAfter: bool with get, set

    type [<AllowNullLiteral>] TextEditorInsertSnippetOptions =
        abstract undoStopBefore: bool with get, set
        abstract undoStopAfter: bool with get, set

    type [<RequireQualifiedAccess>] EndOfLine =
        | LF = 1
        | CRLF = 2

    /// A complex edit that will be applied in one transaction on a TextEditor.
    /// This holds a description of the edits and if the edits are valid (i.e. no overlapping regions, document was not changed in the meantime, etc.)
    /// they can be applied on a {@link TextDocument document} associated with a {@link TextEditor text editor}.
    type [<AllowNullLiteral>] TextEditorEdit =
        /// <summary>Replace a certain text region with a new value.
        /// You can use \r\n or \n in `value` and they will be normalized to the current {@link TextDocument document}.</summary>
        /// <param name="location">The range this operation should remove.</param>
        /// <param name="value">The new text this operation should insert after removing `location`.</param>
        abstract replace: location: U3<Position, Range, Selection> * value: string -> unit
        /// <summary>Insert text at a location.
        /// You can use \r\n or \n in `value` and they will be normalized to the current {@link TextDocument document}.
        /// Although the equivalent text edit can be made with {@link TextEditorEdit.replace replace}, `insert` will produce a different resulting selection (it will get moved).</summary>
        /// <param name="location">The position where the new text should be inserted.</param>
        /// <param name="value">The new text this operation should insert.</param>
        abstract insert: location: Position * value: string -> unit
        /// <summary>Delete a certain text region.</summary>
        /// <param name="location">The range this operation should remove.</param>
        abstract delete: location: U2<Range, Selection> -> unit
        /// <summary>Set the end of line sequence.</summary>
        /// <param name="endOfLine">The new end of line for the {@link TextDocument document}.</param>
        abstract setEndOfLine: endOfLine: EndOfLine -> unit

    /// A universal resource identifier representing either a file on disk
    /// or another resource, like untitled resources.
    type [<AllowNullLiteral>] Uri =
        /// Scheme is the `http` part of `http://www.msft.com/some/path?query#fragment`.
        /// The part before the first colon.
        abstract scheme: string
        /// Authority is the `www.msft.com` part of `http://www.msft.com/some/path?query#fragment`.
        /// The part between the first double slashes and the next slash.
        abstract authority: string
        /// Path is the `/some/path` part of `http://www.msft.com/some/path?query#fragment`.
        abstract path: string
        /// Query is the `query` part of `http://www.msft.com/some/path?query#fragment`.
        abstract query: string
        /// Fragment is the `fragment` part of `http://www.msft.com/some/path?query#fragment`.
        abstract fragment: string
        /// The string representing the corresponding file system path of this Uri.
        /// 
        /// Will handle UNC paths and normalize windows drive letters to lower-case. Also
        /// uses the platform specific path separator.
        /// 
        /// * Will *not* validate the path for invalid characters and semantics.
        /// * Will *not* look at the scheme of this Uri.
        /// * The resulting string shall *not* be used for display purposes but
        /// for disk operations, like `readFile` et al.
        /// 
        /// The *difference* to the {@link Uri.path `path`}-property is the use of the platform specific
        /// path separator and the handling of UNC paths. The sample below outlines the difference:
        /// ```ts
        /// const u = URI.parse('file://server/c$/folder/file.txt')
        /// u.authority === 'server'
        /// u.path === '/shares/c$/file.txt'
        /// u.fsPath === '\\server\c$\folder\file.txt'
        /// ```
        abstract fsPath: string
        /// <summary>Derive a new Uri from this Uri.
        /// 
        /// ```ts
        /// let file = Uri.parse('before:some/file/path');
        /// let other = file.with({ scheme: 'after' });
        /// assert.ok(other.toString() === 'after:some/file/path');
        /// ```</summary>
        /// <param name="change">An object that describes a change to this Uri. To unset components use `null` or
        /// the empty string.</param>
        abstract ``with``: change: UriWithChange -> Uri
        /// <summary>Returns a string representation of this Uri. The representation and normalization
        /// of a URI depends on the scheme.
        /// 
        /// * The resulting string can be safely used with Uri.parse.
        /// * The resulting string shall *not* be used for display purposes.
        /// 
        /// Note: that the implementation will encode aggressive which often leads to unexpected,
        /// but not incorrect, results. For instance, colons are encoded to `%3A which might be unexpected
        /// in file-uri. Also `&amp;` and `=` will be encoded which might be unexpected for http-uris. For stability
        /// reasons this cannot be changed anymore. If you suffer from too aggressive encoding you should use
        /// the skipEncoding argument.
        /// </summary>
        /// <param name="skipEncoding">Do not percentage-encode the result, defaults to `false`. Note that the `#` and `?` characters occurring in the path will always be encoded.</param>
        abstract toString: ?skipEncoding: bool -> string
        /// Returns a JSON representation of this Uri.
        abstract toJSON: unit -> obj option

    type [<AllowNullLiteral>] UriWithChange =
        abstract scheme: string option with get, set
        abstract authority: string option with get, set
        abstract path: string option with get, set
        abstract query: string option with get, set
        abstract fragment: string option with get, set

    /// A universal resource identifier representing either a file on disk
    /// or another resource, like untitled resources.
    type [<AllowNullLiteral>] UriStatic =
        /// <summary>Create an URI from a string, e.g. `http://www.msft.com/some/path`,
        /// `file:///usr/home`, or `scheme:with/path`.
        /// 
        /// *Note* that for a while uris without a `scheme` were accepted. That is not correct
        /// as all uris should have a scheme. To avoid breakage of existing code the optional
        /// `strict`-argument has been added. We *strongly* advise to use it, e.g. `Uri.parse('my:uri', true)`</summary>
        /// <param name="value">The string value of an Uri.</param>
        /// <param name="strict">Throw an error when `value` is empty or when no `scheme` can be parsed.</param>
        abstract parse: value: string * ?strict: bool -> Uri
        /// <summary>Create an URI from a file system path. The {@link Uri.scheme scheme}
        /// will be `file`.
        /// 
        /// The *difference* between {@link Uri.parse} and {@link Uri.file} is that the latter treats the argument
        /// as path, not as stringified-uri. E.g. `Uri.file(path)` is *not* the same as
        /// `Uri.parse('file://' + path)` because the path might contain characters that are
        /// interpreted (# and ?). See the following sample:
        /// ```ts
        /// const good = URI.file('/coding/c#/project1');
        /// good.scheme === 'file';
        /// good.path === '/coding/c#/project1';
        /// good.fragment === '';
        /// 
        /// const bad = URI.parse('file://' + '/coding/c#/project1');
        /// bad.scheme === 'file';
        /// bad.path === '/coding/c'; // path is now broken
        /// bad.fragment === '/project1';
        /// ```</summary>
        /// <param name="path">A file system or UNC path.</param>
        abstract file: path: string -> Uri
        /// <summary>Create a new uri which path is the result of joining
        /// the path of the base uri with the provided path segments.
        /// 
        /// - Note 1: `joinPath` only affects the path component
        /// and all other components (scheme, authority, query, and fragment) are
        /// left as they are.
        /// - Note 2: The base uri must have a path; an error is thrown otherwise.
        /// 
        /// The path segments are normalized in the following ways:
        /// - sequences of path separators (`/` or `\`) are replaced with a single separator
        /// - for `file`-uris on windows, the backslash-character (`\`) is considered a path-separator
        /// - the `..`-segment denotes the parent segment, the `.` denotes the current segment
        /// - paths have a root which always remains, for instance on windows drive-letters are roots
        /// so that is true: `joinPath(Uri.file('file:///c:/root'), '../../other').fsPath === 'c:/other'`</summary>
        /// <param name="base">An uri. Must have a path.</param>
        /// <param name="pathSegments">One more more path fragments</param>
        abstract joinPath: ``base``: Uri * [<ParamArray>] pathSegments: ResizeArray<string> -> Uri
        /// <summary>Create an URI from its component parts</summary>
        /// <param name="components">The component parts of an Uri.</param>
        abstract from: components: UriStaticFromComponents -> Uri

    type [<AllowNullLiteral>] UriStaticFromComponents =
        abstract scheme: string with get, set
        abstract authority: string option with get, set
        abstract path: string option with get, set
        abstract query: string option with get, set
        abstract fragment: string option with get, set

    /// A cancellation token is passed to an asynchronous or long running
    /// operation to request cancellation, like cancelling a request
    /// for completion items because the user continued to type.
    /// 
    /// To get an instance of a `CancellationToken` use a
    /// {@link CancellationTokenSource}.
    type [<AllowNullLiteral>] CancellationToken =
        /// Is `true` when the token has been cancelled, `false` otherwise.
        abstract isCancellationRequested: bool with get, set
        /// An {@link Event} which fires upon cancellation.
        abstract onCancellationRequested: Event<obj option> with get, set

    /// A cancellation source creates and controls a {@link CancellationToken cancellation token}.
    type [<AllowNullLiteral>] CancellationTokenSource =
        /// The cancellation token of this source.
        abstract token: CancellationToken with get, set
        /// Signal cancellation on the token.
        abstract cancel: unit -> unit
        /// Dispose object and free resources.
        abstract dispose: unit -> unit

    /// A cancellation source creates and controls a {@link CancellationToken cancellation token}.
    type [<AllowNullLiteral>] CancellationTokenSourceStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> CancellationTokenSource

    /// An error type that should be used to signal cancellation of an operation.
    /// 
    /// This type can be used in response to a {@link CancellationToken cancellation token}
    /// being cancelled or when an operation is being cancelled by the
    /// executor of that operation.
    type [<AllowNullLiteral; AbstractClass>] CancellationError =
        inherit Error

    /// An error type that should be used to signal cancellation of an operation.
    /// 
    /// This type can be used in response to a {@link CancellationToken cancellation token}
    /// being cancelled or when an operation is being cancelled by the
    /// executor of that operation.
    type [<AllowNullLiteral>] CancellationErrorStatic =
        /// Creates a new cancellation error.
        [<Emit "new $0($1...)">] abstract Create: unit -> CancellationError

    /// Represents a type which can release resources, such
    /// as event listening or a timer.
    type [<AllowNullLiteral>] Disposable =
        /// Dispose this object.
        abstract dispose: unit -> obj option

    /// Represents a type which can release resources, such
    /// as event listening or a timer.
    type [<AllowNullLiteral>] DisposableStatic =
        /// <summary>Combine many disposable-likes into one. Use this method
        /// when having objects with a dispose function which are not
        /// instances of Disposable.</summary>
        /// <param name="disposableLikes">Objects that have at least a `dispose`-function member.</param>
        abstract from: [<ParamArray>] disposableLikes: ResizeArray<DisposableStaticFrom> -> Disposable
        /// <summary>Creates a new Disposable calling the provided function
        /// on dispose.</summary>
        /// <param name="callOnDispose">Function that disposes something.</param>
        [<Emit "new $0($1...)">] abstract Create: callOnDispose: Function -> Disposable

    /// Represents a typed event.
    /// 
    /// A function that represents an event to which you subscribe by calling it with
    /// a listener function as argument.
    type [<AllowNullLiteral>] Event<'T> =
        /// <summary>A function that represents an event to which you subscribe by calling it with
        /// a listener function as argument.</summary>
        /// <param name="listener">The listener function will be called when the event happens.</param>
        /// <param name="thisArgs">The `this`-argument which will be used when calling the event listener.</param>
        /// <param name="disposables">An array to which a {@link Disposable} will be added.</param>
        [<Emit "$0($1...)">] abstract Invoke: listener: ('T -> obj option) * ?thisArgs: obj * ?disposables: ResizeArray<Disposable> -> Disposable

    /// An event emitter can be used to create and manage an {@link Event} for others
    /// to subscribe to. One emitter always owns one event.
    /// 
    /// Use this class if you want to provide event from within your extension, for instance
    /// inside a {@link TextDocumentContentProvider} or when providing
    /// API to other extensions.
    type [<AllowNullLiteral>] EventEmitter<'T> =
        /// The event listeners can subscribe to.
        abstract ``event``: Event<'T> with get, set
        /// <summary>Notify all subscribers of the {@link EventEmitter.event event}. Failure
        /// of one or more listener will not fail this function call.</summary>
        /// <param name="data">The event object.</param>
        abstract fire: data: 'T -> unit
        /// Dispose this object and free resources.
        abstract dispose: unit -> unit

    /// An event emitter can be used to create and manage an {@link Event} for others
    /// to subscribe to. One emitter always owns one event.
    /// 
    /// Use this class if you want to provide event from within your extension, for instance
    /// inside a {@link TextDocumentContentProvider} or when providing
    /// API to other extensions.
    type [<AllowNullLiteral>] EventEmitterStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> EventEmitter<'T>

    /// A file system watcher notifies about changes to files and folders
    /// on disk or from other {@link FileSystemProvider FileSystemProviders}.
    /// 
    /// To get an instance of a `FileSystemWatcher` use
    /// {@link workspace.createFileSystemWatcher createFileSystemWatcher}.
    type [<AllowNullLiteral>] FileSystemWatcher =
        inherit Disposable
        /// true if this file system watcher has been created such that
        /// it ignores creation file system events.
        abstract ignoreCreateEvents: bool with get, set
        /// true if this file system watcher has been created such that
        /// it ignores change file system events.
        abstract ignoreChangeEvents: bool with get, set
        /// true if this file system watcher has been created such that
        /// it ignores delete file system events.
        abstract ignoreDeleteEvents: bool with get, set
        /// An event which fires on file/folder creation.
        abstract onDidCreate: Event<Uri> with get, set
        /// An event which fires on file/folder change.
        abstract onDidChange: Event<Uri> with get, set
        /// An event which fires on file/folder deletion.
        abstract onDidDelete: Event<Uri> with get, set

    /// A text document content provider allows to add readonly documents
    /// to the editor, such as source from a dll or generated html from md.
    /// 
    /// Content providers are {@link workspace.registerTextDocumentContentProvider registered}
    /// for a {@link Uri.scheme uri-scheme}. When a uri with that scheme is to
    /// be {@link workspace.openTextDocument loaded} the content provider is
    /// asked.
    type [<AllowNullLiteral>] TextDocumentContentProvider =
        /// An event to signal a resource has changed.
        abstract onDidChange: Event<Uri> option with get, set
        /// <summary>Provide textual content for a given uri.
        /// 
        /// The editor will use the returned string-content to create a readonly
        /// {@link TextDocument document}. Resources allocated should be released when
        /// the corresponding document has been {@link workspace.onDidCloseTextDocument closed}.
        /// 
        /// **Note**: The contents of the created {@link TextDocument document} might not be
        /// identical to the provided text due to end-of-line-sequence normalization.</summary>
        /// <param name="uri">An uri which scheme matches the scheme this provider was {@link workspace.registerTextDocumentContentProvider registered} for.</param>
        /// <param name="token">A cancellation token.</param>
        abstract provideTextDocumentContent: uri: Uri * token: CancellationToken -> ProviderResult<string>

    /// Represents an item that can be selected from
    /// a list of items.
    type [<AllowNullLiteral>] QuickPickItem =
        /// A human-readable string which is rendered prominent. Supports rendering of {@link ThemeIcon theme icons} via
        /// the `$(<name>)`-syntax.
        abstract label: string with get, set
        /// A human-readable string which is rendered less prominent in the same line. Supports rendering of
        /// {@link ThemeIcon theme icons} via the `$(<name>)`-syntax.
        abstract description: string option with get, set
        /// A human-readable string which is rendered less prominent in a separate line. Supports rendering of
        /// {@link ThemeIcon theme icons} via the `$(<name>)`-syntax.
        abstract detail: string option with get, set
        /// Optional flag indicating if this item is picked initially.
        /// (Only honored when the picker allows multiple selections.)
        abstract picked: bool option with get, set
        /// Always show this item.
        abstract alwaysShow: bool option with get, set

    /// Options to configure the behavior of the quick pick UI.
    type [<AllowNullLiteral>] QuickPickOptions =
        /// An optional string that represents the title of the quick pick.
        abstract title: string option with get, set
        /// An optional flag to include the description when filtering the picks.
        abstract matchOnDescription: bool option with get, set
        /// An optional flag to include the detail when filtering the picks.
        abstract matchOnDetail: bool option with get, set
        /// An optional string to show as placeholder in the input box to guide the user what to pick on.
        abstract placeHolder: string option with get, set
        /// Set to `true` to keep the picker open when focus moves to another part of the editor or to another window.
        /// This setting is ignored on iPad and is always false.
        abstract ignoreFocusOut: bool option with get, set
        /// An optional flag to make the picker accept multiple selections, if true the result is an array of picks.
        abstract canPickMany: bool option with get, set
        /// An optional function that is invoked whenever an item is selected.
        abstract onDidSelectItem: item: U2<QuickPickItem, string> -> obj option

    /// Options to configure the behaviour of the {@link WorkspaceFolder workspace folder} pick UI.
    type [<AllowNullLiteral>] WorkspaceFolderPickOptions =
        /// An optional string to show as placeholder in the input box to guide the user what to pick on.
        abstract placeHolder: string option with get, set
        /// Set to `true` to keep the picker open when focus moves to another part of the editor or to another window.
        /// This setting is ignored on iPad and is always false.
        abstract ignoreFocusOut: bool option with get, set

    /// Options to configure the behaviour of a file open dialog.
    /// 
    /// * Note 1: On Windows and Linux, a file dialog cannot be both a file selector and a folder selector, so if you
    /// set both `canSelectFiles` and `canSelectFolders` to `true` on these platforms, a folder selector will be shown.
    /// * Note 2: Explicitly setting `canSelectFiles` and `canSelectFolders` to `false` is futile
    /// and the editor then silently adjusts the options to select files.
    type [<AllowNullLiteral>] OpenDialogOptions =
        /// The resource the dialog shows when opened.
        abstract defaultUri: Uri option with get, set
        /// A human-readable string for the open button.
        abstract openLabel: string option with get, set
        /// Allow to select files, defaults to `true`.
        abstract canSelectFiles: bool option with get, set
        /// Allow to select folders, defaults to `false`.
        abstract canSelectFolders: bool option with get, set
        /// Allow to select many files or folders.
        abstract canSelectMany: bool option with get, set
        /// A set of file filters that are used by the dialog. Each entry is a human-readable label,
        /// like "TypeScript", and an array of extensions, e.g.
        /// ```ts
        /// {
        ///      'Images': ['png', 'jpg']
        ///      'TypeScript': ['ts', 'tsx']
        /// }
        /// ```
        abstract filters: OpenDialogOptionsFilters option with get, set
        /// Dialog title.
        /// 
        /// This parameter might be ignored, as not all operating systems display a title on open dialogs
        /// (for example, macOS).
        abstract title: string option with get, set

    /// Options to configure the behaviour of a file save dialog.
    type [<AllowNullLiteral>] SaveDialogOptions =
        /// The resource the dialog shows when opened.
        abstract defaultUri: Uri option with get, set
        /// A human-readable string for the save button.
        abstract saveLabel: string option with get, set
        /// A set of file filters that are used by the dialog. Each entry is a human-readable label,
        /// like "TypeScript", and an array of extensions, e.g.
        /// ```ts
        /// {
        ///      'Images': ['png', 'jpg']
        ///      'TypeScript': ['ts', 'tsx']
        /// }
        /// ```
        abstract filters: OpenDialogOptionsFilters option with get, set
        /// Dialog title.
        /// 
        /// This parameter might be ignored, as not all operating systems display a title on save dialogs
        /// (for example, macOS).
        abstract title: string option with get, set

    /// Represents an action that is shown with an information, warning, or
    /// error message.
    type [<AllowNullLiteral>] MessageItem =
        /// A short title like 'Retry', 'Open Log' etc.
        abstract title: string with get, set
        /// A hint for modal dialogs that the item should be triggered
        /// when the user cancels the dialog (e.g. by pressing the ESC
        /// key).
        /// 
        /// Note: this option is ignored for non-modal messages.
        abstract isCloseAffordance: bool option with get, set

    /// Options to configure the behavior of the message.
    type [<AllowNullLiteral>] MessageOptions =
        /// Indicates that this message should be modal.
        abstract modal: bool option with get, set
        /// Human-readable detail message that is rendered less prominent. _Note_ that detail
        /// is only shown for {@link MessageOptions.modal modal} messages.
        abstract detail: string option with get, set

    /// Options to configure the behavior of the input box UI.
    type [<AllowNullLiteral>] InputBoxOptions =
        /// An optional string that represents the title of the input box.
        abstract title: string option with get, set
        /// The value to prefill in the input box.
        abstract value: string option with get, set
        /// Selection of the prefilled {@link InputBoxOptions.value `value`}. Defined as tuple of two number where the
        /// first is the inclusive start index and the second the exclusive end index. When `undefined` the whole
        /// word will be selected, when empty (start equals end) only the cursor will be set,
        /// otherwise the defined range will be selected.
        abstract valueSelection: float * float option with get, set
        /// The text to display underneath the input box.
        abstract prompt: string option with get, set
        /// An optional string to show as placeholder in the input box to guide the user what to type.
        abstract placeHolder: string option with get, set
        /// Controls if a password input is shown. Password input hides the typed text.
        abstract password: bool option with get, set
        /// Set to `true` to keep the input box open when focus moves to another part of the editor or to another window.
        /// This setting is ignored on iPad and is always false.
        abstract ignoreFocusOut: bool option with get, set
        /// <summary>An optional function that will be called to validate input and to give a hint
        /// to the user.</summary>
        /// <param name="value">The current value of the input box.</param>
        abstract validateInput: value: string -> U2<string, Thenable<string option>> option

    /// A relative pattern is a helper to construct glob patterns that are matched
    /// relatively to a base file path. The base path can either be an absolute file
    /// path as string or uri or a {@link WorkspaceFolder workspace folder}, which is the
    /// preferred way of creating the relative pattern.
    type [<AllowNullLiteral>] RelativePattern =
        /// A base file path to which this pattern will be matched against relatively.
        abstract ``base``: string with get, set
        /// A file glob pattern like `*.{ts,js}` that will be matched on file paths
        /// relative to the base path.
        /// 
        /// Example: Given a base of `/home/work/folder` and a file path of `/home/work/folder/index.js`,
        /// the file glob pattern will match on `index.js`.
        abstract pattern: string with get, set

    /// A relative pattern is a helper to construct glob patterns that are matched
    /// relatively to a base file path. The base path can either be an absolute file
    /// path as string or uri or a {@link WorkspaceFolder workspace folder}, which is the
    /// preferred way of creating the relative pattern.
    type [<AllowNullLiteral>] RelativePatternStatic =
        /// <summary>Creates a new relative pattern object with a base file path and pattern to match. This pattern
        /// will be matched on file paths relative to the base.
        /// 
        /// Example:
        /// ```ts
        /// const folder = vscode.workspace.workspaceFolders?.[0];
        /// if (folder) {
        /// 
        ///    // Match any TypeScript file in the root of this workspace folder
        ///    const pattern1 = new vscode.RelativePattern(folder, '*.ts');
        /// 
        ///    // Match any TypeScript file in `someFolder` inside this workspace folder
        ///    const pattern2 = new vscode.RelativePattern(folder, 'someFolder/*.ts');
        /// }
        /// ```</summary>
        /// <param name="base">A base to which this pattern will be matched against relatively. It is recommended
        /// to pass in a {@link WorkspaceFolder workspace folder} if the pattern should match inside the workspace.
        /// Otherwise, a uri or string should only be used if the pattern is for a file path outside the workspace.</param>
        /// <param name="pattern">A file glob pattern like `*.{ts,js}` that will be matched on paths relative to the base.</param>
        [<Emit "new $0($1...)">] abstract Create: ``base``: U3<WorkspaceFolder, Uri, string> * pattern: string -> RelativePattern

    type GlobPattern =
        U2<string, RelativePattern>

    /// A document filter denotes a document by different properties like
    /// the {@link TextDocument.languageId language}, the {@link Uri.scheme scheme} of
    /// its resource, or a glob-pattern that is applied to the {@link TextDocument.fileName path}.
    type [<AllowNullLiteral>] DocumentFilter =
        /// A language id, like `typescript`.
        abstract language: string option
        /// A Uri {@link Uri.scheme scheme}, like `file` or `untitled`.
        abstract scheme: string option
        /// A {@link GlobPattern glob pattern} that is matched on the absolute path of the document. Use a {@link RelativePattern relative pattern}
        /// to filter documents to a {@link WorkspaceFolder workspace folder}.
        abstract pattern: GlobPattern option

    type DocumentSelector =
        U3<DocumentFilter, string, ReadonlyArray<U2<DocumentFilter, string>>>

    type ProviderResult<'T> =
        U2<'T, Thenable<'T option>> option

    /// Kind of a code action.
    /// 
    /// Kinds are a hierarchical list of identifiers separated by `.`, e.g. `"refactor.extract.function"`.
    /// 
    /// Code action kinds are used by the editor for UI elements such as the refactoring context menu. Users
    /// can also trigger code actions with a specific kind with the `editor.action.codeAction` command.
    type [<AllowNullLiteral>] CodeActionKind =
        /// String value of the kind, e.g. `"refactor.extract.function"`.
        abstract value: string
        /// Create a new kind by appending a more specific selector to the current kind.
        /// 
        /// Does not modify the current kind.
        abstract append: parts: string -> CodeActionKind
        /// <summary>Checks if this code action kind intersects `other`.
        /// 
        /// The kind `"refactor.extract"` for example intersects `refactor`, `"refactor.extract"` and ``"refactor.extract.function"`,
        /// but not `"unicorn.refactor.extract"`, or `"refactor.extractAll"`.</summary>
        /// <param name="other">Kind to check.</param>
        abstract intersects: other: CodeActionKind -> bool
        /// <summary>Checks if `other` is a sub-kind of this `CodeActionKind`.
        /// 
        /// The kind `"refactor.extract"` for example contains `"refactor.extract"` and ``"refactor.extract.function"`,
        /// but not `"unicorn.refactor.extract"`, or `"refactor.extractAll"` or `refactor`.</summary>
        /// <param name="other">Kind to check.</param>
        abstract contains: other: CodeActionKind -> bool

    /// Kind of a code action.
    /// 
    /// Kinds are a hierarchical list of identifiers separated by `.`, e.g. `"refactor.extract.function"`.
    /// 
    /// Code action kinds are used by the editor for UI elements such as the refactoring context menu. Users
    /// can also trigger code actions with a specific kind with the `editor.action.codeAction` command.
    type [<AllowNullLiteral>] CodeActionKindStatic =
        /// Empty kind.
        abstract Empty: CodeActionKind
        /// Base kind for quickfix actions: `quickfix`.
        /// 
        /// Quick fix actions address a problem in the code and are shown in the normal code action context menu.
        abstract QuickFix: CodeActionKind
        /// Base kind for refactoring actions: `refactor`
        /// 
        /// Refactoring actions are shown in the refactoring context menu.
        abstract Refactor: CodeActionKind
        /// Base kind for refactoring extraction actions: `refactor.extract`
        /// 
        /// Example extract actions:
        /// 
        /// - Extract method
        /// - Extract function
        /// - Extract variable
        /// - Extract interface from class
        /// - ...
        abstract RefactorExtract: CodeActionKind
        /// Base kind for refactoring inline actions: `refactor.inline`
        /// 
        /// Example inline actions:
        /// 
        /// - Inline function
        /// - Inline variable
        /// - Inline constant
        /// - ...
        abstract RefactorInline: CodeActionKind
        /// Base kind for refactoring rewrite actions: `refactor.rewrite`
        /// 
        /// Example rewrite actions:
        /// 
        /// - Convert JavaScript function to class
        /// - Add or remove parameter
        /// - Encapsulate field
        /// - Make method static
        /// - Move method to base class
        /// - ...
        abstract RefactorRewrite: CodeActionKind
        /// Base kind for source actions: `source`
        /// 
        /// Source code actions apply to the entire file. They must be explicitly requested and will not show in the
        /// normal [lightbulb](https://code.visualstudio.com/docs/editor/editingevolved#_code-action) menu. Source actions
        /// can be run on save using `editor.codeActionsOnSave` and are also shown in the `source` context menu.
        abstract Source: CodeActionKind
        /// Base kind for an organize imports source action: `source.organizeImports`.
        abstract SourceOrganizeImports: CodeActionKind
        /// Base kind for auto-fix source actions: `source.fixAll`.
        /// 
        /// Fix all actions automatically fix errors that have a clear fix that do not require user input.
        /// They should not suppress errors or perform unsafe fixes such as generating new types or classes.
        abstract SourceFixAll: CodeActionKind

    type [<RequireQualifiedAccess>] CodeActionTriggerKind =
        | Invoke = 1
        | Automatic = 2

    /// Contains additional diagnostic information about the context in which
    /// a {@link CodeActionProvider.provideCodeActions code action} is run.
    type [<AllowNullLiteral>] CodeActionContext =
        /// The reason why code actions were requested.
        abstract triggerKind: CodeActionTriggerKind
        /// An array of diagnostics.
        abstract diagnostics: ResizeArray<Diagnostic>
        /// Requested kind of actions to return.
        /// 
        /// Actions not of this kind are filtered out before being shown by the [lightbulb](https://code.visualstudio.com/docs/editor/editingevolved#_code-action).
        abstract only: CodeActionKind option

    /// A code action represents a change that can be performed in code, e.g. to fix a problem or
    /// to refactor code.
    /// 
    /// A CodeAction must set either {@link CodeAction.edit `edit`} and/or a {@link CodeAction.command `command`}. If both are supplied, the `edit` is applied first, then the command is executed.
    type [<AllowNullLiteral>] CodeAction =
        /// A short, human-readable, title for this code action.
        abstract title: string with get, set
        /// A {@link WorkspaceEdit workspace edit} this code action performs.
        abstract edit: WorkspaceEdit option with get, set
        /// {@link Diagnostic Diagnostics} that this code action resolves.
        abstract diagnostics: ResizeArray<Diagnostic> option with get, set
        /// A {@link Command} this code action executes.
        /// 
        /// If this command throws an exception, the editor displays the exception message to users in the editor at the
        /// current cursor position.
        abstract command: Command option with get, set
        /// {@link CodeActionKind Kind} of the code action.
        /// 
        /// Used to filter code actions.
        abstract kind: CodeActionKind option with get, set
        /// Marks this as a preferred action. Preferred actions are used by the `auto fix` command and can be targeted
        /// by keybindings.
        /// 
        /// A quick fix should be marked preferred if it properly addresses the underlying error.
        /// A refactoring should be marked preferred if it is the most reasonable choice of actions to take.
        abstract isPreferred: bool option with get, set
        /// Marks that the code action cannot currently be applied.
        /// 
        /// - Disabled code actions are not shown in automatic [lightbulb](https://code.visualstudio.com/docs/editor/editingevolved#_code-action)
        /// code action menu.
        /// 
        /// - Disabled actions are shown as faded out in the code action menu when the user request a more specific type
        /// of code action, such as refactorings.
        /// 
        /// - If the user has a [keybinding](https://code.visualstudio.com/docs/editor/refactoring#_keybindings-for-code-actions)
        /// that auto applies a code action and only a disabled code actions are returned, the editor will show the user an
        /// error message with `reason` in the editor.
        abstract disabled: CodeActionDisabled option with get, set

    /// A code action represents a change that can be performed in code, e.g. to fix a problem or
    /// to refactor code.
    /// 
    /// A CodeAction must set either {@link CodeAction.edit `edit`} and/or a {@link CodeAction.command `command`}. If both are supplied, the `edit` is applied first, then the command is executed.
    type [<AllowNullLiteral>] CodeActionStatic =
        /// <summary>Creates a new code action.
        /// 
        /// A code action must have at least a {@link CodeAction.title title} and {@link CodeAction.edit edits}
        /// and/or a {@link CodeAction.command command}.</summary>
        /// <param name="title">The title of the code action.</param>
        /// <param name="kind">The kind of the code action.</param>
        [<Emit "new $0($1...)">] abstract Create: title: string * ?kind: CodeActionKind -> CodeAction

    type CodeActionProvider =
        CodeActionProvider<obj>

    /// The code action interface defines the contract between extensions and
    /// the [lightbulb](https://code.visualstudio.com/docs/editor/editingevolved#_code-action) feature.
    /// 
    /// A code action can be any command that is {@link commands.getCommands known} to the system.
    type [<AllowNullLiteral>] CodeActionProvider<'T> =
        /// <summary>Provide commands for the given document and range.</summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="range">The selector or range for which the command was invoked. This will always be a selection if
        /// there is a currently active editor.</param>
        /// <param name="context">Context carrying additional information.</param>
        /// <param name="token">A cancellation token.</param>
        abstract provideCodeActions: document: TextDocument * range: U2<Range, Selection> * context: CodeActionContext * token: CancellationToken -> ProviderResult<ResizeArray<U2<Command, 'T>>>
        /// <summary>Given a code action fill in its {@link CodeAction.edit `edit`}-property. Changes to
        /// all other properties, like title, are ignored. A code action that has an edit
        /// will not be resolved.
        /// 
        /// *Note* that a code action provider that returns commands, not code actions, cannot successfully
        /// implement this function. Returning commands is deprecated and instead code actions should be
        /// returned.</summary>
        /// <param name="codeAction">A code action.</param>
        /// <param name="token">A cancellation token.</param>
        abstract resolveCodeAction: codeAction: 'T * token: CancellationToken -> ProviderResult<'T>

    /// Metadata about the type of code actions that a {@link CodeActionProvider} provides.
    type [<AllowNullLiteral>] CodeActionProviderMetadata =
        /// List of {@link CodeActionKind CodeActionKinds} that a {@link CodeActionProvider} may return.
        /// 
        /// This list is used to determine if a given `CodeActionProvider` should be invoked or not.
        /// To avoid unnecessary computation, every `CodeActionProvider` should list use `providedCodeActionKinds`. The
        /// list of kinds may either be generic, such as `[CodeActionKind.Refactor]`, or list out every kind provided,
        /// such as `[CodeActionKind.Refactor.Extract.append('function'), CodeActionKind.Refactor.Extract.append('constant'), ...]`.
        abstract providedCodeActionKinds: ResizeArray<CodeActionKind> option
        /// Static documentation for a class of code actions.
        /// 
        /// Documentation from the provider is shown in the code actions menu if either:
        /// 
        /// - Code actions of `kind` are requested by the editor. In this case, the editor will show the documentation that
        ///    most closely matches the requested code action kind. For example, if a provider has documentation for
        ///    both `Refactor` and `RefactorExtract`, when the user requests code actions for `RefactorExtract`,
        ///    the editor will use the documentation for `RefactorExtract` instead of the documentation for `Refactor`.
        /// 
        /// - Any code actions of `kind` are returned by the provider.
        /// 
        /// At most one documentation entry will be shown per provider.
        abstract documentation: ReadonlyArray<CodeActionProviderMetadataDocumentationReadonlyArray> option

    /// A code lens represents a {@link Command} that should be shown along with
    /// source text, like the number of references, a way to run tests, etc.
    /// 
    /// A code lens is _unresolved_ when no command is associated to it. For performance
    /// reasons the creation of a code lens and resolving should be done to two stages.
    type [<AllowNullLiteral>] CodeLens =
        /// The range in which this code lens is valid. Should only span a single line.
        abstract range: Range with get, set
        /// The command this code lens represents.
        abstract command: Command option with get, set
        /// `true` when there is a command associated.
        abstract isResolved: bool

    /// A code lens represents a {@link Command} that should be shown along with
    /// source text, like the number of references, a way to run tests, etc.
    /// 
    /// A code lens is _unresolved_ when no command is associated to it. For performance
    /// reasons the creation of a code lens and resolving should be done to two stages.
    type [<AllowNullLiteral>] CodeLensStatic =
        /// <summary>Creates a new code lens object.</summary>
        /// <param name="range">The range to which this code lens applies.</param>
        /// <param name="command">The command associated to this code lens.</param>
        [<Emit "new $0($1...)">] abstract Create: range: Range * ?command: Command -> CodeLens

    type CodeLensProvider =
        CodeLensProvider<obj>

    /// A code lens provider adds {@link Command commands} to source text. The commands will be shown
    /// as dedicated horizontal lines in between the source text.
    type [<AllowNullLiteral>] CodeLensProvider<'T> =
        /// An optional event to signal that the code lenses from this provider have changed.
        abstract onDidChangeCodeLenses: Event<unit> option with get, set
        /// <summary>Compute a list of {@link CodeLens lenses}. This call should return as fast as possible and if
        /// computing the commands is expensive implementors should only return code lens objects with the
        /// range set and implement {@link CodeLensProvider.resolveCodeLens resolve}.</summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="token">A cancellation token.</param>
        abstract provideCodeLenses: document: TextDocument * token: CancellationToken -> ProviderResult<ResizeArray<'T>>
        /// <summary>This function will be called for each visible code lens, usually when scrolling and after
        /// calls to {@link CodeLensProvider.provideCodeLenses compute}-lenses.</summary>
        /// <param name="codeLens">Code lens that must be resolved.</param>
        /// <param name="token">A cancellation token.</param>
        abstract resolveCodeLens: codeLens: 'T * token: CancellationToken -> ProviderResult<'T>

    type DefinitionLink =
        LocationLink

    type Definition =
        U2<Location, ResizeArray<Location>>

    /// The definition provider interface defines the contract between extensions and
    /// the [go to definition](https://code.visualstudio.com/docs/editor/editingevolved#_go-to-definition)
    /// and peek definition features.
    type [<AllowNullLiteral>] DefinitionProvider =
        /// <summary>Provide the definition of the symbol at the given position and document.</summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="position">The position at which the command was invoked.</param>
        /// <param name="token">A cancellation token.</param>
        abstract provideDefinition: document: TextDocument * position: Position * token: CancellationToken -> ProviderResult<U2<Definition, ResizeArray<DefinitionLink>>>

    /// The implementation provider interface defines the contract between extensions and
    /// the go to implementation feature.
    type [<AllowNullLiteral>] ImplementationProvider =
        /// <summary>Provide the implementations of the symbol at the given position and document.</summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="position">The position at which the command was invoked.</param>
        /// <param name="token">A cancellation token.</param>
        abstract provideImplementation: document: TextDocument * position: Position * token: CancellationToken -> ProviderResult<U2<Definition, ResizeArray<DefinitionLink>>>

    /// The type definition provider defines the contract between extensions and
    /// the go to type definition feature.
    type [<AllowNullLiteral>] TypeDefinitionProvider =
        /// <summary>Provide the type definition of the symbol at the given position and document.</summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="position">The position at which the command was invoked.</param>
        /// <param name="token">A cancellation token.</param>
        abstract provideTypeDefinition: document: TextDocument * position: Position * token: CancellationToken -> ProviderResult<U2<Definition, ResizeArray<DefinitionLink>>>

    type Declaration =
        U3<Location, ResizeArray<Location>, ResizeArray<LocationLink>>

    /// The declaration provider interface defines the contract between extensions and
    /// the go to declaration feature.
    type [<AllowNullLiteral>] DeclarationProvider =
        /// <summary>Provide the declaration of the symbol at the given position and document.</summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="position">The position at which the command was invoked.</param>
        /// <param name="token">A cancellation token.</param>
        abstract provideDeclaration: document: TextDocument * position: Position * token: CancellationToken -> ProviderResult<Declaration>

    /// The MarkdownString represents human-readable text that supports formatting via the
    /// markdown syntax. Standard markdown is supported, also tables, but no embedded html.
    /// 
    /// Rendering of {@link ThemeIcon theme icons} via the `$(<name>)`-syntax is supported
    /// when the {@link MarkdownString.supportThemeIcons `supportThemeIcons`} is set to `true`.
    type [<AllowNullLiteral>] MarkdownString =
        /// The markdown string.
        abstract value: string with get, set
        /// Indicates that this markdown string is from a trusted source. Only *trusted*
        /// markdown supports links that execute commands, e.g. `[Run it](command:myCommandId)`.
        abstract isTrusted: bool option with get, set
        /// Indicates that this markdown string can contain {@link ThemeIcon ThemeIcons}, e.g. `$(zap)`.
        abstract supportThemeIcons: bool option with get, set
        /// <summary>Appends and escapes the given string to this markdown string.</summary>
        /// <param name="value">Plain text.</param>
        abstract appendText: value: string -> MarkdownString
        /// <summary>Appends the given string 'as is' to this markdown string. When {@link MarkdownString.supportThemeIcons `supportThemeIcons`} is `true`, {@link ThemeIcon ThemeIcons} in the `value` will be iconified.</summary>
        /// <param name="value">Markdown string.</param>
        abstract appendMarkdown: value: string -> MarkdownString
        /// <summary>Appends the given string as codeblock using the provided language.</summary>
        /// <param name="value">A code snippet.</param>
        /// <param name="language">An optional {@link languages.getLanguages language identifier}.</param>
        abstract appendCodeblock: value: string * ?language: string -> MarkdownString

    /// The MarkdownString represents human-readable text that supports formatting via the
    /// markdown syntax. Standard markdown is supported, also tables, but no embedded html.
    /// 
    /// Rendering of {@link ThemeIcon theme icons} via the `$(<name>)`-syntax is supported
    /// when the {@link MarkdownString.supportThemeIcons `supportThemeIcons`} is set to `true`.
    type [<AllowNullLiteral>] MarkdownStringStatic =
        /// <summary>Creates a new markdown string with the given value.</summary>
        /// <param name="value">Optional, initial value.</param>
        /// <param name="supportThemeIcons">Optional, Specifies whether {@link ThemeIcon ThemeIcons} are supported within the {@link MarkdownString `MarkdownString`}.</param>
        [<Emit "new $0($1...)">] abstract Create: ?value: string * ?supportThemeIcons: bool -> MarkdownString

    type MarkedString =
        U3<string, string, string>

    /// A hover represents additional information for a symbol or word. Hovers are
    /// rendered in a tooltip-like widget.
    type [<AllowNullLiteral>] Hover =
        /// The contents of this hover.
        abstract contents: Array<U2<MarkdownString, MarkedString>> with get, set
        /// The range to which this hover applies. When missing, the
        /// editor will use the range at the current position or the
        /// current position itself.
        abstract range: Range option with get, set

    /// A hover represents additional information for a symbol or word. Hovers are
    /// rendered in a tooltip-like widget.
    type [<AllowNullLiteral>] HoverStatic =
        /// <summary>Creates a new hover object.</summary>
        /// <param name="contents">The contents of the hover.</param>
        /// <param name="range">The range to which the hover applies.</param>
        [<Emit "new $0($1...)">] abstract Create: contents: U3<MarkdownString, MarkedString, Array<U2<MarkdownString, MarkedString>>> * ?range: Range -> Hover

    /// The hover provider interface defines the contract between extensions and
    /// the [hover](https://code.visualstudio.com/docs/editor/intellisense)-feature.
    type [<AllowNullLiteral>] HoverProvider =
        /// <summary>Provide a hover for the given position and document. Multiple hovers at the same
        /// position will be merged by the editor. A hover can have a range which defaults
        /// to the word range at the position when omitted.</summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="position">The position at which the command was invoked.</param>
        /// <param name="token">A cancellation token.</param>
        abstract provideHover: document: TextDocument * position: Position * token: CancellationToken -> ProviderResult<Hover>

    /// An EvaluatableExpression represents an expression in a document that can be evaluated by an active debugger or runtime.
    /// The result of this evaluation is shown in a tooltip-like widget.
    /// If only a range is specified, the expression will be extracted from the underlying document.
    /// An optional expression can be used to override the extracted expression.
    /// In this case the range is still used to highlight the range in the document.
    type [<AllowNullLiteral>] EvaluatableExpression =
        abstract range: Range
        abstract expression: string option

    /// An EvaluatableExpression represents an expression in a document that can be evaluated by an active debugger or runtime.
    /// The result of this evaluation is shown in a tooltip-like widget.
    /// If only a range is specified, the expression will be extracted from the underlying document.
    /// An optional expression can be used to override the extracted expression.
    /// In this case the range is still used to highlight the range in the document.
    type [<AllowNullLiteral>] EvaluatableExpressionStatic =
        /// <summary>Creates a new evaluatable expression object.</summary>
        /// <param name="range">The range in the underlying document from which the evaluatable expression is extracted.</param>
        /// <param name="expression">If specified overrides the extracted expression.</param>
        [<Emit "new $0($1...)">] abstract Create: range: Range * ?expression: string -> EvaluatableExpression

    /// The evaluatable expression provider interface defines the contract between extensions and
    /// the debug hover. In this contract the provider returns an evaluatable expression for a given position
    /// in a document and the editor evaluates this expression in the active debug session and shows the result in a debug hover.
    type [<AllowNullLiteral>] EvaluatableExpressionProvider =
        /// <summary>Provide an evaluatable expression for the given document and position.
        /// The editor will evaluate this expression in the active debug session and will show the result in the debug hover.
        /// The expression can be implicitly specified by the range in the underlying document or by explicitly returning an expression.</summary>
        /// <param name="document">The document for which the debug hover is about to appear.</param>
        /// <param name="position">The line and character position in the document where the debug hover is about to appear.</param>
        /// <param name="token">A cancellation token.</param>
        abstract provideEvaluatableExpression: document: TextDocument * position: Position * token: CancellationToken -> ProviderResult<EvaluatableExpression>

    /// Provide inline value as text.
    type [<AllowNullLiteral>] InlineValueText =
        /// The document range for which the inline value applies.
        abstract range: Range
        /// The text of the inline value.
        abstract text: string

    /// Provide inline value as text.
    type [<AllowNullLiteral>] InlineValueTextStatic =
        /// <summary>Creates a new InlineValueText object.</summary>
        /// <param name="range">The document line where to show the inline value.</param>
        /// <param name="text">The value to be shown for the line.</param>
        [<Emit "new $0($1...)">] abstract Create: range: Range * text: string -> InlineValueText

    /// Provide inline value through a variable lookup.
    /// If only a range is specified, the variable name will be extracted from the underlying document.
    /// An optional variable name can be used to override the extracted name.
    type [<AllowNullLiteral>] InlineValueVariableLookup =
        /// The document range for which the inline value applies.
        /// The range is used to extract the variable name from the underlying document.
        abstract range: Range
        /// If specified the name of the variable to look up.
        abstract variableName: string option
        /// How to perform the lookup.
        abstract caseSensitiveLookup: bool

    /// Provide inline value through a variable lookup.
    /// If only a range is specified, the variable name will be extracted from the underlying document.
    /// An optional variable name can be used to override the extracted name.
    type [<AllowNullLiteral>] InlineValueVariableLookupStatic =
        /// <summary>Creates a new InlineValueVariableLookup object.</summary>
        /// <param name="range">The document line where to show the inline value.</param>
        /// <param name="variableName">The name of the variable to look up.</param>
        /// <param name="caseSensitiveLookup">How to perform the lookup. If missing lookup is case sensitive.</param>
        [<Emit "new $0($1...)">] abstract Create: range: Range * ?variableName: string * ?caseSensitiveLookup: bool -> InlineValueVariableLookup

    /// Provide an inline value through an expression evaluation.
    /// If only a range is specified, the expression will be extracted from the underlying document.
    /// An optional expression can be used to override the extracted expression.
    type [<AllowNullLiteral>] InlineValueEvaluatableExpression =
        /// The document range for which the inline value applies.
        /// The range is used to extract the evaluatable expression from the underlying document.
        abstract range: Range
        /// If specified the expression overrides the extracted expression.
        abstract expression: string option

    /// Provide an inline value through an expression evaluation.
    /// If only a range is specified, the expression will be extracted from the underlying document.
    /// An optional expression can be used to override the extracted expression.
    type [<AllowNullLiteral>] InlineValueEvaluatableExpressionStatic =
        /// <summary>Creates a new InlineValueEvaluatableExpression object.</summary>
        /// <param name="range">The range in the underlying document from which the evaluatable expression is extracted.</param>
        /// <param name="expression">If specified overrides the extracted expression.</param>
        [<Emit "new $0($1...)">] abstract Create: range: Range * ?expression: string -> InlineValueEvaluatableExpression

    type InlineValue =
        U3<InlineValueText, InlineValueVariableLookup, InlineValueEvaluatableExpression>

    /// A value-object that contains contextual information when requesting inline values from a InlineValuesProvider.
    type [<AllowNullLiteral>] InlineValueContext =
        /// The stack frame (as a DAP Id) where the execution has stopped.
        abstract frameId: float
        /// The document range where execution has stopped.
        /// Typically the end position of the range denotes the line where the inline values are shown.
        abstract stoppedLocation: Range

    /// The inline values provider interface defines the contract between extensions and the editor's debugger inline values feature.
    /// In this contract the provider returns inline value information for a given document range
    /// and the editor shows this information in the editor at the end of lines.
    type [<AllowNullLiteral>] InlineValuesProvider =
        /// An optional event to signal that inline values have changed.
        abstract onDidChangeInlineValues: Event<unit> option with get, set
        /// <summary>Provide "inline value" information for a given document and range.
        /// The editor calls this method whenever debugging stops in the given document.
        /// The returned inline values information is rendered in the editor at the end of lines.</summary>
        /// <param name="document">The document for which the inline values information is needed.</param>
        /// <param name="viewPort">The visible document range for which inline values should be computed.</param>
        /// <param name="context">A bag containing contextual information like the current location.</param>
        /// <param name="token">A cancellation token.</param>
        abstract provideInlineValues: document: TextDocument * viewPort: Range * context: InlineValueContext * token: CancellationToken -> ProviderResult<ResizeArray<InlineValue>>

    type [<RequireQualifiedAccess>] DocumentHighlightKind =
        | Text = 0
        | Read = 1
        | Write = 2

    /// A document highlight is a range inside a text document which deserves
    /// special attention. Usually a document highlight is visualized by changing
    /// the background color of its range.
    type [<AllowNullLiteral>] DocumentHighlight =
        /// The range this highlight applies to.
        abstract range: Range with get, set
        /// The highlight kind, default is {@link DocumentHighlightKind.Text text}.
        abstract kind: DocumentHighlightKind option with get, set

    /// A document highlight is a range inside a text document which deserves
    /// special attention. Usually a document highlight is visualized by changing
    /// the background color of its range.
    type [<AllowNullLiteral>] DocumentHighlightStatic =
        /// <summary>Creates a new document highlight object.</summary>
        /// <param name="range">The range the highlight applies to.</param>
        /// <param name="kind">The highlight kind, default is {@link DocumentHighlightKind.Text text}.</param>
        [<Emit "new $0($1...)">] abstract Create: range: Range * ?kind: DocumentHighlightKind -> DocumentHighlight

    /// The document highlight provider interface defines the contract between extensions and
    /// the word-highlight-feature.
    type [<AllowNullLiteral>] DocumentHighlightProvider =
        /// <summary>Provide a set of document highlights, like all occurrences of a variable or
        /// all exit-points of a function.</summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="position">The position at which the command was invoked.</param>
        /// <param name="token">A cancellation token.</param>
        abstract provideDocumentHighlights: document: TextDocument * position: Position * token: CancellationToken -> ProviderResult<ResizeArray<DocumentHighlight>>

    type [<RequireQualifiedAccess>] SymbolKind =
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
        | Object = 18
        | Key = 19
        | Null = 20
        | EnumMember = 21
        | Struct = 22
        | Event = 23
        | Operator = 24
        | TypeParameter = 25

    type [<RequireQualifiedAccess>] SymbolTag =
        | Deprecated = 1

    /// Represents information about programming constructs like variables, classes,
    /// interfaces etc.
    type [<AllowNullLiteral>] SymbolInformation =
        /// The name of this symbol.
        abstract name: string with get, set
        /// The name of the symbol containing this symbol.
        abstract containerName: string with get, set
        /// The kind of this symbol.
        abstract kind: SymbolKind with get, set
        /// Tags for this symbol.
        abstract tags: ResizeArray<SymbolTag> option with get, set
        /// The location of this symbol.
        abstract location: Location with get, set

    /// Represents information about programming constructs like variables, classes,
    /// interfaces etc.
    type [<AllowNullLiteral>] SymbolInformationStatic =
        /// <summary>Creates a new symbol information object.</summary>
        /// <param name="name">The name of the symbol.</param>
        /// <param name="kind">The kind of the symbol.</param>
        /// <param name="containerName">The name of the symbol containing the symbol.</param>
        /// <param name="location">The location of the symbol.</param>
        [<Emit "new $0($1...)">] abstract Create: name: string * kind: SymbolKind * containerName: string * location: Location -> SymbolInformation
        /// <summary>Creates a new symbol information object.</summary>
        /// <param name="name">The name of the symbol.</param>
        /// <param name="kind">The kind of the symbol.</param>
        /// <param name="range">The range of the location of the symbol.</param>
        /// <param name="uri">The resource of the location of symbol, defaults to the current document.</param>
        /// <param name="containerName">The name of the symbol containing the symbol.</param>
        [<Emit "new $0($1...)">] abstract Create: name: string * kind: SymbolKind * range: Range * ?uri: Uri * ?containerName: string -> SymbolInformation

    /// Represents programming constructs like variables, classes, interfaces etc. that appear in a document. Document
    /// symbols can be hierarchical and they have two ranges: one that encloses its definition and one that points to
    /// its most interesting range, e.g. the range of an identifier.
    type [<AllowNullLiteral>] DocumentSymbol =
        /// The name of this symbol.
        abstract name: string with get, set
        /// More detail for this symbol, e.g. the signature of a function.
        abstract detail: string with get, set
        /// The kind of this symbol.
        abstract kind: SymbolKind with get, set
        /// Tags for this symbol.
        abstract tags: ResizeArray<SymbolTag> option with get, set
        /// The range enclosing this symbol not including leading/trailing whitespace but everything else, e.g. comments and code.
        abstract range: Range with get, set
        /// The range that should be selected and reveal when this symbol is being picked, e.g. the name of a function.
        /// Must be contained by the {@link DocumentSymbol.range `range`}.
        abstract selectionRange: Range with get, set
        /// Children of this symbol, e.g. properties of a class.
        abstract children: ResizeArray<DocumentSymbol> with get, set

    /// Represents programming constructs like variables, classes, interfaces etc. that appear in a document. Document
    /// symbols can be hierarchical and they have two ranges: one that encloses its definition and one that points to
    /// its most interesting range, e.g. the range of an identifier.
    type [<AllowNullLiteral>] DocumentSymbolStatic =
        /// <summary>Creates a new document symbol.</summary>
        /// <param name="name">The name of the symbol.</param>
        /// <param name="detail">Details for the symbol.</param>
        /// <param name="kind">The kind of the symbol.</param>
        /// <param name="range">The full range of the symbol.</param>
        /// <param name="selectionRange">The range that should be reveal.</param>
        [<Emit "new $0($1...)">] abstract Create: name: string * detail: string * kind: SymbolKind * range: Range * selectionRange: Range -> DocumentSymbol

    /// The document symbol provider interface defines the contract between extensions and
    /// the [go to symbol](https://code.visualstudio.com/docs/editor/editingevolved#_go-to-symbol)-feature.
    type [<AllowNullLiteral>] DocumentSymbolProvider =
        /// <summary>Provide symbol information for the given document.</summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="token">A cancellation token.</param>
        abstract provideDocumentSymbols: document: TextDocument * token: CancellationToken -> ProviderResult<U2<ResizeArray<SymbolInformation>, ResizeArray<DocumentSymbol>>>

    /// Metadata about a document symbol provider.
    type [<AllowNullLiteral>] DocumentSymbolProviderMetadata =
        /// A human-readable string that is shown when multiple outlines trees show for one document.
        abstract label: string option with get, set

    type WorkspaceSymbolProvider =
        WorkspaceSymbolProvider<obj>

    /// The workspace symbol provider interface defines the contract between extensions and
    /// the [symbol search](https://code.visualstudio.com/docs/editor/editingevolved#_open-symbol-by-name)-feature.
    type [<AllowNullLiteral>] WorkspaceSymbolProvider<'T> =
        /// <summary>Project-wide search for a symbol matching the given query string.
        /// 
        /// The `query`-parameter should be interpreted in a *relaxed way* as the editor will apply its own highlighting
        /// and scoring on the results. A good rule of thumb is to match case-insensitive and to simply check that the
        /// characters of *query* appear in their order in a candidate symbol. Don't use prefix, substring, or similar
        /// strict matching.
        /// 
        /// To improve performance implementors can implement `resolveWorkspaceSymbol` and then provide symbols with partial
        /// {@link SymbolInformation.location location}-objects, without a `range` defined. The editor will then call
        /// `resolveWorkspaceSymbol` for selected symbols only, e.g. when opening a workspace symbol.</summary>
        /// <param name="query">A query string, can be the empty string in which case all symbols should be returned.</param>
        /// <param name="token">A cancellation token.</param>
        abstract provideWorkspaceSymbols: query: string * token: CancellationToken -> ProviderResult<ResizeArray<'T>>
        /// <summary>Given a symbol fill in its {@link SymbolInformation.location location}. This method is called whenever a symbol
        /// is selected in the UI. Providers can implement this method and return incomplete symbols from
        /// {@link WorkspaceSymbolProvider.provideWorkspaceSymbols `provideWorkspaceSymbols`} which often helps to improve
        /// performance.</summary>
        /// <param name="symbol">The symbol that is to be resolved. Guaranteed to be an instance of an object returned from an
        /// earlier call to `provideWorkspaceSymbols`.</param>
        /// <param name="token">A cancellation token.</param>
        abstract resolveWorkspaceSymbol: symbol: 'T * token: CancellationToken -> ProviderResult<'T>

    /// Value-object that contains additional information when
    /// requesting references.
    type [<AllowNullLiteral>] ReferenceContext =
        /// Include the declaration of the current symbol.
        abstract includeDeclaration: bool with get, set

    /// The reference provider interface defines the contract between extensions and
    /// the [find references](https://code.visualstudio.com/docs/editor/editingevolved#_peek)-feature.
    type [<AllowNullLiteral>] ReferenceProvider =
        /// <summary>Provide a set of project-wide references for the given position and document.</summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="position">The position at which the command was invoked.</param>
        /// <param name="token">A cancellation token.</param>
        /// <param name="context"></param>
        abstract provideReferences: document: TextDocument * position: Position * context: ReferenceContext * token: CancellationToken -> ProviderResult<ResizeArray<Location>>

    /// A text edit represents edits that should be applied
    /// to a document.
    type [<AllowNullLiteral>] TextEdit =
        /// The range this edit applies to.
        abstract range: Range with get, set
        /// The string this edit will insert.
        abstract newText: string with get, set
        /// The eol-sequence used in the document.
        /// 
        /// *Note* that the eol-sequence will be applied to the
        /// whole document.
        abstract newEol: EndOfLine option with get, set

    /// A text edit represents edits that should be applied
    /// to a document.
    type [<AllowNullLiteral>] TextEditStatic =
        /// <summary>Utility to create a replace edit.</summary>
        /// <param name="range">A range.</param>
        /// <param name="newText">A string.</param>
        abstract replace: range: Range * newText: string -> TextEdit
        /// <summary>Utility to create an insert edit.</summary>
        /// <param name="position">A position, will become an empty range.</param>
        /// <param name="newText">A string.</param>
        abstract insert: position: Position * newText: string -> TextEdit
        /// <summary>Utility to create a delete edit.</summary>
        /// <param name="range">A range.</param>
        abstract delete: range: Range -> TextEdit
        /// <summary>Utility to create an eol-edit.</summary>
        /// <param name="eol">An eol-sequence</param>
        abstract setEndOfLine: eol: EndOfLine -> TextEdit
        /// <summary>Create a new TextEdit.</summary>
        /// <param name="range">A range.</param>
        /// <param name="newText">A string.</param>
        [<Emit "new $0($1...)">] abstract Create: range: Range * newText: string -> TextEdit

    /// Additional data for entries of a workspace edit. Supports to label entries and marks entries
    /// as needing confirmation by the user. The editor groups edits with equal labels into tree nodes,
    /// for instance all edits labelled with "Changes in Strings" would be a tree node.
    type [<AllowNullLiteral>] WorkspaceEditEntryMetadata =
        /// A flag which indicates that user confirmation is needed.
        abstract needsConfirmation: bool with get, set
        /// A human-readable string which is rendered prominent.
        abstract label: string with get, set
        /// A human-readable string which is rendered less prominent on the same line.
        abstract description: string option with get, set
        /// The icon path or {@link ThemeIcon} for the edit.
        abstract iconPath: U3<Uri, WorkspaceEditEntryMetadataIconPath, ThemeIcon> option with get, set

    /// A workspace edit is a collection of textual and files changes for
    /// multiple resources and documents.
    /// 
    /// Use the {@link workspace.applyEdit applyEdit}-function to apply a workspace edit.
    type [<AllowNullLiteral>] WorkspaceEdit =
        /// The number of affected resources of textual or resource changes.
        abstract size: float
        /// <summary>Replace the given range with given text for the given resource.</summary>
        /// <param name="uri">A resource identifier.</param>
        /// <param name="range">A range.</param>
        /// <param name="newText">A string.</param>
        /// <param name="metadata">Optional metadata for the entry.</param>
        abstract replace: uri: Uri * range: Range * newText: string * ?metadata: WorkspaceEditEntryMetadata -> unit
        /// <summary>Insert the given text at the given position.</summary>
        /// <param name="uri">A resource identifier.</param>
        /// <param name="position">A position.</param>
        /// <param name="newText">A string.</param>
        /// <param name="metadata">Optional metadata for the entry.</param>
        abstract insert: uri: Uri * position: Position * newText: string * ?metadata: WorkspaceEditEntryMetadata -> unit
        /// <summary>Delete the text at the given range.</summary>
        /// <param name="uri">A resource identifier.</param>
        /// <param name="range">A range.</param>
        /// <param name="metadata">Optional metadata for the entry.</param>
        abstract delete: uri: Uri * range: Range * ?metadata: WorkspaceEditEntryMetadata -> unit
        /// <summary>Check if a text edit for a resource exists.</summary>
        /// <param name="uri">A resource identifier.</param>
        abstract has: uri: Uri -> bool
        /// <summary>Set (and replace) text edits for a resource.</summary>
        /// <param name="uri">A resource identifier.</param>
        /// <param name="edits">An array of text edits.</param>
        abstract set: uri: Uri * edits: ResizeArray<TextEdit> -> unit
        /// <summary>Get the text edits for a resource.</summary>
        /// <param name="uri">A resource identifier.</param>
        abstract get: uri: Uri -> ResizeArray<TextEdit>
        /// <summary>Create a regular file.</summary>
        /// <param name="uri">Uri of the new file..</param>
        /// <param name="options">Defines if an existing file should be overwritten or be
        /// ignored. When overwrite and ignoreIfExists are both set overwrite wins.
        /// When both are unset and when the file already exists then the edit cannot
        /// be applied successfully.</param>
        /// <param name="metadata">Optional metadata for the entry.</param>
        abstract createFile: uri: Uri * ?options: WorkspaceEditCreateFileOptions * ?metadata: WorkspaceEditEntryMetadata -> unit
        /// <summary>Delete a file or folder.</summary>
        /// <param name="uri">The uri of the file that is to be deleted.</param>
        /// <param name="options"></param>
        /// <param name="metadata">Optional metadata for the entry.</param>
        abstract deleteFile: uri: Uri * ?options: WorkspaceEditDeleteFileOptions * ?metadata: WorkspaceEditEntryMetadata -> unit
        /// <summary>Rename a file or folder.</summary>
        /// <param name="oldUri">The existing file.</param>
        /// <param name="newUri">The new location.</param>
        /// <param name="options">Defines if existing files should be overwritten or be
        /// ignored. When overwrite and ignoreIfExists are both set overwrite wins.</param>
        /// <param name="metadata">Optional metadata for the entry.</param>
        abstract renameFile: oldUri: Uri * newUri: Uri * ?options: WorkspaceEditRenameFileOptions * ?metadata: WorkspaceEditEntryMetadata -> unit
        /// Get all text edits grouped by resource.
        abstract entries: unit -> ResizeArray<Uri * ResizeArray<TextEdit>>

    type [<AllowNullLiteral>] WorkspaceEditCreateFileOptions =
        abstract overwrite: bool option with get, set
        abstract ignoreIfExists: bool option with get, set

    type [<AllowNullLiteral>] WorkspaceEditDeleteFileOptions =
        abstract recursive: bool option with get, set
        abstract ignoreIfNotExists: bool option with get, set

    type [<AllowNullLiteral>] WorkspaceEditRenameFileOptions =
        abstract overwrite: bool option with get, set
        abstract ignoreIfExists: bool option with get, set

    /// A workspace edit is a collection of textual and files changes for
    /// multiple resources and documents.
    /// 
    /// Use the {@link workspace.applyEdit applyEdit}-function to apply a workspace edit.
    type [<AllowNullLiteral>] WorkspaceEditStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> WorkspaceEdit

    /// A snippet string is a template which allows to insert text
    /// and to control the editor cursor when insertion happens.
    /// 
    /// A snippet can define tab stops and placeholders with `$1`, `$2`
    /// and `${3:foo}`. `$0` defines the final tab stop, it defaults to
    /// the end of the snippet. Variables are defined with `$name` and
    /// `${name:default value}`. The full snippet syntax is documented
    /// [here](https://code.visualstudio.com/docs/editor/userdefinedsnippets#_creating-your-own-snippets).
    type [<AllowNullLiteral>] SnippetString =
        /// The snippet string.
        abstract value: string with get, set
        /// <summary>Builder-function that appends the given string to
        /// the {@link SnippetString.value `value`} of this snippet string.</summary>
        /// <param name="string">A value to append 'as given'. The string will be escaped.</param>
        abstract appendText: string: string -> SnippetString
        /// <summary>Builder-function that appends a tabstop (`$1`, `$2` etc) to
        /// the {@link SnippetString.value `value`} of this snippet string.</summary>
        /// <param name="number">The number of this tabstop, defaults to an auto-increment
        /// value starting at 1.</param>
        abstract appendTabstop: ?number: float -> SnippetString
        /// <summary>Builder-function that appends a placeholder (`${1:value}`) to
        /// the {@link SnippetString.value `value`} of this snippet string.</summary>
        /// <param name="value">The value of this placeholder - either a string or a function
        /// with which a nested snippet can be created.</param>
        /// <param name="number">The number of this tabstop, defaults to an auto-increment
        /// value starting at 1.</param>
        abstract appendPlaceholder: value: U2<string, (SnippetString -> obj option)> * ?number: float -> SnippetString
        /// <summary>Builder-function that appends a choice (`${1|a,b,c|}`) to
        /// the {@link SnippetString.value `value`} of this snippet string.</summary>
        /// <param name="values">The values for choices - the array of strings</param>
        /// <param name="number">The number of this tabstop, defaults to an auto-increment
        /// value starting at 1.</param>
        abstract appendChoice: values: ResizeArray<string> * ?number: float -> SnippetString
        /// <summary>Builder-function that appends a variable (`${VAR}`) to
        /// the {@link SnippetString.value `value`} of this snippet string.</summary>
        /// <param name="name">The name of the variable - excluding the `$`.</param>
        /// <param name="defaultValue">The default value which is used when the variable name cannot
        /// be resolved - either a string or a function with which a nested snippet can be created.</param>
        abstract appendVariable: name: string * defaultValue: U2<string, (SnippetString -> obj option)> -> SnippetString

    /// A snippet string is a template which allows to insert text
    /// and to control the editor cursor when insertion happens.
    /// 
    /// A snippet can define tab stops and placeholders with `$1`, `$2`
    /// and `${3:foo}`. `$0` defines the final tab stop, it defaults to
    /// the end of the snippet. Variables are defined with `$name` and
    /// `${name:default value}`. The full snippet syntax is documented
    /// [here](https://code.visualstudio.com/docs/editor/userdefinedsnippets#_creating-your-own-snippets).
    type [<AllowNullLiteral>] SnippetStringStatic =
        [<Emit "new $0($1...)">] abstract Create: ?value: string -> SnippetString

    /// The rename provider interface defines the contract between extensions and
    /// the [rename](https://code.visualstudio.com/docs/editor/editingevolved#_rename-symbol)-feature.
    type [<AllowNullLiteral>] RenameProvider =
        /// <summary>Provide an edit that describes changes that have to be made to one
        /// or many resources to rename a symbol to a different name.</summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="position">The position at which the command was invoked.</param>
        /// <param name="newName">The new name of the symbol. If the given name is not valid, the provider must return a rejected promise.</param>
        /// <param name="token">A cancellation token.</param>
        abstract provideRenameEdits: document: TextDocument * position: Position * newName: string * token: CancellationToken -> ProviderResult<WorkspaceEdit>
        /// <summary>Optional function for resolving and validating a position *before* running rename. The result can
        /// be a range or a range and a placeholder text. The placeholder text should be the identifier of the symbol
        /// which is being renamed - when omitted the text in the returned range is used.
        /// 
        /// *Note: * This function should throw an error or return a rejected thenable when the provided location
        /// doesn't allow for a rename.</summary>
        /// <param name="document">The document in which rename will be invoked.</param>
        /// <param name="position">The position at which rename will be invoked.</param>
        /// <param name="token">A cancellation token.</param>
        abstract prepareRename: document: TextDocument * position: Position * token: CancellationToken -> ProviderResult<U2<Range, RenameProviderPrepareRenameProviderResult>>

    /// A semantic tokens legend contains the needed information to decipher
    /// the integer encoded representation of semantic tokens.
    type [<AllowNullLiteral>] SemanticTokensLegend =
        /// The possible token types.
        abstract tokenTypes: ResizeArray<string>
        /// The possible token modifiers.
        abstract tokenModifiers: ResizeArray<string>

    /// A semantic tokens legend contains the needed information to decipher
    /// the integer encoded representation of semantic tokens.
    type [<AllowNullLiteral>] SemanticTokensLegendStatic =
        [<Emit "new $0($1...)">] abstract Create: tokenTypes: ResizeArray<string> * ?tokenModifiers: ResizeArray<string> -> SemanticTokensLegend

    /// A semantic tokens builder can help with creating a `SemanticTokens` instance
    /// which contains delta encoded semantic tokens.
    type [<AllowNullLiteral>] SemanticTokensBuilder =
        /// <summary>Add another token.</summary>
        /// <param name="line">The token start line number (absolute value).</param>
        /// <param name="char">The token start character (absolute value).</param>
        /// <param name="length">The token length in characters.</param>
        /// <param name="tokenType">The encoded token type.</param>
        /// <param name="tokenModifiers">The encoded token modifiers.</param>
        abstract push: line: float * char: float * length: float * tokenType: float * ?tokenModifiers: float -> unit
        /// <summary>Add another token. Use only when providing a legend.</summary>
        /// <param name="range">The range of the token. Must be single-line.</param>
        /// <param name="tokenType">The token type.</param>
        /// <param name="tokenModifiers">The token modifiers.</param>
        abstract push: range: Range * tokenType: string * ?tokenModifiers: ResizeArray<string> -> unit
        /// Finish and create a `SemanticTokens` instance.
        abstract build: ?resultId: string -> SemanticTokens

    /// A semantic tokens builder can help with creating a `SemanticTokens` instance
    /// which contains delta encoded semantic tokens.
    type [<AllowNullLiteral>] SemanticTokensBuilderStatic =
        [<Emit "new $0($1...)">] abstract Create: ?legend: SemanticTokensLegend -> SemanticTokensBuilder

    /// Represents semantic tokens, either in a range or in an entire document.
    type [<AllowNullLiteral>] SemanticTokens =
        /// The result id of the tokens.
        /// 
        /// This is the id that will be passed to `DocumentSemanticTokensProvider.provideDocumentSemanticTokensEdits` (if implemented).
        abstract resultId: string option
        /// The actual tokens data.
        abstract data: Uint32Array

    /// Represents semantic tokens, either in a range or in an entire document.
    type [<AllowNullLiteral>] SemanticTokensStatic =
        [<Emit "new $0($1...)">] abstract Create: data: Uint32Array * ?resultId: string -> SemanticTokens

    /// Represents edits to semantic tokens.
    type [<AllowNullLiteral>] SemanticTokensEdits =
        /// The result id of the tokens.
        /// 
        /// This is the id that will be passed to `DocumentSemanticTokensProvider.provideDocumentSemanticTokensEdits` (if implemented).
        abstract resultId: string option
        /// The edits to the tokens data.
        /// All edits refer to the initial data state.
        abstract edits: ResizeArray<SemanticTokensEdit>

    /// Represents edits to semantic tokens.
    type [<AllowNullLiteral>] SemanticTokensEditsStatic =
        [<Emit "new $0($1...)">] abstract Create: edits: ResizeArray<SemanticTokensEdit> * ?resultId: string -> SemanticTokensEdits

    /// Represents an edit to semantic tokens.
    type [<AllowNullLiteral>] SemanticTokensEdit =
        /// The start offset of the edit.
        abstract start: float
        /// The count of elements to remove.
        abstract deleteCount: float
        /// The elements to insert.
        abstract data: Uint32Array option

    /// Represents an edit to semantic tokens.
    type [<AllowNullLiteral>] SemanticTokensEditStatic =
        [<Emit "new $0($1...)">] abstract Create: start: float * deleteCount: float * ?data: Uint32Array -> SemanticTokensEdit

    /// The document semantic tokens provider interface defines the contract between extensions and
    /// semantic tokens.
    type [<AllowNullLiteral>] DocumentSemanticTokensProvider =
        /// An optional event to signal that the semantic tokens from this provider have changed.
        abstract onDidChangeSemanticTokens: Event<unit> option with get, set
        /// Tokens in a file are represented as an array of integers. The position of each token is expressed relative to
        /// the token before it, because most tokens remain stable relative to each other when edits are made in a file.
        /// 
        /// ---
        /// In short, each token takes 5 integers to represent, so a specific token `i` in the file consists of the following array indices:
        ///   - at index `5*i`   - `deltaLine`: token line number, relative to the previous token
        ///   - at index `5*i+1` - `deltaStart`: token start character, relative to the previous token (relative to 0 or the previous token's start if they are on the same line)
        ///   - at index `5*i+2` - `length`: the length of the token. A token cannot be multiline.
        ///   - at index `5*i+3` - `tokenType`: will be looked up in `SemanticTokensLegend.tokenTypes`. We currently ask that `tokenType` < 65536.
        ///   - at index `5*i+4` - `tokenModifiers`: each set bit will be looked up in `SemanticTokensLegend.tokenModifiers`
        /// 
        /// ---
        /// ### How to encode tokens
        /// 
        /// Here is an example for encoding a file with 3 tokens in a uint32 array:
        /// ```
        ///     { line: 2, startChar:  5, length: 3, tokenType: "property",  tokenModifiers: ["private", "static"] },
        ///     { line: 2, startChar: 10, length: 4, tokenType: "type",      tokenModifiers: [] },
        ///     { line: 5, startChar:  2, length: 7, tokenType: "class",     tokenModifiers: [] }
        /// ```
        /// 
        /// 1. First of all, a legend must be devised. This legend must be provided up-front and capture all possible token types.
        /// For this example, we will choose the following legend which must be passed in when registering the provider:
        /// ```
        ///     tokenTypes: ['property', 'type', 'class'],
        ///     tokenModifiers: ['private', 'static']
        /// ```
        /// 
        /// 2. The first transformation step is to encode `tokenType` and `tokenModifiers` as integers using the legend. Token types are looked
        /// up by index, so a `tokenType` value of `1` means `tokenTypes[1]`. Multiple token modifiers can be set by using bit flags,
        /// so a `tokenModifier` value of `3` is first viewed as binary `0b00000011`, which means `[tokenModifiers[0], tokenModifiers[1]]` because
        /// bits 0 and 1 are set. Using this legend, the tokens now are:
        /// ```
        ///     { line: 2, startChar:  5, length: 3, tokenType: 0, tokenModifiers: 3 },
        ///     { line: 2, startChar: 10, length: 4, tokenType: 1, tokenModifiers: 0 },
        ///     { line: 5, startChar:  2, length: 7, tokenType: 2, tokenModifiers: 0 }
        /// ```
        /// 
        /// 3. The next step is to represent each token relative to the previous token in the file. In this case, the second token
        /// is on the same line as the first token, so the `startChar` of the second token is made relative to the `startChar`
        /// of the first token, so it will be `10 - 5`. The third token is on a different line than the second token, so the
        /// `startChar` of the third token will not be altered:
        /// ```
        ///     { deltaLine: 2, deltaStartChar: 5, length: 3, tokenType: 0, tokenModifiers: 3 },
        ///     { deltaLine: 0, deltaStartChar: 5, length: 4, tokenType: 1, tokenModifiers: 0 },
        ///     { deltaLine: 3, deltaStartChar: 2, length: 7, tokenType: 2, tokenModifiers: 0 }
        /// ```
        /// 
        /// 4. Finally, the last step is to inline each of the 5 fields for a token in a single array, which is a memory friendly representation:
        /// ```
        ///     // 1st token,  2nd token,  3rd token
        ///     [  2,5,3,0,3,  0,5,4,1,0,  3,2,7,2,0 ]
        /// ```
        abstract provideDocumentSemanticTokens: document: TextDocument * token: CancellationToken -> ProviderResult<SemanticTokens>
        /// Instead of always returning all the tokens in a file, it is possible for a `DocumentSemanticTokensProvider` to implement
        /// this method (`provideDocumentSemanticTokensEdits`) and then return incremental updates to the previously provided semantic tokens.
        /// 
        /// ---
        /// ### How tokens change when the document changes
        /// 
        /// Suppose that `provideDocumentSemanticTokens` has previously returned the following semantic tokens:
        /// ```
        ///     // 1st token,  2nd token,  3rd token
        ///     [  2,5,3,0,3,  0,5,4,1,0,  3,2,7,2,0 ]
        /// ```
        /// 
        /// Also suppose that after some edits, the new semantic tokens in a file are:
        /// ```
        ///     // 1st token,  2nd token,  3rd token
        ///     [  3,5,3,0,3,  0,5,4,1,0,  3,2,7,2,0 ]
        /// ```
        /// It is possible to express these new tokens in terms of an edit applied to the previous tokens:
        /// ```
        ///     [  2,5,3,0,3,  0,5,4,1,0,  3,2,7,2,0 ] // old tokens
        ///     [  3,5,3,0,3,  0,5,4,1,0,  3,2,7,2,0 ] // new tokens
        /// 
        ///     edit: { start:  0, deleteCount: 1, data: [3] } // replace integer at offset 0 with 3
        /// ```
        /// 
        /// *NOTE*: If the provider cannot compute `SemanticTokensEdits`, it can "give up" and return all the tokens in the document again.
        /// *NOTE*: All edits in `SemanticTokensEdits` contain indices in the old integers array, so they all refer to the previous result state.
        abstract provideDocumentSemanticTokensEdits: document: TextDocument * previousResultId: string * token: CancellationToken -> ProviderResult<U2<SemanticTokens, SemanticTokensEdits>>

    /// The document range semantic tokens provider interface defines the contract between extensions and
    /// semantic tokens.
    type [<AllowNullLiteral>] DocumentRangeSemanticTokensProvider =
        abstract provideDocumentRangeSemanticTokens: document: TextDocument * range: Range * token: CancellationToken -> ProviderResult<SemanticTokens>

    /// Value-object describing what options formatting should use.
    type [<AllowNullLiteral>] FormattingOptions =
        /// Size of a tab in spaces.
        abstract tabSize: float with get, set
        /// Prefer spaces over tabs.
        abstract insertSpaces: bool with get, set
        /// Signature for further properties.
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> U3<bool, float, string> with get, set

    /// The document formatting provider interface defines the contract between extensions and
    /// the formatting-feature.
    type [<AllowNullLiteral>] DocumentFormattingEditProvider =
        /// <summary>Provide formatting edits for a whole document.</summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="options">Options controlling formatting.</param>
        /// <param name="token">A cancellation token.</param>
        abstract provideDocumentFormattingEdits: document: TextDocument * options: FormattingOptions * token: CancellationToken -> ProviderResult<ResizeArray<TextEdit>>

    /// The document formatting provider interface defines the contract between extensions and
    /// the formatting-feature.
    type [<AllowNullLiteral>] DocumentRangeFormattingEditProvider =
        /// <summary>Provide formatting edits for a range in a document.
        /// 
        /// The given range is a hint and providers can decide to format a smaller
        /// or larger range. Often this is done by adjusting the start and end
        /// of the range to full syntax nodes.</summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="range">The range which should be formatted.</param>
        /// <param name="options">Options controlling formatting.</param>
        /// <param name="token">A cancellation token.</param>
        abstract provideDocumentRangeFormattingEdits: document: TextDocument * range: Range * options: FormattingOptions * token: CancellationToken -> ProviderResult<ResizeArray<TextEdit>>

    /// The document formatting provider interface defines the contract between extensions and
    /// the formatting-feature.
    type [<AllowNullLiteral>] OnTypeFormattingEditProvider =
        /// <summary>Provide formatting edits after a character has been typed.
        /// 
        /// The given position and character should hint to the provider
        /// what range the position to expand to, like find the matching `{`
        /// when `}` has been entered.</summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="position">The position at which the command was invoked.</param>
        /// <param name="ch">The character that has been typed.</param>
        /// <param name="options">Options controlling formatting.</param>
        /// <param name="token">A cancellation token.</param>
        abstract provideOnTypeFormattingEdits: document: TextDocument * position: Position * ch: string * options: FormattingOptions * token: CancellationToken -> ProviderResult<ResizeArray<TextEdit>>

    /// Represents a parameter of a callable-signature. A parameter can
    /// have a label and a doc-comment.
    type [<AllowNullLiteral>] ParameterInformation =
        /// The label of this signature.
        /// 
        /// Either a string or inclusive start and exclusive end offsets within its containing
        /// {@link SignatureInformation.label signature label}. *Note*: A label of type string must be
        /// a substring of its containing signature information's {@link SignatureInformation.label label}.
        abstract label: U2<string, float * float> with get, set
        /// The human-readable doc-comment of this signature. Will be shown
        /// in the UI but can be omitted.
        abstract documentation: U2<string, MarkdownString> option with get, set

    /// Represents a parameter of a callable-signature. A parameter can
    /// have a label and a doc-comment.
    type [<AllowNullLiteral>] ParameterInformationStatic =
        /// <summary>Creates a new parameter information object.</summary>
        /// <param name="label">A label string or inclusive start and exclusive end offsets within its containing signature label.</param>
        /// <param name="documentation">A doc string.</param>
        [<Emit "new $0($1...)">] abstract Create: label: U2<string, float * float> * ?documentation: U2<string, MarkdownString> -> ParameterInformation

    /// Represents the signature of something callable. A signature
    /// can have a label, like a function-name, a doc-comment, and
    /// a set of parameters.
    type [<AllowNullLiteral>] SignatureInformation =
        /// The label of this signature. Will be shown in
        /// the UI.
        abstract label: string with get, set
        /// The human-readable doc-comment of this signature. Will be shown
        /// in the UI but can be omitted.
        abstract documentation: U2<string, MarkdownString> option with get, set
        /// The parameters of this signature.
        abstract parameters: ResizeArray<ParameterInformation> with get, set
        /// The index of the active parameter.
        /// 
        /// If provided, this is used in place of {@link SignatureHelp.activeSignature `SignatureHelp.activeSignature`}.
        abstract activeParameter: float option with get, set

    /// Represents the signature of something callable. A signature
    /// can have a label, like a function-name, a doc-comment, and
    /// a set of parameters.
    type [<AllowNullLiteral>] SignatureInformationStatic =
        /// <summary>Creates a new signature information object.</summary>
        /// <param name="label">A label string.</param>
        /// <param name="documentation">A doc string.</param>
        [<Emit "new $0($1...)">] abstract Create: label: string * ?documentation: U2<string, MarkdownString> -> SignatureInformation

    /// Signature help represents the signature of something
    /// callable. There can be multiple signatures but only one
    /// active and only one active parameter.
    type [<AllowNullLiteral>] SignatureHelp =
        /// One or more signatures.
        abstract signatures: ResizeArray<SignatureInformation> with get, set
        /// The active signature.
        abstract activeSignature: float with get, set
        /// The active parameter of the active signature.
        abstract activeParameter: float with get, set

    /// Signature help represents the signature of something
    /// callable. There can be multiple signatures but only one
    /// active and only one active parameter.
    type [<AllowNullLiteral>] SignatureHelpStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> SignatureHelp

    type [<RequireQualifiedAccess>] SignatureHelpTriggerKind =
        | Invoke = 1
        | TriggerCharacter = 2
        | ContentChange = 3

    /// Additional information about the context in which a
    /// {@link SignatureHelpProvider.provideSignatureHelp `SignatureHelpProvider`} was triggered.
    type [<AllowNullLiteral>] SignatureHelpContext =
        /// Action that caused signature help to be triggered.
        abstract triggerKind: SignatureHelpTriggerKind
        /// Character that caused signature help to be triggered.
        /// 
        /// This is `undefined` when signature help is not triggered by typing, such as when manually invoking
        /// signature help or when moving the cursor.
        abstract triggerCharacter: string option
        /// `true` if signature help was already showing when it was triggered.
        /// 
        /// Retriggers occur when the signature help is already active and can be caused by actions such as
        /// typing a trigger character, a cursor move, or document content changes.
        abstract isRetrigger: bool
        /// The currently active {@link SignatureHelp `SignatureHelp`}.
        /// 
        /// The `activeSignatureHelp` has its [`SignatureHelp.activeSignature`] field updated based on
        /// the user arrowing through available signatures.
        abstract activeSignatureHelp: SignatureHelp option

    /// The signature help provider interface defines the contract between extensions and
    /// the [parameter hints](https://code.visualstudio.com/docs/editor/intellisense)-feature.
    type [<AllowNullLiteral>] SignatureHelpProvider =
        /// <summary>Provide help for the signature at the given position and document.</summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="position">The position at which the command was invoked.</param>
        /// <param name="token">A cancellation token.</param>
        /// <param name="context">Information about how signature help was triggered.</param>
        abstract provideSignatureHelp: document: TextDocument * position: Position * token: CancellationToken * context: SignatureHelpContext -> ProviderResult<SignatureHelp>

    /// Metadata about a registered {@link SignatureHelpProvider `SignatureHelpProvider`}.
    type [<AllowNullLiteral>] SignatureHelpProviderMetadata =
        /// List of characters that trigger signature help.
        abstract triggerCharacters: ResizeArray<string>
        /// List of characters that re-trigger signature help.
        /// 
        /// These trigger characters are only active when signature help is already showing. All trigger characters
        /// are also counted as re-trigger characters.
        abstract retriggerCharacters: ResizeArray<string>

    /// A structured label for a {@link CompletionItem completion item}.
    type [<AllowNullLiteral>] CompletionItemLabel =
        /// The label of this completion item.
        /// 
        /// By default this is also the text that is inserted when this completion is selected.
        abstract label: string with get, set
        /// An optional string which is rendered less prominently directly after {@link CompletionItemLabel.label label},
        /// without any spacing. Should be used for function signatures or type annotations.
        abstract detail: string option with get, set
        /// An optional string which is rendered less prominently after {@link CompletionItemLabel.detail}. Should be used
        /// for fully qualified names or file path.
        abstract description: string option with get, set

    type [<RequireQualifiedAccess>] CompletionItemKind =
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
        | Reference = 17
        | File = 16
        | Folder = 18
        | EnumMember = 19
        | Constant = 20
        | Struct = 21
        | Event = 22
        | Operator = 23
        | TypeParameter = 24
        | User = 25
        | Issue = 26

    type [<RequireQualifiedAccess>] CompletionItemTag =
        | Deprecated = 1

    /// A completion item represents a text snippet that is proposed to complete text that is being typed.
    /// 
    /// It is sufficient to create a completion item from just a {@link CompletionItem.label label}. In that
    /// case the completion item will replace the {@link TextDocument.getWordRangeAtPosition word}
    /// until the cursor with the given label or {@link CompletionItem.insertText insertText}. Otherwise the
    /// given {@link CompletionItem.textEdit edit} is used.
    /// 
    /// When selecting a completion item in the editor its defined or synthesized text edit will be applied
    /// to *all* cursors/selections whereas {@link CompletionItem.additionalTextEdits additionalTextEdits} will be
    /// applied as provided.
    type [<AllowNullLiteral>] CompletionItem =
        /// The label of this completion item. By default
        /// this is also the text that is inserted when selecting
        /// this completion.
        abstract label: U2<string, CompletionItemLabel> with get, set
        /// The kind of this completion item. Based on the kind
        /// an icon is chosen by the editor.
        abstract kind: CompletionItemKind option with get, set
        /// Tags for this completion item.
        abstract tags: ResizeArray<CompletionItemTag> option with get, set
        /// A human-readable string with additional information
        /// about this item, like type or symbol information.
        abstract detail: string option with get, set
        /// A human-readable string that represents a doc-comment.
        abstract documentation: U2<string, MarkdownString> option with get, set
        /// A string that should be used when comparing this item
        /// with other items. When `falsy` the {@link CompletionItem.label label}
        /// is used.
        /// 
        /// Note that `sortText` is only used for the initial ordering of completion
        /// items. When having a leading word (prefix) ordering is based on how
        /// well completions match that prefix and the initial ordering is only used
        /// when completions match equally well. The prefix is defined by the
        /// {@link CompletionItem.range `range`}-property and can therefore be different
        /// for each completion.
        abstract sortText: string option with get, set
        /// A string that should be used when filtering a set of
        /// completion items. When `falsy` the {@link CompletionItem.label label}
        /// is used.
        /// 
        /// Note that the filter text is matched against the leading word (prefix) which is defined
        /// by the {@link CompletionItem.range `range`}-property.
        abstract filterText: string option with get, set
        /// Select this item when showing. *Note* that only one completion item can be selected and
        /// that the editor decides which item that is. The rule is that the *first* item of those
        /// that match best is selected.
        abstract preselect: bool option with get, set
        /// A string or snippet that should be inserted in a document when selecting
        /// this completion. When `falsy` the {@link CompletionItem.label label}
        /// is used.
        abstract insertText: U2<string, SnippetString> option with get, set
        /// A range or a insert and replace range selecting the text that should be replaced by this completion item.
        /// 
        /// When omitted, the range of the {@link TextDocument.getWordRangeAtPosition current word} is used as replace-range
        /// and as insert-range the start of the {@link TextDocument.getWordRangeAtPosition current word} to the
        /// current position is used.
        /// 
        /// *Note 1:* A range must be a {@link Range.isSingleLine single line} and it must
        /// {@link Range.contains contain} the position at which completion has been {@link CompletionItemProvider.provideCompletionItems requested}.
        /// *Note 2:* A insert range must be a prefix of a replace range, that means it must be contained and starting at the same position.
        abstract range: U2<Range, CompletionItemRange> option with get, set
        /// An optional set of characters that when pressed while this completion is active will accept it first and
        /// then type that character. *Note* that all commit characters should have `length=1` and that superfluous
        /// characters will be ignored.
        abstract commitCharacters: ResizeArray<string> option with get, set
        /// Keep whitespace of the {@link CompletionItem.insertText insertText} as is. By default, the editor adjusts leading
        /// whitespace of new lines so that they match the indentation of the line for which the item is accepted - setting
        /// this to `true` will prevent that.
        abstract keepWhitespace: bool option with get, set
        abstract textEdit: TextEdit option with get, set
        /// An optional array of additional {@link TextEdit text edits} that are applied when
        /// selecting this completion. Edits must not overlap with the main {@link CompletionItem.textEdit edit}
        /// nor with themselves.
        abstract additionalTextEdits: ResizeArray<TextEdit> option with get, set
        /// An optional {@link Command} that is executed *after* inserting this completion. *Note* that
        /// additional modifications to the current document should be described with the
        /// {@link CompletionItem.additionalTextEdits additionalTextEdits}-property.
        abstract command: Command option with get, set

    /// A completion item represents a text snippet that is proposed to complete text that is being typed.
    /// 
    /// It is sufficient to create a completion item from just a {@link CompletionItem.label label}. In that
    /// case the completion item will replace the {@link TextDocument.getWordRangeAtPosition word}
    /// until the cursor with the given label or {@link CompletionItem.insertText insertText}. Otherwise the
    /// given {@link CompletionItem.textEdit edit} is used.
    /// 
    /// When selecting a completion item in the editor its defined or synthesized text edit will be applied
    /// to *all* cursors/selections whereas {@link CompletionItem.additionalTextEdits additionalTextEdits} will be
    /// applied as provided.
    type [<AllowNullLiteral>] CompletionItemStatic =
        /// <summary>Creates a new completion item.
        /// 
        /// Completion items must have at least a {@link CompletionItem.label label} which then
        /// will be used as insert text as well as for sorting and filtering.</summary>
        /// <param name="label">The label of the completion.</param>
        /// <param name="kind">The {@link CompletionItemKind kind} of the completion.</param>
        [<Emit "new $0($1...)">] abstract Create: label: U2<string, CompletionItemLabel> * ?kind: CompletionItemKind -> CompletionItem

    type CompletionList =
        CompletionList<obj>

    /// Represents a collection of {@link CompletionItem completion items} to be presented
    /// in the editor.
    type [<AllowNullLiteral>] CompletionList<'T> =
        /// This list is not complete. Further typing should result in recomputing
        /// this list.
        abstract isIncomplete: bool option with get, set
        /// The completion items.
        abstract items: ResizeArray<'T> with get, set

    /// Represents a collection of {@link CompletionItem completion items} to be presented
    /// in the editor.
    type [<AllowNullLiteral>] CompletionListStatic =
        /// <summary>Creates a new completion list.</summary>
        /// <param name="items">The completion items.</param>
        /// <param name="isIncomplete">The list is not complete.</param>
        [<Emit "new $0($1...)">] abstract Create: ?items: ResizeArray<'T> * ?isIncomplete: bool -> CompletionList<'T>

    type [<RequireQualifiedAccess>] CompletionTriggerKind =
        | Invoke = 0
        | TriggerCharacter = 1
        | TriggerForIncompleteCompletions = 2

    /// Contains additional information about the context in which
    /// {@link CompletionItemProvider.provideCompletionItems completion provider} is triggered.
    type [<AllowNullLiteral>] CompletionContext =
        /// How the completion was triggered.
        abstract triggerKind: CompletionTriggerKind
        /// Character that triggered the completion item provider.
        /// 
        /// `undefined` if provider was not triggered by a character.
        /// 
        /// The trigger character is already in the document when the completion provider is triggered.
        abstract triggerCharacter: string option

    type CompletionItemProvider =
        CompletionItemProvider<obj>

    /// The completion item provider interface defines the contract between extensions and
    /// [IntelliSense](https://code.visualstudio.com/docs/editor/intellisense).
    /// 
    /// Providers can delay the computation of the {@link CompletionItem.detail `detail`}
    /// and {@link CompletionItem.documentation `documentation`} properties by implementing the
    /// {@link CompletionItemProvider.resolveCompletionItem `resolveCompletionItem`}-function. However, properties that
    /// are needed for the initial sorting and filtering, like `sortText`, `filterText`, `insertText`, and `range`, must
    /// not be changed during resolve.
    /// 
    /// Providers are asked for completions either explicitly by a user gesture or -depending on the configuration-
    /// implicitly when typing words or trigger characters.
    type [<AllowNullLiteral>] CompletionItemProvider<'T> =
        /// <summary>Provide completion items for the given position and document.</summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="position">The position at which the command was invoked.</param>
        /// <param name="token">A cancellation token.</param>
        /// <param name="context">How the completion was triggered.</param>
        abstract provideCompletionItems: document: TextDocument * position: Position * token: CancellationToken * context: CompletionContext -> ProviderResult<U2<ResizeArray<'T>, CompletionList<'T>>>
        /// <summary>Given a completion item fill in more data, like {@link CompletionItem.documentation doc-comment}
        /// or {@link CompletionItem.detail details}.
        /// 
        /// The editor will only resolve a completion item once.
        /// 
        /// *Note* that this function is called when completion items are already showing in the UI or when an item has been
        /// selected for insertion. Because of that, no property that changes the presentation (label, sorting, filtering etc)
        /// or the (primary) insert behaviour ({@link CompletionItem.insertText insertText}) can be changed.
        /// 
        /// This function may fill in {@link CompletionItem.additionalTextEdits additionalTextEdits}. However, that means an item might be
        /// inserted *before* resolving is done and in that case the editor will do a best effort to still apply those additional
        /// text edits.</summary>
        /// <param name="item">A completion item currently active in the UI.</param>
        /// <param name="token">A cancellation token.</param>
        abstract resolveCompletionItem: item: 'T * token: CancellationToken -> ProviderResult<'T>

    /// A document link is a range in a text document that links to an internal or external resource, like another
    /// text document or a web site.
    type [<AllowNullLiteral>] DocumentLink =
        /// The range this link applies to.
        abstract range: Range with get, set
        /// The uri this link points to.
        abstract target: Uri option with get, set
        /// The tooltip text when you hover over this link.
        /// 
        /// If a tooltip is provided, is will be displayed in a string that includes instructions on how to
        /// trigger the link, such as `{0} (ctrl + click)`. The specific instructions vary depending on OS,
        /// user settings, and localization.
        abstract tooltip: string option with get, set

    /// A document link is a range in a text document that links to an internal or external resource, like another
    /// text document or a web site.
    type [<AllowNullLiteral>] DocumentLinkStatic =
        /// <summary>Creates a new document link.</summary>
        /// <param name="range">The range the document link applies to. Must not be empty.</param>
        /// <param name="target">The uri the document link points to.</param>
        [<Emit "new $0($1...)">] abstract Create: range: Range * ?target: Uri -> DocumentLink

    type DocumentLinkProvider =
        DocumentLinkProvider<obj>

    /// The document link provider defines the contract between extensions and feature of showing
    /// links in the editor.
    type [<AllowNullLiteral>] DocumentLinkProvider<'T> =
        /// <summary>Provide links for the given document. Note that the editor ships with a default provider that detects
        /// `http(s)` and `file` links.</summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="token">A cancellation token.</param>
        abstract provideDocumentLinks: document: TextDocument * token: CancellationToken -> ProviderResult<ResizeArray<'T>>
        /// <summary>Given a link fill in its {@link DocumentLink.target target}. This method is called when an incomplete
        /// link is selected in the UI. Providers can implement this method and return incomplete links
        /// (without target) from the {@link DocumentLinkProvider.provideDocumentLinks `provideDocumentLinks`} method which
        /// often helps to improve performance.</summary>
        /// <param name="link">The link that is to be resolved.</param>
        /// <param name="token">A cancellation token.</param>
        abstract resolveDocumentLink: link: 'T * token: CancellationToken -> ProviderResult<'T>

    /// Represents a color in RGBA space.
    type [<AllowNullLiteral>] Color =
        /// The red component of this color in the range [0-1].
        abstract red: float
        /// The green component of this color in the range [0-1].
        abstract green: float
        /// The blue component of this color in the range [0-1].
        abstract blue: float
        /// The alpha component of this color in the range [0-1].
        abstract alpha: float

    /// Represents a color in RGBA space.
    type [<AllowNullLiteral>] ColorStatic =
        /// <summary>Creates a new color instance.</summary>
        /// <param name="red">The red component.</param>
        /// <param name="green">The green component.</param>
        /// <param name="blue">The blue component.</param>
        /// <param name="alpha">The alpha component.</param>
        [<Emit "new $0($1...)">] abstract Create: red: float * green: float * blue: float * alpha: float -> Color

    /// Represents a color range from a document.
    type [<AllowNullLiteral>] ColorInformation =
        /// The range in the document where this color appears.
        abstract range: Range with get, set
        /// The actual color value for this color range.
        abstract color: Color with get, set

    /// Represents a color range from a document.
    type [<AllowNullLiteral>] ColorInformationStatic =
        /// <summary>Creates a new color range.</summary>
        /// <param name="range">The range the color appears in. Must not be empty.</param>
        /// <param name="color">The value of the color.</param>
        [<Emit "new $0($1...)">] abstract Create: range: Range * color: Color -> ColorInformation

    /// A color presentation object describes how a {@link Color `color`} should be represented as text and what
    /// edits are required to refer to it from source code.
    /// 
    /// For some languages one color can have multiple presentations, e.g. css can represent the color red with
    /// the constant `Red`, the hex-value `#ff0000`, or in rgba and hsla forms. In csharp other representations
    /// apply, e.g. `System.Drawing.Color.Red`.
    type [<AllowNullLiteral>] ColorPresentation =
        /// The label of this color presentation. It will be shown on the color
        /// picker header. By default this is also the text that is inserted when selecting
        /// this color presentation.
        abstract label: string with get, set
        /// An {@link TextEdit edit} which is applied to a document when selecting
        /// this presentation for the color.  When `falsy` the {@link ColorPresentation.label label}
        /// is used.
        abstract textEdit: TextEdit option with get, set
        /// An optional array of additional {@link TextEdit text edits} that are applied when
        /// selecting this color presentation. Edits must not overlap with the main {@link ColorPresentation.textEdit edit} nor with themselves.
        abstract additionalTextEdits: ResizeArray<TextEdit> option with get, set

    /// A color presentation object describes how a {@link Color `color`} should be represented as text and what
    /// edits are required to refer to it from source code.
    /// 
    /// For some languages one color can have multiple presentations, e.g. css can represent the color red with
    /// the constant `Red`, the hex-value `#ff0000`, or in rgba and hsla forms. In csharp other representations
    /// apply, e.g. `System.Drawing.Color.Red`.
    type [<AllowNullLiteral>] ColorPresentationStatic =
        /// <summary>Creates a new color presentation.</summary>
        /// <param name="label">The label of this color presentation.</param>
        [<Emit "new $0($1...)">] abstract Create: label: string -> ColorPresentation

    /// The document color provider defines the contract between extensions and feature of
    /// picking and modifying colors in the editor.
    type [<AllowNullLiteral>] DocumentColorProvider =
        /// <summary>Provide colors for the given document.</summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="token">A cancellation token.</param>
        abstract provideDocumentColors: document: TextDocument * token: CancellationToken -> ProviderResult<ResizeArray<ColorInformation>>
        /// <summary>Provide {@link ColorPresentation representations} for a color.</summary>
        /// <param name="color">The color to show and insert.</param>
        /// <param name="context">A context object with additional information</param>
        /// <param name="token">A cancellation token.</param>
        abstract provideColorPresentations: color: Color * context: DocumentColorProviderProvideColorPresentationsContext * token: CancellationToken -> ProviderResult<ResizeArray<ColorPresentation>>

    type [<AllowNullLiteral>] DocumentColorProviderProvideColorPresentationsContext =
        abstract document: TextDocument with get, set
        abstract range: Range with get, set

    /// A line based folding range. To be valid, start and end line must be bigger than zero and smaller than the number of lines in the document.
    /// Invalid ranges will be ignored.
    type [<AllowNullLiteral>] FoldingRange =
        /// The zero-based start line of the range to fold. The folded area starts after the line's last character.
        /// To be valid, the end must be zero or larger and smaller than the number of lines in the document.
        abstract start: float with get, set
        /// The zero-based end line of the range to fold. The folded area ends with the line's last character.
        /// To be valid, the end must be zero or larger and smaller than the number of lines in the document.
        abstract ``end``: float with get, set
        /// Describes the {@link FoldingRangeKind Kind} of the folding range such as {@link FoldingRangeKind.Comment Comment} or
        /// {@link FoldingRangeKind.Region Region}. The kind is used to categorize folding ranges and used by commands
        /// like 'Fold all comments'. See
        /// {@link FoldingRangeKind} for an enumeration of all kinds.
        /// If not set, the range is originated from a syntax element.
        abstract kind: FoldingRangeKind option with get, set

    /// A line based folding range. To be valid, start and end line must be bigger than zero and smaller than the number of lines in the document.
    /// Invalid ranges will be ignored.
    type [<AllowNullLiteral>] FoldingRangeStatic =
        /// <summary>Creates a new folding range.</summary>
        /// <param name="start">The start line of the folded range.</param>
        /// <param name="end">The end line of the folded range.</param>
        /// <param name="kind">The kind of the folding range.</param>
        [<Emit "new $0($1...)">] abstract Create: start: float * ``end``: float * ?kind: FoldingRangeKind -> FoldingRange

    type [<RequireQualifiedAccess>] FoldingRangeKind =
        | Comment = 1
        | Imports = 2
        | Region = 3

    /// Folding context (for future use)
    type [<AllowNullLiteral>] FoldingContext =
        interface end

    /// The folding range provider interface defines the contract between extensions and
    /// [Folding](https://code.visualstudio.com/docs/editor/codebasics#_folding) in the editor.
    type [<AllowNullLiteral>] FoldingRangeProvider =
        /// An optional event to signal that the folding ranges from this provider have changed.
        abstract onDidChangeFoldingRanges: Event<unit> option with get, set
        /// <summary>Returns a list of folding ranges or null and undefined if the provider
        /// does not want to participate or was cancelled.</summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="context">Additional context information (for future use)</param>
        /// <param name="token">A cancellation token.</param>
        abstract provideFoldingRanges: document: TextDocument * context: FoldingContext * token: CancellationToken -> ProviderResult<ResizeArray<FoldingRange>>

    /// A selection range represents a part of a selection hierarchy. A selection range
    /// may have a parent selection range that contains it.
    type [<AllowNullLiteral>] SelectionRange =
        /// The {@link Range} of this selection range.
        abstract range: Range with get, set
        /// The parent selection range containing this range.
        abstract parent: SelectionRange option with get, set

    /// A selection range represents a part of a selection hierarchy. A selection range
    /// may have a parent selection range that contains it.
    type [<AllowNullLiteral>] SelectionRangeStatic =
        /// <summary>Creates a new selection range.</summary>
        /// <param name="range">The range of the selection range.</param>
        /// <param name="parent">The parent of the selection range.</param>
        [<Emit "new $0($1...)">] abstract Create: range: Range * ?parent: SelectionRange -> SelectionRange

    type [<AllowNullLiteral>] SelectionRangeProvider =
        /// <summary>Provide selection ranges for the given positions.
        /// 
        /// Selection ranges should be computed individually and independent for each position. The editor will merge
        /// and deduplicate ranges but providers must return hierarchies of selection ranges so that a range
        /// is {@link Range.contains contained} by its parent.</summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="positions">The positions at which the command was invoked.</param>
        /// <param name="token">A cancellation token.</param>
        abstract provideSelectionRanges: document: TextDocument * positions: ResizeArray<Position> * token: CancellationToken -> ProviderResult<ResizeArray<SelectionRange>>

    /// Represents programming constructs like functions or constructors in the context
    /// of call hierarchy.
    type [<AllowNullLiteral>] CallHierarchyItem =
        /// The name of this item.
        abstract name: string with get, set
        /// The kind of this item.
        abstract kind: SymbolKind with get, set
        /// Tags for this item.
        abstract tags: ResizeArray<SymbolTag> option with get, set
        /// More detail for this item, e.g. the signature of a function.
        abstract detail: string option with get, set
        /// The resource identifier of this item.
        abstract uri: Uri with get, set
        /// The range enclosing this symbol not including leading/trailing whitespace but everything else, e.g. comments and code.
        abstract range: Range with get, set
        /// The range that should be selected and revealed when this symbol is being picked, e.g. the name of a function.
        /// Must be contained by the {@link CallHierarchyItem.range `range`}.
        abstract selectionRange: Range with get, set

    /// Represents programming constructs like functions or constructors in the context
    /// of call hierarchy.
    type [<AllowNullLiteral>] CallHierarchyItemStatic =
        /// Creates a new call hierarchy item.
        [<Emit "new $0($1...)">] abstract Create: kind: SymbolKind * name: string * detail: string * uri: Uri * range: Range * selectionRange: Range -> CallHierarchyItem

    /// Represents an incoming call, e.g. a caller of a method or constructor.
    type [<AllowNullLiteral>] CallHierarchyIncomingCall =
        /// The item that makes the call.
        abstract from: CallHierarchyItem with get, set
        /// The range at which at which the calls appears. This is relative to the caller
        /// denoted by {@link CallHierarchyIncomingCall.from `this.from`}.
        abstract fromRanges: ResizeArray<Range> with get, set

    /// Represents an incoming call, e.g. a caller of a method or constructor.
    type [<AllowNullLiteral>] CallHierarchyIncomingCallStatic =
        /// <summary>Create a new call object.</summary>
        /// <param name="item">The item making the call.</param>
        /// <param name="fromRanges">The ranges at which the calls appear.</param>
        [<Emit "new $0($1...)">] abstract Create: item: CallHierarchyItem * fromRanges: ResizeArray<Range> -> CallHierarchyIncomingCall

    /// Represents an outgoing call, e.g. calling a getter from a method or a method from a constructor etc.
    type [<AllowNullLiteral>] CallHierarchyOutgoingCall =
        /// The item that is called.
        abstract ``to``: CallHierarchyItem with get, set
        /// The range at which this item is called. This is the range relative to the caller, e.g the item
        /// passed to {@link CallHierarchyProvider.provideCallHierarchyOutgoingCalls `provideCallHierarchyOutgoingCalls`}
        /// and not {@link CallHierarchyOutgoingCall.to `this.to`}.
        abstract fromRanges: ResizeArray<Range> with get, set

    /// Represents an outgoing call, e.g. calling a getter from a method or a method from a constructor etc.
    type [<AllowNullLiteral>] CallHierarchyOutgoingCallStatic =
        /// <summary>Create a new call object.</summary>
        /// <param name="item">The item being called</param>
        /// <param name="fromRanges">The ranges at which the calls appear.</param>
        [<Emit "new $0($1...)">] abstract Create: item: CallHierarchyItem * fromRanges: ResizeArray<Range> -> CallHierarchyOutgoingCall

    /// The call hierarchy provider interface describes the contract between extensions
    /// and the call hierarchy feature which allows to browse calls and caller of function,
    /// methods, constructor etc.
    type [<AllowNullLiteral>] CallHierarchyProvider =
        /// <summary>Bootstraps call hierarchy by returning the item that is denoted by the given document
        /// and position. This item will be used as entry into the call graph. Providers should
        /// return `undefined` or `null` when there is no item at the given location.</summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="position">The position at which the command was invoked.</param>
        /// <param name="token">A cancellation token.</param>
        abstract prepareCallHierarchy: document: TextDocument * position: Position * token: CancellationToken -> ProviderResult<U2<CallHierarchyItem, ResizeArray<CallHierarchyItem>>>
        /// <summary>Provide all incoming calls for an item, e.g all callers for a method. In graph terms this describes directed
        /// and annotated edges inside the call graph, e.g the given item is the starting node and the result is the nodes
        /// that can be reached.</summary>
        /// <param name="item">The hierarchy item for which incoming calls should be computed.</param>
        /// <param name="token">A cancellation token.</param>
        abstract provideCallHierarchyIncomingCalls: item: CallHierarchyItem * token: CancellationToken -> ProviderResult<ResizeArray<CallHierarchyIncomingCall>>
        /// <summary>Provide all outgoing calls for an item, e.g call calls to functions, methods, or constructors from the given item. In
        /// graph terms this describes directed and annotated edges inside the call graph, e.g the given item is the starting
        /// node and the result is the nodes that can be reached.</summary>
        /// <param name="item">The hierarchy item for which outgoing calls should be computed.</param>
        /// <param name="token">A cancellation token.</param>
        abstract provideCallHierarchyOutgoingCalls: item: CallHierarchyItem * token: CancellationToken -> ProviderResult<ResizeArray<CallHierarchyOutgoingCall>>

    /// Represents a list of ranges that can be edited together along with a word pattern to describe valid range contents.
    type [<AllowNullLiteral>] LinkedEditingRanges =
        /// A list of ranges that can be edited together. The ranges must have
        /// identical length and text content. The ranges cannot overlap.
        abstract ranges: ResizeArray<Range>
        /// An optional word pattern that describes valid contents for the given ranges.
        /// If no pattern is provided, the language configuration's word pattern will be used.
        abstract wordPattern: RegExp option

    /// Represents a list of ranges that can be edited together along with a word pattern to describe valid range contents.
    type [<AllowNullLiteral>] LinkedEditingRangesStatic =
        /// <summary>Create a new linked editing ranges object.</summary>
        /// <param name="ranges">A list of ranges that can be edited together</param>
        /// <param name="wordPattern">An optional word pattern that describes valid contents for the given ranges</param>
        [<Emit "new $0($1...)">] abstract Create: ranges: ResizeArray<Range> * ?wordPattern: RegExp -> LinkedEditingRanges

    /// The linked editing range provider interface defines the contract between extensions and
    /// the linked editing feature.
    type [<AllowNullLiteral>] LinkedEditingRangeProvider =
        /// <summary>For a given position in a document, returns the range of the symbol at the position and all ranges
        /// that have the same content. A change to one of the ranges can be applied to all other ranges if the new content
        /// is valid. An optional word pattern can be returned with the result to describe valid contents.
        /// If no result-specific word pattern is provided, the word pattern from the language configuration is used.</summary>
        /// <param name="document">The document in which the provider was invoked.</param>
        /// <param name="position">The position at which the provider was invoked.</param>
        /// <param name="token">A cancellation token.</param>
        abstract provideLinkedEditingRanges: document: TextDocument * position: Position * token: CancellationToken -> ProviderResult<LinkedEditingRanges>

    type CharacterPair =
        string * string

    /// Describes how comments for a language work.
    type [<AllowNullLiteral>] CommentRule =
        /// The line comment token, like `// this is a comment`
        abstract lineComment: string option with get, set
        /// The block comment character pair, like `/* block comment *&#47;`
        abstract blockComment: CharacterPair option with get, set

    /// Describes indentation rules for a language.
    type [<AllowNullLiteral>] IndentationRule =
        /// If a line matches this pattern, then all the lines after it should be unindented once (until another rule matches).
        abstract decreaseIndentPattern: RegExp with get, set
        /// If a line matches this pattern, then all the lines after it should be indented once (until another rule matches).
        abstract increaseIndentPattern: RegExp with get, set
        /// If a line matches this pattern, then **only the next line** after it should be indented once.
        abstract indentNextLinePattern: RegExp option with get, set
        /// If a line matches this pattern, then its indentation should not be changed and it should not be evaluated against the other rules.
        abstract unIndentedLinePattern: RegExp option with get, set

    type [<RequireQualifiedAccess>] IndentAction =
        | None = 0
        | Indent = 1
        | IndentOutdent = 2
        | Outdent = 3

    /// Describes what to do when pressing Enter.
    type [<AllowNullLiteral>] EnterAction =
        /// Describe what to do with the indentation.
        abstract indentAction: IndentAction with get, set
        /// Describes text to be appended after the new line and after the indentation.
        abstract appendText: string option with get, set
        /// Describes the number of characters to remove from the new line's indentation.
        abstract removeText: float option with get, set

    /// Describes a rule to be evaluated when pressing Enter.
    type [<AllowNullLiteral>] OnEnterRule =
        /// This rule will only execute if the text before the cursor matches this regular expression.
        abstract beforeText: RegExp with get, set
        /// This rule will only execute if the text after the cursor matches this regular expression.
        abstract afterText: RegExp option with get, set
        /// This rule will only execute if the text above the current line matches this regular expression.
        abstract previousLineText: RegExp option with get, set
        /// The action to execute.
        abstract action: EnterAction with get, set

    /// The language configuration interfaces defines the contract between extensions
    /// and various editor features, like automatic bracket insertion, automatic indentation etc.
    type [<AllowNullLiteral>] LanguageConfiguration =
        /// The language's comment settings.
        abstract comments: CommentRule option with get, set
        /// The language's brackets.
        /// This configuration implicitly affects pressing Enter around these brackets.
        abstract brackets: ResizeArray<CharacterPair> option with get, set
        /// The language's word definition.
        /// If the language supports Unicode identifiers (e.g. JavaScript), it is preferable
        /// to provide a word definition that uses exclusion of known separators.
        /// e.g.: A regex that matches anything except known separators (and dot is allowed to occur in a floating point number):
        ///    /(-?\d*\.\d\w*)|([^\`\~\!\@\#\%\^\&\*\(\)\-\=\+\[\{\]\}\\\|\;\:\'\"\,\.\<\>\/\?\s]+)/g
        abstract wordPattern: RegExp option with get, set
        /// The language's indentation settings.
        abstract indentationRules: IndentationRule option with get, set
        /// The language's rules to be evaluated when pressing Enter.
        abstract onEnterRules: ResizeArray<OnEnterRule> option with get, set
        /// **Deprecated** Do not use.
        abstract __electricCharacterSupport: LanguageConfiguration__electricCharacterSupport option with get, set
        /// **Deprecated** Do not use.
        abstract __characterPairSupport: LanguageConfiguration__characterPairSupport option with get, set

    type [<RequireQualifiedAccess>] ConfigurationTarget =
        | Global = 1
        | Workspace = 2
        | WorkspaceFolder = 3

    /// Represents the configuration. It is a merged view of
    /// 
    /// - *Default Settings*
    /// - *Global (User) Settings*
    /// - *Workspace settings*
    /// - *Workspace Folder settings* - From one of the {@link workspace.workspaceFolders Workspace Folders} under which requested resource belongs to.
    /// - *Language settings* - Settings defined under requested language.
    /// 
    /// The *effective* value (returned by {@link WorkspaceConfiguration.get `get`}) is computed by overriding or merging the values in the following order.
    /// 
    /// ```
    /// `defaultValue` (if defined in `package.json` otherwise derived from the value's type)
    /// `globalValue` (if defined)
    /// `workspaceValue` (if defined)
    /// `workspaceFolderValue` (if defined)
    /// `defaultLanguageValue` (if defined)
    /// `globalLanguageValue` (if defined)
    /// `workspaceLanguageValue` (if defined)
    /// `workspaceFolderLanguageValue` (if defined)
    /// ```
    /// **Note:** Only `object` value types are merged and all other value types are overridden.
    /// 
    /// Example 1: Overriding
    /// 
    /// ```ts
    /// defaultValue = 'on';
    /// globalValue = 'relative'
    /// workspaceFolderValue = 'off'
    /// value = 'off'
    /// ```
    /// 
    /// Example 2: Language Values
    /// 
    /// ```ts
    /// defaultValue = 'on';
    /// globalValue = 'relative'
    /// workspaceFolderValue = 'off'
    /// globalLanguageValue = 'on'
    /// value = 'on'
    /// ```
    /// 
    /// Example 3: Object Values
    /// 
    /// ```ts
    /// defaultValue = { "a": 1, "b": 2 };
    /// globalValue = { "b": 3, "c": 4 };
    /// value = { "a": 1, "b": 3, "c": 4 };
    /// ```
    /// 
    /// *Note:* Workspace and Workspace Folder configurations contains `launch` and `tasks` settings. Their basename will be
    /// part of the section identifier. The following snippets shows how to retrieve all configurations
    /// from `launch.json`:
    /// 
    /// ```ts
    /// // launch.json configuration
    /// const config = workspace.getConfiguration('launch', vscode.workspace.workspaceFolders[0].uri);
    /// 
    /// // retrieve values
    /// const values = config.get('configurations');
    /// ```
    /// 
    /// Refer to [Settings](https://code.visualstudio.com/docs/getstarted/settings) for more information.
    type [<AllowNullLiteral>] WorkspaceConfiguration =
        /// <summary>Return a value from this configuration.</summary>
        /// <param name="section">Configuration name, supports _dotted_ names.</param>
        abstract get: section: string -> 'T option
        /// <summary>Return a value from this configuration.</summary>
        /// <param name="section">Configuration name, supports _dotted_ names.</param>
        /// <param name="defaultValue">A value should be returned when no value could be found, is `undefined`.</param>
        abstract get: section: string * defaultValue: 'T -> 'T
        /// <summary>Check if this configuration has a certain value.</summary>
        /// <param name="section">Configuration name, supports _dotted_ names.</param>
        abstract has: section: string -> bool
        /// <summary>Retrieve all information about a configuration setting. A configuration value
        /// often consists of a *default* value, a global or installation-wide value,
        /// a workspace-specific value, folder-specific value
        /// and language-specific values (if {@link WorkspaceConfiguration} is scoped to a language).
        /// 
        /// Also provides all language ids under which the given configuration setting is defined.
        /// 
        /// *Note:* The configuration name must denote a leaf in the configuration tree
        /// (`editor.fontSize` vs `editor`) otherwise no result is returned.</summary>
        /// <param name="section">Configuration name, supports _dotted_ names.</param>
        abstract inspect: section: string -> WorkspaceConfigurationInspect<'T> option
        /// <summary>Update a configuration value. The updated configuration values are persisted.
        /// 
        /// A value can be changed in
        /// 
        /// - {@link ConfigurationTarget.Global Global settings}: Changes the value for all instances of the editor.
        /// - {@link ConfigurationTarget.Workspace Workspace settings}: Changes the value for current workspace, if available.
        /// - {@link ConfigurationTarget.WorkspaceFolder Workspace folder settings}: Changes the value for settings from one of the {@link workspace.workspaceFolders Workspace Folders} under which the requested resource belongs to.
        /// - Language settings: Changes the value for the requested languageId.
        /// 
        /// *Note:* To remove a configuration value use `undefined`, like so: `config.update('somekey', undefined)`</summary>
        /// <param name="section">Configuration name, supports _dotted_ names.</param>
        /// <param name="value">The new value.</param>
        /// <param name="configurationTarget">The {@link ConfigurationTarget configuration target} or a boolean value.
        /// - If `true` updates {@link ConfigurationTarget.Global Global settings}.
        /// - If `false` updates {@link ConfigurationTarget.Workspace Workspace settings}.
        /// - If `undefined` or `null` updates to {@link ConfigurationTarget.WorkspaceFolder Workspace folder settings} if configuration is resource specific,
        /// otherwise to {@link ConfigurationTarget.Workspace Workspace settings}.</param>
        /// <param name="overrideInLanguage">Whether to update the value in the scope of requested languageId or not.
        /// - If `true` updates the value under the requested languageId.
        /// - If `undefined` updates the value under the requested languageId only if the configuration is defined for the language.</param>
        abstract update: section: string * value: obj option * ?configurationTarget: U2<ConfigurationTarget, bool> * ?overrideInLanguage: bool -> Thenable<unit>
        /// Readable dictionary that backs this configuration.
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option

    /// Represents a location inside a resource, such as a line
    /// inside a text file.
    type [<AllowNullLiteral>] Location =
        /// The resource identifier of this location.
        abstract uri: Uri with get, set
        /// The document range of this location.
        abstract range: Range with get, set

    /// Represents a location inside a resource, such as a line
    /// inside a text file.
    type [<AllowNullLiteral>] LocationStatic =
        /// <summary>Creates a new location object.</summary>
        /// <param name="uri">The resource identifier.</param>
        /// <param name="rangeOrPosition">The range or position. Positions will be converted to an empty range.</param>
        [<Emit "new $0($1...)">] abstract Create: uri: Uri * rangeOrPosition: U2<Range, Position> -> Location

    /// Represents the connection of two locations. Provides additional metadata over normal {@link Location locations},
    /// including an origin range.
    type [<AllowNullLiteral>] LocationLink =
        /// Span of the origin of this link.
        /// 
        /// Used as the underlined span for mouse definition hover. Defaults to the word range at
        /// the definition position.
        abstract originSelectionRange: Range option with get, set
        /// The target resource identifier of this link.
        abstract targetUri: Uri with get, set
        /// The full target range of this link.
        abstract targetRange: Range with get, set
        /// The span of this link.
        abstract targetSelectionRange: Range option with get, set

    /// The event that is fired when diagnostics change.
    type [<AllowNullLiteral>] DiagnosticChangeEvent =
        /// An array of resources for which diagnostics have changed.
        abstract uris: ResizeArray<Uri>

    type [<RequireQualifiedAccess>] DiagnosticSeverity =
        | Error = 0
        | Warning = 1
        | Information = 2
        | Hint = 3

    /// Represents a related message and source code location for a diagnostic. This should be
    /// used to point to code locations that cause or related to a diagnostics, e.g. when duplicating
    /// a symbol in a scope.
    type [<AllowNullLiteral>] DiagnosticRelatedInformation =
        /// The location of this related diagnostic information.
        abstract location: Location with get, set
        /// The message of this related diagnostic information.
        abstract message: string with get, set

    /// Represents a related message and source code location for a diagnostic. This should be
    /// used to point to code locations that cause or related to a diagnostics, e.g. when duplicating
    /// a symbol in a scope.
    type [<AllowNullLiteral>] DiagnosticRelatedInformationStatic =
        /// <summary>Creates a new related diagnostic information object.</summary>
        /// <param name="location">The location.</param>
        /// <param name="message">The message.</param>
        [<Emit "new $0($1...)">] abstract Create: location: Location * message: string -> DiagnosticRelatedInformation

    type [<RequireQualifiedAccess>] DiagnosticTag =
        | Unnecessary = 1
        | Deprecated = 2

    /// Represents a diagnostic, such as a compiler error or warning. Diagnostic objects
    /// are only valid in the scope of a file.
    type [<AllowNullLiteral>] Diagnostic =
        /// The range to which this diagnostic applies.
        abstract range: Range with get, set
        /// The human-readable message.
        abstract message: string with get, set
        /// The severity, default is {@link DiagnosticSeverity.Error error}.
        abstract severity: DiagnosticSeverity with get, set
        /// A human-readable string describing the source of this
        /// diagnostic, e.g. 'typescript' or 'super lint'.
        abstract source: string option with get, set
        /// A code or identifier for this diagnostic.
        /// Should be used for later processing, e.g. when providing {@link CodeActionContext code actions}.
        abstract code: U3<string, float, DiagnosticCode> option with get, set
        /// An array of related diagnostic information, e.g. when symbol-names within
        /// a scope collide all definitions can be marked via this property.
        abstract relatedInformation: ResizeArray<DiagnosticRelatedInformation> option with get, set
        /// Additional metadata about the diagnostic.
        abstract tags: ResizeArray<DiagnosticTag> option with get, set

    /// Represents a diagnostic, such as a compiler error or warning. Diagnostic objects
    /// are only valid in the scope of a file.
    type [<AllowNullLiteral>] DiagnosticStatic =
        /// <summary>Creates a new diagnostic object.</summary>
        /// <param name="range">The range to which this diagnostic applies.</param>
        /// <param name="message">The human-readable message.</param>
        /// <param name="severity">The severity, default is {@link DiagnosticSeverity.Error error}.</param>
        [<Emit "new $0($1...)">] abstract Create: range: Range * message: string * ?severity: DiagnosticSeverity -> Diagnostic

    /// A diagnostics collection is a container that manages a set of
    /// {@link Diagnostic diagnostics}. Diagnostics are always scopes to a
    /// diagnostics collection and a resource.
    /// 
    /// To get an instance of a `DiagnosticCollection` use
    /// {@link languages.createDiagnosticCollection createDiagnosticCollection}.
    type [<AllowNullLiteral>] DiagnosticCollection =
        /// The name of this diagnostic collection, for instance `typescript`. Every diagnostic
        /// from this collection will be associated with this name. Also, the task framework uses this
        /// name when defining [problem matchers](https://code.visualstudio.com/docs/editor/tasks#_defining-a-problem-matcher).
        abstract name: string
        /// <summary>Assign diagnostics for given resource. Will replace
        /// existing diagnostics for that resource.</summary>
        /// <param name="uri">A resource identifier.</param>
        /// <param name="diagnostics">Array of diagnostics or `undefined`</param>
        abstract set: uri: Uri * diagnostics: ResizeArray<Diagnostic> option -> unit
        /// <summary>Replace diagnostics for multiple resources in this collection.
        /// 
        ///   _Note_ that multiple tuples of the same uri will be merged, e.g
        /// `[[file1, [d1]], [file1, [d2]]]` is equivalent to `[[file1, [d1, d2]]]`.
        /// If a diagnostics item is `undefined` as in `[file1, undefined]`
        /// all previous but not subsequent diagnostics are removed.</summary>
        /// <param name="entries">An array of tuples, like `[[file1, [d1, d2]], [file2, [d3, d4, d5]]]`, or `undefined`.</param>
        abstract set: entries: ResizeArray<Uri * ResizeArray<Diagnostic> option> -> unit
        /// <summary>Remove all diagnostics from this collection that belong
        /// to the provided `uri`. The same as `#set(uri, undefined)`.</summary>
        /// <param name="uri">A resource identifier.</param>
        abstract delete: uri: Uri -> unit
        /// Remove all diagnostics from this collection. The same
        /// as calling `#set(undefined)`;
        abstract clear: unit -> unit
        /// <summary>Iterate over each entry in this collection.</summary>
        /// <param name="callback">Function to execute for each entry.</param>
        /// <param name="thisArg">The `this` context used when invoking the handler function.</param>
        abstract forEach: callback: (Uri -> ResizeArray<Diagnostic> -> DiagnosticCollection -> obj option) * ?thisArg: obj -> unit
        /// <summary>Get the diagnostics for a given resource. *Note* that you cannot
        /// modify the diagnostics-array returned from this call.</summary>
        /// <param name="uri">A resource identifier.</param>
        abstract get: uri: Uri -> ResizeArray<Diagnostic> option
        /// <summary>Check if this collection contains diagnostics for a
        /// given resource.</summary>
        /// <param name="uri">A resource identifier.</param>
        abstract has: uri: Uri -> bool
        /// Dispose and free associated resources. Calls
        /// {@link DiagnosticCollection.clear clear}.
        abstract dispose: unit -> unit

    type [<RequireQualifiedAccess>] ViewColumn =
        | Active = -1
        | Beside = -2
        | One = 1
        | Two = 2
        | Three = 3
        | Four = 4
        | Five = 5
        | Six = 6
        | Seven = 7
        | Eight = 8
        | Nine = 9

    /// An output channel is a container for readonly textual information.
    /// 
    /// To get an instance of an `OutputChannel` use
    /// {@link window.createOutputChannel createOutputChannel}.
    type [<AllowNullLiteral>] OutputChannel =
        /// The human-readable name of this output channel.
        abstract name: string
        /// <summary>Append the given value to the channel.</summary>
        /// <param name="value">A string, falsy values will not be printed.</param>
        abstract append: value: string -> unit
        /// <summary>Append the given value and a line feed character
        /// to the channel.</summary>
        /// <param name="value">A string, falsy values will be printed.</param>
        abstract appendLine: value: string -> unit
        /// Removes all output from the channel.
        abstract clear: unit -> unit
        /// <summary>Reveal this channel in the UI.</summary>
        /// <param name="preserveFocus">When `true` the channel will not take focus.</param>
        abstract show: ?preserveFocus: bool -> unit
        /// <summary>Reveal this channel in the UI.</summary>
        /// <param name="column">This argument is **deprecated** and will be ignored.</param>
        /// <param name="preserveFocus">When `true` the channel will not take focus.</param>
        abstract show: ?column: ViewColumn * ?preserveFocus: bool -> unit
        /// Hide this channel from the UI.
        abstract hide: unit -> unit
        /// Dispose and free associated resources.
        abstract dispose: unit -> unit

    /// Accessibility information which controls screen reader behavior.
    type [<AllowNullLiteral>] AccessibilityInformation =
        /// Label to be read out by a screen reader once the item has focus.
        abstract label: string with get, set
        /// Role of the widget which defines how a screen reader interacts with it.
        /// The role should be set in special cases when for example a tree-like element behaves like a checkbox.
        /// If role is not specified the editor will pick the appropriate role automatically.
        /// More about aria roles can be found here https://w3c.github.io/aria/#widget_roles
        abstract role: string option with get, set

    type [<RequireQualifiedAccess>] StatusBarAlignment =
        | Left = 1
        | Right = 2

    /// A status bar item is a status bar contribution that can
    /// show text and icons and run a command on click.
    type [<AllowNullLiteral>] StatusBarItem =
        /// The identifier of this item.
        /// 
        /// *Note*: if no identifier was provided by the {@link window.createStatusBarItem `window.createStatusBarItem`}
        /// method, the identifier will match the {@link Extension.id extension identifier}.
        abstract id: string
        /// The alignment of this item.
        abstract alignment: StatusBarAlignment
        /// The priority of this item. Higher value means the item should
        /// be shown more to the left.
        abstract priority: float option
        /// The name of the entry, like 'Python Language Indicator', 'Git Status' etc.
        /// Try to keep the length of the name short, yet descriptive enough that
        /// users can understand what the status bar item is about.
        abstract name: string option with get, set
        /// The text to show for the entry. You can embed icons in the text by leveraging the syntax:
        /// 
        /// `My text $(icon-name) contains icons like $(icon-name) this one.`
        /// 
        /// Where the icon-name is taken from the ThemeIcon [icon set](https://code.visualstudio.com/api/references/icons-in-labels#icon-listing), e.g.
        /// `light-bulb`, `thumbsup`, `zap` etc.
        abstract text: string with get, set
        /// The tooltip text when you hover over this entry.
        abstract tooltip: string option with get, set
        /// The foreground color for this entry.
        abstract color: U2<string, ThemeColor> option with get, set
        /// The background color for this entry.
        /// 
        /// *Note*: only `new ThemeColor('statusBarItem.errorBackground')` is
        /// supported for now. More background colors may be supported in the
        /// future.
        /// 
        /// *Note*: when a background color is set, the statusbar may override
        /// the `color` choice to ensure the entry is readable in all themes.
        abstract backgroundColor: ThemeColor option with get, set
        /// {@link Command `Command`} or identifier of a command to run on click.
        /// 
        /// The command must be {@link commands.getCommands known}.
        /// 
        /// Note that if this is a {@link Command `Command`} object, only the {@link Command.command `command`} and {@link Command.arguments `arguments`}
        /// are used by the editor.
        abstract command: U2<string, Command> option with get, set
        /// Accessibility information used when a screen reader interacts with this StatusBar item
        abstract accessibilityInformation: AccessibilityInformation option with get, set
        /// Shows the entry in the status bar.
        abstract show: unit -> unit
        /// Hide the entry in the status bar.
        abstract hide: unit -> unit
        /// Dispose and free associated resources. Call
        /// {@link StatusBarItem.hide hide}.
        abstract dispose: unit -> unit

    /// Defines a generalized way of reporting progress updates.
    type [<AllowNullLiteral>] Progress<'T> =
        /// <summary>Report a progress update.</summary>
        /// <param name="value">A progress item, like a message and/or an
        /// report on how much work finished</param>
        abstract report: value: 'T -> unit

    /// An individual terminal instance within the integrated terminal.
    type [<AllowNullLiteral>] Terminal =
        /// The name of the terminal.
        abstract name: string
        /// The process ID of the shell process.
        abstract processId: Thenable<float option>
        /// The object used to initialize the terminal, this is useful for example to detecting the
        /// shell type of when the terminal was not launched by this extension or for detecting what
        /// folder the shell was launched in.
        abstract creationOptions: obj
        /// The exit status of the terminal, this will be undefined while the terminal is active.
        /// 
        /// **Example:** Show a notification with the exit code when the terminal exits with a
        /// non-zero exit code.
        /// ```typescript
        /// window.onDidCloseTerminal(t => {
        ///    if (t.exitStatus && t.exitStatus.code) {
        ///        vscode.window.showInformationMessage(`Exit code: ${t.exitStatus.code}`);
        ///    }
        /// });
        /// ```
        abstract exitStatus: TerminalExitStatus option
        /// <summary>Send text to the terminal. The text is written to the stdin of the underlying pty process
        /// (shell) of the terminal.</summary>
        /// <param name="text">The text to send.</param>
        /// <param name="addNewLine">Whether to add a new line to the text being sent, this is normally
        /// required to run a command in the terminal. The character(s) added are \n or \r\n
        /// depending on the platform. This defaults to `true`.</param>
        abstract sendText: text: string * ?addNewLine: bool -> unit
        /// <summary>Show the terminal panel and reveal this terminal in the UI.</summary>
        /// <param name="preserveFocus">When `true` the terminal will not take focus.</param>
        abstract show: ?preserveFocus: bool -> unit
        /// Hide the terminal panel if this terminal is currently showing.
        abstract hide: unit -> unit
        /// Dispose and free associated resources.
        abstract dispose: unit -> unit

    /// Provides information on a line in a terminal in order to provide links for it.
    type [<AllowNullLiteral>] TerminalLinkContext =
        /// This is the text from the unwrapped line in the terminal.
        abstract line: string with get, set
        /// The terminal the link belongs to.
        abstract terminal: Terminal with get, set

    type TerminalLinkProvider =
        TerminalLinkProvider<obj>

    /// A provider that enables detection and handling of links within terminals.
    type [<AllowNullLiteral>] TerminalLinkProvider<'T> =
        /// <summary>Provide terminal links for the given context. Note that this can be called multiple times
        /// even before previous calls resolve, make sure to not share global objects (eg. `RegExp`)
        /// that could have problems when asynchronous usage may overlap.</summary>
        /// <param name="context">Information about what links are being provided for.</param>
        /// <param name="token">A cancellation token.</param>
        abstract provideTerminalLinks: context: TerminalLinkContext * token: CancellationToken -> ProviderResult<ResizeArray<'T>>
        /// <summary>Handle an activated terminal link.</summary>
        /// <param name="link">The link to handle.</param>
        abstract handleTerminalLink: link: 'T -> ProviderResult<unit>

    /// A link on a terminal line.
    type [<AllowNullLiteral>] TerminalLink =
        /// The start index of the link on {@link TerminalLinkContext.line}.
        abstract startIndex: float with get, set
        /// The length of the link on {@link TerminalLinkContext.line}.
        abstract length: float with get, set
        /// The tooltip text when you hover over this link.
        /// 
        /// If a tooltip is provided, is will be displayed in a string that includes instructions on
        /// how to trigger the link, such as `{0} (ctrl + click)`. The specific instructions vary
        /// depending on OS, user settings, and localization.
        abstract tooltip: string option with get, set

    /// A link on a terminal line.
    type [<AllowNullLiteral>] TerminalLinkStatic =
        /// <summary>Creates a new terminal link.</summary>
        /// <param name="startIndex">The start index of the link on {@link TerminalLinkContext.line}.</param>
        /// <param name="length">The length of the link on {@link TerminalLinkContext.line}.</param>
        /// <param name="tooltip">The tooltip text when you hover over this link.
        /// 
        /// If a tooltip is provided, is will be displayed in a string that includes instructions on
        /// how to trigger the link, such as `{0} (ctrl + click)`. The specific instructions vary
        /// depending on OS, user settings, and localization.</param>
        [<Emit "new $0($1...)">] abstract Create: startIndex: float * length: float * ?tooltip: string -> TerminalLink

    /// Provides a terminal profile for the contributed terminal profile when launched via the UI or
    /// command.
    type [<AllowNullLiteral>] TerminalProfileProvider =
        /// <summary>Provide the terminal profile.</summary>
        /// <param name="token">A cancellation token that indicates the result is no longer needed.</param>
        abstract provideTerminalProfile: token: CancellationToken -> ProviderResult<TerminalProfile>

    /// A terminal profile defines how a terminal will be launched.
    type [<AllowNullLiteral>] TerminalProfile =
        /// The options that the terminal will launch with.
        abstract options: U2<TerminalOptions, ExtensionTerminalOptions> with get, set

    /// A terminal profile defines how a terminal will be launched.
    type [<AllowNullLiteral>] TerminalProfileStatic =
        /// <summary>Creates a new terminal profile.</summary>
        /// <param name="options">The options that the terminal will launch with.</param>
        [<Emit "new $0($1...)">] abstract Create: options: U2<TerminalOptions, ExtensionTerminalOptions> -> TerminalProfile

    /// A file decoration represents metadata that can be rendered with a file.
    type [<AllowNullLiteral>] FileDecoration =
        /// A very short string that represents this decoration.
        abstract badge: string option with get, set
        /// A human-readable tooltip for this decoration.
        abstract tooltip: string option with get, set
        /// The color of this decoration.
        abstract color: ThemeColor option with get, set
        /// A flag expressing that this decoration should be
        /// propagated to its parents.
        abstract propagate: bool option with get, set

    /// A file decoration represents metadata that can be rendered with a file.
    type [<AllowNullLiteral>] FileDecorationStatic =
        /// <summary>Creates a new decoration.</summary>
        /// <param name="badge">A letter that represents the decoration.</param>
        /// <param name="tooltip">The tooltip of the decoration.</param>
        /// <param name="color">The color of the decoration.</param>
        [<Emit "new $0($1...)">] abstract Create: ?badge: string * ?tooltip: string * ?color: ThemeColor -> FileDecoration

    /// The decoration provider interfaces defines the contract between extensions and
    /// file decorations.
    type [<AllowNullLiteral>] FileDecorationProvider =
        /// An optional event to signal that decorations for one or many files have changed.
        /// 
        /// *Note* that this event should be used to propagate information about children.
        abstract onDidChangeFileDecorations: Event<U2<Uri, ResizeArray<Uri>> option> option with get, set
        /// <summary>Provide decorations for a given uri.
        /// 
        /// *Note* that this function is only called when a file gets rendered in the UI.
        /// This means a decoration from a descendent that propagates upwards must be signaled
        /// to the editor via the {@link FileDecorationProvider.onDidChangeFileDecorations onDidChangeFileDecorations}-event.</summary>
        /// <param name="uri">The uri of the file to provide a decoration for.</param>
        /// <param name="token">A cancellation token.</param>
        abstract provideFileDecoration: uri: Uri * token: CancellationToken -> ProviderResult<FileDecoration>

    type [<RequireQualifiedAccess>] ExtensionKind =
        | UI = 1
        | Workspace = 2

    /// Represents an extension.
    /// 
    /// To get an instance of an `Extension` use {@link extensions.getExtension getExtension}.
    type [<AllowNullLiteral>] Extension<'T> =
        /// The canonical extension identifier in the form of: `publisher.name`.
        abstract id: string
        /// The uri of the directory containing the extension.
        abstract extensionUri: Uri
        /// The absolute file path of the directory containing this extension. Shorthand
        /// notation for {@link Extension.extensionUri Extension.extensionUri.fsPath} (independent of the uri scheme).
        abstract extensionPath: string
        /// `true` if the extension has been activated.
        abstract isActive: bool
        /// The parsed contents of the extension's package.json.
        abstract packageJSON: obj option
        /// The extension kind describes if an extension runs where the UI runs
        /// or if an extension runs where the remote extension host runs. The extension kind
        /// is defined in the `package.json`-file of extensions but can also be refined
        /// via the `remote.extensionKind`-setting. When no remote extension host exists,
        /// the value is {@link ExtensionKind.UI `ExtensionKind.UI`}.
        abstract extensionKind: ExtensionKind with get, set
        /// The public API exported by this extension. It is an invalid action
        /// to access this field before this extension has been activated.
        abstract exports: 'T
        /// Activates this extension and returns its public API.
        abstract activate: unit -> Thenable<'T>

    type [<RequireQualifiedAccess>] ExtensionMode =
        | Production = 1
        | Development = 2
        | Test = 3

    /// An extension context is a collection of utilities private to an
    /// extension.
    /// 
    /// An instance of an `ExtensionContext` is provided as the first
    /// parameter to the `activate`-call of an extension.
    type [<AllowNullLiteral>] ExtensionContext =
        /// An array to which disposables can be added. When this
        /// extension is deactivated the disposables will be disposed.
        abstract subscriptions: ResizeArray<ExtensionContextSubscriptions>
        /// A memento object that stores state in the context
        /// of the currently opened {@link workspace.workspaceFolders workspace}.
        abstract workspaceState: Memento
        /// A memento object that stores state independent
        /// of the current opened {@link workspace.workspaceFolders workspace}.
        abstract globalState: obj
        /// A storage utility for secrets. Secrets are persisted across reloads and are independent of the
        /// current opened {@link workspace.workspaceFolders workspace}.
        abstract secrets: SecretStorage
        /// The uri of the directory containing the extension.
        abstract extensionUri: Uri
        /// The absolute file path of the directory containing the extension. Shorthand
        /// notation for {@link TextDocument.uri ExtensionContext.extensionUri.fsPath} (independent of the uri scheme).
        abstract extensionPath: string
        /// Gets the extension's environment variable collection for this workspace, enabling changes
        /// to be applied to terminal environment variables.
        abstract environmentVariableCollection: EnvironmentVariableCollection
        /// <summary>Get the absolute path of a resource contained in the extension.
        /// 
        /// *Note* that an absolute uri can be constructed via {@link Uri.joinPath `Uri.joinPath`} and
        /// {@link ExtensionContext.extensionUri `extensionUri`}, e.g. `vscode.Uri.joinPath(context.extensionUri, relativePath);`</summary>
        /// <param name="relativePath">A relative path to a resource contained in the extension.</param>
        abstract asAbsolutePath: relativePath: string -> string
        /// The uri of a workspace specific directory in which the extension
        /// can store private state. The directory might not exist and creation is
        /// up to the extension. However, the parent directory is guaranteed to be existent.
        /// The value is `undefined` when no workspace nor folder has been opened.
        /// 
        /// Use {@link ExtensionContext.workspaceState `workspaceState`} or
        /// {@link ExtensionContext.globalState `globalState`} to store key value data.
        abstract storageUri: Uri option
        /// An absolute file path of a workspace specific directory in which the extension
        /// can store private state. The directory might not exist on disk and creation is
        /// up to the extension. However, the parent directory is guaranteed to be existent.
        /// 
        /// Use {@link ExtensionContext.workspaceState `workspaceState`} or
        /// {@link ExtensionContext.globalState `globalState`} to store key value data.
        abstract storagePath: string option
        /// The uri of a directory in which the extension can store global state.
        /// The directory might not exist on disk and creation is
        /// up to the extension. However, the parent directory is guaranteed to be existent.
        /// 
        /// Use {@link ExtensionContext.globalState `globalState`} to store key value data.
        abstract globalStorageUri: Uri
        /// An absolute file path in which the extension can store global state.
        /// The directory might not exist on disk and creation is
        /// up to the extension. However, the parent directory is guaranteed to be existent.
        /// 
        /// Use {@link ExtensionContext.globalState `globalState`} to store key value data.
        abstract globalStoragePath: string
        /// The uri of a directory in which the extension can create log files.
        /// The directory might not exist on disk and creation is up to the extension. However,
        /// the parent directory is guaranteed to be existent.
        abstract logUri: Uri
        /// An absolute file path of a directory in which the extension can create log files.
        /// The directory might not exist on disk and creation is up to the extension. However,
        /// the parent directory is guaranteed to be existent.
        abstract logPath: string
        /// The mode the extension is running in. This is specific to the current
        /// extension. One extension may be in `ExtensionMode.Development` while
        /// other extensions in the host run in `ExtensionMode.Release`.
        abstract extensionMode: ExtensionMode
        /// The current `Extension` instance.
        abstract extension: Extension<obj option>

    /// A memento represents a storage utility. It can store and retrieve
    /// values.
    type [<AllowNullLiteral>] Memento =
        /// Returns the stored keys.
        abstract keys: unit -> ResizeArray<string>
        /// <summary>Return a value.</summary>
        /// <param name="key">A string.</param>
        abstract get: key: string -> 'T option
        /// <summary>Return a value.</summary>
        /// <param name="key">A string.</param>
        /// <param name="defaultValue">A value that should be returned when there is no
        /// value (`undefined`) with the given key.</param>
        abstract get: key: string * defaultValue: 'T -> 'T
        /// <summary>Store a value. The value must be JSON-stringifyable.</summary>
        /// <param name="key">A string.</param>
        /// <param name="value">A value. MUST not contain cyclic references.</param>
        abstract update: key: string * value: obj option -> Thenable<unit>

    /// The event data that is fired when a secret is added or removed.
    type [<AllowNullLiteral>] SecretStorageChangeEvent =
        /// The key of the secret that has changed.
        abstract key: string

    /// Represents a storage utility for secrets, information that is
    /// sensitive.
    type [<AllowNullLiteral>] SecretStorage =
        /// <summary>Retrieve a secret that was stored with key. Returns undefined if there
        /// is no password matching that key.</summary>
        /// <param name="key">The key the secret was stored under.</param>
        abstract get: key: string -> Thenable<string option>
        /// <summary>Store a secret under a given key.</summary>
        /// <param name="key">The key to store the secret under.</param>
        /// <param name="value">The secret.</param>
        abstract store: key: string * value: string -> Thenable<unit>
        /// <summary>Remove a secret from storage.</summary>
        /// <param name="key">The key the secret was stored under.</param>
        abstract delete: key: string -> Thenable<unit>
        /// Fires when a secret is stored or deleted.
        abstract onDidChange: Event<SecretStorageChangeEvent> with get, set

    type [<RequireQualifiedAccess>] ColorThemeKind =
        | Light = 1
        | Dark = 2
        | HighContrast = 3

    /// Represents a color theme.
    type [<AllowNullLiteral>] ColorTheme =
        /// The kind of this color theme: light, dark or high contrast.
        abstract kind: ColorThemeKind

    type [<RequireQualifiedAccess>] TaskRevealKind =
        | Always = 1
        | Silent = 2
        | Never = 3

    type [<RequireQualifiedAccess>] TaskPanelKind =
        | Shared = 1
        | Dedicated = 2
        | New = 3

    /// Controls how the task is presented in the UI.
    type [<AllowNullLiteral>] TaskPresentationOptions =
        /// Controls whether the task output is reveal in the user interface.
        /// Defaults to `RevealKind.Always`.
        abstract reveal: TaskRevealKind option with get, set
        /// Controls whether the command associated with the task is echoed
        /// in the user interface.
        abstract echo: bool option with get, set
        /// Controls whether the panel showing the task output is taking focus.
        abstract focus: bool option with get, set
        /// Controls if the task panel is used for this task only (dedicated),
        /// shared between tasks (shared) or if a new panel is created on
        /// every task execution (new). Defaults to `TaskInstanceKind.Shared`
        abstract panel: TaskPanelKind option with get, set
        /// Controls whether to show the "Terminal will be reused by tasks, press any key to close it" message.
        abstract showReuseMessage: bool option with get, set
        /// Controls whether the terminal is cleared before executing the task.
        abstract clear: bool option with get, set

    /// A grouping for tasks. The editor by default supports the
    /// 'Clean', 'Build', 'RebuildAll' and 'Test' group.
    type [<AllowNullLiteral>] TaskGroup =
        interface end

    /// A grouping for tasks. The editor by default supports the
    /// 'Clean', 'Build', 'RebuildAll' and 'Test' group.
    type [<AllowNullLiteral>] TaskGroupStatic =
        /// The clean task group;
        abstract Clean: TaskGroup with get, set
        /// The build task group;
        abstract Build: TaskGroup with get, set
        /// The rebuild all task group;
        abstract Rebuild: TaskGroup with get, set
        /// The test all task group;
        abstract Test: TaskGroup with get, set

    /// A structure that defines a task kind in the system.
    /// The value must be JSON-stringifyable.
    type [<AllowNullLiteral>] TaskDefinition =
        /// The task definition describing the task provided by an extension.
        /// Usually a task provider defines more properties to identify
        /// a task. They need to be defined in the package.json of the
        /// extension under the 'taskDefinitions' extension point. The npm
        /// task definition for example looks like this
        /// ```typescript
        /// interface NpmTaskDefinition extends TaskDefinition {
        ///      script: string;
        /// }
        /// ```
        /// 
        /// Note that type identifier starting with a '$' are reserved for internal
        /// usages and shouldn't be used by extensions.
        abstract ``type``: string
        /// Additional attributes of a concrete task definition.
        [<Emit "$0[$1]{{=$2}}">] abstract Item: name: string -> obj option with get, set

    /// Options for a process execution
    type [<AllowNullLiteral>] ProcessExecutionOptions =
        /// The current working directory of the executed program or shell.
        /// If omitted the tools current workspace root is used.
        abstract cwd: string option with get, set
        /// The additional environment of the executed program or shell. If omitted
        /// the parent process' environment is used. If provided it is merged with
        /// the parent process' environment.
        abstract env: ProcessExecutionOptionsEnv option with get, set

    /// The execution of a task happens as an external process
    /// without shell interaction.
    type [<AllowNullLiteral>] ProcessExecution =
        /// The process to be executed.
        abstract ``process``: string with get, set
        /// The arguments passed to the process. Defaults to an empty array.
        abstract args: ResizeArray<string> with get, set
        /// The process options used when the process is executed.
        /// Defaults to undefined.
        abstract options: ProcessExecutionOptions option with get, set

    /// The execution of a task happens as an external process
    /// without shell interaction.
    type [<AllowNullLiteral>] ProcessExecutionStatic =
        /// <summary>Creates a process execution.</summary>
        /// <param name="process">The process to start.</param>
        /// <param name="options">Optional options for the started process.</param>
        [<Emit "new $0($1...)">] abstract Create: ``process``: string * ?options: ProcessExecutionOptions -> ProcessExecution
        /// <summary>Creates a process execution.</summary>
        /// <param name="process">The process to start.</param>
        /// <param name="args">Arguments to be passed to the process.</param>
        /// <param name="options">Optional options for the started process.</param>
        [<Emit "new $0($1...)">] abstract Create: ``process``: string * args: ResizeArray<string> * ?options: ProcessExecutionOptions -> ProcessExecution

    /// The shell quoting options.
    type [<AllowNullLiteral>] ShellQuotingOptions =
        /// The character used to do character escaping. If a string is provided only spaces
        /// are escaped. If a `{ escapeChar, charsToEscape }` literal is provide all characters
        /// in `charsToEscape` are escaped using the `escapeChar`.
        abstract escape: U2<string, ShellQuotingOptionsEscape> option with get, set
        /// The character used for strong quoting. The string's length must be 1.
        abstract strong: string option with get, set
        /// The character used for weak quoting. The string's length must be 1.
        abstract weak: string option with get, set

    /// Options for a shell execution
    type [<AllowNullLiteral>] ShellExecutionOptions =
        /// The shell executable.
        abstract executable: string option with get, set
        /// The arguments to be passed to the shell executable used to run the task. Most shells
        /// require special arguments to execute a command. For  example `bash` requires the `-c`
        /// argument to execute a command, `PowerShell` requires `-Command` and `cmd` requires both
        /// `/d` and `/c`.
        abstract shellArgs: ResizeArray<string> option with get, set
        /// The shell quotes supported by this shell.
        abstract shellQuoting: ShellQuotingOptions option with get, set
        /// The current working directory of the executed shell.
        /// If omitted the tools current workspace root is used.
        abstract cwd: string option with get, set
        /// The additional environment of the executed shell. If omitted
        /// the parent process' environment is used. If provided it is merged with
        /// the parent process' environment.
        abstract env: ProcessExecutionOptionsEnv option with get, set

    type [<RequireQualifiedAccess>] ShellQuoting =
        | Escape = 1
        | Strong = 2
        | Weak = 3

    /// A string that will be quoted depending on the used shell.
    type [<AllowNullLiteral>] ShellQuotedString =
        /// The actual string value.
        abstract value: string with get, set
        /// The quoting style to use.
        abstract quoting: ShellQuoting with get, set

    type [<AllowNullLiteral>] ShellExecution =
        /// The shell command line. Is `undefined` if created with a command and arguments.
        abstract commandLine: string option with get, set
        /// The shell command. Is `undefined` if created with a full command line.
        abstract command: U2<string, ShellQuotedString> with get, set
        /// The shell args. Is `undefined` if created with a full command line.
        abstract args: ResizeArray<U2<string, ShellQuotedString>> with get, set
        /// The shell options used when the command line is executed in a shell.
        /// Defaults to undefined.
        abstract options: ShellExecutionOptions option with get, set

    type [<AllowNullLiteral>] ShellExecutionStatic =
        /// <summary>Creates a shell execution with a full command line.</summary>
        /// <param name="commandLine">The command line to execute.</param>
        /// <param name="options">Optional options for the started the shell.</param>
        [<Emit "new $0($1...)">] abstract Create: commandLine: string * ?options: ShellExecutionOptions -> ShellExecution
        /// <summary>Creates a shell execution with a command and arguments. For the real execution the editor will
        /// construct a command line from the command and the arguments. This is subject to interpretation
        /// especially when it comes to quoting. If full control over the command line is needed please
        /// use the constructor that creates a `ShellExecution` with the full command line.</summary>
        /// <param name="command">The command to execute.</param>
        /// <param name="args">The command arguments.</param>
        /// <param name="options">Optional options for the started the shell.</param>
        [<Emit "new $0($1...)">] abstract Create: command: U2<string, ShellQuotedString> * args: ResizeArray<U2<string, ShellQuotedString>> * ?options: ShellExecutionOptions -> ShellExecution

    /// Class used to execute an extension callback as a task.
    type [<AllowNullLiteral>] CustomExecution =
        interface end

    /// Class used to execute an extension callback as a task.
    type [<AllowNullLiteral>] CustomExecutionStatic =
        /// <summary>Constructs a CustomExecution task object. The callback will be executed when the task is run, at which point the
        /// extension should return the Pseudoterminal it will "run in". The task should wait to do further execution until
        /// {@link Pseudoterminal.open} is called. Task cancellation should be handled using
        /// {@link Pseudoterminal.close}. When the task is complete fire
        /// {@link Pseudoterminal.onDidClose}.</summary>
        /// <param name="callback">The callback that will be called when the task is started by a user. Any ${} style variables that
        /// were in the task definition will be resolved and passed into the callback as `resolvedDefinition`.</param>
        [<Emit "new $0($1...)">] abstract Create: callback: (TaskDefinition -> Thenable<Pseudoterminal>) -> CustomExecution

    type [<RequireQualifiedAccess>] TaskScope =
        | Global = 1
        | Workspace = 2

    /// Run options for a task.
    type [<AllowNullLiteral>] RunOptions =
        /// Controls whether task variables are re-evaluated on rerun.
        abstract reevaluateOnRerun: bool option with get, set

    /// A task to execute
    type [<AllowNullLiteral>] Task =
        /// The task's definition.
        abstract definition: TaskDefinition with get, set
        /// The task's scope.
        abstract scope: U2<TaskScope, WorkspaceFolder> option
        /// The task's name
        abstract name: string with get, set
        /// A human-readable string which is rendered less prominently on a separate line in places
        /// where the task's name is displayed. Supports rendering of {@link ThemeIcon theme icons}
        /// via the `$(<name>)`-syntax.
        abstract detail: string option with get, set
        /// The task's execution engine
        abstract execution: U3<ProcessExecution, ShellExecution, CustomExecution> option with get, set
        /// Whether the task is a background task or not.
        abstract isBackground: bool with get, set
        /// A human-readable string describing the source of this shell task, e.g. 'gulp'
        /// or 'npm'. Supports rendering of {@link ThemeIcon theme icons} via the `$(<name>)`-syntax.
        abstract source: string with get, set
        /// The task group this tasks belongs to. See TaskGroup
        /// for a predefined set of available groups.
        /// Defaults to undefined meaning that the task doesn't
        /// belong to any special group.
        abstract group: TaskGroup option with get, set
        /// The presentation options. Defaults to an empty literal.
        abstract presentationOptions: TaskPresentationOptions with get, set
        /// The problem matchers attached to the task. Defaults to an empty
        /// array.
        abstract problemMatchers: ResizeArray<string> with get, set
        /// Run options for the task
        abstract runOptions: RunOptions with get, set

    /// A task to execute
    type [<AllowNullLiteral>] TaskStatic =
        /// <summary>Creates a new task.</summary>
        /// <param name="taskDefinition"></param>
        /// <param name="scope">Specifies the task's scope. It is either a global or a workspace task or a task for a specific workspace folder. Global tasks are currently not supported.</param>
        /// <param name="name">The task's name. Is presented in the user interface.</param>
        /// <param name="source">The task's source (e.g. 'gulp', 'npm', ...). Is presented in the user interface.</param>
        /// <param name="execution">The process or shell execution.</param>
        /// <param name="problemMatchers">the names of problem matchers to use, like '$tsc'
        /// or '$eslint'. Problem matchers can be contributed by an extension using
        /// the `problemMatchers` extension point.</param>
        [<Emit "new $0($1...)">] abstract Create: taskDefinition: TaskDefinition * scope: U2<WorkspaceFolder, TaskScope> * name: string * source: string * ?execution: U3<ProcessExecution, ShellExecution, CustomExecution> * ?problemMatchers: U2<string, ResizeArray<string>> -> Task
        /// <summary>Creates a new task.</summary>
        /// <param name="taskDefinition"></param>
        /// <param name="name">The task's name. Is presented in the user interface.</param>
        /// <param name="source">The task's source (e.g. 'gulp', 'npm', ...). Is presented in the user interface.</param>
        /// <param name="execution">The process or shell execution.</param>
        /// <param name="problemMatchers">the names of problem matchers to use, like '$tsc'
        /// or '$eslint'. Problem matchers can be contributed by an extension using
        /// the `problemMatchers` extension point.</param>
        [<Emit "new $0($1...)">] abstract Create: taskDefinition: TaskDefinition * name: string * source: string * ?execution: U2<ProcessExecution, ShellExecution> * ?problemMatchers: U2<string, ResizeArray<string>> -> Task

    type TaskProvider =
        TaskProvider<obj>

    /// A task provider allows to add tasks to the task service.
    /// A task provider is registered via {@link tasks.registerTaskProvider}.
    type [<AllowNullLiteral>] TaskProvider<'T> =
        /// <summary>Provides tasks.</summary>
        /// <param name="token">A cancellation token.</param>
        abstract provideTasks: token: CancellationToken -> ProviderResult<ResizeArray<'T>>
        /// <summary>Resolves a task that has no {@link Task.execution `execution`} set. Tasks are
        /// often created from information found in the `tasks.json`-file. Such tasks miss
        /// the information on how to execute them and a task provider must fill in
        /// the missing information in the `resolveTask`-method. This method will not be
        /// called for tasks returned from the above `provideTasks` method since those
        /// tasks are always fully resolved. A valid default implementation for the
        /// `resolveTask` method is to return `undefined`.
        /// 
        /// Note that when filling in the properties of `task`, you _must_ be sure to
        /// use the exact same `TaskDefinition` and not create a new one. Other properties
        /// may be changed.</summary>
        /// <param name="task">The task to resolve.</param>
        /// <param name="token">A cancellation token.</param>
        abstract resolveTask: task: 'T * token: CancellationToken -> ProviderResult<'T>

    /// An object representing an executed Task. It can be used
    /// to terminate a task.
    /// 
    /// This interface is not intended to be implemented.
    type [<AllowNullLiteral>] TaskExecution =
        /// The task that got started.
        abstract task: Task with get, set
        /// Terminates the task execution.
        abstract terminate: unit -> unit

    /// An event signaling the start of a task execution.
    /// 
    /// This interface is not intended to be implemented.
    type [<AllowNullLiteral>] TaskStartEvent =
        /// The task item representing the task that got started.
        abstract execution: TaskExecution

    /// An event signaling the end of an executed task.
    /// 
    /// This interface is not intended to be implemented.
    type [<AllowNullLiteral>] TaskEndEvent =
        /// The task item representing the task that finished.
        abstract execution: TaskExecution

    /// An event signaling the start of a process execution
    /// triggered through a task
    type [<AllowNullLiteral>] TaskProcessStartEvent =
        /// The task execution for which the process got started.
        abstract execution: TaskExecution
        /// The underlying process id.
        abstract processId: float

    /// An event signaling the end of a process execution
    /// triggered through a task
    type [<AllowNullLiteral>] TaskProcessEndEvent =
        /// The task execution for which the process got started.
        abstract execution: TaskExecution
        /// The process's exit code. Will be `undefined` when the task is terminated.
        abstract exitCode: float option

    type [<AllowNullLiteral>] TaskFilter =
        /// The task version as used in the tasks.json file.
        /// The string support the package.json semver notation.
        abstract version: string option with get, set
        /// The task type to return;
        abstract ``type``: string option with get, set

    module Tasks =

        type [<AllowNullLiteral>] IExports =
            /// <summary>Register a task provider.</summary>
            /// <param name="type">The task kind type this provider is registered for.</param>
            /// <param name="provider">A task provider.</param>
            abstract registerTaskProvider: ``type``: string * provider: TaskProvider -> Disposable
            /// <summary>Fetches all tasks available in the systems. This includes tasks
            /// from `tasks.json` files as well as tasks from task providers
            /// contributed through extensions.</summary>
            /// <param name="filter">Optional filter to select tasks of a certain type or version.</param>
            abstract fetchTasks: ?filter: TaskFilter -> Thenable<ResizeArray<Task>>
            /// <summary>Executes a task that is managed by the editor. The returned
            /// task execution can be used to terminate the task.</summary>
            /// <param name="task">the task to execute</param>
            abstract executeTask: task: Task -> Thenable<TaskExecution>
            abstract taskExecutions: ResizeArray<TaskExecution>
            abstract onDidStartTask: Event<TaskStartEvent>
            abstract onDidEndTask: Event<TaskEndEvent>
            abstract onDidStartTaskProcess: Event<TaskProcessStartEvent>
            abstract onDidEndTaskProcess: Event<TaskProcessEndEvent>

    type [<RequireQualifiedAccess>] FileType =
        | Unknown = 0
        | File = 1
        | Directory = 2
        | SymbolicLink = 64

    /// The `FileStat`-type represents metadata about a file
    type [<AllowNullLiteral>] FileStat =
        /// The type of the file, e.g. is a regular file, a directory, or symbolic link
        /// to a file.
        /// 
        /// *Note:* This value might be a bitmask, e.g. `FileType.File | FileType.SymbolicLink`.
        abstract ``type``: FileType with get, set
        /// The creation timestamp in milliseconds elapsed since January 1, 1970 00:00:00 UTC.
        abstract ctime: float with get, set
        /// The modification timestamp in milliseconds elapsed since January 1, 1970 00:00:00 UTC.
        /// 
        /// *Note:* If the file changed, it is important to provide an updated `mtime` that advanced
        /// from the previous value. Otherwise there may be optimizations in place that will not show
        /// the updated file contents in an editor for example.
        abstract mtime: float with get, set
        /// The size in bytes.
        /// 
        /// *Note:* If the file changed, it is important to provide an updated `size`. Otherwise there
        /// may be optimizations in place that will not show the updated file contents in an editor for
        /// example.
        abstract size: float with get, set

    /// A type that filesystem providers should use to signal errors.
    /// 
    /// This class has factory methods for common error-cases, like `FileNotFound` when
    /// a file or folder doesn't exist, use them like so: `throw vscode.FileSystemError.FileNotFound(someUri);`
    type [<AllowNullLiteral; AbstractClass>] FileSystemError =
        inherit Error
        /// A code that identifies this error.
        /// 
        /// Possible values are names of errors, like {@link FileSystemError.FileNotFound `FileNotFound`},
        /// or `Unknown` for unspecified errors.
        abstract code: string

    /// A type that filesystem providers should use to signal errors.
    /// 
    /// This class has factory methods for common error-cases, like `FileNotFound` when
    /// a file or folder doesn't exist, use them like so: `throw vscode.FileSystemError.FileNotFound(someUri);`
    type [<AllowNullLiteral>] FileSystemErrorStatic =
        /// <summary>Create an error to signal that a file or folder wasn't found.</summary>
        /// <param name="messageOrUri">Message or uri.</param>
        abstract FileNotFound: ?messageOrUri: U2<string, Uri> -> FileSystemError
        /// <summary>Create an error to signal that a file or folder already exists, e.g. when
        /// creating but not overwriting a file.</summary>
        /// <param name="messageOrUri">Message or uri.</param>
        abstract FileExists: ?messageOrUri: U2<string, Uri> -> FileSystemError
        /// <summary>Create an error to signal that a file is not a folder.</summary>
        /// <param name="messageOrUri">Message or uri.</param>
        abstract FileNotADirectory: ?messageOrUri: U2<string, Uri> -> FileSystemError
        /// <summary>Create an error to signal that a file is a folder.</summary>
        /// <param name="messageOrUri">Message or uri.</param>
        abstract FileIsADirectory: ?messageOrUri: U2<string, Uri> -> FileSystemError
        /// <summary>Create an error to signal that an operation lacks required permissions.</summary>
        /// <param name="messageOrUri">Message or uri.</param>
        abstract NoPermissions: ?messageOrUri: U2<string, Uri> -> FileSystemError
        /// <summary>Create an error to signal that the file system is unavailable or too busy to
        /// complete a request.</summary>
        /// <param name="messageOrUri">Message or uri.</param>
        abstract Unavailable: ?messageOrUri: U2<string, Uri> -> FileSystemError
        /// <summary>Creates a new filesystem error.</summary>
        /// <param name="messageOrUri">Message or uri.</param>
        [<Emit "new $0($1...)">] abstract Create: ?messageOrUri: U2<string, Uri> -> FileSystemError

    type [<RequireQualifiedAccess>] FileChangeType =
        | Changed = 1
        | Created = 2
        | Deleted = 3

    /// The event filesystem providers must use to signal a file change.
    type [<AllowNullLiteral>] FileChangeEvent =
        /// The type of change.
        abstract ``type``: FileChangeType
        /// The uri of the file that has changed.
        abstract uri: Uri

    /// The filesystem provider defines what the editor needs to read, write, discover,
    /// and to manage files and folders. It allows extensions to serve files from remote places,
    /// like ftp-servers, and to seamlessly integrate those into the editor.
    /// 
    /// * *Note 1:* The filesystem provider API works with {@link Uri uris} and assumes hierarchical
    /// paths, e.g. `foo:/my/path` is a child of `foo:/my/` and a parent of `foo:/my/path/deeper`.
    /// * *Note 2:* There is an activation event `onFileSystem:<scheme>` that fires when a file
    /// or folder is being accessed.
    /// * *Note 3:* The word 'file' is often used to denote all {@link FileType kinds} of files, e.g.
    /// folders, symbolic links, and regular files.
    type [<AllowNullLiteral>] FileSystemProvider =
        /// An event to signal that a resource has been created, changed, or deleted. This
        /// event should fire for resources that are being {@link FileSystemProvider.watch watched}
        /// by clients of this provider.
        /// 
        /// *Note:* It is important that the metadata of the file that changed provides an
        /// updated `mtime` that advanced from the previous value in the {@link FileStat stat} and a
        /// correct `size` value. Otherwise there may be optimizations in place that will not show
        /// the change in an editor for example.
        abstract onDidChangeFile: Event<ResizeArray<FileChangeEvent>>
        /// <summary>Subscribe to events in the file or folder denoted by `uri`.
        /// 
        /// The editor will call this function for files and folders. In the latter case, the
        /// options differ from defaults, e.g. what files/folders to exclude from watching
        /// and if subfolders, sub-subfolder, etc. should be watched (`recursive`).</summary>
        /// <param name="uri">The uri of the file to be watched.</param>
        /// <param name="options">Configures the watch.</param>
        abstract watch: uri: Uri * options: FileSystemProviderWatchOptions -> Disposable
        /// <summary>Retrieve metadata about a file.
        /// 
        /// Note that the metadata for symbolic links should be the metadata of the file they refer to.
        /// Still, the {@link FileType.SymbolicLink SymbolicLink}-type must be used in addition to the actual type, e.g.
        /// `FileType.SymbolicLink | FileType.Directory`.</summary>
        /// <param name="uri">The uri of the file to retrieve metadata about.</param>
        abstract stat: uri: Uri -> U2<FileStat, Thenable<FileStat>>
        /// <summary>Retrieve all entries of a {@link FileType.Directory directory}.</summary>
        /// <param name="uri">The uri of the folder.</param>
        abstract readDirectory: uri: Uri -> U2<ResizeArray<string * FileType>, Thenable<ResizeArray<string * FileType>>>
        /// <summary>Create a new directory (Note, that new files are created via `write`-calls).</summary>
        /// <param name="uri">The uri of the new folder.</param>
        abstract createDirectory: uri: Uri -> U2<unit, Thenable<unit>>
        /// <summary>Read the entire contents of a file.</summary>
        /// <param name="uri">The uri of the file.</param>
        abstract readFile: uri: Uri -> U2<Uint8Array, Thenable<Uint8Array>>
        /// <summary>Write data to a file, replacing its entire contents.</summary>
        /// <param name="uri">The uri of the file.</param>
        /// <param name="content">The new content of the file.</param>
        /// <param name="options">Defines if missing files should or must be created.</param>
        abstract writeFile: uri: Uri * content: Uint8Array * options: FileSystemProviderWriteFileOptions -> U2<unit, Thenable<unit>>
        /// <summary>Delete a file.</summary>
        /// <param name="uri">The resource that is to be deleted.</param>
        /// <param name="options">Defines if deletion of folders is recursive.</param>
        abstract delete: uri: Uri * options: FileSystemProviderDeleteOptions -> U2<unit, Thenable<unit>>
        /// <summary>Rename a file or folder.</summary>
        /// <param name="oldUri">The existing file.</param>
        /// <param name="newUri">The new location.</param>
        /// <param name="options">Defines if existing files should be overwritten.</param>
        abstract rename: oldUri: Uri * newUri: Uri * options: FileSystemProviderRenameOptions -> U2<unit, Thenable<unit>>
        /// <summary>Copy files or folders. Implementing this function is optional but it will speedup
        /// the copy operation.</summary>
        /// <param name="source">The existing file.</param>
        /// <param name="destination">The destination location.</param>
        /// <param name="options">Defines if existing files should be overwritten.</param>
        abstract copy: source: Uri * destination: Uri * options: FileSystemProviderCopyOptions -> U2<unit, Thenable<unit>>

    type [<AllowNullLiteral>] FileSystemProviderWatchOptions =
        abstract recursive: bool with get, set
        abstract excludes: ResizeArray<string> with get, set

    type [<AllowNullLiteral>] FileSystemProviderWriteFileOptions =
        abstract create: bool with get, set
        abstract overwrite: bool with get, set

    type [<AllowNullLiteral>] FileSystemProviderDeleteOptions =
        abstract recursive: bool with get, set

    type [<AllowNullLiteral>] FileSystemProviderRenameOptions =
        abstract overwrite: bool with get, set

    type [<AllowNullLiteral>] FileSystemProviderCopyOptions =
        abstract overwrite: bool with get, set

    /// The file system interface exposes the editor's built-in and contributed
    /// {@link FileSystemProvider file system providers}. It allows extensions to work
    /// with files from the local disk as well as files from remote places, like the
    /// remote extension host or ftp-servers.
    /// 
    /// *Note* that an instance of this interface is available as {@link workspace.fs `workspace.fs`}.
    type [<AllowNullLiteral>] FileSystem =
        /// <summary>Retrieve metadata about a file.</summary>
        /// <param name="uri">The uri of the file to retrieve metadata about.</param>
        abstract stat: uri: Uri -> Thenable<FileStat>
        /// <summary>Retrieve all entries of a {@link FileType.Directory directory}.</summary>
        /// <param name="uri">The uri of the folder.</param>
        abstract readDirectory: uri: Uri -> Thenable<ResizeArray<string * FileType>>
        /// <summary>Create a new directory (Note, that new files are created via `write`-calls).
        /// 
        /// *Note* that missing directories are created automatically, e.g this call has
        /// `mkdirp` semantics.</summary>
        /// <param name="uri">The uri of the new folder.</param>
        abstract createDirectory: uri: Uri -> Thenable<unit>
        /// <summary>Read the entire contents of a file.</summary>
        /// <param name="uri">The uri of the file.</param>
        abstract readFile: uri: Uri -> Thenable<Uint8Array>
        /// <summary>Write data to a file, replacing its entire contents.</summary>
        /// <param name="uri">The uri of the file.</param>
        /// <param name="content">The new content of the file.</param>
        abstract writeFile: uri: Uri * content: Uint8Array -> Thenable<unit>
        /// <summary>Delete a file.</summary>
        /// <param name="uri">The resource that is to be deleted.</param>
        /// <param name="options">Defines if trash can should be used and if deletion of folders is recursive</param>
        abstract delete: uri: Uri * ?options: FileSystemDeleteOptions -> Thenable<unit>
        /// <summary>Rename a file or folder.</summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="options">Defines if existing files should be overwritten.</param>
        abstract rename: source: Uri * target: Uri * ?options: FileSystemRenameOptions -> Thenable<unit>
        /// <summary>Copy files or folders.</summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="options">Defines if existing files should be overwritten.</param>
        abstract copy: source: Uri * target: Uri * ?options: FileSystemCopyOptions -> Thenable<unit>
        /// <summary>Check if a given file system supports writing files.
        /// 
        /// Keep in mind that just because a file system supports writing, that does
        /// not mean that writes will always succeed. There may be permissions issues
        /// or other errors that prevent writing a file.</summary>
        /// <param name="scheme">The scheme of the filesystem, for example `file` or `git`.</param>
        abstract isWritableFileSystem: scheme: string -> bool option

    type [<AllowNullLiteral>] FileSystemDeleteOptions =
        abstract recursive: bool option with get, set
        abstract useTrash: bool option with get, set

    type [<AllowNullLiteral>] FileSystemRenameOptions =
        abstract overwrite: bool option with get, set

    type [<AllowNullLiteral>] FileSystemCopyOptions =
        abstract overwrite: bool option with get, set

    /// Defines a port mapping used for localhost inside the webview.
    type [<AllowNullLiteral>] WebviewPortMapping =
        /// Localhost port to remap inside the webview.
        abstract webviewPort: float
        /// Destination port. The `webviewPort` is resolved to this port.
        abstract extensionHostPort: float

    /// Content settings for a webview.
    type [<AllowNullLiteral>] WebviewOptions =
        /// Controls whether scripts are enabled in the webview content or not.
        /// 
        /// Defaults to false (scripts-disabled).
        abstract enableScripts: bool option
        /// Controls whether command uris are enabled in webview content or not.
        /// 
        /// Defaults to false.
        abstract enableCommandUris: bool option
        /// Root paths from which the webview can load local (filesystem) resources using uris from `asWebviewUri`
        /// 
        /// Default to the root folders of the current workspace plus the extension's install directory.
        /// 
        /// Pass in an empty array to disallow access to any local resources.
        abstract localResourceRoots: ResizeArray<Uri> option
        /// Mappings of localhost ports used inside the webview.
        /// 
        /// Port mapping allow webviews to transparently define how localhost ports are resolved. This can be used
        /// to allow using a static localhost port inside the webview that is resolved to random port that a service is
        /// running on.
        /// 
        /// If a webview accesses localhost content, we recommend that you specify port mappings even if
        /// the `webviewPort` and `extensionHostPort` ports are the same.
        /// 
        /// *Note* that port mappings only work for `http` or `https` urls. Websocket urls (e.g. `ws://localhost:3000`)
        /// cannot be mapped to another port.
        abstract portMapping: ResizeArray<WebviewPortMapping> option

    /// Displays html content, similarly to an iframe.
    type [<AllowNullLiteral>] Webview =
        /// Content settings for the webview.
        abstract options: WebviewOptions with get, set
        /// HTML contents of the webview.
        /// 
        /// This should be a complete, valid html document. Changing this property causes the webview to be reloaded.
        /// 
        /// Webviews are sandboxed from normal extension process, so all communication with the webview must use
        /// message passing. To send a message from the extension to the webview, use {@link Webview.postMessage `postMessage`}.
        /// To send message from the webview back to an extension, use the `acquireVsCodeApi` function inside the webview
        /// to get a handle to the editor's api and then call `.postMessage()`:
        /// 
        /// ```html
        /// <script>
        ///      const vscode = acquireVsCodeApi(); // acquireVsCodeApi can only be invoked once
        ///      vscode.postMessage({ message: 'hello!' });
        /// </script>
        /// ```
        /// 
        /// To load a resources from the workspace inside a webview, use the `{@link Webview.asWebviewUri asWebviewUri}` method
        /// and ensure the resource's directory is listed in {@link WebviewOptions.localResourceRoots `WebviewOptions.localResourceRoots`}.
        /// 
        /// Keep in mind that even though webviews are sandboxed, they still allow running scripts and loading arbitrary content,
        /// so extensions must follow all standard web security best practices when working with webviews. This includes
        /// properly sanitizing all untrusted input (including content from the workspace) and
        /// setting a [content security policy](https://aka.ms/vscode-api-webview-csp).
        abstract html: string with get, set
        /// Fired when the webview content posts a message.
        /// 
        /// Webview content can post strings or json serializable objects back to an extension. They cannot
        /// post `Blob`, `File`, `ImageData` and other DOM specific objects since the extension that receives the
        /// message does not run in a browser environment.
        abstract onDidReceiveMessage: Event<obj option>
        /// <summary>Post a message to the webview content.
        /// 
        /// Messages are only delivered if the webview is live (either visible or in the
        /// background with `retainContextWhenHidden`).</summary>
        /// <param name="message">Body of the message. This must be a string or other json serializable object.
        /// 
        /// For older versions of vscode, if an `ArrayBuffer` is included in `message`,
        /// it will not be serialized properly and will not be received by the webview.
        /// Similarly any TypedArrays, such as a `Uint8Array`, will be very inefficiently
        /// serialized and will also not be recreated as a typed array inside the webview.
        /// 
        /// However if your extension targets vscode 1.57+ in the `engines` field of its
        /// `package.json`, any `ArrayBuffer` values that appear in `message` will be more
        /// efficiently transferred to the webview and will also be correctly recreated inside
        /// of the webview.</param>
        abstract postMessage: message: obj option -> Thenable<bool>
        /// Convert a uri for the local file system to one that can be used inside webviews.
        /// 
        /// Webviews cannot directly load resources from the workspace or local file system using `file:` uris. The
        /// `asWebviewUri` function takes a local `file:` uri and converts it into a uri that can be used inside of
        /// a webview to load the same resource:
        /// 
        /// ```ts
        /// webview.html = `<img src="${webview.asWebviewUri(vscode.Uri.file('/Users/codey/workspace/cat.gif'))}">`
        /// ```
        abstract asWebviewUri: localResource: Uri -> Uri
        /// Content security policy source for webview resources.
        /// 
        /// This is the origin that should be used in a content security policy rule:
        /// 
        /// ```
        /// img-src https: ${webview.cspSource} ...;
        /// ```
        abstract cspSource: string

    /// Content settings for a webview panel.
    type [<AllowNullLiteral>] WebviewPanelOptions =
        /// Controls if the find widget is enabled in the panel.
        /// 
        /// Defaults to false.
        abstract enableFindWidget: bool option
        /// Controls if the webview panel's content (iframe) is kept around even when the panel
        /// is no longer visible.
        /// 
        /// Normally the webview panel's html context is created when the panel becomes visible
        /// and destroyed when it is hidden. Extensions that have complex state
        /// or UI can set the `retainContextWhenHidden` to make the editor keep the webview
        /// context around, even when the webview moves to a background tab. When a webview using
        /// `retainContextWhenHidden` becomes hidden, its scripts and other dynamic content are suspended.
        /// When the panel becomes visible again, the context is automatically restored
        /// in the exact same state it was in originally. You cannot send messages to a
        /// hidden webview, even with `retainContextWhenHidden` enabled.
        /// 
        /// `retainContextWhenHidden` has a high memory overhead and should only be used if
        /// your panel's context cannot be quickly saved and restored.
        abstract retainContextWhenHidden: bool option

    /// A panel that contains a webview.
    type [<AllowNullLiteral>] WebviewPanel =
        /// Identifies the type of the webview panel, such as `'markdown.preview'`.
        abstract viewType: string
        /// Title of the panel shown in UI.
        abstract title: string with get, set
        /// Icon for the panel shown in UI.
        abstract iconPath: U2<Uri, WorkspaceEditEntryMetadataIconPath> option with get, set
        /// {@link Webview `Webview`} belonging to the panel.
        abstract webview: Webview
        /// Content settings for the webview panel.
        abstract options: WebviewPanelOptions
        /// Editor position of the panel. This property is only set if the webview is in
        /// one of the editor view columns.
        abstract viewColumn: ViewColumn option
        /// Whether the panel is active (focused by the user).
        abstract active: bool
        /// Whether the panel is visible.
        abstract visible: bool
        /// Fired when the panel's view state changes.
        abstract onDidChangeViewState: Event<WebviewPanelOnDidChangeViewStateEvent>
        /// Fired when the panel is disposed.
        /// 
        /// This may be because the user closed the panel or because `.dispose()` was
        /// called on it.
        /// 
        /// Trying to use the panel after it has been disposed throws an exception.
        abstract onDidDispose: Event<unit>
        /// <summary>Show the webview panel in a given column.
        /// 
        /// A webview panel may only show in a single column at a time. If it is already showing, this
        /// method moves it to a new column.</summary>
        /// <param name="viewColumn">View column to show the panel in. Shows in the current `viewColumn` if undefined.</param>
        /// <param name="preserveFocus">When `true`, the webview will not take focus.</param>
        abstract reveal: ?viewColumn: ViewColumn * ?preserveFocus: bool -> unit
        /// Dispose of the webview panel.
        /// 
        /// This closes the panel if it showing and disposes of the resources owned by the webview.
        /// Webview panels are also disposed when the user closes the webview panel. Both cases
        /// fire the `onDispose` event.
        abstract dispose: unit -> obj option

    /// Event fired when a webview panel's view state changes.
    type [<AllowNullLiteral>] WebviewPanelOnDidChangeViewStateEvent =
        /// Webview panel whose view state changed.
        abstract webviewPanel: WebviewPanel

    type WebviewPanelSerializer =
        WebviewPanelSerializer<obj>

    /// Restore webview panels that have been persisted when vscode shuts down.
    /// 
    /// There are two types of webview persistence:
    /// 
    /// - Persistence within a session.
    /// - Persistence across sessions (across restarts of the editor).
    /// 
    /// A `WebviewPanelSerializer` is only required for the second case: persisting a webview across sessions.
    /// 
    /// Persistence within a session allows a webview to save its state when it becomes hidden
    /// and restore its content from this state when it becomes visible again. It is powered entirely
    /// by the webview content itself. To save off a persisted state, call `acquireVsCodeApi().setState()` with
    /// any json serializable object. To restore the state again, call `getState()`
    /// 
    /// ```js
    /// // Within the webview
    /// const vscode = acquireVsCodeApi();
    /// 
    /// // Get existing state
    /// const oldState = vscode.getState() || { value: 0 };
    /// 
    /// // Update state
    /// setState({ value: oldState.value + 1 })
    /// ```
    /// 
    /// A `WebviewPanelSerializer` extends this persistence across restarts of the editor. When the editor is shutdown,
    /// it will save off the state from `setState` of all webviews that have a serializer. When the
    /// webview first becomes visible after the restart, this state is passed to `deserializeWebviewPanel`.
    /// The extension can then restore the old `WebviewPanel` from this state.
    type [<AllowNullLiteral>] WebviewPanelSerializer<'T> =
        /// <summary>Restore a webview panel from its serialized `state`.
        /// 
        /// Called when a serialized webview first becomes visible.</summary>
        /// <param name="webviewPanel">Webview panel to restore. The serializer should take ownership of this panel. The
        /// serializer must restore the webview's `.html` and hook up all webview events.</param>
        /// <param name="state">Persisted state from the webview content.</param>
        abstract deserializeWebviewPanel: webviewPanel: WebviewPanel * state: 'T -> Thenable<unit>

    /// A webview based view.
    type [<AllowNullLiteral>] WebviewView =
        /// Identifies the type of the webview view, such as `'hexEditor.dataView'`.
        abstract viewType: string
        /// The underlying webview for the view.
        abstract webview: Webview
        /// View title displayed in the UI.
        /// 
        /// The view title is initially taken from the extension `package.json` contribution.
        abstract title: string option with get, set
        /// Human-readable string which is rendered less prominently in the title.
        abstract description: string option with get, set
        /// Event fired when the view is disposed.
        /// 
        /// Views are disposed when they are explicitly hidden by a user (this happens when a user
        /// right clicks in a view and unchecks the webview view).
        /// 
        /// Trying to use the view after it has been disposed throws an exception.
        abstract onDidDispose: Event<unit>
        /// Tracks if the webview is currently visible.
        /// 
        /// Views are visible when they are on the screen and expanded.
        abstract visible: bool
        /// Event fired when the visibility of the view changes.
        /// 
        /// Actions that trigger a visibility change:
        /// 
        /// - The view is collapsed or expanded.
        /// - The user switches to a different view group in the sidebar or panel.
        /// 
        /// Note that hiding a view using the context menu instead disposes of the view and fires `onDidDispose`.
        abstract onDidChangeVisibility: Event<unit>
        /// <summary>Reveal the view in the UI.
        /// 
        /// If the view is collapsed, this will expand it.</summary>
        /// <param name="preserveFocus">When `true` the view will not take focus.</param>
        abstract show: ?preserveFocus: bool -> unit

    type WebviewViewResolveContext =
        WebviewViewResolveContext<obj>

    /// Additional information the webview view being resolved.
    type [<AllowNullLiteral>] WebviewViewResolveContext<'T> =
        /// Persisted state from the webview content.
        /// 
        /// To save resources, the editor normally deallocates webview documents (the iframe content) that are not visible.
        /// For example, when the user collapse a view or switches to another top level activity in the sidebar, the
        /// `WebviewView` itself is kept alive but the webview's underlying document is deallocated. It is recreated when
        /// the view becomes visible again.
        /// 
        /// You can prevent this behavior by setting `retainContextWhenHidden` in the `WebviewOptions`. However this
        /// increases resource usage and should be avoided wherever possible. Instead, you can use persisted state to
        /// save off a webview's state so that it can be quickly recreated as needed.
        /// 
        /// To save off a persisted state, inside the webview call `acquireVsCodeApi().setState()` with
        /// any json serializable object. To restore the state again, call `getState()`. For example:
        /// 
        /// ```js
        /// // Within the webview
        /// const vscode = acquireVsCodeApi();
        /// 
        /// // Get existing state
        /// const oldState = vscode.getState() || { value: 0 };
        /// 
        /// // Update state
        /// setState({ value: oldState.value + 1 })
        /// ```
        /// 
        /// The editor ensures that the persisted state is saved correctly when a webview is hidden and across
        /// editor restarts.
        abstract state: 'T option

    /// Provider for creating `WebviewView` elements.
    type [<AllowNullLiteral>] WebviewViewProvider =
        /// <summary>Revolves a webview view.
        /// 
        /// `resolveWebviewView` is called when a view first becomes visible. This may happen when the view is
        /// first loaded or when the user hides and then shows a view again.</summary>
        /// <param name="webviewView">Webview view to restore. The provider should take ownership of this view. The
        /// provider must set the webview's `.html` and hook up all webview events it is interested in.</param>
        /// <param name="context">Additional metadata about the view being resolved.</param>
        /// <param name="token">Cancellation token indicating that the view being provided is no longer needed.</param>
        abstract resolveWebviewView: webviewView: WebviewView * context: WebviewViewResolveContext * token: CancellationToken -> U2<Thenable<unit>, unit>

    /// Provider for text based custom editors.
    /// 
    /// Text based custom editors use a {@link TextDocument `TextDocument`} as their data model. This considerably simplifies
    /// implementing a custom editor as it allows the editor to handle many common operations such as
    /// undo and backup. The provider is responsible for synchronizing text changes between the webview and the `TextDocument`.
    type [<AllowNullLiteral>] CustomTextEditorProvider =
        /// <summary>Resolve a custom editor for a given text resource.
        /// 
        /// This is called when a user first opens a resource for a `CustomTextEditorProvider`, or if they reopen an
        /// existing editor using this `CustomTextEditorProvider`.</summary>
        /// <param name="document">Document for the resource to resolve.</param>
        /// <param name="webviewPanel">The webview panel used to display the editor UI for this resource.
        /// 
        /// During resolve, the provider must fill in the initial html for the content webview panel and hook up all
        /// the event listeners on it that it is interested in. The provider can also hold onto the `WebviewPanel` to
        /// use later for example in a command. See {@link WebviewPanel `WebviewPanel`} for additional details.</param>
        /// <param name="token">A cancellation token that indicates the result is no longer needed.</param>
        abstract resolveCustomTextEditor: document: TextDocument * webviewPanel: WebviewPanel * token: CancellationToken -> U2<Thenable<unit>, unit>

    /// Represents a custom document used by a {@link CustomEditorProvider `CustomEditorProvider`}.
    /// 
    /// Custom documents are only used within a given `CustomEditorProvider`. The lifecycle of a `CustomDocument` is
    /// managed by the editor. When no more references remain to a `CustomDocument`, it is disposed of.
    type [<AllowNullLiteral>] CustomDocument =
        /// The associated uri for this document.
        abstract uri: Uri
        /// Dispose of the custom document.
        /// 
        /// This is invoked by the editor when there are no more references to a given `CustomDocument` (for example when
        /// all editors associated with the document have been closed.)
        abstract dispose: unit -> unit

    type CustomDocumentEditEvent =
        CustomDocumentEditEvent<obj>

    /// Event triggered by extensions to signal to the editor that an edit has occurred on an {@link CustomDocument `CustomDocument`}.
    type [<AllowNullLiteral>] CustomDocumentEditEvent<'T> =
        /// The document that the edit is for.
        abstract document: 'T
        /// Undo the edit operation.
        /// 
        /// This is invoked by the editor when the user undoes this edit. To implement `undo`, your
        /// extension should restore the document and editor to the state they were in just before this
        /// edit was added to the editor's internal edit stack by `onDidChangeCustomDocument`.
        abstract undo: unit -> U2<Thenable<unit>, unit>
        /// Redo the edit operation.
        /// 
        /// This is invoked by the editor when the user redoes this edit. To implement `redo`, your
        /// extension should restore the document and editor to the state they were in just after this
        /// edit was added to the editor's internal edit stack by `onDidChangeCustomDocument`.
        abstract redo: unit -> U2<Thenable<unit>, unit>
        /// Display name describing the edit.
        /// 
        /// This will be shown to users in the UI for undo/redo operations.
        abstract label: string option

    type CustomDocumentContentChangeEvent =
        CustomDocumentContentChangeEvent<obj>

    /// Event triggered by extensions to signal to the editor that the content of a {@link CustomDocument `CustomDocument`}
    /// has changed.
    type [<AllowNullLiteral>] CustomDocumentContentChangeEvent<'T> =
        /// The document that the change is for.
        abstract document: 'T

    /// A backup for an {@link CustomDocument `CustomDocument`}.
    type [<AllowNullLiteral>] CustomDocumentBackup =
        /// Unique identifier for the backup.
        /// 
        /// This id is passed back to your extension in `openCustomDocument` when opening a custom editor from a backup.
        abstract id: string
        /// Delete the current backup.
        /// 
        /// This is called by the editor when it is clear the current backup is no longer needed, such as when a new backup
        /// is made or when the file is saved.
        abstract delete: unit -> unit

    /// Additional information used to implement {@link CustomEditableDocument.backup `CustomEditableDocument.backup`}.
    type [<AllowNullLiteral>] CustomDocumentBackupContext =
        /// Suggested file location to write the new backup.
        /// 
        /// Note that your extension is free to ignore this and use its own strategy for backup.
        /// 
        /// If the editor is for a resource from the current workspace, `destination` will point to a file inside
        /// `ExtensionContext.storagePath`. The parent folder of `destination` may not exist, so make sure to created it
        /// before writing the backup to this location.
        abstract destination: Uri

    /// Additional information about the opening custom document.
    type [<AllowNullLiteral>] CustomDocumentOpenContext =
        /// The id of the backup to restore the document from or `undefined` if there is no backup.
        /// 
        /// If this is provided, your extension should restore the editor from the backup instead of reading the file
        /// from the user's workspace.
        abstract backupId: string option
        /// If the URI is an untitled file, this will be populated with the byte data of that file
        /// 
        /// If this is provided, your extension should utilize this byte data rather than executing fs APIs on the URI passed in
        abstract untitledDocumentData: Uint8Array option

    type CustomReadonlyEditorProvider =
        CustomReadonlyEditorProvider<obj>

    /// Provider for readonly custom editors that use a custom document model.
    /// 
    /// Custom editors use {@link CustomDocument `CustomDocument`} as their document model instead of a {@link TextDocument `TextDocument`}.
    /// 
    /// You should use this type of custom editor when dealing with binary files or more complex scenarios. For simple
    /// text based documents, use {@link CustomTextEditorProvider `CustomTextEditorProvider`} instead.
    type [<AllowNullLiteral>] CustomReadonlyEditorProvider<'T> =
        /// <summary>Create a new document for a given resource.
        /// 
        /// `openCustomDocument` is called when the first time an editor for a given resource is opened. The opened
        /// document is then passed to `resolveCustomEditor` so that the editor can be shown to the user.
        /// 
        /// Already opened `CustomDocument` are re-used if the user opened additional editors. When all editors for a
        /// given resource are closed, the `CustomDocument` is disposed of. Opening an editor at this point will
        /// trigger another call to `openCustomDocument`.</summary>
        /// <param name="uri">Uri of the document to open.</param>
        /// <param name="openContext">Additional information about the opening custom document.</param>
        /// <param name="token">A cancellation token that indicates the result is no longer needed.</param>
        abstract openCustomDocument: uri: Uri * openContext: CustomDocumentOpenContext * token: CancellationToken -> U2<Thenable<'T>, 'T>
        /// <summary>Resolve a custom editor for a given resource.
        /// 
        /// This is called whenever the user opens a new editor for this `CustomEditorProvider`.</summary>
        /// <param name="document">Document for the resource being resolved.</param>
        /// <param name="webviewPanel">The webview panel used to display the editor UI for this resource.
        /// 
        /// During resolve, the provider must fill in the initial html for the content webview panel and hook up all
        /// the event listeners on it that it is interested in. The provider can also hold onto the `WebviewPanel` to
        /// use later for example in a command. See {@link WebviewPanel `WebviewPanel`} for additional details.</param>
        /// <param name="token">A cancellation token that indicates the result is no longer needed.</param>
        abstract resolveCustomEditor: document: 'T * webviewPanel: WebviewPanel * token: CancellationToken -> U2<Thenable<unit>, unit>

    type CustomEditorProvider =
        CustomEditorProvider<obj>

    /// Provider for editable custom editors that use a custom document model.
    /// 
    /// Custom editors use {@link CustomDocument `CustomDocument`} as their document model instead of a {@link TextDocument `TextDocument`}.
    /// This gives extensions full control over actions such as edit, save, and backup.
    /// 
    /// You should use this type of custom editor when dealing with binary files or more complex scenarios. For simple
    /// text based documents, use {@link CustomTextEditorProvider `CustomTextEditorProvider`} instead.
    type [<AllowNullLiteral>] CustomEditorProvider<'T> =
        inherit CustomReadonlyEditorProvider<'T>
        /// Signal that an edit has occurred inside a custom editor.
        /// 
        /// This event must be fired by your extension whenever an edit happens in a custom editor. An edit can be
        /// anything from changing some text, to cropping an image, to reordering a list. Your extension is free to
        /// define what an edit is and what data is stored on each edit.
        /// 
        /// Firing `onDidChange` causes the editors to be marked as being dirty. This is cleared when the user either
        /// saves or reverts the file.
        /// 
        /// Editors that support undo/redo must fire a `CustomDocumentEditEvent` whenever an edit happens. This allows
        /// users to undo and redo the edit using the editor's standard keyboard shortcuts. The editor will also mark
        /// the editor as no longer being dirty if the user undoes all edits to the last saved state.
        /// 
        /// Editors that support editing but cannot use the editor's standard undo/redo mechanism must fire a `CustomDocumentContentChangeEvent`.
        /// The only way for a user to clear the dirty state of an editor that does not support undo/redo is to either
        /// `save` or `revert` the file.
        /// 
        /// An editor should only ever fire `CustomDocumentEditEvent` events, or only ever fire `CustomDocumentContentChangeEvent` events.
        abstract onDidChangeCustomDocument: U2<Event<CustomDocumentEditEvent<'T>>, Event<CustomDocumentContentChangeEvent<'T>>>
        /// <summary>Save a custom document.
        /// 
        /// This method is invoked by the editor when the user saves a custom editor. This can happen when the user
        /// triggers save while the custom editor is active, by commands such as `save all`, or by auto save if enabled.
        /// 
        /// To implement `save`, the implementer must persist the custom editor. This usually means writing the
        /// file data for the custom document to disk. After `save` completes, any associated editor instances will
        /// no longer be marked as dirty.</summary>
        /// <param name="document">Document to save.</param>
        /// <param name="cancellation">Token that signals the save is no longer required (for example, if another save was triggered).</param>
        abstract saveCustomDocument: document: 'T * cancellation: CancellationToken -> Thenable<unit>
        /// <summary>Save a custom document to a different location.
        /// 
        /// This method is invoked by the editor when the user triggers 'save as' on a custom editor. The implementer must
        /// persist the custom editor to `destination`.
        /// 
        /// When the user accepts save as, the current editor is be replaced by an non-dirty editor for the newly saved file.</summary>
        /// <param name="document">Document to save.</param>
        /// <param name="destination">Location to save to.</param>
        /// <param name="cancellation">Token that signals the save is no longer required.</param>
        abstract saveCustomDocumentAs: document: 'T * destination: Uri * cancellation: CancellationToken -> Thenable<unit>
        /// <summary>Revert a custom document to its last saved state.
        /// 
        /// This method is invoked by the editor when the user triggers `File: Revert File` in a custom editor. (Note that
        /// this is only used using the editor's `File: Revert File` command and not on a `git revert` of the file).
        /// 
        /// To implement `revert`, the implementer must make sure all editor instances (webviews) for `document`
        /// are displaying the document in the same state is saved in. This usually means reloading the file from the
        /// workspace.</summary>
        /// <param name="document">Document to revert.</param>
        /// <param name="cancellation">Token that signals the revert is no longer required.</param>
        abstract revertCustomDocument: document: 'T * cancellation: CancellationToken -> Thenable<unit>
        /// <summary>Back up a dirty custom document.
        /// 
        /// Backups are used for hot exit and to prevent data loss. Your `backup` method should persist the resource in
        /// its current state, i.e. with the edits applied. Most commonly this means saving the resource to disk in
        /// the `ExtensionContext.storagePath`. When the editor reloads and your custom editor is opened for a resource,
        /// your extension should first check to see if any backups exist for the resource. If there is a backup, your
        /// extension should load the file contents from there instead of from the resource in the workspace.
        /// 
        /// `backup` is triggered approximately one second after the user stops editing the document. If the user
        /// rapidly edits the document, `backup` will not be invoked until the editing stops.
        /// 
        /// `backup` is not invoked when `auto save` is enabled (since auto save already persists the resource).</summary>
        /// <param name="document">Document to backup.</param>
        /// <param name="context">Information that can be used to backup the document.</param>
        /// <param name="cancellation">Token that signals the current backup since a new backup is coming in. It is up to your
        /// extension to decided how to respond to cancellation. If for example your extension is backing up a large file
        /// in an operation that takes time to complete, your extension may decide to finish the ongoing backup rather
        /// than cancelling it to ensure that the editor has some valid backup.</param>
        abstract backupCustomDocument: document: 'T * context: CustomDocumentBackupContext * cancellation: CancellationToken -> Thenable<CustomDocumentBackup>

    /// The clipboard provides read and write access to the system's clipboard.
    type [<AllowNullLiteral>] Clipboard =
        /// Read the current clipboard contents as text.
        abstract readText: unit -> Thenable<string>
        /// Writes text into the clipboard.
        abstract writeText: value: string -> Thenable<unit>

    type [<RequireQualifiedAccess>] UIKind =
        | Desktop = 1
        | Web = 2

    module Env =

        type [<AllowNullLiteral>] IExports =
            abstract appName: string
            abstract appRoot: string
            abstract uriScheme: string
            abstract language: string
            abstract clipboard: Clipboard
            abstract machineId: string
            abstract sessionId: string
            abstract isNewAppInstall: bool
            abstract isTelemetryEnabled: bool
            abstract onDidChangeTelemetryEnabled: Event<bool>
            abstract remoteName: string option
            abstract shell: string
            abstract uiKind: UIKind
            /// <summary>Opens a link externally using the default application. Depending on the
            /// used scheme this can be:
            /// * a browser (`http:`, `https:`)
            /// * a mail client (`mailto:`)
            /// * VSCode itself (`vscode:` from `vscode.env.uriScheme`)
            /// 
            /// *Note* that {@link window.showTextDocument `showTextDocument`} is the right
            /// way to open a text document inside the editor, not this function.</summary>
            /// <param name="target">The uri that should be opened.</param>
            abstract openExternal: target: Uri -> Thenable<bool>
            /// Resolves a uri to a form that is accessible externally.
            /// 
            /// #### `http:` or `https:` scheme
            /// 
            /// Resolves an *external* uri, such as a `http:` or `https:` link, from where the extension is running to a
            /// uri to the same resource on the client machine.
            /// 
            /// This is a no-op if the extension is running on the client machine.
            /// 
            /// If the extension is running remotely, this function automatically establishes a port forwarding tunnel
            /// from the local machine to `target` on the remote and returns a local uri to the tunnel. The lifetime of
            /// the port forwarding tunnel is managed by the editor and the tunnel can be closed by the user.
            /// 
            /// *Note* that uris passed through `openExternal` are automatically resolved and you should not call `asExternalUri` on them.
            /// 
            /// #### `vscode.env.uriScheme`
            /// 
            /// Creates a uri that - if opened in a browser (e.g. via `openExternal`) - will result in a registered {@link UriHandler}
            /// to trigger.
            /// 
            /// Extensions should not make any assumptions about the resulting uri and should not alter it in any way.
            /// Rather, extensions can e.g. use this uri in an authentication flow, by adding the uri as callback query
            /// argument to the server to authenticate to.
            /// 
            /// *Note* that if the server decides to add additional query parameters to the uri (e.g. a token or secret), it
            /// will appear in the uri that is passed to the {@link UriHandler}.
            /// 
            /// **Example** of an authentication flow:
            /// ```typescript
            /// vscode.window.registerUriHandler({
            ///    handleUri(uri: vscode.Uri): vscode.ProviderResult<void> {
            ///      if (uri.path === '/did-authenticate') {
            ///        console.log(uri.toString());
            ///      }
            ///    }
            /// });
            /// 
            /// const callableUri = await vscode.env.asExternalUri(vscode.Uri.parse(`${vscode.env.uriScheme}://my.extension/did-authenticate`));
            /// await vscode.env.openExternal(callableUri);
            /// ```
            /// 
            /// *Note* that extensions should not cache the result of `asExternalUri` as the resolved uri may become invalid due to
            /// a system or user action — for example, in remote cases, a user may close a port forwarding tunnel that was opened by
            /// `asExternalUri`.
            /// 
            /// #### Any other scheme
            /// 
            /// Any other scheme will be handled as if the provided URI is a workspace URI. In that case, the method will return
            /// a URI which, when handled, will make the editor open the workspace.
            abstract asExternalUri: target: Uri -> Thenable<Uri>

    module Commands =

        type [<AllowNullLiteral>] IExports =
            /// <summary>Registers a command that can be invoked via a keyboard shortcut,
            /// a menu item, an action, or directly.
            /// 
            /// Registering a command with an existing command identifier twice
            /// will cause an error.</summary>
            /// <param name="command">A unique identifier for the command.</param>
            /// <param name="callback">A command handler function.</param>
            /// <param name="thisArg">The `this` context used when invoking the handler function.</param>
            abstract registerCommand: command: string * callback: (ResizeArray<obj option> -> obj option) * ?thisArg: obj -> Disposable
            /// <summary>Registers a text editor command that can be invoked via a keyboard shortcut,
            /// a menu item, an action, or directly.
            /// 
            /// Text editor commands are different from ordinary {@link commands.registerCommand commands} as
            /// they only execute when there is an active editor when the command is called. Also, the
            /// command handler of an editor command has access to the active editor and to an
            /// {@link TextEditorEdit edit}-builder. Note that the edit-builder is only valid while the
            /// callback executes.</summary>
            /// <param name="command">A unique identifier for the command.</param>
            /// <param name="callback">A command handler function with access to an {@link TextEditor editor} and an {@link TextEditorEdit edit}.</param>
            /// <param name="thisArg">The `this` context used when invoking the handler function.</param>
            abstract registerTextEditorCommand: command: string * callback: (TextEditor -> TextEditorEdit -> ResizeArray<obj option> -> unit) * ?thisArg: obj -> Disposable
            /// <summary>Executes the command denoted by the given command identifier.
            /// 
            /// * *Note 1:* When executing an editor command not all types are allowed to
            /// be passed as arguments. Allowed are the primitive types `string`, `boolean`,
            /// `number`, `undefined`, and `null`, as well as {@link Position `Position`}, {@link Range `Range`}, {@link Uri `Uri`} and {@link Location `Location`}.
            /// * *Note 2:* There are no restrictions when executing commands that have been contributed
            /// by extensions.</summary>
            /// <param name="command">Identifier of the command to execute.</param>
            /// <param name="rest">Parameters passed to the command function.</param>
            abstract executeCommand: command: string * [<ParamArray>] rest: ResizeArray<obj option> -> Thenable<'T option>
            /// <summary>Retrieve the list of all available commands. Commands starting with an underscore are
            /// treated as internal commands.</summary>
            /// <param name="filterInternal">Set `true` to not see internal commands (starting with an underscore)</param>
            abstract getCommands: ?filterInternal: bool -> Thenable<ResizeArray<string>>

    /// Represents the state of a window.
    type [<AllowNullLiteral>] WindowState =
        /// Whether the current window is focused.
        abstract focused: bool

    /// A uri handler is responsible for handling system-wide {@link Uri uris}.
    type [<AllowNullLiteral>] UriHandler =
        /// Handle the provided system-wide {@link Uri}.
        abstract handleUri: uri: Uri -> ProviderResult<unit>

    module Window =

        type [<AllowNullLiteral>] IExports =
            abstract activeTextEditor: TextEditor option
            abstract visibleTextEditors: ResizeArray<TextEditor>
            abstract onDidChangeActiveTextEditor: Event<TextEditor option>
            abstract onDidChangeVisibleTextEditors: Event<ResizeArray<TextEditor>>
            abstract onDidChangeTextEditorSelection: Event<TextEditorSelectionChangeEvent>
            abstract onDidChangeTextEditorVisibleRanges: Event<TextEditorVisibleRangesChangeEvent>
            abstract onDidChangeTextEditorOptions: Event<TextEditorOptionsChangeEvent>
            abstract onDidChangeTextEditorViewColumn: Event<TextEditorViewColumnChangeEvent>
            abstract terminals: ResizeArray<Terminal>
            abstract activeTerminal: Terminal option
            abstract onDidChangeActiveTerminal: Event<Terminal option>
            abstract onDidOpenTerminal: Event<Terminal>
            abstract onDidCloseTerminal: Event<Terminal>
            abstract state: WindowState
            abstract onDidChangeWindowState: Event<WindowState>
            /// <summary>Show the given document in a text editor. A {@link ViewColumn column} can be provided
            /// to control where the editor is being shown. Might change the {@link window.activeTextEditor active editor}.</summary>
            /// <param name="document">A text document to be shown.</param>
            /// <param name="column">A view column in which the {@link TextEditor editor} should be shown. The default is the {@link ViewColumn.Active active}, other values
            /// are adjusted to be `Min(column, columnCount + 1)`, the {@link ViewColumn.Active active}-column is not adjusted. Use {@link ViewColumn.Beside `ViewColumn.Beside`}
            /// to open the editor to the side of the currently active one.</param>
            /// <param name="preserveFocus">When `true` the editor will not take focus.</param>
            abstract showTextDocument: document: TextDocument * ?column: ViewColumn * ?preserveFocus: bool -> Thenable<TextEditor>
            /// <summary>Show the given document in a text editor. {@link TextDocumentShowOptions Options} can be provided
            /// to control options of the editor is being shown. Might change the {@link window.activeTextEditor active editor}.</summary>
            /// <param name="document">A text document to be shown.</param>
            /// <param name="options"></param>
            abstract showTextDocument: document: TextDocument * ?options: TextDocumentShowOptions -> Thenable<TextEditor>
            /// <summary>A short-hand for `openTextDocument(uri).then(document => showTextDocument(document, options))`.</summary>
            /// <param name="uri">A resource identifier.</param>
            /// <param name="options"></param>
            abstract showTextDocument: uri: Uri * ?options: TextDocumentShowOptions -> Thenable<TextEditor>
            /// <summary>Create a TextEditorDecorationType that can be used to add decorations to text editors.</summary>
            /// <param name="options">Rendering options for the decoration type.</param>
            abstract createTextEditorDecorationType: options: DecorationRenderOptions -> TextEditorDecorationType
            /// <summary>Show an information message to users. Optionally provide an array of items which will be presented as
            /// clickable buttons.</summary>
            /// <param name="message">The message to show.</param>
            /// <param name="items">A set of items that will be rendered as actions in the message.</param>
            abstract showInformationMessage: message: string * [<ParamArray>] items: ResizeArray<string> -> Thenable<string option>
            /// <summary>Show an information message to users. Optionally provide an array of items which will be presented as
            /// clickable buttons.</summary>
            /// <param name="message">The message to show.</param>
            /// <param name="options">Configures the behaviour of the message.</param>
            /// <param name="items">A set of items that will be rendered as actions in the message.</param>
            abstract showInformationMessage: message: string * options: MessageOptions * [<ParamArray>] items: ResizeArray<string> -> Thenable<string option>
            /// <summary>Show an information message.</summary>
            /// <param name="message">The message to show.</param>
            /// <param name="items">A set of items that will be rendered as actions in the message.</param>
            abstract showInformationMessage: message: string * [<ParamArray>] items: ResizeArray<'T> -> Thenable<'T option>
            /// <summary>Show an information message.</summary>
            /// <param name="message">The message to show.</param>
            /// <param name="options">Configures the behaviour of the message.</param>
            /// <param name="items">A set of items that will be rendered as actions in the message.</param>
            abstract showInformationMessage: message: string * options: MessageOptions * [<ParamArray>] items: ResizeArray<'T> -> Thenable<'T option>
            /// <summary>Show a warning message.</summary>
            /// <param name="message">The message to show.</param>
            /// <param name="items">A set of items that will be rendered as actions in the message.</param>
            abstract showWarningMessage: message: string * [<ParamArray>] items: ResizeArray<string> -> Thenable<string option>
            /// <summary>Show a warning message.</summary>
            /// <param name="message">The message to show.</param>
            /// <param name="options">Configures the behaviour of the message.</param>
            /// <param name="items">A set of items that will be rendered as actions in the message.</param>
            abstract showWarningMessage: message: string * options: MessageOptions * [<ParamArray>] items: ResizeArray<string> -> Thenable<string option>
            /// <summary>Show a warning message.</summary>
            /// <param name="message">The message to show.</param>
            /// <param name="items">A set of items that will be rendered as actions in the message.</param>
            abstract showWarningMessage: message: string * [<ParamArray>] items: ResizeArray<'T> -> Thenable<'T option>
            /// <summary>Show a warning message.</summary>
            /// <param name="message">The message to show.</param>
            /// <param name="options">Configures the behaviour of the message.</param>
            /// <param name="items">A set of items that will be rendered as actions in the message.</param>
            abstract showWarningMessage: message: string * options: MessageOptions * [<ParamArray>] items: ResizeArray<'T> -> Thenable<'T option>
            /// <summary>Show an error message.</summary>
            /// <param name="message">The message to show.</param>
            /// <param name="items">A set of items that will be rendered as actions in the message.</param>
            abstract showErrorMessage: message: string * [<ParamArray>] items: ResizeArray<string> -> Thenable<string option>
            /// <summary>Show an error message.</summary>
            /// <param name="message">The message to show.</param>
            /// <param name="options">Configures the behaviour of the message.</param>
            /// <param name="items">A set of items that will be rendered as actions in the message.</param>
            abstract showErrorMessage: message: string * options: MessageOptions * [<ParamArray>] items: ResizeArray<string> -> Thenable<string option>
            /// <summary>Show an error message.</summary>
            /// <param name="message">The message to show.</param>
            /// <param name="items">A set of items that will be rendered as actions in the message.</param>
            abstract showErrorMessage: message: string * [<ParamArray>] items: ResizeArray<'T> -> Thenable<'T option>
            /// <summary>Show an error message.</summary>
            /// <param name="message">The message to show.</param>
            /// <param name="options">Configures the behaviour of the message.</param>
            /// <param name="items">A set of items that will be rendered as actions in the message.</param>
            abstract showErrorMessage: message: string * options: MessageOptions * [<ParamArray>] items: ResizeArray<'T> -> Thenable<'T option>
            /// <summary>Shows a selection list allowing multiple selections.</summary>
            /// <param name="items">An array of strings, or a promise that resolves to an array of strings.</param>
            /// <param name="options">Configures the behavior of the selection list.</param>
            /// <param name="token">A token that can be used to signal cancellation.</param>
            abstract showQuickPick: items: U2<ResizeArray<string>, Thenable<ResizeArray<string>>> * options: obj * ?token: CancellationToken -> Thenable<ResizeArray<string> option>
            /// <summary>Shows a selection list.</summary>
            /// <param name="items">An array of strings, or a promise that resolves to an array of strings.</param>
            /// <param name="options">Configures the behavior of the selection list.</param>
            /// <param name="token">A token that can be used to signal cancellation.</param>
            abstract showQuickPick: items: U2<ResizeArray<string>, Thenable<ResizeArray<string>>> * ?options: QuickPickOptions * ?token: CancellationToken -> Thenable<string option>
            /// <summary>Shows a selection list allowing multiple selections.</summary>
            /// <param name="items">An array of items, or a promise that resolves to an array of items.</param>
            /// <param name="options">Configures the behavior of the selection list.</param>
            /// <param name="token">A token that can be used to signal cancellation.</param>
            abstract showQuickPick: items: U2<ResizeArray<'T>, Thenable<ResizeArray<'T>>> * options: obj * ?token: CancellationToken -> Thenable<ResizeArray<'T> option>
            /// <summary>Shows a selection list.</summary>
            /// <param name="items">An array of items, or a promise that resolves to an array of items.</param>
            /// <param name="options">Configures the behavior of the selection list.</param>
            /// <param name="token">A token that can be used to signal cancellation.</param>
            abstract showQuickPick: items: U2<ResizeArray<'T>, Thenable<ResizeArray<'T>>> * ?options: QuickPickOptions * ?token: CancellationToken -> Thenable<'T option>
            /// <summary>Shows a selection list of {@link workspace.workspaceFolders workspace folders} to pick from.
            /// Returns `undefined` if no folder is open.</summary>
            /// <param name="options">Configures the behavior of the workspace folder list.</param>
            abstract showWorkspaceFolderPick: ?options: WorkspaceFolderPickOptions -> Thenable<WorkspaceFolder option>
            /// <summary>Shows a file open dialog to the user which allows to select a file
            /// for opening-purposes.</summary>
            /// <param name="options">Options that control the dialog.</param>
            abstract showOpenDialog: ?options: OpenDialogOptions -> Thenable<ResizeArray<Uri> option>
            /// <summary>Shows a file save dialog to the user which allows to select a file
            /// for saving-purposes.</summary>
            /// <param name="options">Options that control the dialog.</param>
            abstract showSaveDialog: ?options: SaveDialogOptions -> Thenable<Uri option>
            /// <summary>Opens an input box to ask the user for input.
            /// 
            /// The returned value will be `undefined` if the input box was canceled (e.g. pressing ESC). Otherwise the
            /// returned value will be the string typed by the user or an empty string if the user did not type
            /// anything but dismissed the input box with OK.</summary>
            /// <param name="options">Configures the behavior of the input box.</param>
            /// <param name="token">A token that can be used to signal cancellation.</param>
            abstract showInputBox: ?options: InputBoxOptions * ?token: CancellationToken -> Thenable<string option>
            /// Creates a {@link QuickPick} to let the user pick an item from a list
            /// of items of type T.
            /// 
            /// Note that in many cases the more convenient {@link window.showQuickPick}
            /// is easier to use. {@link window.createQuickPick} should be used
            /// when {@link window.showQuickPick} does not offer the required flexibility.
            abstract createQuickPick: unit -> QuickPick<'T>
            /// Creates a {@link InputBox} to let the user enter some text input.
            /// 
            /// Note that in many cases the more convenient {@link window.showInputBox}
            /// is easier to use. {@link window.createInputBox} should be used
            /// when {@link window.showInputBox} does not offer the required flexibility.
            abstract createInputBox: unit -> InputBox
            /// <summary>Creates a new {@link OutputChannel output channel} with the given name.</summary>
            /// <param name="name">Human-readable string which will be used to represent the channel in the UI.</param>
            abstract createOutputChannel: name: string -> OutputChannel
            /// <summary>Create and show a new webview panel.</summary>
            /// <param name="viewType">Identifies the type of the webview panel.</param>
            /// <param name="title">Title of the panel.</param>
            /// <param name="showOptions">Where to show the webview in the editor. If preserveFocus is set, the new webview will not take focus.</param>
            /// <param name="options">Settings for the new panel.</param>
            abstract createWebviewPanel: viewType: string * title: string * showOptions: U2<ViewColumn, IExportsCreateWebviewPanel> * ?options: obj -> WebviewPanel
            /// <summary>Set a message to the status bar. This is a short hand for the more powerful
            /// status bar {@link window.createStatusBarItem items}.</summary>
            /// <param name="text">The message to show, supports icon substitution as in status bar {@link StatusBarItem.text items}.</param>
            /// <param name="hideAfterTimeout">Timeout in milliseconds after which the message will be disposed.</param>
            abstract setStatusBarMessage: text: string * hideAfterTimeout: float -> Disposable
            /// <summary>Set a message to the status bar. This is a short hand for the more powerful
            /// status bar {@link window.createStatusBarItem items}.</summary>
            /// <param name="text">The message to show, supports icon substitution as in status bar {@link StatusBarItem.text items}.</param>
            /// <param name="hideWhenDone">Thenable on which completion (resolve or reject) the message will be disposed.</param>
            abstract setStatusBarMessage: text: string * hideWhenDone: Thenable<obj option> -> Disposable
            /// <summary>Set a message to the status bar. This is a short hand for the more powerful
            /// status bar {@link window.createStatusBarItem items}.
            /// 
            /// *Note* that status bar messages stack and that they must be disposed when no
            /// longer used.</summary>
            /// <param name="text">The message to show, supports icon substitution as in status bar {@link StatusBarItem.text items}.</param>
            abstract setStatusBarMessage: text: string -> Disposable
            /// <summary>Show progress in the Source Control viewlet while running the given callback and while
            /// its returned promise isn't resolve or rejected.</summary>
            /// <param name="task">A callback returning a promise. Progress increments can be reported with
            /// the provided {@link Progress}-object.</param>
            abstract withScmProgress: task: (Progress<float> -> Thenable<'R>) -> Thenable<'R>
            /// <summary>Show progress in the editor. Progress is shown while running the given callback
            /// and while the promise it returned isn't resolved nor rejected. The location at which
            /// progress should show (and other details) is defined via the passed {@link ProgressOptions `ProgressOptions`}.</summary>
            /// <param name="options"></param>
            /// <param name="task">A callback returning a promise. Progress state can be reported with
            /// the provided {@link Progress}-object.
            /// 
            /// To report discrete progress, use `increment` to indicate how much work has been completed. Each call with
            /// a `increment` value will be summed up and reflected as overall progress until 100% is reached (a value of
            /// e.g. `10` accounts for `10%` of work done).
            /// Note that currently only `ProgressLocation.Notification` is capable of showing discrete progress.
            /// 
            /// To monitor if the operation has been cancelled by the user, use the provided {@link CancellationToken `CancellationToken`}.
            /// Note that currently only `ProgressLocation.Notification` is supporting to show a cancel button to cancel the
            /// long running operation.</param>
            abstract withProgress: options: ProgressOptions * task: (Progress<IExportsWithProgressProgress> -> CancellationToken -> Thenable<'R>) -> Thenable<'R>
            /// <summary>Creates a status bar {@link StatusBarItem item}.</summary>
            /// <param name="alignment">The alignment of the item.</param>
            /// <param name="priority">The priority of the item. Higher values mean the item should be shown more to the left.</param>
            abstract createStatusBarItem: ?alignment: StatusBarAlignment * ?priority: float -> StatusBarItem
            /// <summary>Creates a status bar {@link StatusBarItem item}.</summary>
            /// <param name="id">The unique identifier of the item.</param>
            /// <param name="alignment">The alignment of the item.</param>
            /// <param name="priority">The priority of the item. Higher values mean the item should be shown more to the left.</param>
            abstract createStatusBarItem: id: string * ?alignment: StatusBarAlignment * ?priority: float -> StatusBarItem
            /// <summary>Creates a {@link Terminal} with a backing shell process. The cwd of the terminal will be the workspace
            /// directory if it exists.</summary>
            /// <param name="name">Optional human-readable string which will be used to represent the terminal in the UI.</param>
            /// <param name="shellPath">Optional path to a custom shell executable to be used in the terminal.</param>
            /// <param name="shellArgs">Optional args for the custom shell executable. A string can be used on Windows only which
            /// allows specifying shell args in
            /// [command-line format](https://msdn.microsoft.com/en-au/08dfcab2-eb6e-49a4-80eb-87d4076c98c6).</param>
            abstract createTerminal: ?name: string * ?shellPath: string * ?shellArgs: U2<ResizeArray<string>, string> -> Terminal
            /// <summary>Creates a {@link Terminal} with a backing shell process.</summary>
            /// <param name="options">A TerminalOptions object describing the characteristics of the new terminal.</param>
            abstract createTerminal: options: TerminalOptions -> Terminal
            /// <summary>Creates a {@link Terminal} where an extension controls its input and output.</summary>
            /// <param name="options">An {@link ExtensionTerminalOptions} object describing
            /// the characteristics of the new terminal.</param>
            abstract createTerminal: options: ExtensionTerminalOptions -> Terminal
            /// <summary>Register a {@link TreeDataProvider} for the view contributed using the extension point `views`.
            /// This will allow you to contribute data to the {@link TreeView} and update if the data changes.
            /// 
            /// **Note:** To get access to the {@link TreeView} and perform operations on it, use {@link window.createTreeView createTreeView}.</summary>
            /// <param name="viewId">Id of the view contributed using the extension point `views`.</param>
            /// <param name="treeDataProvider">A {@link TreeDataProvider} that provides tree data for the view</param>
            abstract registerTreeDataProvider: viewId: string * treeDataProvider: TreeDataProvider<'T> -> Disposable
            /// <summary>Create a {@link TreeView} for the view contributed using the extension point `views`.</summary>
            /// <param name="viewId">Id of the view contributed using the extension point `views`.</param>
            /// <param name="options">Options for creating the {@link TreeView}</param>
            abstract createTreeView: viewId: string * options: TreeViewOptions<'T> -> TreeView<'T>
            /// <summary>Registers a {@link UriHandler uri handler} capable of handling system-wide {@link Uri uris}.
            /// In case there are multiple windows open, the topmost window will handle the uri.
            /// A uri handler is scoped to the extension it is contributed from; it will only
            /// be able to handle uris which are directed to the extension itself. A uri must respect
            /// the following rules:
            /// 
            /// - The uri-scheme must be `vscode.env.uriScheme`;
            /// - The uri-authority must be the extension id (e.g. `my.extension`);
            /// - The uri-path, -query and -fragment parts are arbitrary.
            /// 
            /// For example, if the `my.extension` extension registers a uri handler, it will only
            /// be allowed to handle uris with the prefix `product-name://my.extension`.
            /// 
            /// An extension can only register a single uri handler in its entire activation lifetime.
            /// 
            /// * *Note:* There is an activation event `onUri` that fires when a uri directed for
            /// the current extension is about to be handled.</summary>
            /// <param name="handler">The uri handler to register for this extension.</param>
            abstract registerUriHandler: handler: UriHandler -> Disposable
            /// <summary>Registers a webview panel serializer.
            /// 
            /// Extensions that support reviving should have an `"onWebviewPanel:viewType"` activation event and
            /// make sure that {@link registerWebviewPanelSerializer} is called during activation.
            /// 
            /// Only a single serializer may be registered at a time for a given `viewType`.</summary>
            /// <param name="viewType">Type of the webview panel that can be serialized.</param>
            /// <param name="serializer">Webview serializer.</param>
            abstract registerWebviewPanelSerializer: viewType: string * serializer: WebviewPanelSerializer -> Disposable
            /// <summary>Register a new provider for webview views.</summary>
            /// <param name="viewId">Unique id of the view. This should match the `id` from the
            /// `views` contribution in the package.json.</param>
            /// <param name="provider">Provider for the webview views.</param>
            /// <param name="options"></param>
            abstract registerWebviewViewProvider: viewId: string * provider: WebviewViewProvider * ?options: RegisterWebviewViewProviderOptions -> Disposable
            /// <summary>Register a provider for custom editors for the `viewType` contributed by the `customEditors` extension point.
            /// 
            /// When a custom editor is opened, an `onCustomEditor:viewType` activation event is fired. Your extension
            /// must register a {@link CustomTextEditorProvider `CustomTextEditorProvider`}, {@link CustomReadonlyEditorProvider `CustomReadonlyEditorProvider`},
            /// {@link CustomEditorProvider `CustomEditorProvider`}for `viewType` as part of activation.</summary>
            /// <param name="viewType">Unique identifier for the custom editor provider. This should match the `viewType` from the
            /// `customEditors` contribution point.</param>
            /// <param name="provider">Provider that resolves custom editors.</param>
            /// <param name="options">Options for the provider.</param>
            abstract registerCustomEditorProvider: viewType: string * provider: U3<CustomTextEditorProvider, CustomReadonlyEditorProvider, CustomEditorProvider> * ?options: RegisterCustomEditorProviderOptions -> Disposable
            /// <summary>Register provider that enables the detection and handling of links within the terminal.</summary>
            /// <param name="provider">The provider that provides the terminal links.</param>
            abstract registerTerminalLinkProvider: provider: TerminalLinkProvider -> Disposable
            /// <summary>Registers a provider for a contributed terminal profile.</summary>
            /// <param name="id">The ID of the contributed terminal profile.</param>
            /// <param name="provider">The terminal profile provider.</param>
            abstract registerTerminalProfileProvider: id: string * provider: TerminalProfileProvider -> Disposable
            /// <summary>Register a file decoration provider.</summary>
            /// <param name="provider">A {@link FileDecorationProvider}.</param>
            abstract registerFileDecorationProvider: provider: FileDecorationProvider -> Disposable
            abstract activeColorTheme: ColorTheme
            abstract onDidChangeActiveColorTheme: Event<ColorTheme>

        type [<AllowNullLiteral>] RegisterWebviewViewProviderOptions =
            /// Content settings for the webview created for this view.
            abstract webviewOptions: RegisterWebviewViewProviderOptionsWebviewOptions option

        type [<AllowNullLiteral>] RegisterCustomEditorProviderOptions =
            /// Content settings for the webview panels created for this custom editor.
            abstract webviewOptions: WebviewPanelOptions option
            /// Only applies to `CustomReadonlyEditorProvider | CustomEditorProvider`.
            /// 
            /// Indicates that the provider allows multiple editor instances to be open at the same time for
            /// the same resource.
            /// 
            /// By default, the editor only allows one editor instance to be open at a time for each resource. If the
            /// user tries to open a second editor instance for the resource, the first one is instead moved to where
            /// the second one was to be opened.
            /// 
            /// When `supportsMultipleEditorsPerDocument` is enabled, users can split and create copies of the custom
            /// editor. In this case, the custom editor must make sure it can properly synchronize the states of all
            /// editor instances for a resource so that they are consistent.
            abstract supportsMultipleEditorsPerDocument: bool option

        type [<AllowNullLiteral>] IExportsCreateWebviewPanel =
            abstract viewColumn: ViewColumn with get, set
            abstract preserveFocus: bool option with get, set

        type [<AllowNullLiteral>] IExportsWithProgressProgress =
            abstract message: string option with get, set
            abstract increment: float option with get, set

        type [<AllowNullLiteral>] RegisterWebviewViewProviderOptionsWebviewOptions =
            /// Controls if the webview element itself (iframe) is kept around even when the view
            /// is no longer visible.
            /// 
            /// Normally the webview's html context is created when the view becomes visible
            /// and destroyed when it is hidden. Extensions that have complex state
            /// or UI can set the `retainContextWhenHidden` to make the editor keep the webview
            /// context around, even when the webview moves to a background tab. When a webview using
            /// `retainContextWhenHidden` becomes hidden, its scripts and other dynamic content are suspended.
            /// When the view becomes visible again, the context is automatically restored
            /// in the exact same state it was in originally. You cannot send messages to a
            /// hidden webview, even with `retainContextWhenHidden` enabled.
            /// 
            /// `retainContextWhenHidden` has a high memory overhead and should only be used if
            /// your view's context cannot be quickly saved and restored.
            abstract retainContextWhenHidden: bool option

    /// Options for creating a {@link TreeView}
    type [<AllowNullLiteral>] TreeViewOptions<'T> =
        /// A data provider that provides tree data.
        abstract treeDataProvider: TreeDataProvider<'T> with get, set
        /// Whether to show collapse all action or not.
        abstract showCollapseAll: bool option with get, set
        /// Whether the tree supports multi-select. When the tree supports multi-select and a command is executed from the tree,
        /// the first argument to the command is the tree item that the command was executed on and the second argument is an
        /// array containing all selected tree items.
        abstract canSelectMany: bool option with get, set

    /// The event that is fired when an element in the {@link TreeView} is expanded or collapsed
    type [<AllowNullLiteral>] TreeViewExpansionEvent<'T> =
        /// Element that is expanded or collapsed.
        abstract element: 'T

    /// The event that is fired when there is a change in {@link TreeView.selection tree view's selection}
    type [<AllowNullLiteral>] TreeViewSelectionChangeEvent<'T> =
        /// Selected elements.
        abstract selection: ResizeArray<'T>

    /// The event that is fired when there is a change in {@link TreeView.visible tree view's visibility}
    type [<AllowNullLiteral>] TreeViewVisibilityChangeEvent =
        /// `true` if the {@link TreeView tree view} is visible otherwise `false`.
        abstract visible: bool

    /// Represents a Tree view
    type [<AllowNullLiteral>] TreeView<'T> =
        inherit Disposable
        /// Event that is fired when an element is expanded
        abstract onDidExpandElement: Event<TreeViewExpansionEvent<'T>>
        /// Event that is fired when an element is collapsed
        abstract onDidCollapseElement: Event<TreeViewExpansionEvent<'T>>
        /// Currently selected elements.
        abstract selection: ResizeArray<'T>
        /// Event that is fired when the {@link TreeView.selection selection} has changed
        abstract onDidChangeSelection: Event<TreeViewSelectionChangeEvent<'T>>
        /// `true` if the {@link TreeView tree view} is visible otherwise `false`.
        abstract visible: bool
        /// Event that is fired when {@link TreeView.visible visibility} has changed
        abstract onDidChangeVisibility: Event<TreeViewVisibilityChangeEvent>
        /// An optional human-readable message that will be rendered in the view.
        /// Setting the message to null, undefined, or empty string will remove the message from the view.
        abstract message: string option with get, set
        /// The tree view title is initially taken from the extension package.json
        /// Changes to the title property will be properly reflected in the UI in the title of the view.
        abstract title: string option with get, set
        /// An optional human-readable description which is rendered less prominently in the title of the view.
        /// Setting the title description to null, undefined, or empty string will remove the description from the view.
        abstract description: string option with get, set
        /// Reveals the given element in the tree view.
        /// If the tree view is not visible then the tree view is shown and element is revealed.
        /// 
        /// By default revealed element is selected.
        /// In order to not to select, set the option `select` to `false`.
        /// In order to focus, set the option `focus` to `true`.
        /// In order to expand the revealed element, set the option `expand` to `true`. To expand recursively set `expand` to the number of levels to expand.
        /// **NOTE:** You can expand only to 3 levels maximum.
        /// 
        /// **NOTE:** The {@link TreeDataProvider} that the `TreeView` {@link window.createTreeView is registered with} with must implement {@link TreeDataProvider.getParent getParent} method to access this API.
        abstract reveal: element: 'T * ?options: TreeViewRevealOptions -> Thenable<unit>

    type [<AllowNullLiteral>] TreeViewRevealOptions =
        abstract select: bool option with get, set
        abstract focus: bool option with get, set
        abstract expand: U2<bool, float> option with get, set

    /// A data provider that provides tree data
    type [<AllowNullLiteral>] TreeDataProvider<'T> =
        /// An optional event to signal that an element or root has changed.
        /// This will trigger the view to update the changed element/root and its children recursively (if shown).
        /// To signal that root has changed, do not pass any argument or pass `undefined` or `null`.
        abstract onDidChangeTreeData: Event<U2<'T, unit> option> option with get, set
        /// <summary>Get {@link TreeItem} representation of the `element`</summary>
        /// <param name="element">The element for which {@link TreeItem} representation is asked for.</param>
        abstract getTreeItem: element: 'T -> U2<TreeItem, Thenable<TreeItem>>
        /// <summary>Get the children of `element` or root if no element is passed.</summary>
        /// <param name="element">The element from which the provider gets children. Can be `undefined`.</param>
        abstract getChildren: ?element: 'T -> ProviderResult<ResizeArray<'T>>
        /// <summary>Optional method to return the parent of `element`.
        /// Return `null` or `undefined` if `element` is a child of root.
        /// 
        /// **NOTE:** This method should be implemented in order to access {@link TreeView.reveal reveal} API.</summary>
        /// <param name="element">The element for which the parent has to be returned.</param>
        abstract getParent: element: 'T -> ProviderResult<'T>
        /// <summary>Called on hover to resolve the {@link TreeItem.tooltip TreeItem} property if it is undefined.
        /// Called on tree item click/open to resolve the {@link TreeItem.command TreeItem} property if it is undefined.
        /// Only properties that were undefined can be resolved in `resolveTreeItem`.
        /// Functionality may be expanded later to include being called to resolve other missing
        /// properties on selection and/or on open.
        /// 
        /// Will only ever be called once per TreeItem.
        /// 
        /// onDidChangeTreeData should not be triggered from within resolveTreeItem.
        /// 
        /// *Note* that this function is called when tree items are already showing in the UI.
        /// Because of that, no property that changes the presentation (label, description, etc.)
        /// can be changed.</summary>
        /// <param name="item">Undefined properties of `item` should be set then `item` should be returned.</param>
        /// <param name="element">The object associated with the TreeItem.</param>
        /// <param name="token">A cancellation token.</param>
        abstract resolveTreeItem: item: TreeItem * element: 'T * token: CancellationToken -> ProviderResult<TreeItem>

    type [<AllowNullLiteral>] TreeItem =
        /// A human-readable string describing this item. When `falsy`, it is derived from {@link TreeItem.resourceUri resourceUri}.
        abstract label: U2<string, TreeItemLabel> option with get, set
        /// Optional id for the tree item that has to be unique across tree. The id is used to preserve the selection and expansion state of the tree item.
        /// 
        /// If not provided, an id is generated using the tree item's label. **Note** that when labels change, ids will change and that selection and expansion state cannot be kept stable anymore.
        abstract id: string option with get, set
        /// The icon path or {@link ThemeIcon} for the tree item.
        /// When `falsy`, {@link ThemeIcon.Folder Folder Theme Icon} is assigned, if item is collapsible otherwise {@link ThemeIcon.File File Theme Icon}.
        /// When a file or folder {@link ThemeIcon} is specified, icon is derived from the current file icon theme for the specified theme icon using {@link TreeItem.resourceUri resourceUri} (if provided).
        abstract iconPath: U4<string, Uri, TreeItemIconPath, ThemeIcon> option with get, set
        /// A human-readable string which is rendered less prominent.
        /// When `true`, it is derived from {@link TreeItem.resourceUri resourceUri} and when `falsy`, it is not shown.
        abstract description: U2<string, bool> option with get, set
        /// The {@link Uri} of the resource representing this item.
        /// 
        /// Will be used to derive the {@link TreeItem.label label}, when it is not provided.
        /// Will be used to derive the icon from current file icon theme, when {@link TreeItem.iconPath iconPath} has {@link ThemeIcon} value.
        abstract resourceUri: Uri option with get, set
        /// The tooltip text when you hover over this item.
        abstract tooltip: U2<string, MarkdownString> option with get, set
        /// The {@link Command} that should be executed when the tree item is selected.
        /// 
        /// Please use `vscode.open` or `vscode.diff` as command IDs when the tree item is opening
        /// something in the editor. Using these commands ensures that the resulting editor will
        /// appear consistent with how other built-in trees open editors.
        abstract command: Command option with get, set
        /// {@link TreeItemCollapsibleState} of the tree item.
        abstract collapsibleState: TreeItemCollapsibleState option with get, set
        /// Context value of the tree item. This can be used to contribute item specific actions in the tree.
        /// For example, a tree item is given a context value as `folder`. When contributing actions to `view/item/context`
        /// using `menus` extension point, you can specify context value for key `viewItem` in `when` expression like `viewItem == folder`.
        /// ```
        ///     "contributes": {
        ///         "menus": {
        ///             "view/item/context": [
        ///                 {
        ///                     "command": "extension.deleteFolder",
        ///                     "when": "viewItem == folder"
        ///                 }
        ///             ]
        ///         }
        ///     }
        /// ```
        /// This will show action `extension.deleteFolder` only for items with `contextValue` is `folder`.
        abstract contextValue: string option with get, set
        /// Accessibility information used when screen reader interacts with this tree item.
        /// Generally, a TreeItem has no need to set the `role` of the accessibilityInformation;
        /// however, there are cases where a TreeItem is not displayed in a tree-like way where setting the `role` may make sense.
        abstract accessibilityInformation: AccessibilityInformation option with get, set

    type [<AllowNullLiteral>] TreeItemStatic =
        /// <param name="label">A human-readable string describing this item</param>
        /// <param name="collapsibleState"></param>
        [<Emit "new $0($1...)">] abstract Create: label: U2<string, TreeItemLabel> * ?collapsibleState: TreeItemCollapsibleState -> TreeItem
        /// <param name="resourceUri">The {@link Uri} of the resource representing this item.</param>
        /// <param name="collapsibleState"></param>
        [<Emit "new $0($1...)">] abstract Create: resourceUri: Uri * ?collapsibleState: TreeItemCollapsibleState -> TreeItem

    type [<RequireQualifiedAccess>] TreeItemCollapsibleState =
        | None = 0
        | Collapsed = 1
        | Expanded = 2

    /// Label describing the {@link TreeItem Tree item}
    type [<AllowNullLiteral>] TreeItemLabel =
        /// A human-readable string describing the {@link TreeItem Tree item}.
        abstract label: string with get, set
        /// Ranges in the label to highlight. A range is defined as a tuple of two number where the
        /// first is the inclusive start index and the second the exclusive end index
        abstract highlights: ResizeArray<float * float> option with get, set

    /// Value-object describing what options a terminal should use.
    type [<AllowNullLiteral>] TerminalOptions =
        /// A human-readable string which will be used to represent the terminal in the UI.
        abstract name: string option with get, set
        /// A path to a custom shell executable to be used in the terminal.
        abstract shellPath: string option with get, set
        /// Args for the custom shell executable. A string can be used on Windows only which allows
        /// specifying shell args in [command-line format](https://msdn.microsoft.com/en-au/08dfcab2-eb6e-49a4-80eb-87d4076c98c6).
        abstract shellArgs: U2<ResizeArray<string>, string> option with get, set
        /// A path or Uri for the current working directory to be used for the terminal.
        abstract cwd: U2<string, Uri> option with get, set
        /// Object with environment variables that will be added to the editor process.
        abstract env: TerminalOptionsEnv option with get, set
        /// Whether the terminal process environment should be exactly as provided in
        /// `TerminalOptions.env`. When this is false (default), the environment will be based on the
        /// window's environment and also apply configured platform settings like
        /// `terminal.integrated.windows.env` on top. When this is true, the complete environment
        /// must be provided as nothing will be inherited from the process or any configuration.
        abstract strictEnv: bool option with get, set
        /// When enabled the terminal will run the process as normal but not be surfaced to the user
        /// until `Terminal.show` is called. The typical usage for this is when you need to run
        /// something that may need interactivity but only want to tell the user about it when
        /// interaction is needed. Note that the terminals will still be exposed to all extensions
        /// as normal.
        abstract hideFromUser: bool option with get, set
        /// A message to write to the terminal on first launch, note that this is not sent to the
        /// process but, rather written directly to the terminal. This supports escape sequences such
        /// a setting text style.
        abstract message: string option with get, set
        /// The icon path or {@link ThemeIcon} for the terminal.
        abstract iconPath: U3<Uri, WorkspaceEditEntryMetadataIconPath, ThemeIcon> option with get, set

    /// Value-object describing what options a virtual process terminal should use.
    type [<AllowNullLiteral>] ExtensionTerminalOptions =
        /// A human-readable string which will be used to represent the terminal in the UI.
        abstract name: string with get, set
        /// An implementation of {@link Pseudoterminal} that allows an extension to
        /// control a terminal.
        abstract pty: Pseudoterminal with get, set
        /// The icon path or {@link ThemeIcon} for the terminal.
        abstract iconPath: U3<Uri, WorkspaceEditEntryMetadataIconPath, ThemeIcon> option with get, set

    /// Defines the interface of a terminal pty, enabling extensions to control a terminal.
    type [<AllowNullLiteral>] Pseudoterminal =
        /// An event that when fired will write data to the terminal. Unlike
        /// {@link Terminal.sendText} which sends text to the underlying child
        /// pseudo-device (the child), this will write the text to parent pseudo-device (the
        /// _terminal_ itself).
        /// 
        /// Note writing `\n` will just move the cursor down 1 row, you need to write `\r` as well
        /// to move the cursor to the left-most cell.
        /// 
        /// **Example:** Write red text to the terminal
        /// ```typescript
        /// const writeEmitter = new vscode.EventEmitter<string>();
        /// const pty: vscode.Pseudoterminal = {
        ///    onDidWrite: writeEmitter.event,
        ///    open: () => writeEmitter.fire('\x1b[31mHello world\x1b[0m'),
        ///    close: () => {}
        /// };
        /// vscode.window.createTerminal({ name: 'My terminal', pty });
        /// ```
        /// 
        /// **Example:** Move the cursor to the 10th row and 20th column and write an asterisk
        /// ```typescript
        /// writeEmitter.fire('\x1b[10;20H*');
        /// ```
        abstract onDidWrite: Event<string> with get, set
        /// An event that when fired allows overriding the {@link Pseudoterminal.setDimensions dimensions} of the
        /// terminal. Note that when set, the overridden dimensions will only take effect when they
        /// are lower than the actual dimensions of the terminal (ie. there will never be a scroll
        /// bar). Set to `undefined` for the terminal to go back to the regular dimensions (fit to
        /// the size of the panel).
        /// 
        /// **Example:** Override the dimensions of a terminal to 20 columns and 10 rows
        /// ```typescript
        /// const dimensionsEmitter = new vscode.EventEmitter<vscode.TerminalDimensions>();
        /// const pty: vscode.Pseudoterminal = {
        ///    onDidWrite: writeEmitter.event,
        ///    onDidOverrideDimensions: dimensionsEmitter.event,
        ///    open: () => {
        ///      dimensionsEmitter.fire({
        ///        columns: 20,
        ///        rows: 10
        ///      });
        ///    },
        ///    close: () => {}
        /// };
        /// vscode.window.createTerminal({ name: 'My terminal', pty });
        /// ```
        abstract onDidOverrideDimensions: Event<TerminalDimensions option> option with get, set
        /// An event that when fired will signal that the pty is closed and dispose of the terminal.
        /// 
        /// A number can be used to provide an exit code for the terminal. Exit codes must be
        /// positive and a non-zero exit codes signals failure which shows a notification for a
        /// regular terminal and allows dependent tasks to proceed when used with the
        /// `CustomExecution` API.
        /// 
        /// **Example:** Exit the terminal when "y" is pressed, otherwise show a notification.
        /// ```typescript
        /// const writeEmitter = new vscode.EventEmitter<string>();
        /// const closeEmitter = new vscode.EventEmitter<vscode.TerminalDimensions>();
        /// const pty: vscode.Pseudoterminal = {
        ///    onDidWrite: writeEmitter.event,
        ///    onDidClose: closeEmitter.event,
        ///    open: () => writeEmitter.fire('Press y to exit successfully'),
        ///    close: () => {},
        ///    handleInput: data => {
        ///      if (data !== 'y') {
        ///        vscode.window.showInformationMessage('Something went wrong');
        ///      }
        ///      closeEmitter.fire();
        ///    }
        /// };
        /// vscode.window.createTerminal({ name: 'Exit example', pty });
        /// ```
        abstract onDidClose: Event<U2<unit, float>> option with get, set
        /// An event that when fired allows changing the name of the terminal.
        /// 
        /// **Example:** Change the terminal name to "My new terminal".
        /// ```typescript
        /// const writeEmitter = new vscode.EventEmitter<string>();
        /// const changeNameEmitter = new vscode.EventEmitter<string>();
        /// const pty: vscode.Pseudoterminal = {
        ///    onDidWrite: writeEmitter.event,
        ///    onDidChangeName: changeNameEmitter.event,
        ///    open: () => changeNameEmitter.fire('My new terminal'),
        ///    close: () => {}
        /// };
        /// vscode.window.createTerminal({ name: 'My terminal', pty });
        /// ```
        abstract onDidChangeName: Event<string> option with get, set
        /// <summary>Implement to handle when the pty is open and ready to start firing events.</summary>
        /// <param name="initialDimensions">The dimensions of the terminal, this will be undefined if the
        /// terminal panel has not been opened before this is called.</param>
        abstract ``open``: initialDimensions: TerminalDimensions option -> unit
        /// Implement to handle when the terminal is closed by an act of the user.
        abstract close: unit -> unit
        /// <summary>Implement to handle incoming keystrokes in the terminal or when an extension calls
        /// {@link Terminal.sendText}. `data` contains the keystrokes/text serialized into
        /// their corresponding VT sequence representation.</summary>
        /// <param name="data">The incoming data.</param>
        /// 
        /// <example>
        /// Echo input in the terminal. The sequence for enter (`\r`) is translated to
        /// CRLF to go to a new line and move the cursor to the start of the line.
        /// ```typescript
        /// const writeEmitter = new vscode.EventEmitter&lt;string&gt;();
        /// const pty: vscode.Pseudoterminal = {
        ///   onDidWrite: writeEmitter.event,
        ///   open: () => {},
        ///   close: () => {},
        ///   handleInput: data => writeEmitter.fire(data === '\r' ? '\r\n' : data)
        /// };
        /// vscode.window.createTerminal({ name: 'Local echo', pty });
        /// ```
        /// </example>
        abstract handleInput: data: string -> unit
        /// <summary>Implement to handle when the number of rows and columns that fit into the terminal panel
        /// changes, for example when font size changes or when the panel is resized. The initial
        /// state of a terminal's dimensions should be treated as `undefined` until this is triggered
        /// as the size of a terminal isn't known until it shows up in the user interface.
        /// 
        /// When dimensions are overridden by
        /// {@link Pseudoterminal.onDidOverrideDimensions onDidOverrideDimensions}, `setDimensions` will
        /// continue to be called with the regular panel dimensions, allowing the extension continue
        /// to react dimension changes.</summary>
        /// <param name="dimensions">The new dimensions.</param>
        abstract setDimensions: dimensions: TerminalDimensions -> unit

    /// Represents the dimensions of a terminal.
    type [<AllowNullLiteral>] TerminalDimensions =
        /// The number of columns in the terminal.
        abstract columns: float
        /// The number of rows in the terminal.
        abstract rows: float

    /// Represents how a terminal exited.
    type [<AllowNullLiteral>] TerminalExitStatus =
        /// The exit code that a terminal exited with, it can have the following values:
        /// - Zero: the terminal process or custom execution succeeded.
        /// - Non-zero: the terminal process or custom execution failed.
        /// - `undefined`: the user forcibly closed the terminal or a custom execution exited
        ///    without providing an exit code.
        abstract code: float option

    type [<RequireQualifiedAccess>] EnvironmentVariableMutatorType =
        | Replace = 1
        | Append = 2
        | Prepend = 3

    /// A type of mutation and its value to be applied to an environment variable.
    type [<AllowNullLiteral>] EnvironmentVariableMutator =
        /// The type of mutation that will occur to the variable.
        abstract ``type``: EnvironmentVariableMutatorType
        /// The value to use for the variable.
        abstract value: string

    /// A collection of mutations that an extension can apply to a process environment.
    type [<AllowNullLiteral>] EnvironmentVariableCollection =
        /// Whether the collection should be cached for the workspace and applied to the terminal
        /// across window reloads. When true the collection will be active immediately such when the
        /// window reloads. Additionally, this API will return the cached version if it exists. The
        /// collection will be invalidated when the extension is uninstalled or when the collection
        /// is cleared. Defaults to true.
        abstract persistent: bool with get, set
        /// <summary>Replace an environment variable with a value.
        /// 
        /// Note that an extension can only make a single change to any one variable, so this will
        /// overwrite any previous calls to replace, append or prepend.</summary>
        /// <param name="variable">The variable to replace.</param>
        /// <param name="value">The value to replace the variable with.</param>
        abstract replace: variable: string * value: string -> unit
        /// <summary>Append a value to an environment variable.
        /// 
        /// Note that an extension can only make a single change to any one variable, so this will
        /// overwrite any previous calls to replace, append or prepend.</summary>
        /// <param name="variable">The variable to append to.</param>
        /// <param name="value">The value to append to the variable.</param>
        abstract append: variable: string * value: string -> unit
        /// <summary>Prepend a value to an environment variable.
        /// 
        /// Note that an extension can only make a single change to any one variable, so this will
        /// overwrite any previous calls to replace, append or prepend.</summary>
        /// <param name="variable">The variable to prepend.</param>
        /// <param name="value">The value to prepend to the variable.</param>
        abstract prepend: variable: string * value: string -> unit
        /// <summary>Gets the mutator that this collection applies to a variable, if any.</summary>
        /// <param name="variable">The variable to get the mutator for.</param>
        abstract get: variable: string -> EnvironmentVariableMutator option
        /// <summary>Iterate over each mutator in this collection.</summary>
        /// <param name="callback">Function to execute for each entry.</param>
        /// <param name="thisArg">The `this` context used when invoking the handler function.</param>
        abstract forEach: callback: (string -> EnvironmentVariableMutator -> EnvironmentVariableCollection -> obj option) * ?thisArg: obj -> unit
        /// <summary>Deletes this collection's mutator for a variable.</summary>
        /// <param name="variable">The variable to delete the mutator for.</param>
        abstract delete: variable: string -> unit
        /// Clears all mutators from this collection.
        abstract clear: unit -> unit

    type [<RequireQualifiedAccess>] ProgressLocation =
        | SourceControl = 1
        | Window = 10
        | Notification = 15

    /// Value-object describing where and how progress should show.
    type [<AllowNullLiteral>] ProgressOptions =
        /// The location at which progress should show.
        abstract location: U2<ProgressLocation, ProgressOptionsLocation> with get, set
        /// A human-readable string which will be used to describe the
        /// operation.
        abstract title: string option with get, set
        /// Controls if a cancel button should show to allow the user to
        /// cancel the long running operation.  Note that currently only
        /// `ProgressLocation.Notification` is supporting to show a cancel
        /// button.
        abstract cancellable: bool option with get, set

    /// A light-weight user input UI that is initially not visible. After
    /// configuring it through its properties the extension can make it
    /// visible by calling {@link QuickInput.show}.
    /// 
    /// There are several reasons why this UI might have to be hidden and
    /// the extension will be notified through {@link QuickInput.onDidHide}.
    /// (Examples include: an explicit call to {@link QuickInput.hide},
    /// the user pressing Esc, some other input UI opening, etc.)
    /// 
    /// A user pressing Enter or some other gesture implying acceptance
    /// of the current state does not automatically hide this UI component.
    /// It is up to the extension to decide whether to accept the user's input
    /// and if the UI should indeed be hidden through a call to {@link QuickInput.hide}.
    /// 
    /// When the extension no longer needs this input UI, it should
    /// {@link QuickInput.dispose} it to allow for freeing up
    /// any resources associated with it.
    /// 
    /// See {@link QuickPick} and {@link InputBox} for concrete UIs.
    type [<AllowNullLiteral>] QuickInput =
        /// An optional title.
        abstract title: string option with get, set
        /// An optional current step count.
        abstract step: float option with get, set
        /// An optional total step count.
        abstract totalSteps: float option with get, set
        /// If the UI should allow for user input. Defaults to true.
        /// 
        /// Change this to false, e.g., while validating user input or
        /// loading data for the next step in user input.
        abstract enabled: bool with get, set
        /// If the UI should show a progress indicator. Defaults to false.
        /// 
        /// Change this to true, e.g., while loading more data or validating
        /// user input.
        abstract busy: bool with get, set
        /// If the UI should stay open even when loosing UI focus. Defaults to false.
        /// This setting is ignored on iPad and is always false.
        abstract ignoreFocusOut: bool with get, set
        /// Makes the input UI visible in its current configuration. Any other input
        /// UI will first fire an {@link QuickInput.onDidHide} event.
        abstract show: unit -> unit
        /// Hides this input UI. This will also fire an {@link QuickInput.onDidHide}
        /// event.
        abstract hide: unit -> unit
        /// An event signaling when this input UI is hidden.
        /// 
        /// There are several reasons why this UI might have to be hidden and
        /// the extension will be notified through {@link QuickInput.onDidHide}.
        /// (Examples include: an explicit call to {@link QuickInput.hide},
        /// the user pressing Esc, some other input UI opening, etc.)
        abstract onDidHide: Event<unit> with get, set
        /// Dispose of this input UI and any associated resources. If it is still
        /// visible, it is first hidden. After this call the input UI is no longer
        /// functional and no additional methods or properties on it should be
        /// accessed. Instead a new input UI should be created.
        abstract dispose: unit -> unit

    /// A concrete {@link QuickInput} to let the user pick an item from a
    /// list of items of type T. The items can be filtered through a filter text field and
    /// there is an option {@link QuickPick.canSelectMany canSelectMany} to allow for
    /// selecting multiple items.
    /// 
    /// Note that in many cases the more convenient {@link window.showQuickPick}
    /// is easier to use. {@link window.createQuickPick} should be used
    /// when {@link window.showQuickPick} does not offer the required flexibility.
    type [<AllowNullLiteral>] QuickPick<'T> =
        inherit QuickInput
        /// Current value of the filter text.
        abstract value: string with get, set
        /// Optional placeholder in the filter text.
        abstract placeholder: string option with get, set
        /// An event signaling when the value of the filter text has changed.
        abstract onDidChangeValue: Event<string>
        /// An event signaling when the user indicated acceptance of the selected item(s).
        abstract onDidAccept: Event<unit>
        /// Buttons for actions in the UI.
        abstract buttons: ResizeArray<QuickInputButton> with get, set
        /// An event signaling when a button was triggered.
        abstract onDidTriggerButton: Event<QuickInputButton>
        /// Items to pick from. This can be read and updated by the extension.
        abstract items: ResizeArray<'T> with get, set
        /// If multiple items can be selected at the same time. Defaults to false.
        abstract canSelectMany: bool with get, set
        /// If the filter text should also be matched against the description of the items. Defaults to false.
        abstract matchOnDescription: bool with get, set
        /// If the filter text should also be matched against the detail of the items. Defaults to false.
        abstract matchOnDetail: bool with get, set
        /// Active items. This can be read and updated by the extension.
        abstract activeItems: ResizeArray<'T> with get, set
        /// An event signaling when the active items have changed.
        abstract onDidChangeActive: Event<ResizeArray<'T>>
        /// Selected items. This can be read and updated by the extension.
        abstract selectedItems: ResizeArray<'T> with get, set
        /// An event signaling when the selected items have changed.
        abstract onDidChangeSelection: Event<ResizeArray<'T>>

    /// A concrete {@link QuickInput} to let the user input a text value.
    /// 
    /// Note that in many cases the more convenient {@link window.showInputBox}
    /// is easier to use. {@link window.createInputBox} should be used
    /// when {@link window.showInputBox} does not offer the required flexibility.
    type [<AllowNullLiteral>] InputBox =
        inherit QuickInput
        /// Current input value.
        abstract value: string with get, set
        /// Optional placeholder in the filter text.
        abstract placeholder: string option with get, set
        /// If the input value should be hidden. Defaults to false.
        abstract password: bool with get, set
        /// An event signaling when the value has changed.
        abstract onDidChangeValue: Event<string>
        /// An event signaling when the user indicated acceptance of the input value.
        abstract onDidAccept: Event<unit>
        /// Buttons for actions in the UI.
        abstract buttons: ResizeArray<QuickInputButton> with get, set
        /// An event signaling when a button was triggered.
        abstract onDidTriggerButton: Event<QuickInputButton>
        /// An optional prompt text providing some ask or explanation to the user.
        abstract prompt: string option with get, set
        /// An optional validation message indicating a problem with the current input value.
        abstract validationMessage: string option with get, set

    /// Button for an action in a {@link QuickPick} or {@link InputBox}.
    type [<AllowNullLiteral>] QuickInputButton =
        /// Icon for the button.
        abstract iconPath: U3<Uri, WorkspaceEditEntryMetadataIconPath, ThemeIcon>
        /// An optional tooltip.
        abstract tooltip: string option

    /// Predefined buttons for {@link QuickPick} and {@link InputBox}.
    type [<AllowNullLiteral>] QuickInputButtons =
        interface end

    /// Predefined buttons for {@link QuickPick} and {@link InputBox}.
    type [<AllowNullLiteral>] QuickInputButtonsStatic =
        /// A back button for {@link QuickPick} and {@link InputBox}.
        /// 
        /// When a navigation 'back' button is needed this one should be used for consistency.
        /// It comes with a predefined icon, tooltip and location.
        abstract Back: QuickInputButton

    /// An event describing an individual change in the text of a {@link TextDocument document}.
    type [<AllowNullLiteral>] TextDocumentContentChangeEvent =
        /// The range that got replaced.
        abstract range: Range
        /// The offset of the range that got replaced.
        abstract rangeOffset: float
        /// The length of the range that got replaced.
        abstract rangeLength: float
        /// The new text for the range.
        abstract text: string

    type [<RequireQualifiedAccess>] TextDocumentChangeReason =
        | Undo = 1
        | Redo = 2

    /// An event describing a transactional {@link TextDocument document} change.
    type [<AllowNullLiteral>] TextDocumentChangeEvent =
        /// The affected document.
        abstract document: TextDocument
        /// An array of content changes.
        abstract contentChanges: ResizeArray<TextDocumentContentChangeEvent>
        /// The reason why the document was changed.
        /// Is undefined if the reason is not known.
        abstract reason: TextDocumentChangeReason option

    type [<RequireQualifiedAccess>] TextDocumentSaveReason =
        | Manual = 1
        | AfterDelay = 2
        | FocusOut = 3

    /// An event that is fired when a {@link TextDocument document} will be saved.
    /// 
    /// To make modifications to the document before it is being saved, call the
    /// {@link TextDocumentWillSaveEvent.waitUntil `waitUntil`}-function with a thenable
    /// that resolves to an array of {@link TextEdit text edits}.
    type [<AllowNullLiteral>] TextDocumentWillSaveEvent =
        /// The document that will be saved.
        abstract document: TextDocument
        /// The reason why save was triggered.
        abstract reason: TextDocumentSaveReason
        /// <summary>Allows to pause the event loop and to apply {@link TextEdit pre-save-edits}.
        /// Edits of subsequent calls to this function will be applied in order. The
        /// edits will be *ignored* if concurrent modifications of the document happened.
        /// 
        /// *Note:* This function can only be called during event dispatch and not
        /// in an asynchronous manner:
        /// 
        /// ```ts
        /// workspace.onWillSaveTextDocument(event => {
        ///      // async, will *throw* an error
        ///      setTimeout(() => event.waitUntil(promise));
        /// 
        ///      // sync, OK
        ///      event.waitUntil(promise);
        /// })
        /// ```</summary>
        /// <param name="thenable">A thenable that resolves to {@link TextEdit pre-save-edits}.</param>
        abstract waitUntil: thenable: Thenable<ResizeArray<TextEdit>> -> unit
        /// <summary>Allows to pause the event loop until the provided thenable resolved.
        /// 
        /// *Note:* This function can only be called during event dispatch.</summary>
        /// <param name="thenable">A thenable that delays saving.</param>
        abstract waitUntil: thenable: Thenable<obj option> -> unit

    /// An event that is fired when files are going to be created.
    /// 
    /// To make modifications to the workspace before the files are created,
    /// call the {@link FileWillCreateEvent.waitUntil `waitUntil`}-function with a
    /// thenable that resolves to a {@link WorkspaceEdit workspace edit}.
    type [<AllowNullLiteral>] FileWillCreateEvent =
        /// The files that are going to be created.
        abstract files: ResizeArray<Uri>
        /// <summary>Allows to pause the event and to apply a {@link WorkspaceEdit workspace edit}.
        /// 
        /// *Note:* This function can only be called during event dispatch and not
        /// in an asynchronous manner:
        /// 
        /// ```ts
        /// workspace.onWillCreateFiles(event => {
        ///      // async, will *throw* an error
        ///      setTimeout(() => event.waitUntil(promise));
        /// 
        ///      // sync, OK
        ///      event.waitUntil(promise);
        /// })
        /// ```</summary>
        /// <param name="thenable">A thenable that delays saving.</param>
        abstract waitUntil: thenable: Thenable<WorkspaceEdit> -> unit
        /// <summary>Allows to pause the event until the provided thenable resolves.
        /// 
        /// *Note:* This function can only be called during event dispatch.</summary>
        /// <param name="thenable">A thenable that delays saving.</param>
        abstract waitUntil: thenable: Thenable<obj option> -> unit

    /// An event that is fired after files are created.
    type [<AllowNullLiteral>] FileCreateEvent =
        /// The files that got created.
        abstract files: ResizeArray<Uri>

    /// An event that is fired when files are going to be deleted.
    /// 
    /// To make modifications to the workspace before the files are deleted,
    /// call the {@link FileWillCreateEvent.waitUntil `waitUntil}-function with a
    /// thenable that resolves to a {@link WorkspaceEdit workspace edit}.
    type [<AllowNullLiteral>] FileWillDeleteEvent =
        /// The files that are going to be deleted.
        abstract files: ResizeArray<Uri>
        /// <summary>Allows to pause the event and to apply a {@link WorkspaceEdit workspace edit}.
        /// 
        /// *Note:* This function can only be called during event dispatch and not
        /// in an asynchronous manner:
        /// 
        /// ```ts
        /// workspace.onWillCreateFiles(event => {
        ///      // async, will *throw* an error
        ///      setTimeout(() => event.waitUntil(promise));
        /// 
        ///      // sync, OK
        ///      event.waitUntil(promise);
        /// })
        /// ```</summary>
        /// <param name="thenable">A thenable that delays saving.</param>
        abstract waitUntil: thenable: Thenable<WorkspaceEdit> -> unit
        /// <summary>Allows to pause the event until the provided thenable resolves.
        /// 
        /// *Note:* This function can only be called during event dispatch.</summary>
        /// <param name="thenable">A thenable that delays saving.</param>
        abstract waitUntil: thenable: Thenable<obj option> -> unit

    /// An event that is fired after files are deleted.
    type [<AllowNullLiteral>] FileDeleteEvent =
        /// The files that got deleted.
        abstract files: ResizeArray<Uri>

    /// An event that is fired when files are going to be renamed.
    /// 
    /// To make modifications to the workspace before the files are renamed,
    /// call the {@link FileWillCreateEvent.waitUntil `waitUntil}-function with a
    /// thenable that resolves to a {@link WorkspaceEdit workspace edit}.
    type [<AllowNullLiteral>] FileWillRenameEvent =
        /// The files that are going to be renamed.
        abstract files: ReadonlyArray<FileWillRenameEventFilesReadonlyArray>
        /// <summary>Allows to pause the event and to apply a {@link WorkspaceEdit workspace edit}.
        /// 
        /// *Note:* This function can only be called during event dispatch and not
        /// in an asynchronous manner:
        /// 
        /// ```ts
        /// workspace.onWillCreateFiles(event => {
        ///      // async, will *throw* an error
        ///      setTimeout(() => event.waitUntil(promise));
        /// 
        ///      // sync, OK
        ///      event.waitUntil(promise);
        /// })
        /// ```</summary>
        /// <param name="thenable">A thenable that delays saving.</param>
        abstract waitUntil: thenable: Thenable<WorkspaceEdit> -> unit
        /// <summary>Allows to pause the event until the provided thenable resolves.
        /// 
        /// *Note:* This function can only be called during event dispatch.</summary>
        /// <param name="thenable">A thenable that delays saving.</param>
        abstract waitUntil: thenable: Thenable<obj option> -> unit

    /// An event that is fired after files are renamed.
    type [<AllowNullLiteral>] FileRenameEvent =
        /// The files that got renamed.
        abstract files: ReadonlyArray<FileWillRenameEventFilesReadonlyArray>

    /// An event describing a change to the set of {@link workspace.workspaceFolders workspace folders}.
    type [<AllowNullLiteral>] WorkspaceFoldersChangeEvent =
        /// Added workspace folders.
        abstract added: ResizeArray<WorkspaceFolder>
        /// Removed workspace folders.
        abstract removed: ResizeArray<WorkspaceFolder>

    /// A workspace folder is one of potentially many roots opened by the editor. All workspace folders
    /// are equal which means there is no notion of an active or primary workspace folder.
    type [<AllowNullLiteral>] WorkspaceFolder =
        /// The associated uri for this workspace folder.
        /// 
        /// *Note:* The {@link Uri}-type was intentionally chosen such that future releases of the editor can support
        /// workspace folders that are not stored on the local disk, e.g. `ftp://server/workspaces/foo`.
        abstract uri: Uri
        /// The name of this workspace folder. Defaults to
        /// the basename of its {@link Uri.path uri-path}
        abstract name: string
        /// The ordinal number of this workspace folder.
        abstract index: float

    module Workspace =

        type [<AllowNullLiteral>] IExports =
            abstract fs: FileSystem
            abstract rootPath: string option
            abstract workspaceFolders: ResizeArray<WorkspaceFolder> option
            abstract name: string option
            abstract workspaceFile: Uri option
            abstract onDidChangeWorkspaceFolders: Event<WorkspaceFoldersChangeEvent>
            /// <summary>Returns the {@link WorkspaceFolder workspace folder} that contains a given uri.
            /// * returns `undefined` when the given uri doesn't match any workspace folder
            /// * returns the *input* when the given uri is a workspace folder itself</summary>
            /// <param name="uri">An uri.</param>
            abstract getWorkspaceFolder: uri: Uri -> WorkspaceFolder option
            /// <summary>Returns a path that is relative to the workspace folder or folders.
            /// 
            /// When there are no {@link workspace.workspaceFolders workspace folders} or when the path
            /// is not contained in them, the input is returned.</summary>
            /// <param name="pathOrUri">A path or uri. When a uri is given its {@link Uri.fsPath fsPath} is used.</param>
            /// <param name="includeWorkspaceFolder">When `true` and when the given path is contained inside a
            /// workspace folder the name of the workspace is prepended. Defaults to `true` when there are
            /// multiple workspace folders and `false` otherwise.</param>
            abstract asRelativePath: pathOrUri: U2<string, Uri> * ?includeWorkspaceFolder: bool -> string
            /// <summary>This method replaces `deleteCount` {@link workspace.workspaceFolders workspace folders} starting at index `start`
            /// by an optional set of `workspaceFoldersToAdd` on the `vscode.workspace.workspaceFolders` array. This "splice"
            /// behavior can be used to add, remove and change workspace folders in a single operation.
            /// 
            /// If the first workspace folder is added, removed or changed, the currently executing extensions (including the
            /// one that called this method) will be terminated and restarted so that the (deprecated) `rootPath` property is
            /// updated to point to the first workspace folder.
            /// 
            /// Use the {@link onDidChangeWorkspaceFolders `onDidChangeWorkspaceFolders()`} event to get notified when the
            /// workspace folders have been updated.
            /// 
            /// **Example:** adding a new workspace folder at the end of workspace folders
            /// ```typescript
            /// workspace.updateWorkspaceFolders(workspace.workspaceFolders ? workspace.workspaceFolders.length : 0, null, { uri: ...});
            /// ```
            /// 
            /// **Example:** removing the first workspace folder
            /// ```typescript
            /// workspace.updateWorkspaceFolders(0, 1);
            /// ```
            /// 
            /// **Example:** replacing an existing workspace folder with a new one
            /// ```typescript
            /// workspace.updateWorkspaceFolders(0, 1, { uri: ...});
            /// ```
            /// 
            /// It is valid to remove an existing workspace folder and add it again with a different name
            /// to rename that folder.
            /// 
            /// **Note:** it is not valid to call {@link updateWorkspaceFolders updateWorkspaceFolders()} multiple times
            /// without waiting for the {@link onDidChangeWorkspaceFolders `onDidChangeWorkspaceFolders()`} to fire.</summary>
            /// <param name="start">the zero-based location in the list of currently opened {@link WorkspaceFolder workspace folders}
            /// from which to start deleting workspace folders.</param>
            /// <param name="deleteCount">the optional number of workspace folders to remove.</param>
            /// <param name="workspaceFoldersToAdd">the optional variable set of workspace folders to add in place of the deleted ones.
            /// Each workspace is identified with a mandatory URI and an optional name.</param>
            abstract updateWorkspaceFolders: start: float * deleteCount: float option * [<ParamArray>] workspaceFoldersToAdd: ResizeArray<IExportsUpdateWorkspaceFolders> -> bool
            /// <summary>Creates a file system watcher.
            /// 
            /// A glob pattern that filters the file events on their absolute path must be provided. Optionally,
            /// flags to ignore certain kinds of events can be provided. To stop listening to events the watcher must be disposed.
            /// 
            /// *Note* that only files within the current {@link workspace.workspaceFolders workspace folders} can be watched.
            /// *Note* that when watching for file changes such as '**​/*.js', notifications will not be sent when a parent folder is
            /// moved or deleted (this is a known limitation of the current implementation and may change in the future).</summary>
            /// <param name="globPattern">A {@link GlobPattern glob pattern} that is applied to the absolute paths of created, changed,
            /// and deleted files. Use a {@link RelativePattern relative pattern} to limit events to a certain {@link WorkspaceFolder workspace folder}.</param>
            /// <param name="ignoreCreateEvents">Ignore when files have been created.</param>
            /// <param name="ignoreChangeEvents">Ignore when files have been changed.</param>
            /// <param name="ignoreDeleteEvents">Ignore when files have been deleted.</param>
            abstract createFileSystemWatcher: globPattern: GlobPattern * ?ignoreCreateEvents: bool * ?ignoreChangeEvents: bool * ?ignoreDeleteEvents: bool -> FileSystemWatcher
            /// <summary>Find files across all {@link workspace.workspaceFolders workspace folders} in the workspace.</summary>
            /// <param name="include">A {@link GlobPattern glob pattern} that defines the files to search for. The glob pattern
            /// will be matched against the file paths of resulting matches relative to their workspace. Use a {@link RelativePattern relative pattern}
            /// to restrict the search results to a {@link WorkspaceFolder workspace folder}.</param>
            /// <param name="exclude">A {@link GlobPattern glob pattern} that defines files and folders to exclude. The glob pattern
            /// will be matched against the file paths of resulting matches relative to their workspace. When `undefined`, default excludes and the user's
            /// configured excludes will apply. When `null`, no excludes will apply.</param>
            /// <param name="maxResults">An upper-bound for the result.</param>
            /// <param name="token">A token that can be used to signal cancellation to the underlying search engine.</param>
            abstract findFiles: ``include``: GlobPattern * ?exclude: GlobPattern * ?maxResults: float * ?token: CancellationToken -> Thenable<ResizeArray<Uri>>
            /// <summary>Save all dirty files.</summary>
            /// <param name="includeUntitled">Also save files that have been created during this session.</param>
            abstract saveAll: ?includeUntitled: bool -> Thenable<bool>
            /// <summary>Make changes to one or many resources or create, delete, and rename resources as defined by the given
            /// {@link WorkspaceEdit workspace edit}.
            /// 
            /// All changes of a workspace edit are applied in the same order in which they have been added. If
            /// multiple textual inserts are made at the same position, these strings appear in the resulting text
            /// in the order the 'inserts' were made, unless that are interleaved with resource edits. Invalid sequences
            /// like 'delete file a' -> 'insert text in file a' cause failure of the operation.
            /// 
            /// When applying a workspace edit that consists only of text edits an 'all-or-nothing'-strategy is used.
            /// A workspace edit with resource creations or deletions aborts the operation, e.g. consecutive edits will
            /// not be attempted, when a single edit fails.</summary>
            /// <param name="edit">A workspace edit.</param>
            abstract applyEdit: edit: WorkspaceEdit -> Thenable<bool>
            abstract textDocuments: ResizeArray<TextDocument>
            /// <summary>Opens a document. Will return early if this document is already open. Otherwise
            /// the document is loaded and the {@link workspace.onDidOpenTextDocument didOpen}-event fires.
            /// 
            /// The document is denoted by an {@link Uri}. Depending on the {@link Uri.scheme scheme} the
            /// following rules apply:
            /// * `file`-scheme: Open a file on disk, will be rejected if the file does not exist or cannot be loaded.
            /// * `untitled`-scheme: A new file that should be saved on disk, e.g. `untitled:c:\frodo\new.js`. The language
            /// will be derived from the file name.
            /// * For all other schemes contributed {@link TextDocumentContentProvider text document content providers} and
            /// {@link FileSystemProvider file system providers} are consulted.
            /// 
            /// *Note* that the lifecycle of the returned document is owned by the editor and not by the extension. That means an
            /// {@link workspace.onDidCloseTextDocument `onDidClose`}-event can occur at any time after opening it.</summary>
            /// <param name="uri">Identifies the resource to open.</param>
            abstract openTextDocument: uri: Uri -> Thenable<TextDocument>
            /// <summary>A short-hand for `openTextDocument(Uri.file(fileName))`.</summary>
            /// <param name="fileName">A name of a file on disk.</param>
            abstract openTextDocument: fileName: string -> Thenable<TextDocument>
            /// <summary>Opens an untitled text document. The editor will prompt the user for a file
            /// path when the document is to be saved. The `options` parameter allows to
            /// specify the *language* and/or the *content* of the document.</summary>
            /// <param name="options">Options to control how the document will be created.</param>
            abstract openTextDocument: ?options: OpenTextDocumentOptions -> Thenable<TextDocument>
            /// <summary>Register a text document content provider.
            /// 
            /// Only one provider can be registered per scheme.</summary>
            /// <param name="scheme">The uri-scheme to register for.</param>
            /// <param name="provider">A content provider.</param>
            abstract registerTextDocumentContentProvider: scheme: string * provider: TextDocumentContentProvider -> Disposable
            abstract onDidOpenTextDocument: Event<TextDocument>
            abstract onDidCloseTextDocument: Event<TextDocument>
            abstract onDidChangeTextDocument: Event<TextDocumentChangeEvent>
            abstract onWillSaveTextDocument: Event<TextDocumentWillSaveEvent>
            abstract onDidSaveTextDocument: Event<TextDocument>
            abstract notebookDocuments: ResizeArray<NotebookDocument>
            /// <summary>Open a notebook. Will return early if this notebook is already {@link notebook.notebookDocuments loaded}. Otherwise
            /// the notebook is loaded and the {@link notebook.onDidOpenNotebookDocument `onDidOpenNotebookDocument`}-event fires.
            /// 
            /// *Note* that the lifecycle of the returned notebook is owned by the editor and not by the extension. That means an
            /// {@link notebook.onDidCloseNotebookDocument `onDidCloseNotebookDocument`}-event can occur at any time after.
            /// 
            /// *Note* that opening a notebook does not show a notebook editor. This function only returns a notebook document which
            /// can be showns in a notebook editor but it can also be used for other things.</summary>
            /// <param name="uri">The resource to open.</param>
            abstract openNotebookDocument: uri: Uri -> Thenable<NotebookDocument>
            /// <summary>Open an untitled notebook. The editor will prompt the user for a file
            /// path when the document is to be saved.</summary>
            /// <param name="notebookType">The notebook type that should be used.</param>
            /// <param name="content">The initial contents of the notebook.</param>
            abstract openNotebookDocument: notebookType: string * ?content: NotebookData -> Thenable<NotebookDocument>
            /// <summary>Register a {@link NotebookSerializer notebook serializer}.
            /// 
            /// A notebook serializer must be contributed through the `notebooks` extension point. When opening a notebook file, the editor will send
            /// the `onNotebook:&lt;notebookType&gt;` activation event, and extensions must register their serializer in return.</summary>
            /// <param name="notebookType">A notebook.</param>
            /// <param name="serializer">A notebook serialzier.</param>
            /// <param name="options">Optional context options that define what parts of a notebook should be persisted</param>
            abstract registerNotebookSerializer: notebookType: string * serializer: NotebookSerializer * ?options: NotebookDocumentContentOptions -> Disposable
            abstract onDidOpenNotebookDocument: Event<NotebookDocument>
            abstract onDidCloseNotebookDocument: Event<NotebookDocument>
            abstract onWillCreateFiles: Event<FileWillCreateEvent>
            abstract onDidCreateFiles: Event<FileCreateEvent>
            abstract onWillDeleteFiles: Event<FileWillDeleteEvent>
            abstract onDidDeleteFiles: Event<FileDeleteEvent>
            abstract onWillRenameFiles: Event<FileWillRenameEvent>
            abstract onDidRenameFiles: Event<FileRenameEvent>
            /// <summary>Get a workspace configuration object.
            /// 
            /// When a section-identifier is provided only that part of the configuration
            /// is returned. Dots in the section-identifier are interpreted as child-access,
            /// like `{ myExt: { setting: { doIt: true }}}` and `getConfiguration('myExt.setting').get('doIt') === true`.
            /// 
            /// When a scope is provided configuration confined to that scope is returned. Scope can be a resource or a language identifier or both.</summary>
            /// <param name="section">A dot-separated identifier.</param>
            /// <param name="scope">A scope for which the configuration is asked for.</param>
            abstract getConfiguration: ?section: string * ?scope: ConfigurationScope -> WorkspaceConfiguration
            abstract onDidChangeConfiguration: Event<ConfigurationChangeEvent>
            /// <summary>Register a task provider.</summary>
            /// <param name="type">The task kind type this provider is registered for.</param>
            /// <param name="provider">A task provider.</param>
            abstract registerTaskProvider: ``type``: string * provider: TaskProvider -> Disposable
            /// <summary>Register a filesystem provider for a given scheme, e.g. `ftp`.
            /// 
            /// There can only be one provider per scheme and an error is being thrown when a scheme
            /// has been claimed by another provider or when it is reserved.</summary>
            /// <param name="scheme">The uri-{@link Uri.scheme scheme} the provider registers for.</param>
            /// <param name="provider">The filesystem provider.</param>
            /// <param name="options">Immutable metadata about the provider.</param>
            abstract registerFileSystemProvider: scheme: string * provider: FileSystemProvider * ?options: RegisterFileSystemProviderOptions -> Disposable
            abstract isTrusted: bool
            abstract onDidGrantWorkspaceTrust: Event<unit>

        type [<AllowNullLiteral>] OpenTextDocumentOptions =
            abstract language: string option with get, set
            abstract content: string option with get, set

        type [<AllowNullLiteral>] RegisterFileSystemProviderOptions =
            abstract isCaseSensitive: bool option
            abstract isReadonly: bool option

        type [<AllowNullLiteral>] IExportsUpdateWorkspaceFolders =
            abstract uri: Uri with get, set
            abstract name: string option with get, set

    type ConfigurationScope =
        U5<Uri, TextDocument, WorkspaceFolder, Uri, string>

    /// An event describing the change in Configuration
    type [<AllowNullLiteral>] ConfigurationChangeEvent =
        /// <summary>Checks if the given section has changed.
        /// If scope is provided, checks if the section has changed for resources under the given scope.</summary>
        /// <param name="section">Configuration name, supports _dotted_ names.</param>
        /// <param name="scope">A scope in which to check.</param>
        abstract affectsConfiguration: section: string * ?scope: ConfigurationScope -> bool

    module Languages =

        type [<AllowNullLiteral>] IExports =
            /// Return the identifiers of all known languages.
            abstract getLanguages: unit -> Thenable<ResizeArray<string>>
            /// <summary>Set (and change) the {@link TextDocument.languageId language} that is associated
            /// with the given document.
            /// 
            /// *Note* that calling this function will trigger the {@link workspace.onDidCloseTextDocument `onDidCloseTextDocument`} event
            /// followed by the {@link workspace.onDidOpenTextDocument `onDidOpenTextDocument`} event.</summary>
            /// <param name="document">The document which language is to be changed</param>
            /// <param name="languageId">The new language identifier.</param>
            abstract setTextDocumentLanguage: document: TextDocument * languageId: string -> Thenable<TextDocument>
            /// <summary>Compute the match between a document {@link DocumentSelector selector} and a document. Values
            /// greater than zero mean the selector matches the document.
            /// 
            /// A match is computed according to these rules:
            /// 1. When {@link DocumentSelector `DocumentSelector`} is an array, compute the match for each contained `DocumentFilter` or language identifier and take the maximum value.
            /// 2. A string will be desugared to become the `language`-part of a {@link DocumentFilter `DocumentFilter`}, so `"fooLang"` is like `{ language: "fooLang" }`.
            /// 3. A {@link DocumentFilter `DocumentFilter`} will be matched against the document by comparing its parts with the document. The following rules apply:
            ///   1. When the `DocumentFilter` is empty (`{}`) the result is `0`
            ///   2. When `scheme`, `language`, or `pattern` are defined but one doesn’t match, the result is `0`
            ///   3. Matching against `*` gives a score of `5`, matching via equality or via a glob-pattern gives a score of `10`
            ///   4. The result is the maximum value of each match
            /// 
            /// Samples:
            /// ```js
            /// // default document from disk (file-scheme)
            /// doc.uri; //'file:///my/file.js'
            /// doc.languageId; // 'javascript'
            /// match('javascript', doc); // 10;
            /// match({language: 'javascript'}, doc); // 10;
            /// match({language: 'javascript', scheme: 'file'}, doc); // 10;
            /// match('*', doc); // 5
            /// match('fooLang', doc); // 0
            /// match(['fooLang', '*'], doc); // 5
            /// 
            /// // virtual document, e.g. from git-index
            /// doc.uri; // 'git:/my/file.js'
            /// doc.languageId; // 'javascript'
            /// match('javascript', doc); // 10;
            /// match({language: 'javascript', scheme: 'git'}, doc); // 10;
            /// match('*', doc); // 5
            /// ```</summary>
            /// <param name="selector">A document selector.</param>
            /// <param name="document">A text document.</param>
            abstract ``match``: selector: DocumentSelector * document: TextDocument -> float
            abstract onDidChangeDiagnostics: Event<DiagnosticChangeEvent>
            /// <summary>Get all diagnostics for a given resource.</summary>
            /// <param name="resource">A resource</param>
            abstract getDiagnostics: resource: Uri -> ResizeArray<Diagnostic>
            /// Get all diagnostics.
            abstract getDiagnostics: unit -> ResizeArray<Uri * ResizeArray<Diagnostic>>
            /// <summary>Create a diagnostics collection.</summary>
            /// <param name="name">The {@link DiagnosticCollection.name name} of the collection.</param>
            abstract createDiagnosticCollection: ?name: string -> DiagnosticCollection
            /// <summary>Register a completion provider.
            /// 
            /// Multiple providers can be registered for a language. In that case providers are sorted
            /// by their {@link languages.match score} and groups of equal score are sequentially asked for
            /// completion items. The process stops when one or many providers of a group return a
            /// result. A failing provider (rejected promise or exception) will not fail the whole
            /// operation.
            /// 
            /// A completion item provider can be associated with a set of `triggerCharacters`. When trigger
            /// characters are being typed, completions are requested but only from providers that registered
            /// the typed character. Because of that trigger characters should be different than {@link LanguageConfiguration.wordPattern word characters},
            /// a common trigger character is `.` to trigger member completions.</summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A completion provider.</param>
            /// <param name="triggerCharacters">Trigger completion when the user types one of the characters.</param>
            abstract registerCompletionItemProvider: selector: DocumentSelector * provider: CompletionItemProvider * [<ParamArray>] triggerCharacters: ResizeArray<string> -> Disposable
            /// <summary>Register a code action provider.
            /// 
            /// Multiple providers can be registered for a language. In that case providers are asked in
            /// parallel and the results are merged. A failing provider (rejected promise or exception) will
            /// not cause a failure of the whole operation.</summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A code action provider.</param>
            /// <param name="metadata">Metadata about the kind of code actions the provider provides.</param>
            abstract registerCodeActionsProvider: selector: DocumentSelector * provider: CodeActionProvider * ?metadata: CodeActionProviderMetadata -> Disposable
            /// <summary>Register a code lens provider.
            /// 
            /// Multiple providers can be registered for a language. In that case providers are asked in
            /// parallel and the results are merged. A failing provider (rejected promise or exception) will
            /// not cause a failure of the whole operation.</summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A code lens provider.</param>
            abstract registerCodeLensProvider: selector: DocumentSelector * provider: CodeLensProvider -> Disposable
            /// <summary>Register a definition provider.
            /// 
            /// Multiple providers can be registered for a language. In that case providers are asked in
            /// parallel and the results are merged. A failing provider (rejected promise or exception) will
            /// not cause a failure of the whole operation.</summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A definition provider.</param>
            abstract registerDefinitionProvider: selector: DocumentSelector * provider: DefinitionProvider -> Disposable
            /// <summary>Register an implementation provider.
            /// 
            /// Multiple providers can be registered for a language. In that case providers are asked in
            /// parallel and the results are merged. A failing provider (rejected promise or exception) will
            /// not cause a failure of the whole operation.</summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">An implementation provider.</param>
            abstract registerImplementationProvider: selector: DocumentSelector * provider: ImplementationProvider -> Disposable
            /// <summary>Register a type definition provider.
            /// 
            /// Multiple providers can be registered for a language. In that case providers are asked in
            /// parallel and the results are merged. A failing provider (rejected promise or exception) will
            /// not cause a failure of the whole operation.</summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A type definition provider.</param>
            abstract registerTypeDefinitionProvider: selector: DocumentSelector * provider: TypeDefinitionProvider -> Disposable
            /// <summary>Register a declaration provider.
            /// 
            /// Multiple providers can be registered for a language. In that case providers are asked in
            /// parallel and the results are merged. A failing provider (rejected promise or exception) will
            /// not cause a failure of the whole operation.</summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A declaration provider.</param>
            abstract registerDeclarationProvider: selector: DocumentSelector * provider: DeclarationProvider -> Disposable
            /// <summary>Register a hover provider.
            /// 
            /// Multiple providers can be registered for a language. In that case providers are asked in
            /// parallel and the results are merged. A failing provider (rejected promise or exception) will
            /// not cause a failure of the whole operation.</summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A hover provider.</param>
            abstract registerHoverProvider: selector: DocumentSelector * provider: HoverProvider -> Disposable
            /// <summary>Register a provider that locates evaluatable expressions in text documents.
            /// The editor will evaluate the expression in the active debug session and will show the result in the debug hover.
            /// 
            /// If multiple providers are registered for a language an arbitrary provider will be used.</summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">An evaluatable expression provider.</param>
            abstract registerEvaluatableExpressionProvider: selector: DocumentSelector * provider: EvaluatableExpressionProvider -> Disposable
            /// <summary>Register a provider that returns data for the debugger's 'inline value' feature.
            /// Whenever the generic debugger has stopped in a source file, providers registered for the language of the file
            /// are called to return textual data that will be shown in the editor at the end of lines.
            /// 
            /// Multiple providers can be registered for a language. In that case providers are asked in
            /// parallel and the results are merged. A failing provider (rejected promise or exception) will
            /// not cause a failure of the whole operation.</summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">An inline values provider.</param>
            abstract registerInlineValuesProvider: selector: DocumentSelector * provider: InlineValuesProvider -> Disposable
            /// <summary>Register a document highlight provider.
            /// 
            /// Multiple providers can be registered for a language. In that case providers are sorted
            /// by their {@link languages.match score} and groups sequentially asked for document highlights.
            /// The process stops when a provider returns a `non-falsy` or `non-failure` result.</summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A document highlight provider.</param>
            abstract registerDocumentHighlightProvider: selector: DocumentSelector * provider: DocumentHighlightProvider -> Disposable
            /// <summary>Register a document symbol provider.
            /// 
            /// Multiple providers can be registered for a language. In that case providers are asked in
            /// parallel and the results are merged. A failing provider (rejected promise or exception) will
            /// not cause a failure of the whole operation.</summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A document symbol provider.</param>
            /// <param name="metaData">metadata about the provider</param>
            abstract registerDocumentSymbolProvider: selector: DocumentSelector * provider: DocumentSymbolProvider * ?metaData: DocumentSymbolProviderMetadata -> Disposable
            /// <summary>Register a workspace symbol provider.
            /// 
            /// Multiple providers can be registered. In that case providers are asked in parallel and
            /// the results are merged. A failing provider (rejected promise or exception) will not cause
            /// a failure of the whole operation.</summary>
            /// <param name="provider">A workspace symbol provider.</param>
            abstract registerWorkspaceSymbolProvider: provider: WorkspaceSymbolProvider -> Disposable
            /// <summary>Register a reference provider.
            /// 
            /// Multiple providers can be registered for a language. In that case providers are asked in
            /// parallel and the results are merged. A failing provider (rejected promise or exception) will
            /// not cause a failure of the whole operation.</summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A reference provider.</param>
            abstract registerReferenceProvider: selector: DocumentSelector * provider: ReferenceProvider -> Disposable
            /// <summary>Register a rename provider.
            /// 
            /// Multiple providers can be registered for a language. In that case providers are sorted
            /// by their {@link languages.match score} and asked in sequence. The first provider producing a result
            /// defines the result of the whole operation.</summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A rename provider.</param>
            abstract registerRenameProvider: selector: DocumentSelector * provider: RenameProvider -> Disposable
            /// <summary>Register a semantic tokens provider for a whole document.
            /// 
            /// Multiple providers can be registered for a language. In that case providers are sorted
            /// by their {@link languages.match score} and the best-matching provider is used. Failure
            /// of the selected provider will cause a failure of the whole operation.</summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A document semantic tokens provider.</param>
            /// <param name="legend"></param>
            abstract registerDocumentSemanticTokensProvider: selector: DocumentSelector * provider: DocumentSemanticTokensProvider * legend: SemanticTokensLegend -> Disposable
            /// <summary>Register a semantic tokens provider for a document range.
            /// 
            /// *Note:* If a document has both a `DocumentSemanticTokensProvider` and a `DocumentRangeSemanticTokensProvider`,
            /// the range provider will be invoked only initially, for the time in which the full document provider takes
            /// to resolve the first request. Once the full document provider resolves the first request, the semantic tokens
            /// provided via the range provider will be discarded and from that point forward, only the document provider
            /// will be used.
            /// 
            /// Multiple providers can be registered for a language. In that case providers are sorted
            /// by their {@link languages.match score} and the best-matching provider is used. Failure
            /// of the selected provider will cause a failure of the whole operation.</summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A document range semantic tokens provider.</param>
            /// <param name="legend"></param>
            abstract registerDocumentRangeSemanticTokensProvider: selector: DocumentSelector * provider: DocumentRangeSemanticTokensProvider * legend: SemanticTokensLegend -> Disposable
            /// <summary>Register a formatting provider for a document.
            /// 
            /// Multiple providers can be registered for a language. In that case providers are sorted
            /// by their {@link languages.match score} and the best-matching provider is used. Failure
            /// of the selected provider will cause a failure of the whole operation.</summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A document formatting edit provider.</param>
            abstract registerDocumentFormattingEditProvider: selector: DocumentSelector * provider: DocumentFormattingEditProvider -> Disposable
            /// <summary>Register a formatting provider for a document range.
            /// 
            /// *Note:* A document range provider is also a {@link DocumentFormattingEditProvider document formatter}
            /// which means there is no need to {@link languages.registerDocumentFormattingEditProvider register} a document
            /// formatter when also registering a range provider.
            /// 
            /// Multiple providers can be registered for a language. In that case providers are sorted
            /// by their {@link languages.match score} and the best-matching provider is used. Failure
            /// of the selected provider will cause a failure of the whole operation.</summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A document range formatting edit provider.</param>
            abstract registerDocumentRangeFormattingEditProvider: selector: DocumentSelector * provider: DocumentRangeFormattingEditProvider -> Disposable
            /// <summary>Register a formatting provider that works on type. The provider is active when the user enables the setting `editor.formatOnType`.
            /// 
            /// Multiple providers can be registered for a language. In that case providers are sorted
            /// by their {@link languages.match score} and the best-matching provider is used. Failure
            /// of the selected provider will cause a failure of the whole operation.</summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">An on type formatting edit provider.</param>
            /// <param name="firstTriggerCharacter">A character on which formatting should be triggered, like `}`.</param>
            /// <param name="moreTriggerCharacter">More trigger characters.</param>
            abstract registerOnTypeFormattingEditProvider: selector: DocumentSelector * provider: OnTypeFormattingEditProvider * firstTriggerCharacter: string * [<ParamArray>] moreTriggerCharacter: ResizeArray<string> -> Disposable
            /// <summary>Register a signature help provider.
            /// 
            /// Multiple providers can be registered for a language. In that case providers are sorted
            /// by their {@link languages.match score} and called sequentially until a provider returns a
            /// valid result.</summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A signature help provider.</param>
            /// <param name="triggerCharacters">Trigger signature help when the user types one of the characters, like `,` or `(`.</param>
            abstract registerSignatureHelpProvider: selector: DocumentSelector * provider: SignatureHelpProvider * [<ParamArray>] triggerCharacters: ResizeArray<string> -> Disposable
            abstract registerSignatureHelpProvider: selector: DocumentSelector * provider: SignatureHelpProvider * metadata: SignatureHelpProviderMetadata -> Disposable
            /// <summary>Register a document link provider.
            /// 
            /// Multiple providers can be registered for a language. In that case providers are asked in
            /// parallel and the results are merged. A failing provider (rejected promise or exception) will
            /// not cause a failure of the whole operation.</summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A document link provider.</param>
            abstract registerDocumentLinkProvider: selector: DocumentSelector * provider: DocumentLinkProvider -> Disposable
            /// <summary>Register a color provider.
            /// 
            /// Multiple providers can be registered for a language. In that case providers are asked in
            /// parallel and the results are merged. A failing provider (rejected promise or exception) will
            /// not cause a failure of the whole operation.</summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A color provider.</param>
            abstract registerColorProvider: selector: DocumentSelector * provider: DocumentColorProvider -> Disposable
            /// <summary>Register a folding range provider.
            /// 
            /// Multiple providers can be registered for a language. In that case providers are asked in
            /// parallel and the results are merged.
            /// If multiple folding ranges start at the same position, only the range of the first registered provider is used.
            /// If a folding range overlaps with an other range that has a smaller position, it is also ignored.
            /// 
            /// A failing provider (rejected promise or exception) will
            /// not cause a failure of the whole operation.</summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A folding range provider.</param>
            abstract registerFoldingRangeProvider: selector: DocumentSelector * provider: FoldingRangeProvider -> Disposable
            /// <summary>Register a selection range provider.
            /// 
            /// Multiple providers can be registered for a language. In that case providers are asked in
            /// parallel and the results are merged. A failing provider (rejected promise or exception) will
            /// not cause a failure of the whole operation.</summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A selection range provider.</param>
            abstract registerSelectionRangeProvider: selector: DocumentSelector * provider: SelectionRangeProvider -> Disposable
            /// <summary>Register a call hierarchy provider.</summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A call hierarchy provider.</param>
            abstract registerCallHierarchyProvider: selector: DocumentSelector * provider: CallHierarchyProvider -> Disposable
            /// <summary>Register a linked editing range provider.
            /// 
            /// Multiple providers can be registered for a language. In that case providers are sorted
            /// by their {@link languages.match score} and the best-matching provider that has a result is used. Failure
            /// of the selected provider will cause a failure of the whole operation.</summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A linked editing range provider.</param>
            abstract registerLinkedEditingRangeProvider: selector: DocumentSelector * provider: LinkedEditingRangeProvider -> Disposable
            /// <summary>Set a {@link LanguageConfiguration language configuration} for a language.</summary>
            /// <param name="language">A language identifier like `typescript`.</param>
            /// <param name="configuration">Language configuration.</param>
            abstract setLanguageConfiguration: language: string * configuration: LanguageConfiguration -> Disposable

    type [<RequireQualifiedAccess>] NotebookCellKind =
        | Markup = 1
        | Code = 2

    /// Represents a cell of a {@link NotebookDocument notebook}, either a {@link NotebookCellKind.Code code}-cell
    /// or {@link NotebookCellKind.Markup markup}-cell.
    /// 
    /// NotebookCell instances are immutable and are kept in sync for as long as they are part of their notebook.
    type [<AllowNullLiteral>] NotebookCell =
        /// The index of this cell in its {@link NotebookDocument.cellAt containing notebook}. The
        /// index is updated when a cell is moved within its notebook. The index is `-1`
        /// when the cell has been removed from its notebook.
        abstract index: float
        /// The {@link NotebookDocument notebook} that contains this cell.
        abstract notebook: NotebookDocument
        /// The kind of this cell.
        abstract kind: NotebookCellKind
        /// The {@link TextDocument text} of this cell, represented as text document.
        abstract document: TextDocument
        /// The metadata of this cell. Can be anything but must be JSON-stringifyable.
        abstract metadata: NotebookCellMetadata
        /// The outputs of this cell.
        abstract outputs: ResizeArray<NotebookCellOutput>
        /// The most recent {@link NotebookCellExecutionSummary execution summary} for this cell.
        abstract executionSummary: NotebookCellExecutionSummary option

    /// Represents a notebook which itself is a sequence of {@link NotebookCell code or markup cells}. Notebook documents are
    /// created from {@link NotebookData notebook data}.
    type [<AllowNullLiteral>] NotebookDocument =
        /// The associated uri for this notebook.
        /// 
        /// *Note* that most notebooks use the `file`-scheme, which means they are files on disk. However, **not** all notebooks are
        /// saved on disk and therefore the `scheme` must be checked before trying to access the underlying file or siblings on disk.
        abstract uri: Uri
        /// The type of notebook.
        abstract notebookType: string
        /// The version number of this notebook (it will strictly increase after each
        /// change, including undo/redo).
        abstract version: float
        /// `true` if there are unpersisted changes.
        abstract isDirty: bool
        /// Is this notebook representing an untitled file which has not been saved yet.
        abstract isUntitled: bool
        /// `true` if the notebook has been closed. A closed notebook isn't synchronized anymore
        /// and won't be re-used when the same resource is opened again.
        abstract isClosed: bool
        /// Arbitrary metadata for this notebook. Can be anything but must be JSON-stringifyable.
        abstract metadata: NotebookCellMetadata
        /// The number of cells in the notebook.
        abstract cellCount: float
        /// <summary>Return the cell at the specified index. The index will be adjusted to the notebook.</summary>
        /// <param name="index">- The index of the cell to retrieve.</param>
        abstract cellAt: index: float -> NotebookCell
        /// <summary>Get the cells of this notebook. A subset can be retrieved by providing
        /// a range. The range will be adjusted to the notebook.</summary>
        /// <param name="range">A notebook range.</param>
        abstract getCells: ?range: NotebookRange -> ResizeArray<NotebookCell>
        /// Save the document. The saving will be handled by the corresponding {@link NotebookSerializer serializer}.
        abstract save: unit -> Thenable<bool>

    /// The summary of a notebook cell execution.
    type [<AllowNullLiteral>] NotebookCellExecutionSummary =
        /// The order in which the execution happened.
        abstract executionOrder: float option
        /// If the exclusive finished successfully.
        abstract success: bool option
        /// The times at which execution started and ended, as unix timestamps
        abstract timing: NotebookCellExecutionSummaryTiming option

    /// A notebook range represents an ordered pair of two cell indices.
    /// It is guaranteed that start is less than or equal to end.
    type [<AllowNullLiteral>] NotebookRange =
        /// The zero-based start index of this range.
        abstract start: float
        /// The exclusive end index of this range (zero-based).
        abstract ``end``: float
        /// `true` if `start` and `end` are equal.
        abstract isEmpty: bool
        /// <summary>Derive a new range for this range.</summary>
        /// <param name="change">An object that describes a change to this range.</param>
        abstract ``with``: change: NotebookRangeWithChange -> NotebookRange

    type [<AllowNullLiteral>] NotebookRangeWithChange =
        abstract start: float option with get, set
        abstract ``end``: float option with get, set

    /// A notebook range represents an ordered pair of two cell indices.
    /// It is guaranteed that start is less than or equal to end.
    type [<AllowNullLiteral>] NotebookRangeStatic =
        /// <summary>Create a new notebook range. If `start` is not
        /// before or equal to `end`, the values will be swapped.</summary>
        /// <param name="start">start index</param>
        /// <param name="end">end index.</param>
        [<Emit "new $0($1...)">] abstract Create: start: float * ``end``: float -> NotebookRange

    /// One representation of a {@link NotebookCellOutput notebook output}, defined by MIME type and data.
    type [<AllowNullLiteral>] NotebookCellOutputItem =
        /// The mime type which determines how the {@link NotebookCellOutputItem.data `data`}-property
        /// is interpreted.
        /// 
        /// Notebooks have built-in support for certain mime-types, extensions can add support for new
        /// types and override existing types.
        abstract mime: string with get, set
        /// The data of this output item. Must always be an array of unsigned 8-bit integers.
        abstract data: Uint8Array with get, set

    /// One representation of a {@link NotebookCellOutput notebook output}, defined by MIME type and data.
    type [<AllowNullLiteral>] NotebookCellOutputItemStatic =
        /// <summary>Factory function to create a `NotebookCellOutputItem` from a string.
        /// 
        /// *Note* that an UTF-8 encoder is used to create bytes for the string.</summary>
        /// <param name="value">A string.</param>
        /// <param name="mime">Optional MIME type, defaults to `text/plain`.</param>
        abstract text: value: string * ?mime: string -> NotebookCellOutputItem
        /// <summary>Factory function to create a `NotebookCellOutputItem` from
        /// a JSON object.
        /// 
        /// *Note* that this function is not expecting "stringified JSON" but
        /// an object that can be stringified. This function will throw an error
        /// when the passed value cannot be JSON-stringified.</summary>
        /// <param name="value">A JSON-stringifyable value.</param>
        /// <param name="mime">Optional MIME type, defaults to `application/json`</param>
        abstract json: value: obj option * ?mime: string -> NotebookCellOutputItem
        /// <summary>Factory function to create a `NotebookCellOutputItem` that uses
        /// uses the `application/vnd.code.notebook.stdout` mime type.</summary>
        /// <param name="value">A string.</param>
        abstract stdout: value: string -> NotebookCellOutputItem
        /// <summary>Factory function to create a `NotebookCellOutputItem` that uses
        /// uses the `application/vnd.code.notebook.stderr` mime type.</summary>
        /// <param name="value">A string.</param>
        abstract stderr: value: string -> NotebookCellOutputItem
        /// <summary>Factory function to create a `NotebookCellOutputItem` that uses
        /// uses the `application/vnd.code.notebook.error` mime type.</summary>
        /// <param name="value">An error object.</param>
        abstract error: value: Error -> NotebookCellOutputItem
        /// <summary>Create a new notebook cell output item.</summary>
        /// <param name="data">The value of the output item.</param>
        /// <param name="mime">The mime type of the output item.</param>
        [<Emit "new $0($1...)">] abstract Create: data: Uint8Array * mime: string -> NotebookCellOutputItem

    /// Notebook cell output represents a result of executing a cell. It is a container type for multiple
    /// {@link NotebookCellOutputItem output items} where contained items represent the same result but
    /// use different MIME types.
    type [<AllowNullLiteral>] NotebookCellOutput =
        /// The output items of this output. Each item must represent the same result. _Note_ that repeated
        /// MIME types per output is invalid and that the editor will just pick one of them.
        /// 
        /// ```ts
        /// new vscode.NotebookCellOutput([
        ///      vscode.NotebookCellOutputItem.text('Hello', 'text/plain'),
        ///      vscode.NotebookCellOutputItem.text('<i>Hello</i>', 'text/html'),
        ///      vscode.NotebookCellOutputItem.text('_Hello_', 'text/markdown'),
        ///      vscode.NotebookCellOutputItem.text('Hey', 'text/plain'), // INVALID: repeated type, editor will pick just one
        /// ])
        /// ```
        abstract items: ResizeArray<NotebookCellOutputItem> with get, set
        /// Arbitrary metadata for this cell output. Can be anything but must be JSON-stringifyable.
        abstract metadata: NotebookCellMetadata option with get, set

    /// Notebook cell output represents a result of executing a cell. It is a container type for multiple
    /// {@link NotebookCellOutputItem output items} where contained items represent the same result but
    /// use different MIME types.
    type [<AllowNullLiteral>] NotebookCellOutputStatic =
        /// <summary>Create new notebook output.</summary>
        /// <param name="items">Notebook output items.</param>
        /// <param name="metadata">Optional metadata.</param>
        [<Emit "new $0($1...)">] abstract Create: items: ResizeArray<NotebookCellOutputItem> * ?metadata: NotebookCellOutputStaticMetadata -> NotebookCellOutput

    type [<AllowNullLiteral>] NotebookCellOutputStaticMetadata =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    /// NotebookCellData is the raw representation of notebook cells. Its is part of {@link NotebookData `NotebookData`}.
    type [<AllowNullLiteral>] NotebookCellData =
        /// The {@link NotebookCellKind kind} of this cell data.
        abstract kind: NotebookCellKind with get, set
        /// The source value of this cell data - either source code or formatted text.
        abstract value: string with get, set
        /// The language identifier of the source value of this cell data. Any value from
        /// {@link languages.getLanguages `getLanguages`} is possible.
        abstract languageId: string with get, set
        /// The outputs of this cell data.
        abstract outputs: ResizeArray<NotebookCellOutput> option with get, set
        /// Arbitrary metadata of this cell data. Can be anything but must be JSON-stringifyable.
        abstract metadata: NotebookCellMetadata option with get, set
        /// The execution summary of this cell data.
        abstract executionSummary: NotebookCellExecutionSummary option with get, set

    /// NotebookCellData is the raw representation of notebook cells. Its is part of {@link NotebookData `NotebookData`}.
    type [<AllowNullLiteral>] NotebookCellDataStatic =
        /// <summary>Create new cell data. Minimal cell data specifies its kind, its source value, and the
        /// language identifier of its source.</summary>
        /// <param name="kind">The kind.</param>
        /// <param name="value">The source value.</param>
        /// <param name="languageId">The language identifier of the source value.</param>
        [<Emit "new $0($1...)">] abstract Create: kind: NotebookCellKind * value: string * languageId: string -> NotebookCellData

    /// Raw representation of a notebook.
    /// 
    /// Extensions are responsible for creating {@link NotebookData `NotebookData`} so that the editor
    /// can create a {@link NotebookDocument `NotebookDocument`}.
    type [<AllowNullLiteral>] NotebookData =
        /// The cell data of this notebook data.
        abstract cells: ResizeArray<NotebookCellData> with get, set
        /// Arbitrary metadata of notebook data.
        abstract metadata: NotebookCellMetadata option with get, set

    /// Raw representation of a notebook.
    /// 
    /// Extensions are responsible for creating {@link NotebookData `NotebookData`} so that the editor
    /// can create a {@link NotebookDocument `NotebookDocument`}.
    type [<AllowNullLiteral>] NotebookDataStatic =
        /// <summary>Create new notebook data.</summary>
        /// <param name="cells">An array of cell data.</param>
        [<Emit "new $0($1...)">] abstract Create: cells: ResizeArray<NotebookCellData> -> NotebookData

    /// The notebook serializer enables the editor to open notebook files.
    /// 
    /// At its core the editor only knows a {@link NotebookData notebook data structure} but not
    /// how that data structure is written to a file, nor how it is read from a file. The
    /// notebook serializer bridges this gap by deserializing bytes into notebook data and
    /// vice versa.
    type [<AllowNullLiteral>] NotebookSerializer =
        /// <summary>Deserialize contents of a notebook file into the notebook data structure.</summary>
        /// <param name="content">Contents of a notebook file.</param>
        /// <param name="token">A cancellation token.</param>
        abstract deserializeNotebook: content: Uint8Array * token: CancellationToken -> U2<NotebookData, Thenable<NotebookData>>
        /// <summary>Serialize notebook data into file contents.</summary>
        /// <param name="data">A notebook data structure.</param>
        /// <param name="token">A cancellation token.</param>
        abstract serializeNotebook: data: NotebookData * token: CancellationToken -> U2<Uint8Array, Thenable<Uint8Array>>

    /// Notebook content options define what parts of a notebook are persisted. Note
    /// 
    /// For instance, a notebook serializer can opt-out of saving outputs and in that case the editor doesn't mark a
    /// notebooks as {@link NotebookDocument.isDirty dirty} when its output has changed.
    type [<AllowNullLiteral>] NotebookDocumentContentOptions =
        /// Controls if outputs change will trigger notebook document content change and if it will be used in the diff editor
        /// Default to false. If the content provider doesn't persisit the outputs in the file document, this should be set to true.
        abstract transientOutputs: bool option with get, set
        /// Controls if a cell metadata property change will trigger notebook document content change and if it will be used in the diff editor
        /// Default to false. If the content provider doesn't persisit a metadata property in the file document, it should be set to true.
        abstract transientCellMetadata: NotebookDocumentContentOptionsTransientCellMetadata option with get, set
        /// Controls if a document metadata property change will trigger notebook document content change and if it will be used in the diff editor
        /// Default to false. If the content provider doesn't persisit a metadata property in the file document, it should be set to true.
        abstract transientDocumentMetadata: NotebookDocumentContentOptionsTransientCellMetadata option with get, set

    type [<RequireQualifiedAccess>] NotebookControllerAffinity =
        | Default = 1
        | Preferred = 2

    /// A notebook controller represents an entity that can execute notebook cells. This is often referred to as a kernel.
    /// 
    /// There can be multiple controllers and the editor will let users choose which controller to use for a certain notebook. The
    /// {@link NotebookController.notebookType `notebookType`}-property defines for what kind of notebooks a controller is for and
    /// the {@link NotebookController.updateNotebookAffinity `updateNotebookAffinity`}-function allows controllers to set a preference
    /// for specific notebook documents. When a controller has been selected its
    /// {@link NotebookController.onDidChangeSelectedNotebooks onDidChangeSelectedNotebooks}-event fires.
    /// 
    /// When a cell is being run the editor will invoke the {@link NotebookController.executeHandler `executeHandler`} and a controller
    /// is expected to create and finalize a {@link NotebookCellExecution notebook cell execution}. However, controllers are also free
    /// to create executions by themselves.
    type [<AllowNullLiteral>] NotebookController =
        /// The identifier of this notebook controller.
        /// 
        /// _Note_ that controllers are remembered by their identifier and that extensions should use
        /// stable identifiers across sessions.
        abstract id: string
        /// The notebook type this controller is for.
        abstract notebookType: string
        /// An array of language identifiers that are supported by this
        /// controller. Any language identifier from {@link languages.getLanguages `getLanguages`}
        /// is possible. When falsy all languages are supported.
        /// 
        /// Samples:
        /// ```js
        /// // support JavaScript and TypeScript
        /// myController.supportedLanguages = ['javascript', 'typescript']
        /// 
        /// // support all languages
        /// myController.supportedLanguages = undefined; // falsy
        /// myController.supportedLanguages = []; // falsy
        /// ```
        abstract supportedLanguages: ResizeArray<string> option with get, set
        /// The human-readable label of this notebook controller.
        abstract label: string with get, set
        /// The human-readable description which is rendered less prominent.
        abstract description: string option with get, set
        /// The human-readable detail which is rendered less prominent.
        abstract detail: string option with get, set
        /// Whether this controller supports execution order so that the
        /// editor can render placeholders for them.
        abstract supportsExecutionOrder: bool option with get, set
        /// <summary>Create a cell execution task.
        /// 
        /// _Note_ that there can only be one execution per cell at a time and that an error is thrown if
        /// a cell execution is created while another is still active.
        /// 
        /// This should be used in response to the {@link NotebookController.executeHandler execution handler}
        /// being called or when cell execution has been started else, e.g when a cell was already
        /// executing or when cell execution was triggered from another source.</summary>
        /// <param name="cell">The notebook cell for which to create the execution.</param>
        abstract createNotebookCellExecution: cell: NotebookCell -> NotebookCellExecution
        /// The execute handler is invoked when the run gestures in the UI are selected, e.g Run Cell, Run All,
        /// Run Selection etc. The execute handler is responsible for creating and managing {@link NotebookCellExecution execution}-objects.
        abstract executeHandler: (ResizeArray<NotebookCell> -> NotebookDocument -> NotebookController -> U2<unit, Thenable<unit>>) with get, set
        /// Optional interrupt handler.
        /// 
        /// By default cell execution is canceled via {@link NotebookCellExecution.token tokens}. Cancellation
        /// tokens require that a controller can keep track of its execution so that it can cancel a specific execution at a later
        /// point. Not all scenarios allow for that, eg. REPL-style controllers often work by interrupting whatever is currently
        /// running. For those cases the interrupt handler exists - it can be thought of as the equivalent of `SIGINT`
        /// or `Control+C` in terminals.
        /// 
        /// _Note_ that supporting {@link NotebookCellExecution.token cancellation tokens} is preferred and that interrupt handlers should
        /// only be used when tokens cannot be supported.
        abstract interruptHandler: (NotebookDocument -> U2<unit, Thenable<unit>>) option with get, set
        /// An event that fires whenever a controller has been selected or un-selected for a notebook document.
        /// 
        /// There can be multiple controllers for a notebook and in that case a controllers needs to be _selected_. This is a user gesture
        /// and happens either explicitly or implicitly when interacting with a notebook for which a controller was _suggested_. When possible,
        /// the editor _suggests_ a controller that is most likely to be _selected_.
        /// 
        /// _Note_ that controller selection is persisted (by the controllers {@link NotebookController.id id}) and restored as soon as a
        /// controller is re-created or as a notebook is {@link workspace.onDidOpenNotebookDocument opened}.
        abstract onDidChangeSelectedNotebooks: Event<NotebookControllerOnDidChangeSelectedNotebooksEvent>
        /// <summary>A controller can set affinities for specific notebook documents. This allows a controller
        /// to be presented more prominent for some notebooks.</summary>
        /// <param name="notebook">The notebook for which a priority is set.</param>
        /// <param name="affinity">A controller affinity</param>
        abstract updateNotebookAffinity: notebook: NotebookDocument * affinity: NotebookControllerAffinity -> unit
        /// Dispose and free associated resources.
        abstract dispose: unit -> unit

    /// A NotebookCellExecution is how {@link NotebookController notebook controller} modify a notebook cell as
    /// it is executing.
    /// 
    /// When a cell execution object is created, the cell enters the {@link NotebookCellExecutionState.Pending `Pending`} state.
    /// When {@link NotebookCellExecution.start `start(...)`} is called on the execution task, it enters the {@link NotebookCellExecutionState.Executing `Executing`} state. When
    /// {@link NotebookCellExecution.end `end(...)`} is called, it enters the {@link NotebookCellExecutionState.Idle `Idle`} state.
    type [<AllowNullLiteral>] NotebookCellExecution =
        /// The {@link NotebookCell cell} for which this execution has been created.
        abstract cell: NotebookCell
        /// A cancellation token which will be triggered when the cell execution is canceled
        /// from the UI.
        /// 
        /// _Note_ that the cancellation token will not be triggered when the {@link NotebookController controller}
        /// that created this execution uses an {@link NotebookController.interruptHandler interrupt-handler}.
        abstract token: CancellationToken
        /// Set and unset the order of this cell execution.
        abstract executionOrder: float option with get, set
        /// <summary>Signal that the execution has begun.</summary>
        /// <param name="startTime">The time that execution began, in milliseconds in the Unix epoch. Used to drive the clock
        /// that shows for how long a cell has been running. If not given, the clock won't be shown.</param>
        abstract start: ?startTime: float -> unit
        /// <summary>Signal that execution has ended.</summary>
        /// <param name="success">If true, a green check is shown on the cell status bar.
        /// If false, a red X is shown.
        /// If undefined, no check or X icon is shown.</param>
        /// <param name="endTime">The time that execution finished, in milliseconds in the Unix epoch.</param>
        abstract ``end``: success: bool option * ?endTime: float -> unit
        /// <summary>Clears the output of the cell that is executing or of another cell that is affected by this execution.</summary>
        /// <param name="cell">Cell for which output is cleared. Defaults to the {@link NotebookCellExecution.cell cell} of
        /// this execution.</param>
        abstract clearOutput: ?cell: NotebookCell -> Thenable<unit>
        /// <summary>Replace the output of the cell that is executing or of another cell that is affected by this execution.</summary>
        /// <param name="out">Output that replaces the current output.</param>
        /// <param name="cell">Cell for which output is cleared. Defaults to the {@link NotebookCellExecution.cell cell} of
        /// this execution.</param>
        abstract replaceOutput: out: U2<NotebookCellOutput, ResizeArray<NotebookCellOutput>> * ?cell: NotebookCell -> Thenable<unit>
        /// <summary>Append to the output of the cell that is executing or to another cell that is affected by this execution.</summary>
        /// <param name="out">Output that is appended to the current output.</param>
        /// <param name="cell">Cell for which output is cleared. Defaults to the {@link NotebookCellExecution.cell cell} of
        /// this execution.</param>
        abstract appendOutput: out: U2<NotebookCellOutput, ResizeArray<NotebookCellOutput>> * ?cell: NotebookCell -> Thenable<unit>
        /// <summary>Replace all output items of existing cell output.</summary>
        /// <param name="items">Output items that replace the items of existing output.</param>
        /// <param name="output">Output object that already exists.</param>
        abstract replaceOutputItems: items: U2<NotebookCellOutputItem, ResizeArray<NotebookCellOutputItem>> * output: NotebookCellOutput -> Thenable<unit>
        /// <summary>Append output items to existing cell output.</summary>
        /// <param name="items">Output items that are append to existing output.</param>
        /// <param name="output">Output object that already exists.</param>
        abstract appendOutputItems: items: U2<NotebookCellOutputItem, ResizeArray<NotebookCellOutputItem>> * output: NotebookCellOutput -> Thenable<unit>

    type [<RequireQualifiedAccess>] NotebookCellStatusBarAlignment =
        | Left = 1
        | Right = 2

    /// A contribution to a cell's status bar
    type [<AllowNullLiteral>] NotebookCellStatusBarItem =
        /// The text to show for the item.
        abstract text: string with get, set
        /// Whether the item is aligned to the left or right.
        abstract alignment: NotebookCellStatusBarAlignment with get, set
        /// An optional {@link Command `Command`} or identifier of a command to run on click.
        /// 
        /// The command must be {@link commands.getCommands known}.
        /// 
        /// Note that if this is a {@link Command `Command`} object, only the {@link Command.command `command`} and {@link Command.arguments `arguments`}
        /// are used by the editor.
        abstract command: U2<string, Command> option with get, set
        /// A tooltip to show when the item is hovered.
        abstract tooltip: string option with get, set
        /// The priority of the item. A higher value item will be shown more to the left.
        abstract priority: float option with get, set
        /// Accessibility information used when a screen reader interacts with this item.
        abstract accessibilityInformation: AccessibilityInformation option with get, set

    /// A contribution to a cell's status bar
    type [<AllowNullLiteral>] NotebookCellStatusBarItemStatic =
        /// <summary>Creates a new NotebookCellStatusBarItem.</summary>
        /// <param name="text">The text to show for the item.</param>
        /// <param name="alignment">Whether the item is aligned to the left or right.</param>
        [<Emit "new $0($1...)">] abstract Create: text: string * alignment: NotebookCellStatusBarAlignment -> NotebookCellStatusBarItem

    /// A provider that can contribute items to the status bar that appears below a cell's editor.
    type [<AllowNullLiteral>] NotebookCellStatusBarItemProvider =
        /// An optional event to signal that statusbar items have changed. The provide method will be called again.
        abstract onDidChangeCellStatusBarItems: Event<unit> option with get, set
        /// <summary>The provider will be called when the cell scrolls into view, when its content, outputs, language, or metadata change, and when it changes execution state.</summary>
        /// <param name="cell">The cell for which to return items.</param>
        /// <param name="token">A token triggered if this request should be cancelled.</param>
        abstract provideCellStatusBarItems: cell: NotebookCell * token: CancellationToken -> ProviderResult<U2<NotebookCellStatusBarItem, ResizeArray<NotebookCellStatusBarItem>>>

    module Notebooks =

        type [<AllowNullLiteral>] IExports =
            /// <summary>Creates a new notebook controller.</summary>
            /// <param name="id">Identifier of the controller. Must be unique per extension.</param>
            /// <param name="notebookType">A notebook type for which this controller is for.</param>
            /// <param name="label">The label of the controller.</param>
            /// <param name="handler">The execute-handler of the controller.</param>
            abstract createNotebookController: id: string * notebookType: string * label: string * ?handler: (ResizeArray<NotebookCell> -> NotebookDocument -> NotebookController -> U2<unit, Thenable<unit>>) -> NotebookController
            /// <summary>Register a {@link NotebookCellStatusBarItemProvider cell statusbar item provider} for the given notebook type.</summary>
            /// <param name="notebookType">The notebook type to register for.</param>
            /// <param name="provider">A cell status bar provider.</param>
            abstract registerNotebookCellStatusBarItemProvider: notebookType: string * provider: NotebookCellStatusBarItemProvider -> Disposable

    /// Represents the input box in the Source Control viewlet.
    type [<AllowNullLiteral>] SourceControlInputBox =
        /// Setter and getter for the contents of the input box.
        abstract value: string with get, set
        /// A string to show as placeholder in the input box to guide the user.
        abstract placeholder: string with get, set
        /// Controls whether the input box is visible (default is `true`).
        abstract visible: bool with get, set

    type [<AllowNullLiteral>] QuickDiffProvider =
        /// <summary>Provide a {@link Uri} to the original resource of any given resource uri.</summary>
        /// <param name="uri">The uri of the resource open in a text editor.</param>
        /// <param name="token">A cancellation token.</param>
        abstract provideOriginalResource: uri: Uri * token: CancellationToken -> ProviderResult<Uri>

    /// The theme-aware decorations for a
    /// {@link SourceControlResourceState source control resource state}.
    type [<AllowNullLiteral>] SourceControlResourceThemableDecorations =
        /// The icon path for a specific
        /// {@link SourceControlResourceState source control resource state}.
        abstract iconPath: U2<string, Uri> option

    /// The decorations for a {@link SourceControlResourceState source control resource state}.
    /// Can be independently specified for light and dark themes.
    type [<AllowNullLiteral>] SourceControlResourceDecorations =
        inherit SourceControlResourceThemableDecorations
        /// Whether the {@link SourceControlResourceState source control resource state} should
        /// be striked-through in the UI.
        abstract strikeThrough: bool option
        /// Whether the {@link SourceControlResourceState source control resource state} should
        /// be faded in the UI.
        abstract faded: bool option
        /// The title for a specific
        /// {@link SourceControlResourceState source control resource state}.
        abstract tooltip: string option
        /// The light theme decorations.
        abstract light: SourceControlResourceThemableDecorations option
        /// The dark theme decorations.
        abstract dark: SourceControlResourceThemableDecorations option

    /// An source control resource state represents the state of an underlying workspace
    /// resource within a certain {@link SourceControlResourceGroup source control group}.
    type [<AllowNullLiteral>] SourceControlResourceState =
        /// The {@link Uri} of the underlying resource inside the workspace.
        abstract resourceUri: Uri
        /// The {@link Command} which should be run when the resource
        /// state is open in the Source Control viewlet.
        abstract command: Command option
        /// The {@link SourceControlResourceDecorations decorations} for this source control
        /// resource state.
        abstract decorations: SourceControlResourceDecorations option
        /// Context value of the resource state. This can be used to contribute resource specific actions.
        /// For example, if a resource is given a context value as `diffable`. When contributing actions to `scm/resourceState/context`
        /// using `menus` extension point, you can specify context value for key `scmResourceState` in `when` expressions, like `scmResourceState == diffable`.
        /// ```
        ///     "contributes": {
        ///         "menus": {
        ///             "scm/resourceState/context": [
        ///                 {
        ///                     "command": "extension.diff",
        ///                     "when": "scmResourceState == diffable"
        ///                 }
        ///             ]
        ///         }
        ///     }
        /// ```
        /// This will show action `extension.diff` only for resources with `contextValue` is `diffable`.
        abstract contextValue: string option

    /// A source control resource group is a collection of
    /// {@link SourceControlResourceState source control resource states}.
    type [<AllowNullLiteral>] SourceControlResourceGroup =
        /// The id of this source control resource group.
        abstract id: string
        /// The label of this source control resource group.
        abstract label: string with get, set
        /// Whether this source control resource group is hidden when it contains
        /// no {@link SourceControlResourceState source control resource states}.
        abstract hideWhenEmpty: bool option with get, set
        /// This group's collection of
        /// {@link SourceControlResourceState source control resource states}.
        abstract resourceStates: ResizeArray<SourceControlResourceState> with get, set
        /// Dispose this source control resource group.
        abstract dispose: unit -> unit

    /// An source control is able to provide {@link SourceControlResourceState resource states}
    /// to the editor and interact with the editor in several source control related ways.
    type [<AllowNullLiteral>] SourceControl =
        /// The id of this source control.
        abstract id: string
        /// The human-readable label of this source control.
        abstract label: string
        /// The (optional) Uri of the root of this source control.
        abstract rootUri: Uri option
        /// The {@link SourceControlInputBox input box} for this source control.
        abstract inputBox: SourceControlInputBox
        /// The UI-visible count of {@link SourceControlResourceState resource states} of
        /// this source control.
        /// 
        /// Equals to the total number of {@link SourceControlResourceState resource state}
        /// of this source control, if undefined.
        abstract count: float option with get, set
        /// An optional {@link QuickDiffProvider quick diff provider}.
        abstract quickDiffProvider: QuickDiffProvider option with get, set
        /// Optional commit template string.
        /// 
        /// The Source Control viewlet will populate the Source Control
        /// input with this value when appropriate.
        abstract commitTemplate: string option with get, set
        /// Optional accept input command.
        /// 
        /// This command will be invoked when the user accepts the value
        /// in the Source Control input.
        abstract acceptInputCommand: Command option with get, set
        /// Optional status bar commands.
        /// 
        /// These commands will be displayed in the editor's status bar.
        abstract statusBarCommands: ResizeArray<Command> option with get, set
        /// Create a new {@link SourceControlResourceGroup resource group}.
        abstract createResourceGroup: id: string * label: string -> SourceControlResourceGroup
        /// Dispose this source control.
        abstract dispose: unit -> unit

    module Scm =

        type [<AllowNullLiteral>] IExports =
            abstract inputBox: SourceControlInputBox
            /// <summary>Creates a new {@link SourceControl source control} instance.</summary>
            /// <param name="id">An `id` for the source control. Something short, e.g.: `git`.</param>
            /// <param name="label">A human-readable string for the source control. E.g.: `Git`.</param>
            /// <param name="rootUri">An optional Uri of the root of the source control. E.g.: `Uri.parse(workspaceRoot)`.</param>
            abstract createSourceControl: id: string * label: string * ?rootUri: Uri -> SourceControl

    /// A DebugProtocolMessage is an opaque stand-in type for the [ProtocolMessage](https://microsoft.github.io/debug-adapter-protocol/specification#Base_Protocol_ProtocolMessage) type defined in the Debug Adapter Protocol.
    type [<AllowNullLiteral>] DebugProtocolMessage =
        interface end

    /// A DebugProtocolSource is an opaque stand-in type for the [Source](https://microsoft.github.io/debug-adapter-protocol/specification#Types_Source) type defined in the Debug Adapter Protocol.
    type [<AllowNullLiteral>] DebugProtocolSource =
        interface end

    /// A DebugProtocolBreakpoint is an opaque stand-in type for the [Breakpoint](https://microsoft.github.io/debug-adapter-protocol/specification#Types_Breakpoint) type defined in the Debug Adapter Protocol.
    type [<AllowNullLiteral>] DebugProtocolBreakpoint =
        interface end

    /// Configuration for a debug session.
    type [<AllowNullLiteral>] DebugConfiguration =
        /// The type of the debug session.
        abstract ``type``: string with get, set
        /// The name of the debug session.
        abstract name: string with get, set
        /// The request type of the debug session.
        abstract request: string with get, set
        /// Additional debug type specific properties.
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    /// A debug session.
    type [<AllowNullLiteral>] DebugSession =
        /// The unique ID of this debug session.
        abstract id: string
        /// The debug session's type from the {@link DebugConfiguration debug configuration}.
        abstract ``type``: string
        /// The parent session of this debug session, if it was created as a child.
        abstract parentSession: DebugSession option
        /// The debug session's name is initially taken from the {@link DebugConfiguration debug configuration}.
        /// Any changes will be properly reflected in the UI.
        abstract name: string with get, set
        /// The workspace folder of this session or `undefined` for a folderless setup.
        abstract workspaceFolder: WorkspaceFolder option
        /// The "resolved" {@link DebugConfiguration debug configuration} of this session.
        /// "Resolved" means that
        /// - all variables have been substituted and
        /// - platform specific attribute sections have been "flattened" for the matching platform and removed for non-matching platforms.
        abstract configuration: DebugConfiguration
        /// Send a custom request to the debug adapter.
        abstract customRequest: command: string * ?args: obj -> Thenable<obj option>
        /// <summary>Maps a breakpoint in the editor to the corresponding Debug Adapter Protocol (DAP) breakpoint that is managed by the debug adapter of the debug session.
        /// If no DAP breakpoint exists (either because the editor breakpoint was not yet registered or because the debug adapter is not interested in the breakpoint), the value `undefined` is returned.</summary>
        /// <param name="breakpoint">A {@link Breakpoint} in the editor.</param>
        abstract getDebugProtocolBreakpoint: breakpoint: Breakpoint -> Thenable<DebugProtocolBreakpoint option>

    /// A custom Debug Adapter Protocol event received from a {@link DebugSession debug session}.
    type [<AllowNullLiteral>] DebugSessionCustomEvent =
        /// The {@link DebugSession debug session} for which the custom event was received.
        abstract session: DebugSession
        /// Type of event.
        abstract ``event``: string
        /// Event specific information.
        abstract body: obj option

    /// A debug configuration provider allows to add debug configurations to the debug service
    /// and to resolve launch configurations before they are used to start a debug session.
    /// A debug configuration provider is registered via {@link debug.registerDebugConfigurationProvider}.
    type [<AllowNullLiteral>] DebugConfigurationProvider =
        /// <summary>Provides {@link DebugConfiguration debug configuration} to the debug service. If more than one debug configuration provider is
        /// registered for the same type, debug configurations are concatenated in arbitrary order.</summary>
        /// <param name="folder">The workspace folder for which the configurations are used or `undefined` for a folderless setup.</param>
        /// <param name="token">A cancellation token.</param>
        abstract provideDebugConfigurations: folder: WorkspaceFolder option * ?token: CancellationToken -> ProviderResult<ResizeArray<DebugConfiguration>>
        /// <summary>Resolves a {@link DebugConfiguration debug configuration} by filling in missing values or by adding/changing/removing attributes.
        /// If more than one debug configuration provider is registered for the same type, the resolveDebugConfiguration calls are chained
        /// in arbitrary order and the initial debug configuration is piped through the chain.
        /// Returning the value 'undefined' prevents the debug session from starting.
        /// Returning the value 'null' prevents the debug session from starting and opens the underlying debug configuration instead.</summary>
        /// <param name="folder">The workspace folder from which the configuration originates from or `undefined` for a folderless setup.</param>
        /// <param name="debugConfiguration">The {@link DebugConfiguration debug configuration} to resolve.</param>
        /// <param name="token">A cancellation token.</param>
        abstract resolveDebugConfiguration: folder: WorkspaceFolder option * debugConfiguration: DebugConfiguration * ?token: CancellationToken -> ProviderResult<DebugConfiguration>
        /// <summary>This hook is directly called after 'resolveDebugConfiguration' but with all variables substituted.
        /// It can be used to resolve or verify a {@link DebugConfiguration debug configuration} by filling in missing values or by adding/changing/removing attributes.
        /// If more than one debug configuration provider is registered for the same type, the 'resolveDebugConfigurationWithSubstitutedVariables' calls are chained
        /// in arbitrary order and the initial debug configuration is piped through the chain.
        /// Returning the value 'undefined' prevents the debug session from starting.
        /// Returning the value 'null' prevents the debug session from starting and opens the underlying debug configuration instead.</summary>
        /// <param name="folder">The workspace folder from which the configuration originates from or `undefined` for a folderless setup.</param>
        /// <param name="debugConfiguration">The {@link DebugConfiguration debug configuration} to resolve.</param>
        /// <param name="token">A cancellation token.</param>
        abstract resolveDebugConfigurationWithSubstitutedVariables: folder: WorkspaceFolder option * debugConfiguration: DebugConfiguration * ?token: CancellationToken -> ProviderResult<DebugConfiguration>

    /// Represents a debug adapter executable and optional arguments and runtime options passed to it.
    type [<AllowNullLiteral>] DebugAdapterExecutable =
        /// The command or path of the debug adapter executable.
        /// A command must be either an absolute path of an executable or the name of an command to be looked up via the PATH environment variable.
        /// The special value 'node' will be mapped to the editor's built-in Node.js runtime.
        abstract command: string
        /// The arguments passed to the debug adapter executable. Defaults to an empty array.
        abstract args: ResizeArray<string>
        /// Optional options to be used when the debug adapter is started.
        /// Defaults to undefined.
        abstract options: DebugAdapterExecutableOptions option

    /// Represents a debug adapter executable and optional arguments and runtime options passed to it.
    type [<AllowNullLiteral>] DebugAdapterExecutableStatic =
        /// <summary>Creates a description for a debug adapter based on an executable program.</summary>
        /// <param name="command">The command or executable path that implements the debug adapter.</param>
        /// <param name="args">Optional arguments to be passed to the command or executable.</param>
        /// <param name="options">Optional options to be used when starting the command or executable.</param>
        [<Emit "new $0($1...)">] abstract Create: command: string * ?args: ResizeArray<string> * ?options: DebugAdapterExecutableOptions -> DebugAdapterExecutable

    /// Options for a debug adapter executable.
    type [<AllowNullLiteral>] DebugAdapterExecutableOptions =
        /// The additional environment of the executed program or shell. If omitted
        /// the parent process' environment is used. If provided it is merged with
        /// the parent process' environment.
        abstract env: ProcessExecutionOptionsEnv option with get, set
        /// The current working directory for the executed debug adapter.
        abstract cwd: string option with get, set

    /// Represents a debug adapter running as a socket based server.
    type [<AllowNullLiteral>] DebugAdapterServer =
        /// The port.
        abstract port: float
        /// The host.
        abstract host: string option

    /// Represents a debug adapter running as a socket based server.
    type [<AllowNullLiteral>] DebugAdapterServerStatic =
        /// Create a description for a debug adapter running as a socket based server.
        [<Emit "new $0($1...)">] abstract Create: port: float * ?host: string -> DebugAdapterServer

    /// Represents a debug adapter running as a Named Pipe (on Windows)/UNIX Domain Socket (on non-Windows) based server.
    type [<AllowNullLiteral>] DebugAdapterNamedPipeServer =
        /// The path to the NamedPipe/UNIX Domain Socket.
        abstract path: string

    /// Represents a debug adapter running as a Named Pipe (on Windows)/UNIX Domain Socket (on non-Windows) based server.
    type [<AllowNullLiteral>] DebugAdapterNamedPipeServerStatic =
        /// Create a description for a debug adapter running as a Named Pipe (on Windows)/UNIX Domain Socket (on non-Windows) based server.
        [<Emit "new $0($1...)">] abstract Create: path: string -> DebugAdapterNamedPipeServer

    /// A debug adapter that implements the Debug Adapter Protocol can be registered with the editor if it implements the DebugAdapter interface.
    type [<AllowNullLiteral>] DebugAdapter =
        inherit Disposable
        /// An event which fires after the debug adapter has sent a Debug Adapter Protocol message to the editor.
        /// Messages can be requests, responses, or events.
        abstract onDidSendMessage: Event<DebugProtocolMessage>
        /// <summary>Handle a Debug Adapter Protocol message.
        /// Messages can be requests, responses, or events.
        /// Results or errors are returned via onSendMessage events.</summary>
        /// <param name="message">A Debug Adapter Protocol message</param>
        abstract handleMessage: message: DebugProtocolMessage -> unit

    /// A debug adapter descriptor for an inline implementation.
    type [<AllowNullLiteral>] DebugAdapterInlineImplementation =
        interface end

    /// A debug adapter descriptor for an inline implementation.
    type [<AllowNullLiteral>] DebugAdapterInlineImplementationStatic =
        /// Create a descriptor for an inline implementation of a debug adapter.
        [<Emit "new $0($1...)">] abstract Create: implementation: DebugAdapter -> DebugAdapterInlineImplementation

    type DebugAdapterDescriptor =
        U4<DebugAdapterExecutable, DebugAdapterServer, DebugAdapterNamedPipeServer, DebugAdapterInlineImplementation>

    type [<AllowNullLiteral>] DebugAdapterDescriptorFactory =
        /// <summary>'createDebugAdapterDescriptor' is called at the start of a debug session to provide details about the debug adapter to use.
        /// These details must be returned as objects of type {@link DebugAdapterDescriptor}.
        /// Currently two types of debug adapters are supported:
        /// - a debug adapter executable is specified as a command path and arguments (see {@link DebugAdapterExecutable}),
        /// - a debug adapter server reachable via a communication port (see {@link DebugAdapterServer}).
        /// If the method is not implemented the default behavior is this:
        ///    createDebugAdapter(session: DebugSession, executable: DebugAdapterExecutable) {
        ///       if (typeof session.configuration.debugServer === 'number') {
        ///          return new DebugAdapterServer(session.configuration.debugServer);
        ///       }
        ///       return executable;
        ///    }</summary>
        /// <param name="session">The {@link DebugSession debug session} for which the debug adapter will be used.</param>
        /// <param name="executable">The debug adapter's executable information as specified in the package.json (or undefined if no such information exists).</param>
        abstract createDebugAdapterDescriptor: session: DebugSession * executable: DebugAdapterExecutable option -> ProviderResult<DebugAdapterDescriptor>

    /// A Debug Adapter Tracker is a means to track the communication between the editor and a Debug Adapter.
    type [<AllowNullLiteral>] DebugAdapterTracker =
        /// A session with the debug adapter is about to be started.
        abstract onWillStartSession: unit -> unit
        /// The debug adapter is about to receive a Debug Adapter Protocol message from the editor.
        abstract onWillReceiveMessage: message: obj option -> unit
        /// The debug adapter has sent a Debug Adapter Protocol message to the editor.
        abstract onDidSendMessage: message: obj option -> unit
        /// The debug adapter session is about to be stopped.
        abstract onWillStopSession: unit -> unit
        /// An error with the debug adapter has occurred.
        abstract onError: error: Error -> unit
        /// The debug adapter has exited with the given exit code or signal.
        abstract onExit: code: float option * signal: string option -> unit

    type [<AllowNullLiteral>] DebugAdapterTrackerFactory =
        /// <summary>The method 'createDebugAdapterTracker' is called at the start of a debug session in order
        /// to return a "tracker" object that provides read-access to the communication between the editor and a debug adapter.</summary>
        /// <param name="session">The {@link DebugSession debug session} for which the debug adapter tracker will be used.</param>
        abstract createDebugAdapterTracker: session: DebugSession -> ProviderResult<DebugAdapterTracker>

    /// Represents the debug console.
    type [<AllowNullLiteral>] DebugConsole =
        /// <summary>Append the given value to the debug console.</summary>
        /// <param name="value">A string, falsy values will not be printed.</param>
        abstract append: value: string -> unit
        /// <summary>Append the given value and a line feed character
        /// to the debug console.</summary>
        /// <param name="value">A string, falsy values will be printed.</param>
        abstract appendLine: value: string -> unit

    /// An event describing the changes to the set of {@link Breakpoint breakpoints}.
    type [<AllowNullLiteral>] BreakpointsChangeEvent =
        /// Added breakpoints.
        abstract added: ResizeArray<Breakpoint>
        /// Removed breakpoints.
        abstract removed: ResizeArray<Breakpoint>
        /// Changed breakpoints.
        abstract changed: ResizeArray<Breakpoint>

    /// The base class of all breakpoint types.
    type [<AllowNullLiteral>] Breakpoint =
        /// The unique ID of the breakpoint.
        abstract id: string
        /// Is breakpoint enabled.
        abstract enabled: bool
        /// An optional expression for conditional breakpoints.
        abstract condition: string option
        /// An optional expression that controls how many hits of the breakpoint are ignored.
        abstract hitCondition: string option
        /// An optional message that gets logged when this breakpoint is hit. Embedded expressions within {} are interpolated by the debug adapter.
        abstract logMessage: string option

    /// The base class of all breakpoint types.
    type [<AllowNullLiteral>] BreakpointStatic =
        [<Emit "new $0($1...)">] abstract Create: ?enabled: bool * ?condition: string * ?hitCondition: string * ?logMessage: string -> Breakpoint

    /// A breakpoint specified by a source location.
    type [<AllowNullLiteral>] SourceBreakpoint =
        inherit Breakpoint
        /// The source and line position of this breakpoint.
        abstract location: Location

    /// A breakpoint specified by a source location.
    type [<AllowNullLiteral>] SourceBreakpointStatic =
        /// Create a new breakpoint for a source location.
        [<Emit "new $0($1...)">] abstract Create: location: Location * ?enabled: bool * ?condition: string * ?hitCondition: string * ?logMessage: string -> SourceBreakpoint

    /// A breakpoint specified by a function name.
    type [<AllowNullLiteral>] FunctionBreakpoint =
        inherit Breakpoint
        /// The name of the function to which this breakpoint is attached.
        abstract functionName: string

    /// A breakpoint specified by a function name.
    type [<AllowNullLiteral>] FunctionBreakpointStatic =
        /// Create a new function breakpoint.
        [<Emit "new $0($1...)">] abstract Create: functionName: string * ?enabled: bool * ?condition: string * ?hitCondition: string * ?logMessage: string -> FunctionBreakpoint

    type [<RequireQualifiedAccess>] DebugConsoleMode =
        | Separate = 0
        | MergeWithParent = 1

    /// Options for {@link debug.startDebugging starting a debug session}.
    type [<AllowNullLiteral>] DebugSessionOptions =
        /// When specified the newly created debug session is registered as a "child" session of this
        /// "parent" debug session.
        abstract parentSession: DebugSession option with get, set
        /// Controls whether this session should have a separate debug console or share it
        /// with the parent session. Has no effect for sessions which do not have a parent session.
        /// Defaults to Separate.
        abstract consoleMode: DebugConsoleMode option with get, set
        /// Controls whether this session should run without debugging, thus ignoring breakpoints.
        /// When this property is not specified, the value from the parent session (if there is one) is used.
        abstract noDebug: bool option with get, set
        /// Controls if the debug session's parent session is shown in the CALL STACK view even if it has only a single child.
        /// By default, the debug session will never hide its parent.
        /// If compact is true, debug sessions with a single child are hidden in the CALL STACK view to make the tree more compact.
        abstract compact: bool option with get, set

    type [<RequireQualifiedAccess>] DebugConfigurationProviderTriggerKind =
        | Initial = 1
        | Dynamic = 2

    module Debug =

        type [<AllowNullLiteral>] IExports =
            abstract activeDebugSession: DebugSession option
            abstract activeDebugConsole: DebugConsole
            abstract breakpoints: ResizeArray<Breakpoint>
            abstract onDidChangeActiveDebugSession: Event<DebugSession option>
            abstract onDidStartDebugSession: Event<DebugSession>
            abstract onDidReceiveDebugSessionCustomEvent: Event<DebugSessionCustomEvent>
            abstract onDidTerminateDebugSession: Event<DebugSession>
            abstract onDidChangeBreakpoints: Event<BreakpointsChangeEvent>
            /// <summary>Register a {@link DebugConfigurationProvider debug configuration provider} for a specific debug type.
            /// The optional {@link DebugConfigurationProviderTriggerKind triggerKind} can be used to specify when the `provideDebugConfigurations` method of the provider is triggered.
            /// Currently two trigger kinds are possible: with the value `Initial` (or if no trigger kind argument is given) the `provideDebugConfigurations` method is used to provide the initial debug configurations to be copied into a newly created launch.json.
            /// With the trigger kind `Dynamic` the `provideDebugConfigurations` method is used to dynamically determine debug configurations to be presented to the user (in addition to the static configurations from the launch.json).
            /// Please note that the `triggerKind` argument only applies to the `provideDebugConfigurations` method: so the `resolveDebugConfiguration` methods are not affected at all.
            /// Registering a single provider with resolve methods for different trigger kinds, results in the same resolve methods called multiple times.
            /// More than one provider can be registered for the same type.</summary>
            /// <param name="debugType"></param>
            /// <param name="provider">The {@link DebugConfigurationProvider debug configuration provider} to register.</param>
            /// <param name="triggerKind">The {@link DebugConfigurationProviderTrigger trigger} for which the 'provideDebugConfiguration' method of the provider is registered. If `triggerKind` is missing, the value `DebugConfigurationProviderTriggerKind.Initial` is assumed.</param>
            abstract registerDebugConfigurationProvider: debugType: string * provider: DebugConfigurationProvider * ?triggerKind: DebugConfigurationProviderTriggerKind -> Disposable
            /// <summary>Register a {@link DebugAdapterDescriptorFactory debug adapter descriptor factory} for a specific debug type.
            /// An extension is only allowed to register a DebugAdapterDescriptorFactory for the debug type(s) defined by the extension. Otherwise an error is thrown.
            /// Registering more than one DebugAdapterDescriptorFactory for a debug type results in an error.</summary>
            /// <param name="debugType">The debug type for which the factory is registered.</param>
            /// <param name="factory">The {@link DebugAdapterDescriptorFactory debug adapter descriptor factory} to register.</param>
            abstract registerDebugAdapterDescriptorFactory: debugType: string * factory: DebugAdapterDescriptorFactory -> Disposable
            /// <summary>Register a debug adapter tracker factory for the given debug type.</summary>
            /// <param name="debugType">The debug type for which the factory is registered or '*' for matching all debug types.</param>
            /// <param name="factory">The {@link DebugAdapterTrackerFactory debug adapter tracker factory} to register.</param>
            abstract registerDebugAdapterTrackerFactory: debugType: string * factory: DebugAdapterTrackerFactory -> Disposable
            /// <summary>Start debugging by using either a named launch or named compound configuration,
            /// or by directly passing a {@link DebugConfiguration}.
            /// The named configurations are looked up in '.vscode/launch.json' found in the given folder.
            /// Before debugging starts, all unsaved files are saved and the launch configurations are brought up-to-date.
            /// Folder specific variables used in the configuration (e.g. '${workspaceFolder}') are resolved against the given folder.</summary>
            /// <param name="folder">The {@link WorkspaceFolder workspace folder} for looking up named configurations and resolving variables or `undefined` for a non-folder setup.</param>
            /// <param name="nameOrConfiguration">Either the name of a debug or compound configuration or a {@link DebugConfiguration} object.</param>
            /// <param name="parentSessionOrOptions">Debug session options. When passed a parent {@link DebugSession debug session}, assumes options with just this parent session.</param>
            abstract startDebugging: folder: WorkspaceFolder option * nameOrConfiguration: U2<string, DebugConfiguration> * ?parentSessionOrOptions: U2<DebugSession, DebugSessionOptions> -> Thenable<bool>
            /// <summary>Stop the given debug session or stop all debug sessions if session is omitted.</summary>
            /// <param name="session">The {@link DebugSession debug session} to stop; if omitted all sessions are stopped.</param>
            abstract stopDebugging: ?session: DebugSession -> Thenable<unit>
            /// <summary>Add breakpoints.</summary>
            /// <param name="breakpoints">The breakpoints to add.</param>
            abstract addBreakpoints: breakpoints: ResizeArray<Breakpoint> -> unit
            /// <summary>Remove breakpoints.</summary>
            /// <param name="breakpoints">The breakpoints to remove.</param>
            abstract removeBreakpoints: breakpoints: ResizeArray<Breakpoint> -> unit
            /// <summary>Converts a "Source" descriptor object received via the Debug Adapter Protocol into a Uri that can be used to load its contents.
            /// If the source descriptor is based on a path, a file Uri is returned.
            /// If the source descriptor uses a reference number, a specific debug Uri (scheme 'debug') is constructed that requires a corresponding ContentProvider and a running debug session
            /// 
            /// If the "Source" descriptor has insufficient information for creating the Uri, an error is thrown.</summary>
            /// <param name="source">An object conforming to the [Source](https://microsoft.github.io/debug-adapter-protocol/specification#Types_Source) type defined in the Debug Adapter Protocol.</param>
            /// <param name="session">An optional debug session that will be used when the source descriptor uses a reference number to load the contents from an active debug session.</param>
            abstract asDebugSourceUri: source: DebugProtocolSource * ?session: DebugSession -> Uri

    module Extensions =

        type [<AllowNullLiteral>] IExports =
            /// <summary>Get an extension by its full identifier in the form of: `publisher.name`.</summary>
            /// <param name="extensionId">An extension identifier.</param>
            abstract getExtension: extensionId: string -> Extension<obj option> option
            /// <summary>Get an extension by its full identifier in the form of: `publisher.name`.</summary>
            /// <param name="extensionId">An extension identifier.</param>
            abstract getExtension: extensionId: string -> Extension<'T> option
            abstract all: ResizeArray<Extension<obj option>>
            abstract onDidChange: Event<unit>

    type [<RequireQualifiedAccess>] CommentThreadCollapsibleState =
        | Collapsed = 0
        | Expanded = 1

    type [<RequireQualifiedAccess>] CommentMode =
        | Editing = 0
        | Preview = 1

    /// A collection of {@link Comment comments} representing a conversation at a particular range in a document.
    type [<AllowNullLiteral>] CommentThread =
        /// The uri of the document the thread has been created on.
        abstract uri: Uri
        /// The range the comment thread is located within the document. The thread icon will be shown
        /// at the first line of the range.
        abstract range: Range with get, set
        /// The ordered comments of the thread.
        abstract comments: ResizeArray<Comment> with get, set
        /// Whether the thread should be collapsed or expanded when opening the document.
        /// Defaults to Collapsed.
        abstract collapsibleState: CommentThreadCollapsibleState with get, set
        /// Whether the thread supports reply.
        /// Defaults to true.
        abstract canReply: bool with get, set
        /// Context value of the comment thread. This can be used to contribute thread specific actions.
        /// For example, a comment thread is given a context value as `editable`. When contributing actions to `comments/commentThread/title`
        /// using `menus` extension point, you can specify context value for key `commentThread` in `when` expression like `commentThread == editable`.
        /// ```
        ///     "contributes": {
        ///         "menus": {
        ///             "comments/commentThread/title": [
        ///                 {
        ///                     "command": "extension.deleteCommentThread",
        ///                     "when": "commentThread == editable"
        ///                 }
        ///             ]
        ///         }
        ///     }
        /// ```
        /// This will show action `extension.deleteCommentThread` only for comment threads with `contextValue` is `editable`.
        abstract contextValue: string option with get, set
        /// The optional human-readable label describing the {@link CommentThread Comment Thread}
        abstract label: string option with get, set
        /// Dispose this comment thread.
        /// 
        /// Once disposed, this comment thread will be removed from visible editors and Comment Panel when appropriate.
        abstract dispose: unit -> unit

    /// Author information of a {@link Comment}
    type [<AllowNullLiteral>] CommentAuthorInformation =
        /// The display name of the author of the comment
        abstract name: string with get, set
        /// The optional icon path for the author
        abstract iconPath: Uri option with get, set

    /// Reactions of a {@link Comment}
    type [<AllowNullLiteral>] CommentReaction =
        /// The human-readable label for the reaction
        abstract label: string
        /// Icon for the reaction shown in UI.
        abstract iconPath: U2<string, Uri>
        /// The number of users who have reacted to this reaction
        abstract count: float
        /// Whether the [author](CommentAuthorInformation) of the comment has reacted to this reaction
        abstract authorHasReacted: bool

    /// A comment is displayed within the editor or the Comments Panel, depending on how it is provided.
    type [<AllowNullLiteral>] Comment =
        /// The human-readable comment body
        abstract body: U2<string, MarkdownString> with get, set
        /// {@link CommentMode Comment mode} of the comment
        abstract mode: CommentMode with get, set
        /// The {@link CommentAuthorInformation author information} of the comment
        abstract author: CommentAuthorInformation with get, set
        /// Context value of the comment. This can be used to contribute comment specific actions.
        /// For example, a comment is given a context value as `editable`. When contributing actions to `comments/comment/title`
        /// using `menus` extension point, you can specify context value for key `comment` in `when` expression like `comment == editable`.
        /// ```json
        ///     "contributes": {
        ///         "menus": {
        ///             "comments/comment/title": [
        ///                 {
        ///                     "command": "extension.deleteComment",
        ///                     "when": "comment == editable"
        ///                 }
        ///             ]
        ///         }
        ///     }
        /// ```
        /// This will show action `extension.deleteComment` only for comments with `contextValue` is `editable`.
        abstract contextValue: string option with get, set
        /// Optional reactions of the {@link Comment}
        abstract reactions: ResizeArray<CommentReaction> option with get, set
        /// Optional label describing the {@link Comment}
        /// Label will be rendered next to authorName if exists.
        abstract label: string option with get, set

    /// Command argument for actions registered in `comments/commentThread/context`.
    type [<AllowNullLiteral>] CommentReply =
        /// The active {@link CommentThread comment thread}
        abstract thread: CommentThread with get, set
        /// The value in the comment editor
        abstract text: string with get, set

    /// Commenting range provider for a {@link CommentController comment controller}.
    type [<AllowNullLiteral>] CommentingRangeProvider =
        /// Provide a list of ranges which allow new comment threads creation or null for a given document
        abstract provideCommentingRanges: document: TextDocument * token: CancellationToken -> ProviderResult<ResizeArray<Range>>

    /// Represents a {@link CommentController comment controller}'s {@link CommentController.options options}.
    type [<AllowNullLiteral>] CommentOptions =
        /// An optional string to show on the comment input box when it's collapsed.
        abstract prompt: string option with get, set
        /// An optional string to show as placeholder in the comment input box when it's focused.
        abstract placeHolder: string option with get, set

    /// A comment controller is able to provide {@link CommentThread comments} support to the editor and
    /// provide users various ways to interact with comments.
    type [<AllowNullLiteral>] CommentController =
        /// The id of this comment controller.
        abstract id: string
        /// The human-readable label of this comment controller.
        abstract label: string
        /// Comment controller options
        abstract options: CommentOptions option with get, set
        /// Optional commenting range provider. Provide a list {@link Range ranges} which support commenting to any given resource uri.
        /// 
        /// If not provided, users can leave comments in any document opened in the editor.
        abstract commentingRangeProvider: CommentingRangeProvider option with get, set
        /// <summary>Create a {@link CommentThread comment thread}. The comment thread will be displayed in visible text editors (if the resource matches)
        /// and Comments Panel once created.</summary>
        /// <param name="uri">The uri of the document the thread has been created on.</param>
        /// <param name="range">The range the comment thread is located within the document.</param>
        /// <param name="comments">The ordered comments of the thread.</param>
        abstract createCommentThread: uri: Uri * range: Range * comments: ResizeArray<Comment> -> CommentThread
        /// Optional reaction handler for creating and deleting reactions on a {@link Comment}.
        abstract reactionHandler: (Comment -> CommentReaction -> Thenable<unit>) option with get, set
        /// Dispose this comment controller.
        /// 
        /// Once disposed, all {@link CommentThread comment threads} created by this comment controller will also be removed from the editor
        /// and Comments Panel.
        abstract dispose: unit -> unit

    module Comments =

        type [<AllowNullLiteral>] IExports =
            /// <summary>Creates a new {@link CommentController comment controller} instance.</summary>
            /// <param name="id">An `id` for the comment controller.</param>
            /// <param name="label">A human-readable string for the comment controller.</param>
            abstract createCommentController: id: string * label: string -> CommentController

    /// Represents a session of a currently logged in user.
    type [<AllowNullLiteral>] AuthenticationSession =
        /// The identifier of the authentication session.
        abstract id: string
        /// The access token.
        abstract accessToken: string
        /// The account associated with the session.
        abstract account: AuthenticationSessionAccountInformation
        /// The permissions granted by the session's access token. Available scopes
        /// are defined by the {@link AuthenticationProvider}.
        abstract scopes: ResizeArray<string>

    /// The information of an account associated with an {@link AuthenticationSession}.
    type [<AllowNullLiteral>] AuthenticationSessionAccountInformation =
        /// The unique identifier of the account.
        abstract id: string
        /// The human-readable name of the account.
        abstract label: string

    /// Options to be used when getting an {@link AuthenticationSession} from an {@link AuthenticationProvider}.
    type [<AllowNullLiteral>] AuthenticationGetSessionOptions =
        /// Whether login should be performed if there is no matching session.
        /// 
        /// If true, a modal dialog will be shown asking the user to sign in. If false, a numbered badge will be shown
        /// on the accounts activity bar icon. An entry for the extension will be added under the menu to sign in. This
        /// allows quietly prompting the user to sign in.
        /// 
        /// If there is a matching session but the extension has not been granted access to it, setting this to true
        /// will also result in an immediate modal dialog, and false will add a numbered badge to the accounts icon.
        /// 
        /// Defaults to false.
        abstract createIfNone: bool option with get, set
        /// Whether the existing user session preference should be cleared.
        /// 
        /// For authentication providers that support being signed into multiple accounts at once, the user will be
        /// prompted to select an account to use when {@link authentication.getSession getSession} is called. This preference
        /// is remembered until {@link authentication.getSession getSession} is called with this flag.
        /// 
        /// Defaults to false.
        abstract clearSessionPreference: bool option with get, set

    /// Basic information about an {@link AuthenticationProvider}
    type [<AllowNullLiteral>] AuthenticationProviderInformation =
        /// The unique identifier of the authentication provider.
        abstract id: string
        /// The human-readable name of the authentication provider.
        abstract label: string

    /// An {@link Event} which fires when an {@link AuthenticationSession} is added, removed, or changed.
    type [<AllowNullLiteral>] AuthenticationSessionsChangeEvent =
        /// The {@link AuthenticationProvider} that has had its sessions change.
        abstract provider: AuthenticationProviderInformation

    /// Options for creating an {@link AuthenticationProvider}.
    type [<AllowNullLiteral>] AuthenticationProviderOptions =
        /// Whether it is possible to be signed into multiple accounts at once with this provider.
        /// If not specified, will default to false.
        abstract supportsMultipleAccounts: bool option

    /// An {@link Event} which fires when an {@link AuthenticationSession} is added, removed, or changed.
    type [<AllowNullLiteral>] AuthenticationProviderAuthenticationSessionsChangeEvent =
        /// The {@link AuthenticationSession}s of the {@link AuthenticationProvider} that have been added.
        abstract added: ResizeArray<AuthenticationSession> option
        /// The {@link AuthenticationSession}s of the {@link AuthenticationProvider} that have been removed.
        abstract removed: ResizeArray<AuthenticationSession> option
        /// The {@link AuthenticationSession}s of the {@link AuthenticationProvider} that have been changed.
        /// A session changes when its data excluding the id are updated. An example of this is a session refresh that results in a new
        /// access token being set for the session.
        abstract changed: ResizeArray<AuthenticationSession> option

    /// A provider for performing authentication to a service.
    type [<AllowNullLiteral>] AuthenticationProvider =
        /// An {@link Event} which fires when the array of sessions has changed, or data
        /// within a session has changed.
        abstract onDidChangeSessions: Event<AuthenticationProviderAuthenticationSessionsChangeEvent>
        /// <summary>Get a list of sessions.</summary>
        /// <param name="scopes">An optional list of scopes. If provided, the sessions returned should match
        /// these permissions, otherwise all sessions should be returned.</param>
        abstract getSessions: ?scopes: ResizeArray<string> -> Thenable<ResizeArray<AuthenticationSession>>
        /// <summary>Prompts a user to login.
        /// 
        /// If login is successful, the onDidChangeSessions event should be fired.
        /// 
        /// If login fails, a rejected promise should be returned.
        /// 
        /// If the provider has specified that it does not support multiple accounts,
        /// then this should never be called if there is already an existing session matching these
        /// scopes.</summary>
        /// <param name="scopes">A list of scopes, permissions, that the new session should be created with.</param>
        abstract createSession: scopes: ResizeArray<string> -> Thenable<AuthenticationSession>
        /// <summary>Removes the session corresponding to session id.
        /// 
        /// If the removal is successful, the onDidChangeSessions event should be fired.
        /// 
        /// If a session cannot be removed, the provider should reject with an error message.</summary>
        /// <param name="sessionId">The id of the session to remove.</param>
        abstract removeSession: sessionId: string -> Thenable<unit>

    module Authentication =

        type [<AllowNullLiteral>] IExports =
            /// <summary>Get an authentication session matching the desired scopes. Rejects if a provider with providerId is not
            /// registered, or if the user does not consent to sharing authentication information with
            /// the extension. If there are multiple sessions with the same scopes, the user will be shown a
            /// quickpick to select which account they would like to use.
            /// 
            /// Currently, there are only two authentication providers that are contributed from built in extensions
            /// to the editor that implement GitHub and Microsoft authentication: their providerId's are 'github' and 'microsoft'.</summary>
            /// <param name="providerId">The id of the provider to use</param>
            /// <param name="scopes">A list of scopes representing the permissions requested. These are dependent on the authentication provider</param>
            /// <param name="options">The {@link GetSessionOptions} to use</param>
            abstract getSession: providerId: string * scopes: ResizeArray<string> * options: obj -> Thenable<AuthenticationSession>
            /// <summary>Get an authentication session matching the desired scopes. Rejects if a provider with providerId is not
            /// registered, or if the user does not consent to sharing authentication information with
            /// the extension. If there are multiple sessions with the same scopes, the user will be shown a
            /// quickpick to select which account they would like to use.
            /// 
            /// Currently, there are only two authentication providers that are contributed from built in extensions
            /// to the editor that implement GitHub and Microsoft authentication: their providerId's are 'github' and 'microsoft'.</summary>
            /// <param name="providerId">The id of the provider to use</param>
            /// <param name="scopes">A list of scopes representing the permissions requested. These are dependent on the authentication provider</param>
            /// <param name="options">The {@link GetSessionOptions} to use</param>
            abstract getSession: providerId: string * scopes: ResizeArray<string> * ?options: AuthenticationGetSessionOptions -> Thenable<AuthenticationSession option>
            abstract onDidChangeSessions: Event<AuthenticationSessionsChangeEvent>
            /// <summary>Register an authentication provider.
            /// 
            /// There can only be one provider per id and an error is being thrown when an id
            /// has already been used by another provider. Ids are case-sensitive.</summary>
            /// <param name="id">The unique identifier of the provider.</param>
            /// <param name="label">The human-readable name of the provider.</param>
            /// <param name="provider">The authentication provider provider.</param>
            /// <param name="options"></param>
            abstract registerAuthenticationProvider: id: string * label: string * provider: AuthenticationProvider * ?options: AuthenticationProviderOptions -> Disposable

    type [<AllowNullLiteral>] DisposableStaticFrom =
        abstract dispose: (unit -> obj option) with get, set

    type [<AllowNullLiteral>] OpenDialogOptionsFilters =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: name: string -> ResizeArray<string> with get, set

    type [<AllowNullLiteral>] CodeActionDisabled =
        /// Human readable description of why the code action is currently disabled.
        /// 
        /// This is displayed in the code actions UI.
        abstract reason: string

    type [<AllowNullLiteral>] CodeActionProviderMetadataDocumentationReadonlyArray =
        /// The kind of the code action being documented.
        /// 
        /// If the kind is generic, such as `CodeActionKind.Refactor`, the documentation will be shown whenever any
        /// refactorings are returned. If the kind if more specific, such as `CodeActionKind.RefactorExtract`, the
        /// documentation will only be shown when extract refactoring code actions are returned.
        abstract kind: CodeActionKind
        /// Command that displays the documentation to the user.
        /// 
        /// This can display the documentation directly in the editor or open a website using {@link env.openExternal `env.openExternal`};
        /// 
        /// The title of this documentation code action is taken from {@link Command.title `Command.title`}
        abstract command: Command

    type [<AllowNullLiteral>] WorkspaceEditEntryMetadataIconPath =
        abstract light: Uri with get, set
        abstract dark: Uri with get, set

    type [<AllowNullLiteral>] RenameProviderPrepareRenameProviderResult =
        abstract range: Range with get, set
        abstract placeholder: string with get, set

    type [<AllowNullLiteral>] CompletionItemRange =
        abstract inserting: Range with get, set
        abstract replacing: Range with get, set

    type [<AllowNullLiteral>] LanguageConfiguration__electricCharacterSupportDocComment =
        abstract scope: string with get, set
        abstract ``open``: string with get, set
        abstract lineStart: string with get, set
        abstract close: string option with get, set

    type [<AllowNullLiteral>] LanguageConfiguration__electricCharacterSupport =
        /// This property is deprecated and will be **ignored** from
        /// the editor.
        abstract brackets: obj option with get, set
        /// This property is deprecated and not fully supported anymore by
        /// the editor (scope and lineStart are ignored).
        /// Use the autoClosingPairs property in the language configuration file instead.
        abstract docComment: LanguageConfiguration__electricCharacterSupportDocComment option with get, set

    type [<AllowNullLiteral>] LanguageConfiguration__characterPairSupportAutoClosingPairs =
        abstract ``open``: string with get, set
        abstract close: string with get, set
        abstract notIn: ResizeArray<string> option with get, set

    type [<AllowNullLiteral>] LanguageConfiguration__characterPairSupport =
        abstract autoClosingPairs: ResizeArray<LanguageConfiguration__characterPairSupportAutoClosingPairs> with get, set

    type [<AllowNullLiteral>] WorkspaceConfigurationInspect<'T> =
        abstract key: string with get, set
        abstract defaultValue: 'T option with get, set
        abstract globalValue: 'T option with get, set
        abstract workspaceValue: 'T option with get, set
        abstract workspaceFolderValue: 'T option with get, set
        abstract defaultLanguageValue: 'T option with get, set
        abstract globalLanguageValue: 'T option with get, set
        abstract workspaceLanguageValue: 'T option with get, set
        abstract workspaceFolderLanguageValue: 'T option with get, set
        abstract languageIds: ResizeArray<string> option with get, set

    type [<AllowNullLiteral>] DiagnosticCode =
        /// A code or identifier for this diagnostic.
        /// Should be used for later processing, e.g. when providing {@link CodeActionContext code actions}.
        abstract value: U2<string, float> with get, set
        /// A target URI to open with more information about the diagnostic error.
        abstract target: Uri with get, set

    type [<AllowNullLiteral>] ExtensionContextSubscriptions =
        abstract dispose: unit -> obj option

    type [<AllowNullLiteral>] ProcessExecutionOptionsEnv =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> string with get, set

    type [<AllowNullLiteral>] ShellQuotingOptionsEscape =
        /// The escape character.
        abstract escapeChar: string with get, set
        /// The characters to escape.
        abstract charsToEscape: string with get, set

    type [<AllowNullLiteral>] TreeItemIconPath =
        abstract light: U2<string, Uri> with get, set
        abstract dark: U2<string, Uri> with get, set

    type [<AllowNullLiteral>] TerminalOptionsEnv =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> string option with get, set

    type [<AllowNullLiteral>] ProgressOptionsLocation =
        abstract viewId: string with get, set

    type [<AllowNullLiteral>] FileWillRenameEventFilesReadonlyArray =
        abstract oldUri: Uri
        abstract newUri: Uri

    type [<AllowNullLiteral>] NotebookCellMetadata =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] NotebookCellExecutionSummaryTiming =
        abstract startTime: float with get, set
        abstract endTime: float with get, set

    type [<AllowNullLiteral>] NotebookDocumentContentOptionsTransientCellMetadata =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> bool option with get, set

    type [<AllowNullLiteral>] NotebookControllerOnDidChangeSelectedNotebooksEvent =
        abstract notebook: NotebookDocument with get, set
        abstract selected: bool with get, set

/// Thenable is a common denominator between ES6 promises, Q, jquery.Deferred, WinJS.Promise,
/// and others. This API makes no assumption about what promise library is being used which
/// enables reusing existing code without migrating to a specific promise implementation. Still,
/// we recommend the use of native promises which are available in this editor.
type [<AllowNullLiteral>] Thenable<'T> =
    /// <summary>Attaches callbacks for the resolution and/or rejection of the Promise.</summary>
    /// <param name="onfulfilled">The callback to execute when the Promise is resolved.</param>
    /// <param name="onrejected">The callback to execute when the Promise is rejected.</param>
    abstract ``then``: ?onfulfilled: ('T -> U2<'TResult, Thenable<'TResult>>) * ?onrejected: (obj option -> U2<'TResult, Thenable<'TResult>>) -> Thenable<'TResult>
    abstract ``then``: ?onfulfilled: ('T -> U2<'TResult, Thenable<'TResult>>) * ?onrejected: (obj option -> unit) -> Thenable<'TResult>
