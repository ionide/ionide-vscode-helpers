// ts2fable 0.8.0-build.644
module rec Fable.Import.VSCode

//#nowarn "3390" // disable warnings for invalid XML comments
#nowarn "0044" // disable warnings for `Obsolete` usage

open System
open Fable.Core
open Fable.Core.JS

type Array<'T> = System.Collections.Generic.IList<'T>
type Error = System.Exception
type ReadonlyArray<'T> = System.Collections.Generic.IReadOnlyList<'T>
type RegExp = System.Text.RegularExpressions.Regex

/// <summary>
/// Type Definition for Visual Studio Code 1.66 Extension API
/// See <see href="https://code.visualstudio.com/api" /> for more information
/// </summary>
let [<ImportAll("vscode")>] vscode: Vscode.IExports = jsNative

/// <summary>
/// Type Definition for Visual Studio Code 1.66 Extension API
/// See <see href="https://code.visualstudio.com/api" /> for more information
/// </summary>
module Vscode =
    /// Namespace for tasks functionality.
    let [<Import("tasks","vscode")>] tasks: Tasks.IExports = jsNative
    /// Namespace describing the environment the editor runs in.
    let [<Import("env","vscode")>] env: Env.IExports = jsNative
    /// <summary>
    /// Namespace for dealing with commands. In short, a command is a function with a
    /// unique identifier. The function is sometimes also called _command handler_.
    ///
    /// Commands can be added to the editor using the <see cref="commands.registerCommand">registerCommand</see>
    /// and <see cref="commands.registerTextEditorCommand">registerTextEditorCommand</see> functions. Commands
    /// can be executed <see cref="commands.executeCommand">manually</see> or from a UI gesture. Those are:
    ///
    /// * palette - Use the <c>commands</c>-section in <c>package.json</c> to make a command show in
    /// the <see href="https://code.visualstudio.com/docs/getstarted/userinterface#_command-palette">command palette</see>.
    /// * keybinding - Use the <c>keybindings</c>-section in <c>package.json</c> to enable
    /// <see href="https://code.visualstudio.com/docs/getstarted/keybindings#_customizing-shortcuts">keybindings</see>
    /// for your extension.
    ///
    /// Commands from other extensions and from the editor itself are accessible to an extension. However,
    /// when invoking an editor command not all argument types are supported.
    ///
    /// This is a sample that registers a command handler and adds an entry for that command to the palette. First
    /// register a command handler with the identifier <c>extension.sayHello</c>.
    /// <code lang="javascript">
    /// commands.registerCommand('extension.sayHello', () =&gt; {
    ///      window.showInformationMessage('Hello World!');
    /// });
    /// </code>
    /// Second, bind the command identifier to a title under which it will show in the palette (<c>package.json</c>).
    /// <code lang="json">
    /// {
    ///      "contributes": {
    ///          "commands": [{
    ///              "command": "extension.sayHello",
    ///              "title": "Hello World"
    ///          }]
    ///      }
    /// }
    /// </code>
    /// </summary>
    let [<Import("commands","vscode")>] commands: Commands.IExports = jsNative
    /// Namespace for dealing with the current window of the editor. That is visible
    /// and active editors, as well as, UI elements to show messages, selections, and
    /// asking for user input.
    let [<Import("window","vscode")>] window: Window.IExports = jsNative
    /// <summary>
    /// Namespace for dealing with the current workspace. A workspace is the collection of one
    /// or more folders that are opened in an editor window (instance).
    ///
    /// It is also possible to open an editor without a workspace. For example, when you open a
    /// new editor window by selecting a file from your platform's File menu, you will not be
    /// inside a workspace. In this mode, some of the editor's capabilities are reduced but you can
    /// still open text files and edit them.
    ///
    /// Refer to <see href="https://code.visualstudio.com/docs/editor/workspaces" /> for more information on
    /// the concept of workspaces.
    ///
    /// The workspace offers support for <see cref="workspace.createFileSystemWatcher">listening</see> to fs
    /// events and for <see cref="workspace.findFiles">finding</see> files. Both perform well and run _outside_
    /// the editor-process so that they should be always used instead of nodejs-equivalents.
    /// </summary>
    let [<Import("workspace","vscode")>] workspace: Workspace.IExports = jsNative
    /// <summary>
    /// Namespace for participating in language-specific editor <see href="https://code.visualstudio.com/docs/editor/editingevolved">features</see>,
    /// like IntelliSense, code actions, diagnostics etc.
    ///
    /// Many programming languages exist and there is huge variety in syntaxes, semantics, and paradigms. Despite that, features
    /// like automatic word-completion, code navigation, or code checking have become popular across different tools for different
    /// programming languages.
    ///
    /// The editor provides an API that makes it simple to provide such common features by having all UI and actions already in place and
    /// by allowing you to participate by providing data only. For instance, to contribute a hover all you have to do is provide a function
    /// that can be called with a <see cref="TextDocument" /> and a <see cref="Position" /> returning hover info. The rest, like tracking the
    /// mouse, positioning the hover, keeping the hover stable etc. is taken care of by the editor.
    ///
    /// <code lang="javascript">
    /// languages.registerHoverProvider('javascript', {
    ///      provideHover(document, position, token) {
    ///          return new Hover('I am a hover!');
    ///      }
    /// });
    /// </code>
    ///
    /// Registration is done using a <see cref="DocumentSelector">document selector</see> which is either a language id, like <c>javascript</c> or
    /// a more complex <see cref="DocumentFilter">filter</see> like <c>{ language: 'typescript', scheme: 'file' }</c>. Matching a document against such
    /// a selector will result in a <see cref="languages.match">score</see> that is used to determine if and how a provider shall be used. When
    /// scores are equal the provider that came last wins. For features that allow full arity, like <see cref="languages.registerHoverProvider">hover</see>,
    /// the score is only checked to be <c>&gt;0</c>, for other features, like <see cref="languages.registerCompletionItemProvider">IntelliSense</see> the
    /// score is used for determining the order in which providers are asked to participate.
    /// </summary>
    let [<Import("languages","vscode")>] languages: Languages.IExports = jsNative
    /// <summary>
    /// Namespace for notebooks.
    ///
    /// The notebooks functionality is composed of three loosely coupled components:
    ///
    /// 1. <see cref="NotebookSerializer" /> enable the editor to open, show, and save notebooks
    /// 2. <see cref="NotebookController" /> own the execution of notebooks, e.g they create output from code cells.
    /// 3. NotebookRenderer present notebook output in the editor. They run in a separate context.
    /// </summary>
    let [<Import("notebooks","vscode")>] notebooks: Notebooks.IExports = jsNative
    let [<Import("scm","vscode")>] scm: Scm.IExports = jsNative
    /// Namespace for debug functionality.
    let [<Import("debug","vscode")>] debug: Debug.IExports = jsNative
    /// <summary>
    /// Namespace for dealing with installed extensions. Extensions are represented
    /// by an <see cref="Extension" />-interface which enables reflection on them.
    ///
    /// Extension writers can provide APIs to other extensions by returning their API public
    /// surface from the <c>activate</c>-call.
    ///
    /// <code lang="javascript">
    /// export function activate(context: vscode.ExtensionContext) {
    ///      let api = {
    ///          sum(a, b) {
    ///              return a + b;
    ///          },
    ///          mul(a, b) {
    ///              return a * b;
    ///          }
    ///      };
    ///      // 'export' public api-surface
    ///      return api;
    /// }
    /// </code>
    /// When depending on the API of another extension add an <c>extensionDependencies</c>-entry
    /// to <c>package.json</c>, and use the <see cref="extensions.getExtension">getExtension</see>-function
    /// and the <see cref="Extension.exports">exports</see>-property, like below:
    ///
    /// <code lang="javascript">
    /// let mathExt = extensions.getExtension('genius.math');
    /// let importedApi = mathExt.exports;
    ///
    /// console.log(importedApi.mul(42, 1));
    /// </code>
    /// </summary>
    let [<Import("extensions","vscode")>] extensions: Extensions.IExports = jsNative
    let [<Import("comments","vscode")>] comments: Comments.IExports = jsNative
    /// Namespace for authentication.
    let [<Import("authentication","vscode")>] authentication: Authentication.IExports = jsNative
    /// <summary>
    /// Namespace for testing functionality. Tests are published by registering
    /// <see cref="TestController" /> instances, then adding <see cref="TestItem">TestItems</see>.
    /// Controllers may also describe how to run tests by creating one or more
    /// <see cref="TestRunProfile" /> instances.
    /// </summary>
    let [<Import("tests","vscode")>] tests: Tests.IExports = jsNative

    type [<AllowNullLiteral>] IExports =
        /// The version of the editor.
        abstract version: string
        /// <summary>
        /// Represents a line and character position, such as
        /// the position of the cursor.
        ///
        /// Position objects are __immutable__. Use the <see cref="Position.with">with</see> or
        /// <see cref="Position.translate">translate</see> methods to derive new positions
        /// from an existing position.
        /// </summary>
        abstract Position: PositionStatic
        /// <summary>
        /// A range represents an ordered pair of two positions.
        /// It is guaranteed that <see cref="Range.start">start</see>.isBeforeOrEqual(<see cref="Range.end">end</see>)
        ///
        /// Range objects are __immutable__. Use the <see cref="Range.with">with</see>,
        /// <see cref="Range.intersection">intersection</see>, or <see cref="Range.union">union</see> methods
        /// to derive new ranges from an existing range.
        /// </summary>
        abstract Range: RangeStatic
        /// Represents a text selection in an editor.
        abstract Selection: SelectionStatic
        /// <summary>
        /// A reference to one of the workbench colors as defined in <see href="https://code.visualstudio.com/docs/getstarted/theme-color-reference." />
        /// Using a theme color is preferred over a custom color as it gives theme authors and users the possibility to change the color.
        /// </summary>
        abstract ThemeColor: ThemeColorStatic
        /// <summary>
        /// A reference to a named icon. Currently, <see cref="ThemeIcon.File">File</see>, <see cref="ThemeIcon.Folder">Folder</see>,
        /// and <see href="https://code.visualstudio.com/api/references/icons-in-labels#icon-listing">ThemeIcon ids</see> are supported.
        /// Using a theme icon is preferred over a custom icon as it gives product theme authors the possibility to change the icons.
        ///
        /// *Note* that theme icons can also be rendered inside labels and descriptions. Places that support theme icons spell this out
        /// and they use the <c>$(&lt;name&gt;)</c>-syntax, for instance <c>quickPick.label = "Hello World $(globe)"</c>.
        /// </summary>
        abstract ThemeIcon: ThemeIconStatic
        /// A universal resource identifier representing either a file on disk
        /// or another resource, like untitled resources.
        abstract Uri: UriStatic
        /// <summary>A cancellation source creates and controls a <see cref="CancellationToken">cancellation token</see>.</summary>
        abstract CancellationTokenSource: CancellationTokenSourceStatic
        /// <summary>
        /// An error type that should be used to signal cancellation of an operation.
        ///
        /// This type can be used in response to a <see cref="CancellationToken">cancellation token</see>
        /// being cancelled or when an operation is being cancelled by the
        /// executor of that operation.
        /// </summary>
        abstract CancellationError: CancellationErrorStatic
        /// Represents a type which can release resources, such
        /// as event listening or a timer.
        abstract Disposable: DisposableStatic
        /// <summary>
        /// An event emitter can be used to create and manage an <see cref="Event" /> for others
        /// to subscribe to. One emitter always owns one event.
        ///
        /// Use this class if you want to provide event from within your extension, for instance
        /// inside a <see cref="TextDocumentContentProvider" /> or when providing
        /// API to other extensions.
        /// </summary>
        abstract EventEmitter: EventEmitterStatic
        /// <summary>
        /// A relative pattern is a helper to construct glob patterns that are matched
        /// relatively to a base file path. The base path can either be an absolute file
        /// path as string or uri or a <see cref="WorkspaceFolder">workspace folder</see>, which is the
        /// preferred way of creating the relative pattern.
        /// </summary>
        abstract RelativePattern: RelativePatternStatic
        /// <summary>
        /// Kind of a code action.
        ///
        /// Kinds are a hierarchical list of identifiers separated by <c>.</c>, e.g. <c>"refactor.extract.function"</c>.
        ///
        /// Code action kinds are used by the editor for UI elements such as the refactoring context menu. Users
        /// can also trigger code actions with a specific kind with the <c>editor.action.codeAction</c> command.
        /// </summary>
        abstract CodeActionKind: CodeActionKindStatic
        /// <summary>
        /// A code action represents a change that can be performed in code, e.g. to fix a problem or
        /// to refactor code.
        ///
        /// A CodeAction must set either {@linkcode CodeAction.edit edit} and/or a {@linkcode CodeAction.command command}. If both are supplied, the <c>edit</c> is applied first, then the command is executed.
        /// </summary>
        abstract CodeAction: CodeActionStatic
        /// <summary>
        /// A code lens represents a <see cref="Command" /> that should be shown along with
        /// source text, like the number of references, a way to run tests, etc.
        ///
        /// A code lens is _unresolved_ when no command is associated to it. For performance
        /// reasons the creation of a code lens and resolving should be done to two stages.
        /// </summary>
        /// <seealso cref="CodeLensProvider.provideCodeLenses" />
        /// <seealso cref="CodeLensProvider.resolveCodeLens" />
        abstract CodeLens: CodeLensStatic
        /// <summary>
        /// Human-readable text that supports formatting via the <see href="https://commonmark.org">markdown syntax</see>.
        ///
        /// Rendering of <see cref="ThemeIcon">theme icons</see> via the <c>$(&lt;name&gt;)</c>-syntax is supported
        /// when the {@linkcode supportThemeIcons} is set to <c>true</c>.
        ///
        /// Rendering of embedded html is supported when {@linkcode supportHtml} is set to <c>true</c>.
        /// </summary>
        abstract MarkdownString: MarkdownStringStatic
        /// A hover represents additional information for a symbol or word. Hovers are
        /// rendered in a tooltip-like widget.
        abstract Hover: HoverStatic
        /// An EvaluatableExpression represents an expression in a document that can be evaluated by an active debugger or runtime.
        /// The result of this evaluation is shown in a tooltip-like widget.
        /// If only a range is specified, the expression will be extracted from the underlying document.
        /// An optional expression can be used to override the extracted expression.
        /// In this case the range is still used to highlight the range in the document.
        abstract EvaluatableExpression: EvaluatableExpressionStatic
        /// Provide inline value as text.
        abstract InlineValueText: InlineValueTextStatic
        /// Provide inline value through a variable lookup.
        /// If only a range is specified, the variable name will be extracted from the underlying document.
        /// An optional variable name can be used to override the extracted name.
        abstract InlineValueVariableLookup: InlineValueVariableLookupStatic
        /// Provide an inline value through an expression evaluation.
        /// If only a range is specified, the expression will be extracted from the underlying document.
        /// An optional expression can be used to override the extracted expression.
        abstract InlineValueEvaluatableExpression: InlineValueEvaluatableExpressionStatic
        /// A document highlight is a range inside a text document which deserves
        /// special attention. Usually a document highlight is visualized by changing
        /// the background color of its range.
        abstract DocumentHighlight: DocumentHighlightStatic
        /// Represents information about programming constructs like variables, classes,
        /// interfaces etc.
        abstract SymbolInformation: SymbolInformationStatic
        /// Represents programming constructs like variables, classes, interfaces etc. that appear in a document. Document
        /// symbols can be hierarchical and they have two ranges: one that encloses its definition and one that points to
        /// its most interesting range, e.g. the range of an identifier.
        abstract DocumentSymbol: DocumentSymbolStatic
        /// A text edit represents edits that should be applied
        /// to a document.
        abstract TextEdit: TextEditStatic
        /// <summary>
        /// A workspace edit is a collection of textual and files changes for
        /// multiple resources and documents.
        ///
        /// Use the <see cref="workspace.applyEdit">applyEdit</see>-function to apply a workspace edit.
        /// </summary>
        abstract WorkspaceEdit: WorkspaceEditStatic
        /// <summary>
        /// A snippet string is a template which allows to insert text
        /// and to control the editor cursor when insertion happens.
        ///
        /// A snippet can define tab stops and placeholders with <c>$1</c>, <c>$2</c>
        /// and <c>${3:foo}</c>. <c>$0</c> defines the final tab stop, it defaults to
        /// the end of the snippet. Variables are defined with <c>$name</c> and
        /// <c>${name:default value}</c>. Also see
        /// <see href="https://code.visualstudio.com/docs/editor/userdefinedsnippets#_creating-your-own-snippets">the full snippet syntax</see>.
        /// </summary>
        abstract SnippetString: SnippetStringStatic
        /// A semantic tokens legend contains the needed information to decipher
        /// the integer encoded representation of semantic tokens.
        abstract SemanticTokensLegend: SemanticTokensLegendStatic
        /// <summary>
        /// A semantic tokens builder can help with creating a <c>SemanticTokens</c> instance
        /// which contains delta encoded semantic tokens.
        /// </summary>
        abstract SemanticTokensBuilder: SemanticTokensBuilderStatic
        /// <summary>Represents semantic tokens, either in a range or in an entire document.</summary>
        /// <seealso cref="DocumentSemanticTokensProvider.provideDocumentSemanticTokens">provideDocumentSemanticTokens for an explanation of the format.</seealso>
        /// <seealso cref="SemanticTokensBuilder">for a helper to create an instance.</seealso>
        abstract SemanticTokens: SemanticTokensStatic
        /// <summary>Represents edits to semantic tokens.</summary>
        /// <seealso cref="DocumentSemanticTokensProvider.provideDocumentSemanticTokensEdits">provideDocumentSemanticTokensEdits for an explanation of the format.</seealso>
        abstract SemanticTokensEdits: SemanticTokensEditsStatic
        /// <summary>Represents an edit to semantic tokens.</summary>
        /// <seealso cref="DocumentSemanticTokensProvider.provideDocumentSemanticTokensEdits">provideDocumentSemanticTokensEdits for an explanation of the format.</seealso>
        abstract SemanticTokensEdit: SemanticTokensEditStatic
        /// Represents a parameter of a callable-signature. A parameter can
        /// have a label and a doc-comment.
        abstract ParameterInformation: ParameterInformationStatic
        /// Represents the signature of something callable. A signature
        /// can have a label, like a function-name, a doc-comment, and
        /// a set of parameters.
        abstract SignatureInformation: SignatureInformationStatic
        /// Signature help represents the signature of something
        /// callable. There can be multiple signatures but only one
        /// active and only one active parameter.
        abstract SignatureHelp: SignatureHelpStatic
        /// <summary>
        /// A completion item represents a text snippet that is proposed to complete text that is being typed.
        ///
        /// It is sufficient to create a completion item from just a <see cref="CompletionItem.label">label</see>. In that
        /// case the completion item will replace the <see cref="TextDocument.getWordRangeAtPosition">word</see>
        /// until the cursor with the given label or <see cref="CompletionItem.insertText">insertText</see>. Otherwise the
        /// given <see cref="CompletionItem.textEdit">edit</see> is used.
        ///
        /// When selecting a completion item in the editor its defined or synthesized text edit will be applied
        /// to *all* cursors/selections whereas <see cref="CompletionItem.additionalTextEdits">additionalTextEdits</see> will be
        /// applied as provided.
        /// </summary>
        /// <seealso cref="CompletionItemProvider.provideCompletionItems" />
        /// <seealso cref="CompletionItemProvider.resolveCompletionItem" />
        abstract CompletionItem: CompletionItemStatic
        /// <summary>
        /// Represents a collection of <see cref="CompletionItem">completion items</see> to be presented
        /// in the editor.
        /// </summary>
        abstract CompletionList: CompletionListStatic
        /// A document link is a range in a text document that links to an internal or external resource, like another
        /// text document or a web site.
        abstract DocumentLink: DocumentLinkStatic
        /// Represents a color in RGBA space.
        abstract Color: ColorStatic
        /// Represents a color range from a document.
        abstract ColorInformation: ColorInformationStatic
        /// <summary>
        /// A color presentation object describes how a {@linkcode Color} should be represented as text and what
        /// edits are required to refer to it from source code.
        ///
        /// For some languages one color can have multiple presentations, e.g. css can represent the color red with
        /// the constant <c>Red</c>, the hex-value <c>#ff0000</c>, or in rgba and hsla forms. In csharp other representations
        /// apply, e.g. <c>System.Drawing.Color.Red</c>.
        /// </summary>
        abstract ColorPresentation: ColorPresentationStatic
        /// An inlay hint label part allows for interactive and composite labels of inlay hints.
        abstract InlayHintLabelPart: InlayHintLabelPartStatic
        /// Inlay hint information.
        abstract InlayHint: InlayHintStatic
        /// A line based folding range. To be valid, start and end line must be bigger than zero and smaller than the number of lines in the document.
        /// Invalid ranges will be ignored.
        abstract FoldingRange: FoldingRangeStatic
        /// A selection range represents a part of a selection hierarchy. A selection range
        /// may have a parent selection range that contains it.
        abstract SelectionRange: SelectionRangeStatic
        /// Represents programming constructs like functions or constructors in the context
        /// of call hierarchy.
        abstract CallHierarchyItem: CallHierarchyItemStatic
        /// Represents an incoming call, e.g. a caller of a method or constructor.
        abstract CallHierarchyIncomingCall: CallHierarchyIncomingCallStatic
        /// Represents an outgoing call, e.g. calling a getter from a method or a method from a constructor etc.
        abstract CallHierarchyOutgoingCall: CallHierarchyOutgoingCallStatic
        /// Represents an item of a type hierarchy, like a class or an interface.
        abstract TypeHierarchyItem: TypeHierarchyItemStatic
        /// Represents a list of ranges that can be edited together along with a word pattern to describe valid range contents.
        abstract LinkedEditingRanges: LinkedEditingRangesStatic
        /// Represents a location inside a resource, such as a line
        /// inside a text file.
        abstract Location: LocationStatic
        /// Represents a related message and source code location for a diagnostic. This should be
        /// used to point to code locations that cause or related to a diagnostics, e.g. when duplicating
        /// a symbol in a scope.
        abstract DiagnosticRelatedInformation: DiagnosticRelatedInformationStatic
        /// Represents a diagnostic, such as a compiler error or warning. Diagnostic objects
        /// are only valid in the scope of a file.
        abstract Diagnostic: DiagnosticStatic
        /// A link on a terminal line.
        abstract TerminalLink: TerminalLinkStatic
        /// A terminal profile defines how a terminal will be launched.
        abstract TerminalProfile: TerminalProfileStatic
        /// A file decoration represents metadata that can be rendered with a file.
        abstract FileDecoration: FileDecorationStatic
        /// A grouping for tasks. The editor by default supports the
        /// 'Clean', 'Build', 'RebuildAll' and 'Test' group.
        abstract TaskGroup: TaskGroupStatic
        /// The execution of a task happens as an external process
        /// without shell interaction.
        abstract ProcessExecution: ProcessExecutionStatic
        abstract ShellExecution: ShellExecutionStatic
        /// Class used to execute an extension callback as a task.
        abstract CustomExecution: CustomExecutionStatic
        /// A task to execute
        abstract Task: TaskStatic
        /// <summary>
        /// A type that filesystem providers should use to signal errors.
        ///
        /// This class has factory methods for common error-cases, like <c>FileNotFound</c> when
        /// a file or folder doesn't exist, use them like so: <c>throw vscode.FileSystemError.FileNotFound(someUri);</c>
        /// </summary>
        abstract FileSystemError: FileSystemErrorStatic
        /// <summary>
        /// A class for encapsulating data transferred during a drag and drop event.
        ///
        /// You can use the <c>value</c> of the <c>DataTransferItem</c> to get back the object you put into it
        /// so long as the extension that created the <c>DataTransferItem</c> runs in the same extension host.
        /// </summary>
        abstract DataTransferItem: DataTransferItemStatic
        /// <summary>
        /// A map containing a mapping of the mime type of the corresponding transferred data.
        ///
        /// Drag and drop controllers that implement <see cref="TreeDragAndDropController.handleDrag"><c>handleDrag</c></see> can add additional mime types to the
        /// data transfer. These additional mime types will only be included in the <c>handleDrop</c> when the the drag was initiated from
        /// an element in the same drag and drop controller.
        /// </summary>
        abstract DataTransfer: DataTransferStatic
        abstract TreeItem: TreeItemStatic
        /// <summary>Predefined buttons for <see cref="QuickPick" /> and <see cref="InputBox" />.</summary>
        abstract QuickInputButtons: QuickInputButtonsStatic
        /// A notebook range represents an ordered pair of two cell indices.
        /// It is guaranteed that start is less than or equal to end.
        abstract NotebookRange: NotebookRangeStatic
        /// <summary>One representation of a <see cref="NotebookCellOutput">notebook output</see>, defined by MIME type and data.</summary>
        abstract NotebookCellOutputItem: NotebookCellOutputItemStatic
        /// <summary>
        /// Notebook cell output represents a result of executing a cell. It is a container type for multiple
        /// <see cref="NotebookCellOutputItem">output items</see> where contained items represent the same result but
        /// use different MIME types.
        /// </summary>
        abstract NotebookCellOutput: NotebookCellOutputStatic
        /// NotebookCellData is the raw representation of notebook cells. Its is part of {@linkcode NotebookData}.
        abstract NotebookCellData: NotebookCellDataStatic
        /// <summary>
        /// Raw representation of a notebook.
        ///
        /// Extensions are responsible for creating {@linkcode NotebookData} so that the editor
        /// can create a {@linkcode NotebookDocument}.
        /// </summary>
        /// <seealso cref="NotebookSerializer" />
        abstract NotebookData: NotebookDataStatic
        /// A contribution to a cell's status bar
        abstract NotebookCellStatusBarItem: NotebookCellStatusBarItemStatic
        /// Represents a debug adapter executable and optional arguments and runtime options passed to it.
        abstract DebugAdapterExecutable: DebugAdapterExecutableStatic
        /// Represents a debug adapter running as a socket based server.
        abstract DebugAdapterServer: DebugAdapterServerStatic
        /// Represents a debug adapter running as a Named Pipe (on Windows)/UNIX Domain Socket (on non-Windows) based server.
        abstract DebugAdapterNamedPipeServer: DebugAdapterNamedPipeServerStatic
        /// A debug adapter descriptor for an inline implementation.
        abstract DebugAdapterInlineImplementation: DebugAdapterInlineImplementationStatic
        /// The base class of all breakpoint types.
        abstract Breakpoint: BreakpointStatic
        /// A breakpoint specified by a source location.
        abstract SourceBreakpoint: SourceBreakpointStatic
        /// A breakpoint specified by a function name.
        abstract FunctionBreakpoint: FunctionBreakpointStatic
        /// <summary>
        /// Tags can be associated with <see cref="TestItem">TestItems</see> and
        /// <see cref="TestRunProfile">TestRunProfiles</see>. A profile with a tag can only
        /// execute tests that include that tag in their <see cref="TestItem.tags" /> array.
        /// </summary>
        abstract TestTag: TestTagStatic
        /// <summary>
        /// A TestRunRequest is a precursor to a <see cref="TestRun" />, which in turn is
        /// created by passing a request to <see cref="tests.runTests" />. The TestRunRequest
        /// contains information about which tests should be run, which should not be
        /// run, and how they are run (via the <see cref="TestRunRequest.profile">profile</see>).
        ///
        /// In general, TestRunRequests are created by the editor and pass to
        /// <see cref="TestRunProfile.runHandler" />, however you can also create test
        /// requests and runs outside of the <c>runHandler</c>.
        /// </summary>
        abstract TestRunRequest: TestRunRequestStatic
        /// Message associated with the test state. Can be linked to a specific
        /// source range -- useful for assertion failures, for example.
        abstract TestMessage: TestMessageStatic

    /// Represents a reference to a command. Provides a title which
    /// will be used to represent a command in the UI and, optionally,
    /// an array of arguments which will be passed to the command handler
    /// function when invoked.
    type [<AllowNullLiteral>] Command =
        /// <summary>Title of the command, like <c>save</c>.</summary>
        abstract title: string with get, set
        /// <summary>The identifier of the actual command handler.</summary>
        /// <seealso cref="commands.registerCommand" />
        abstract command: string with get, set
        /// A tooltip for the command, when represented in the UI.
        abstract tooltip: string option with get, set
        /// Arguments that the command handler should be
        /// invoked with.
        abstract arguments: ResizeArray<obj option> option with get, set

    /// <summary>
    /// Represents a line of text, such as a line of source code.
    ///
    /// TextLine objects are __immutable__. When a <see cref="TextDocument">document</see> changes,
    /// previously retrieved lines will not represent the latest state.
    /// </summary>
    type [<AllowNullLiteral>] TextLine =
        /// The zero-based line number.
        abstract lineNumber: float
        /// The text of this line without the line separator characters.
        abstract text: string
        /// The range this line covers without the line separator characters.
        abstract range: Range
        /// The range this line covers with the line separator characters.
        abstract rangeIncludingLineBreak: Range
        /// <summary>
        /// The offset of the first character which is not a whitespace character as defined
        /// by <c>/\s/</c>. **Note** that if a line is all whitespace the length of the line is returned.
        /// </summary>
        abstract firstNonWhitespaceCharacterIndex: float
        /// <summary>
        /// Whether this line is whitespace only, shorthand
        /// for <see cref="TextLine.firstNonWhitespaceCharacterIndex" /> === <see cref="TextLine.text">TextLine.text.length</see>.
        /// </summary>
        abstract isEmptyOrWhitespace: bool

    /// <summary>
    /// Represents a text document, such as a source file. Text documents have
    /// <see cref="TextLine">lines</see> and knowledge about an underlying resource like a file.
    /// </summary>
    type [<AllowNullLiteral>] TextDocument =
        /// <summary>
        /// The associated uri for this document.
        ///
        /// *Note* that most documents use the <c>file</c>-scheme, which means they are files on disk. However, **not** all documents are
        /// saved on disk and therefore the <c>scheme</c> must be checked before trying to access the underlying file or siblings on disk.
        /// </summary>
        /// <seealso cref="FileSystemProvider" />
        /// <seealso cref="TextDocumentContentProvider" />
        abstract uri: Uri
        /// <summary>
        /// The file system path of the associated resource. Shorthand
        /// notation for <see cref="TextDocument.uri">TextDocument.uri.fsPath</see>. Independent of the uri scheme.
        /// </summary>
        abstract fileName: string
        /// <summary>
        /// Is this document representing an untitled file which has never been saved yet. *Note* that
        /// this does not mean the document will be saved to disk, use {@linkcode Uri.scheme}
        /// to figure out where a document will be <see cref="FileSystemProvider">saved</see>, e.g. <c>file</c>, <c>ftp</c> etc.
        /// </summary>
        abstract isUntitled: bool
        /// The identifier of the language associated with this document.
        abstract languageId: string
        /// The version number of this document (it will strictly increase after each
        /// change, including undo/redo).
        abstract version: float
        /// <summary><c>true</c> if there are unpersisted changes.</summary>
        abstract isDirty: bool
        /// <summary>
        /// <c>true</c> if the document has been closed. A closed document isn't synchronized anymore
        /// and won't be re-used when the same resource is opened again.
        /// </summary>
        abstract isClosed: bool
        /// <summary>Save the underlying file.</summary>
        /// <returns>
        /// A promise that will resolve to <c>true</c> when the file
        /// has been saved. If the save failed, will return <c>false</c>.
        /// </returns>
        abstract save: unit -> Thenable<bool>
        /// <summary>
        /// The <see cref="EndOfLine">end of line</see> sequence that is predominately
        /// used in this document.
        /// </summary>
        abstract eol: EndOfLine
        /// The number of lines in this document.
        abstract lineCount: float
        /// <summary>
        /// Returns a text line denoted by the line number. Note
        /// that the returned object is *not* live and changes to the
        /// document are not reflected.
        /// </summary>
        /// <param name="line">A line number in [0, lineCount).</param>
        /// <returns>A <see cref="TextLine">line</see>.</returns>
        abstract lineAt: line: float -> TextLine
        /// <summary>
        /// Returns a text line denoted by the position. Note
        /// that the returned object is *not* live and changes to the
        /// document are not reflected.
        ///
        /// The position will be <see cref="TextDocument.validatePosition">adjusted</see>.
        /// </summary>
        /// <seealso cref="TextDocument.lineAt" />
        /// <param name="position">A position.</param>
        /// <returns>A <see cref="TextLine">line</see>.</returns>
        abstract lineAt: position: Position -> TextLine
        /// <summary>
        /// Converts the position to a zero-based offset.
        ///
        /// The position will be <see cref="TextDocument.validatePosition">adjusted</see>.
        /// </summary>
        /// <param name="position">A position.</param>
        /// <returns>A valid zero-based offset.</returns>
        abstract offsetAt: position: Position -> float
        /// <summary>Converts a zero-based offset to a position.</summary>
        /// <param name="offset">A zero-based offset.</param>
        /// <returns>A valid <see cref="Position" />.</returns>
        abstract positionAt: offset: float -> Position
        /// <summary>
        /// Get the text of this document. A substring can be retrieved by providing
        /// a range. The range will be <see cref="TextDocument.validateRange">adjusted</see>.
        /// </summary>
        /// <param name="range">Include only the text included by the range.</param>
        /// <returns>The text inside the provided range or the entire text.</returns>
        abstract getText: ?range: Range -> string
        /// <summary>
        /// Get a word-range at the given position. By default words are defined by
        /// common separators, like space, -, _, etc. In addition, per language custom
        /// [word definitions} can be defined. It
        /// is also possible to provide a custom regular expression.
        ///
        /// * *Note 1:* A custom regular expression must not match the empty string and
        /// if it does, it will be ignored.
        /// * *Note 2:* A custom regular expression will fail to match multiline strings
        /// and in the name of speed regular expressions should not match words with
        /// spaces. Use {@linkcode TextLine.text} for more complex, non-wordy, scenarios.
        ///
        /// The position will be <see cref="TextDocument.validatePosition">adjusted</see>.
        /// </summary>
        /// <param name="position">A position.</param>
        /// <param name="regex">Optional regular expression that describes what a word is.</param>
        /// <returns>A range spanning a word, or <c>undefined</c>.</returns>
        abstract getWordRangeAtPosition: position: Position * ?regex: RegExp -> Range option
        /// <summary>Ensure a range is completely contained in this document.</summary>
        /// <param name="range">A range.</param>
        /// <returns>The given range or a new, adjusted range.</returns>
        abstract validateRange: range: Range -> Range
        /// <summary>Ensure a position is contained in the range of this document.</summary>
        /// <param name="position">A position.</param>
        /// <returns>The given position or a new, adjusted position.</returns>
        abstract validatePosition: position: Position -> Position

    /// <summary>
    /// Represents a line and character position, such as
    /// the position of the cursor.
    ///
    /// Position objects are __immutable__. Use the <see cref="Position.with">with</see> or
    /// <see cref="Position.translate">translate</see> methods to derive new positions
    /// from an existing position.
    /// </summary>
    type [<AllowNullLiteral>] Position =
        /// The zero-based line value.
        abstract line: float
        /// The zero-based character value.
        abstract character: float
        /// <summary>Check if this position is before <c>other</c>.</summary>
        /// <param name="other">A position.</param>
        /// <returns>
        /// <c>true</c> if position is on a smaller line
        /// or on the same line on a smaller character.
        /// </returns>
        abstract isBefore: other: Position -> bool
        /// <summary>Check if this position is before or equal to <c>other</c>.</summary>
        /// <param name="other">A position.</param>
        /// <returns>
        /// <c>true</c> if position is on a smaller line
        /// or on the same line on a smaller or equal character.
        /// </returns>
        abstract isBeforeOrEqual: other: Position -> bool
        /// <summary>Check if this position is after <c>other</c>.</summary>
        /// <param name="other">A position.</param>
        /// <returns>
        /// <c>true</c> if position is on a greater line
        /// or on the same line on a greater character.
        /// </returns>
        abstract isAfter: other: Position -> bool
        /// <summary>Check if this position is after or equal to <c>other</c>.</summary>
        /// <param name="other">A position.</param>
        /// <returns>
        /// <c>true</c> if position is on a greater line
        /// or on the same line on a greater or equal character.
        /// </returns>
        abstract isAfterOrEqual: other: Position -> bool
        /// <summary>Check if this position is equal to <c>other</c>.</summary>
        /// <param name="other">A position.</param>
        /// <returns>
        /// <c>true</c> if the line and character of the given position are equal to
        /// the line and character of this position.
        /// </returns>
        abstract isEqual: other: Position -> bool
        /// <summary>Compare this to <c>other</c>.</summary>
        /// <param name="other">A position.</param>
        /// <returns>
        /// A number smaller than zero if this position is before the given position,
        /// a number greater than zero if this position is after the given position, or zero when
        /// this and the given position are equal.
        /// </returns>
        abstract compareTo: other: Position -> float
        /// <summary>Create a new position relative to this position.</summary>
        /// <param name="lineDelta">Delta value for the line value, default is <c>0</c>.</param>
        /// <param name="characterDelta">Delta value for the character value, default is <c>0</c>.</param>
        /// <returns>
        /// A position which line and character is the sum of the current line and
        /// character and the corresponding deltas.
        /// </returns>
        abstract translate: ?lineDelta: float * ?characterDelta: float -> Position
        /// <summary>Derived a new position relative to this position.</summary>
        /// <param name="change">An object that describes a delta to this position.</param>
        /// <returns>
        /// A position that reflects the given delta. Will return <c>this</c> position if the change
        /// is not changing anything.
        /// </returns>
        abstract translate: change: {| lineDelta: float option; characterDelta: float option |} -> Position
        /// <summary>Create a new position derived from this position.</summary>
        /// <param name="line">Value that should be used as line value, default is the <see cref="Position.line">existing value</see></param>
        /// <param name="character">Value that should be used as character value, default is the <see cref="Position.character">existing value</see></param>
        /// <returns>A position where line and character are replaced by the given values.</returns>
        abstract ``with``: ?line: float * ?character: float -> Position
        /// <summary>Derived a new position from this position.</summary>
        /// <param name="change">An object that describes a change to this position.</param>
        /// <returns>
        /// A position that reflects the given change. Will return <c>this</c> position if the change
        /// is not changing anything.
        /// </returns>
        abstract ``with``: change: {| line: float option; character: float option |} -> Position

    /// <summary>
    /// Represents a line and character position, such as
    /// the position of the cursor.
    ///
    /// Position objects are __immutable__. Use the <see cref="Position.with">with</see> or
    /// <see cref="Position.translate">translate</see> methods to derive new positions
    /// from an existing position.
    /// </summary>
    type [<AllowNullLiteral>] PositionStatic =
        /// <param name="line">A zero-based line value.</param>
        /// <param name="character">A zero-based character value.</param>
        [<EmitConstructor>] abstract Create: line: float * character: float -> Position

    /// <summary>
    /// A range represents an ordered pair of two positions.
    /// It is guaranteed that <see cref="Range.start">start</see>.isBeforeOrEqual(<see cref="Range.end">end</see>)
    ///
    /// Range objects are __immutable__. Use the <see cref="Range.with">with</see>,
    /// <see cref="Range.intersection">intersection</see>, or <see cref="Range.union">union</see> methods
    /// to derive new ranges from an existing range.
    /// </summary>
    type [<AllowNullLiteral>] Range =
        /// <summary>The start position. It is before or equal to <see cref="Range.end">end</see>.</summary>
        abstract start: Position
        /// <summary>The end position. It is after or equal to <see cref="Range.start">start</see>.</summary>
        abstract ``end``: Position
        /// <summary><c>true</c> if <c>start</c> and <c>end</c> are equal.</summary>
        abstract isEmpty: bool with get, set
        /// <summary><c>true</c> if <c>start.line</c> and <c>end.line</c> are equal.</summary>
        abstract isSingleLine: bool with get, set
        /// <summary>Check if a position or a range is contained in this range.</summary>
        /// <param name="positionOrRange">A position or a range.</param>
        /// <returns>
        /// <c>true</c> if the position or range is inside or equal
        /// to this range.
        /// </returns>
        abstract contains: positionOrRange: U2<Position, Range> -> bool
        /// <summary>Check if <c>other</c> equals this range.</summary>
        /// <param name="other">A range.</param>
        /// <returns>
        /// <c>true</c> when start and end are <see cref="Position.isEqual">equal</see> to
        /// start and end of this range.
        /// </returns>
        abstract isEqual: other: Range -> bool
        /// <summary>
        /// Intersect <c>range</c> with this range and returns a new range or <c>undefined</c>
        /// if the ranges have no overlap.
        /// </summary>
        /// <param name="range">A range.</param>
        /// <returns>
        /// A range of the greater start and smaller end positions. Will
        /// return undefined when there is no overlap.
        /// </returns>
        abstract intersection: range: Range -> Range option
        /// <summary>Compute the union of <c>other</c> with this range.</summary>
        /// <param name="other">A range.</param>
        /// <returns>A range of smaller start position and the greater end position.</returns>
        abstract union: other: Range -> Range
        /// <summary>Derived a new range from this range.</summary>
        /// <param name="start">A position that should be used as start. The default value is the <see cref="Range.start">current start</see>.</param>
        /// <param name="end">A position that should be used as end. The default value is the <see cref="Range.end">current end</see>.</param>
        /// <returns>
        /// A range derived from this range with the given start and end position.
        /// If start and end are not different <c>this</c> range will be returned.
        /// </returns>
        abstract ``with``: ?start: Position * ?``end``: Position -> Range
        /// <summary>Derived a new range from this range.</summary>
        /// <param name="change">An object that describes a change to this range.</param>
        /// <returns>
        /// A range that reflects the given change. Will return <c>this</c> range if the change
        /// is not changing anything.
        /// </returns>
        abstract ``with``: change: {| start: Position option; ``end``: Position option |} -> Range

    /// <summary>
    /// A range represents an ordered pair of two positions.
    /// It is guaranteed that <see cref="Range.start">start</see>.isBeforeOrEqual(<see cref="Range.end">end</see>)
    ///
    /// Range objects are __immutable__. Use the <see cref="Range.with">with</see>,
    /// <see cref="Range.intersection">intersection</see>, or <see cref="Range.union">union</see> methods
    /// to derive new ranges from an existing range.
    /// </summary>
    type [<AllowNullLiteral>] RangeStatic =
        /// <summary>
        /// Create a new range from two positions. If <c>start</c> is not
        /// before or equal to <c>end</c>, the values will be swapped.
        /// </summary>
        /// <param name="start">A position.</param>
        /// <param name="end">A position.</param>
        [<EmitConstructor>] abstract Create: start: Position * ``end``: Position -> Range
        /// <summary>
        /// Create a new range from number coordinates. It is a shorter equivalent of
        /// using <c>new Range(new Position(startLine, startCharacter), new Position(endLine, endCharacter))</c>
        /// </summary>
        /// <param name="startLine">A zero-based line value.</param>
        /// <param name="startCharacter">A zero-based character value.</param>
        /// <param name="endLine">A zero-based line value.</param>
        /// <param name="endCharacter">A zero-based character value.</param>
        [<EmitConstructor>] abstract Create: startLine: float * startCharacter: float * endLine: float * endCharacter: float -> Range

    /// Represents a text selection in an editor.
    type [<AllowNullLiteral>] Selection =
        inherit Range
        /// <summary>
        /// The position at which the selection starts.
        /// This position might be before or after <see cref="Selection.active">active</see>.
        /// </summary>
        abstract anchor: Position with get, set
        /// <summary>
        /// The position of the cursor.
        /// This position might be before or after <see cref="Selection.anchor">anchor</see>.
        /// </summary>
        abstract active: Position with get, set
        /// <summary>A selection is reversed if its <see cref="Selection.anchor">anchor</see> is the <see cref="Selection.end">end</see> position.</summary>
        abstract isReversed: bool with get, set

    /// Represents a text selection in an editor.
    type [<AllowNullLiteral>] SelectionStatic =
        /// <summary>Create a selection from two positions.</summary>
        /// <param name="anchor">A position.</param>
        /// <param name="active">A position.</param>
        [<EmitConstructor>] abstract Create: anchor: Position * active: Position -> Selection
        /// <summary>Create a selection from four coordinates.</summary>
        /// <param name="anchorLine">A zero-based line value.</param>
        /// <param name="anchorCharacter">A zero-based character value.</param>
        /// <param name="activeLine">A zero-based line value.</param>
        /// <param name="activeCharacter">A zero-based character value.</param>
        [<EmitConstructor>] abstract Create: anchorLine: float * anchorCharacter: float * activeLine: float * activeCharacter: float -> Selection

    /// <summary>Represents sources that can cause <see cref="window.onDidChangeTextEditorSelection">selection change events</see>.</summary>
    type [<RequireQualifiedAccess>] TextEditorSelectionChangeKind =
        /// Selection changed due to typing in the editor.
        | Keyboard = 1
        /// Selection change due to clicking in the editor.
        | Mouse = 2
        /// Selection changed because a command ran.
        | Command = 3

    /// <summary>Represents an event describing the change in a <see cref="TextEditor.selections">text editor's selections</see>.</summary>
    type [<AllowNullLiteral>] TextEditorSelectionChangeEvent =
        /// <summary>The <see cref="TextEditor">text editor</see> for which the selections have changed.</summary>
        abstract textEditor: TextEditor
        /// <summary>The new value for the <see cref="TextEditor.selections">text editor's selections</see>.</summary>
        abstract selections: ResizeArray<Selection>
        /// <summary>
        /// The <see cref="TextEditorSelectionChangeKind">change kind</see> which has triggered this
        /// event. Can be <c>undefined</c>.
        /// </summary>
        abstract kind: TextEditorSelectionChangeKind option

    /// <summary>Represents an event describing the change in a <see cref="TextEditor.visibleRanges">text editor's visible ranges</see>.</summary>
    type [<AllowNullLiteral>] TextEditorVisibleRangesChangeEvent =
        /// <summary>The <see cref="TextEditor">text editor</see> for which the visible ranges have changed.</summary>
        abstract textEditor: TextEditor
        /// <summary>The new value for the <see cref="TextEditor.visibleRanges">text editor's visible ranges</see>.</summary>
        abstract visibleRanges: ResizeArray<Range>

    /// <summary>Represents an event describing the change in a <see cref="TextEditor.options">text editor's options</see>.</summary>
    type [<AllowNullLiteral>] TextEditorOptionsChangeEvent =
        /// <summary>The <see cref="TextEditor">text editor</see> for which the options have changed.</summary>
        abstract textEditor: TextEditor
        /// <summary>The new value for the <see cref="TextEditor.options">text editor's options</see>.</summary>
        abstract options: TextEditorOptions

    /// <summary>Represents an event describing the change of a <see cref="TextEditor.viewColumn">text editor's view column</see>.</summary>
    type [<AllowNullLiteral>] TextEditorViewColumnChangeEvent =
        /// <summary>The <see cref="TextEditor">text editor</see> for which the view column has changed.</summary>
        abstract textEditor: TextEditor
        /// <summary>The new value for the <see cref="TextEditor.viewColumn">text editor's view column</see>.</summary>
        abstract viewColumn: ViewColumn

    /// Rendering style of the cursor.
    type [<RequireQualifiedAccess>] TextEditorCursorStyle =
        /// Render the cursor as a vertical thick line.
        | Line = 1
        /// Render the cursor as a block filled.
        | Block = 2
        /// Render the cursor as a thick horizontal line.
        | Underline = 3
        /// Render the cursor as a vertical thin line.
        | LineThin = 4
        /// Render the cursor as a block outlined.
        | BlockOutline = 5
        /// Render the cursor as a thin horizontal line.
        | UnderlineThin = 6

    /// Rendering style of the line numbers.
    type [<RequireQualifiedAccess>] TextEditorLineNumbersStyle =
        /// Do not render the line numbers.
        | Off = 0
        /// Render the line numbers.
        | On = 1
        /// Render the line numbers with values relative to the primary cursor location.
        | Relative = 2

    /// <summary>Represents a <see cref="TextEditor">text editor</see>'s <see cref="TextEditor.options">options</see>.</summary>
    type [<AllowNullLiteral>] TextEditorOptions =
        /// <summary>
        /// The size in spaces a tab takes. This is used for two purposes:
        ///   - the rendering width of a tab character;
        ///   - the number of spaces to insert when <see cref="TextEditorOptions.insertSpaces">insertSpaces</see> is true.
        ///
        /// When getting a text editor's options, this property will always be a number (resolved).
        /// When setting a text editor's options, this property is optional and it can be a number or <c>"auto"</c>.
        /// </summary>
        abstract tabSize: U2<float, string> option with get, set
        /// <summary>
        /// When pressing Tab insert <see cref="TextEditorOptions.tabSize">n</see> spaces.
        /// When getting a text editor's options, this property will always be a boolean (resolved).
        /// When setting a text editor's options, this property is optional and it can be a boolean or <c>"auto"</c>.
        /// </summary>
        abstract insertSpaces: U2<bool, string> option with get, set
        /// The rendering style of the cursor in this editor.
        /// When getting a text editor's options, this property will always be present.
        /// When setting a text editor's options, this property is optional.
        abstract cursorStyle: TextEditorCursorStyle option with get, set
        /// Render relative line numbers w.r.t. the current line number.
        /// When getting a text editor's options, this property will always be present.
        /// When setting a text editor's options, this property is optional.
        abstract lineNumbers: TextEditorLineNumbersStyle option with get, set

    /// <summary>
    /// Represents a handle to a set of decorations
    /// sharing the same <see cref="DecorationRenderOptions">styling options</see> in a <see cref="TextEditor">text editor</see>.
    ///
    /// To get an instance of a <c>TextEditorDecorationType</c> use
    /// <see cref="window.createTextEditorDecorationType">createTextEditorDecorationType</see>.
    /// </summary>
    type [<AllowNullLiteral>] TextEditorDecorationType =
        /// Internal representation of the handle.
        abstract key: string
        /// Remove this decoration type and all decorations on all text editors using it.
        abstract dispose: unit -> unit

    /// <summary>Represents different <see cref="TextEditor.revealRange">reveal</see> strategies in a text editor.</summary>
    type [<RequireQualifiedAccess>] TextEditorRevealType =
        /// The range will be revealed with as little scrolling as possible.
        | Default = 0
        /// The range will always be revealed in the center of the viewport.
        | InCenter = 1
        /// If the range is outside the viewport, it will be revealed in the center of the viewport.
        /// Otherwise, it will be revealed with as little scrolling as possible.
        | InCenterIfOutsideViewport = 2
        /// The range will always be revealed at the top of the viewport.
        | AtTop = 3

    /// <summary>
    /// Represents different positions for rendering a decoration in an <see cref="DecorationRenderOptions.overviewRulerLane">overview ruler</see>.
    /// The overview ruler supports three lanes.
    /// </summary>
    type [<RequireQualifiedAccess>] OverviewRulerLane =
        | Left = 1
        | Center = 2
        | Right = 4
        | Full = 7

    /// Describes the behavior of decorations when typing/editing at their edges.
    type [<RequireQualifiedAccess>] DecorationRangeBehavior =
        /// The decoration's range will widen when edits occur at the start or end.
        | OpenOpen = 0
        /// The decoration's range will not widen when edits occur at the start of end.
        | ClosedClosed = 1
        /// The decoration's range will widen when edits occur at the start, but not at the end.
        | OpenClosed = 2
        /// The decoration's range will widen when edits occur at the end, but not at the start.
        | ClosedOpen = 3

    /// <summary>Represents options to configure the behavior of showing a <see cref="TextDocument">document</see> in an <see cref="TextEditor">editor</see>.</summary>
    type [<AllowNullLiteral>] TextDocumentShowOptions =
        /// <summary>
        /// An optional view column in which the <see cref="TextEditor">editor</see> should be shown.
        /// The default is the <see cref="ViewColumn.Active">active</see>, other values are adjusted to
        /// be <c>Min(column, columnCount + 1)</c>, the <see cref="ViewColumn.Active">active</see>-column is
        /// not adjusted. Use {@linkcode ViewColumn.Beside} to open the
        /// editor to the side of the currently active one.
        /// </summary>
        abstract viewColumn: ViewColumn option with get, set
        /// <summary>An optional flag that when <c>true</c> will stop the <see cref="TextEditor">editor</see> from taking focus.</summary>
        abstract preserveFocus: bool option with get, set
        /// <summary>
        /// An optional flag that controls if an <see cref="TextEditor">editor</see>-tab shows as preview. Preview tabs will
        /// be replaced and reused until set to stay - either explicitly or through editing. The default behaviour depends
        /// on the <c>workbench.editor.enablePreview</c>-setting.
        /// </summary>
        abstract preview: bool option with get, set
        /// <summary>An optional selection to apply for the document in the <see cref="TextEditor">editor</see>.</summary>
        abstract selection: Range option with get, set

    /// <summary>
    /// A reference to one of the workbench colors as defined in <see href="https://code.visualstudio.com/docs/getstarted/theme-color-reference." />
    /// Using a theme color is preferred over a custom color as it gives theme authors and users the possibility to change the color.
    /// </summary>
    type [<AllowNullLiteral>] ThemeColor =
        interface end

    /// <summary>
    /// A reference to one of the workbench colors as defined in <see href="https://code.visualstudio.com/docs/getstarted/theme-color-reference." />
    /// Using a theme color is preferred over a custom color as it gives theme authors and users the possibility to change the color.
    /// </summary>
    type [<AllowNullLiteral>] ThemeColorStatic =
        /// <summary>Creates a reference to a theme color.</summary>
        /// <param name="id">of the color. The available colors are listed in <see href="https://code.visualstudio.com/docs/getstarted/theme-color-reference." /></param>
        [<EmitConstructor>] abstract Create: id: string -> ThemeColor

    /// <summary>
    /// A reference to a named icon. Currently, <see cref="ThemeIcon.File">File</see>, <see cref="ThemeIcon.Folder">Folder</see>,
    /// and <see href="https://code.visualstudio.com/api/references/icons-in-labels#icon-listing">ThemeIcon ids</see> are supported.
    /// Using a theme icon is preferred over a custom icon as it gives product theme authors the possibility to change the icons.
    ///
    /// *Note* that theme icons can also be rendered inside labels and descriptions. Places that support theme icons spell this out
    /// and they use the <c>$(&lt;name&gt;)</c>-syntax, for instance <c>quickPick.label = "Hello World $(globe)"</c>.
    /// </summary>
    type [<AllowNullLiteral>] ThemeIcon =
        /// <summary>The id of the icon. The available icons are listed in <see href="https://code.visualstudio.com/api/references/icons-in-labels#icon-listing." /></summary>
        abstract id: string
        /// <summary>The optional ThemeColor of the icon. The color is currently only used in <see cref="TreeItem" />.</summary>
        abstract color: ThemeColor option

    /// <summary>
    /// A reference to a named icon. Currently, <see cref="ThemeIcon.File">File</see>, <see cref="ThemeIcon.Folder">Folder</see>,
    /// and <see href="https://code.visualstudio.com/api/references/icons-in-labels#icon-listing">ThemeIcon ids</see> are supported.
    /// Using a theme icon is preferred over a custom icon as it gives product theme authors the possibility to change the icons.
    ///
    /// *Note* that theme icons can also be rendered inside labels and descriptions. Places that support theme icons spell this out
    /// and they use the <c>$(&lt;name&gt;)</c>-syntax, for instance <c>quickPick.label = "Hello World $(globe)"</c>.
    /// </summary>
    type [<AllowNullLiteral>] ThemeIconStatic =
        /// Reference to an icon representing a file. The icon is taken from the current file icon theme or a placeholder icon is used.
        abstract File: ThemeIcon
        /// Reference to an icon representing a folder. The icon is taken from the current file icon theme or a placeholder icon is used.
        abstract Folder: ThemeIcon
        /// <summary>Creates a reference to a theme icon.</summary>
        /// <param name="id">id of the icon. The available icons are listed in <see href="https://code.visualstudio.com/api/references/icons-in-labels#icon-listing." /></param>
        /// <param name="color">optional <c>ThemeColor</c> for the icon. The color is currently only used in <see cref="TreeItem" />.</param>
        [<EmitConstructor>] abstract Create: id: string * ?color: ThemeColor -> ThemeIcon

    /// <summary>Represents theme specific rendering styles for a <see cref="TextEditorDecorationType">text editor decoration</see>.</summary>
    type [<AllowNullLiteral>] ThemableDecorationRenderOptions =
        /// <summary>
        /// Background color of the decoration. Use rgba() and define transparent background colors to play well with other decorations.
        /// Alternatively a color from the color registry can be <see cref="ThemeColor">referenced</see>.
        /// </summary>
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
        /// <summary>
        /// Specifies the size of the gutter icon.
        /// Available values are 'auto', 'contain', 'cover' and any percentage value.
        /// For further information: <see href="https://msdn.microsoft.com/en-us/library/jj127316(v=vs.85).aspx" />
        /// </summary>
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

    /// <summary>Represents rendering styles for a <see cref="TextEditorDecorationType">text editor decoration</see>.</summary>
    type [<AllowNullLiteral>] DecorationRenderOptions =
        inherit ThemableDecorationRenderOptions
        /// <summary>
        /// Should the decoration be rendered also on the whitespace after the line text.
        /// Defaults to <c>false</c>.
        /// </summary>
        abstract isWholeLine: bool option with get, set
        /// <summary>
        /// Customize the growing behavior of the decoration when edits occur at the edges of the decoration's range.
        /// Defaults to <c>DecorationRangeBehavior.OpenOpen</c>.
        /// </summary>
        abstract rangeBehavior: DecorationRangeBehavior option with get, set
        /// The position in the overview ruler where the decoration should be rendered.
        abstract overviewRulerLane: OverviewRulerLane option with get, set
        /// Overwrite options for light themes.
        abstract light: ThemableDecorationRenderOptions option with get, set
        /// Overwrite options for dark themes.
        abstract dark: ThemableDecorationRenderOptions option with get, set

    /// <summary>Represents options for a specific decoration in a <see cref="TextEditorDecorationType">decoration set</see>.</summary>
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

    /// <summary>Represents an editor that is attached to a <see cref="TextDocument">document</see>.</summary>
    type [<AllowNullLiteral>] TextEditor =
        /// The document associated with this text editor. The document will be the same for the entire lifetime of this text editor.
        abstract document: TextDocument
        /// <summary>The primary selection on this text editor. Shorthand for <c>TextEditor.selections[0]</c>.</summary>
        abstract selection: Selection with get, set
        /// The selections in this text editor. The primary selection is always at index 0.
        abstract selections: ResizeArray<Selection> with get, set
        /// The current visible ranges in the editor (vertically).
        /// This accounts only for vertical scrolling, and not for horizontal scrolling.
        abstract visibleRanges: ResizeArray<Range>
        /// Text editor options.
        abstract options: TextEditorOptions with get, set
        /// <summary>
        /// The column in which this editor shows. Will be <c>undefined</c> in case this
        /// isn't one of the main editors, e.g. an embedded editor, or when the editor
        /// column is larger than three.
        /// </summary>
        abstract viewColumn: ViewColumn option
        /// <summary>
        /// Perform an edit on the document associated with this text editor.
        ///
        /// The given callback-function is invoked with an <see cref="TextEditorEdit">edit-builder</see> which must
        /// be used to make edits. Note that the edit-builder is only valid while the
        /// callback executes.
        /// </summary>
        /// <param name="callback">A function which can create edits using an <see cref="TextEditorEdit">edit-builder</see>.</param>
        /// <param name="options">The undo/redo behavior around this edit. By default, undo stops will be created before and after this edit.</param>
        /// <returns>A promise that resolves with a value indicating if the edits could be applied.</returns>
        abstract edit: callback: (TextEditorEdit -> unit) * ?options: {| undoStopBefore: bool; undoStopAfter: bool |} -> Thenable<bool>
        /// <summary>
        /// Insert a <see cref="SnippetString">snippet</see> and put the editor into snippet mode. "Snippet mode"
        /// means the editor adds placeholders and additional cursors so that the user can complete
        /// or accept the snippet.
        /// </summary>
        /// <param name="snippet">The snippet to insert in this edit.</param>
        /// <param name="location">Position or range at which to insert the snippet, defaults to the current editor selection or selections.</param>
        /// <param name="options">The undo/redo behavior around this edit. By default, undo stops will be created before and after this edit.</param>
        /// <returns>
        /// A promise that resolves with a value indicating if the snippet could be inserted. Note that the promise does not signal
        /// that the snippet is completely filled-in or accepted.
        /// </returns>
        abstract insertSnippet: snippet: SnippetString * ?location: U4<Position, Range, ResizeArray<Position>, ResizeArray<Range>> * ?options: {| undoStopBefore: bool; undoStopAfter: bool |} -> Thenable<bool>
        /// <summary>
        /// Adds a set of decorations to the text editor. If a set of decorations already exists with
        /// the given <see cref="TextEditorDecorationType">decoration type</see>, they will be replaced. If
        /// <c>rangesOrOptions</c> is empty, the existing decorations with the given <see cref="TextEditorDecorationType">decoration type</see>
        /// will be removed.
        /// </summary>
        /// <seealso cref="window.createTextEditorDecorationType">createTextEditorDecorationType .</seealso>
        /// <param name="decorationType">A decoration type.</param>
        /// <param name="rangesOrOptions">Either <see cref="Range">ranges</see> or more detailed <see cref="DecorationOptions">options</see>.</param>
        abstract setDecorations: decorationType: TextEditorDecorationType * rangesOrOptions: U2<ResizeArray<Range>, ResizeArray<DecorationOptions>> -> unit
        /// <summary>Scroll as indicated by <c>revealType</c> in order to reveal the given range.</summary>
        /// <param name="range">A range.</param>
        /// <param name="revealType">The scrolling strategy for revealing <c>range</c>.</param>
        abstract revealRange: range: Range * ?revealType: TextEditorRevealType -> unit
        /// <summary>Show the text editor.</summary>
        /// <param name="column">
        /// The <see cref="ViewColumn">column</see> in which to show this editor.
        /// This method shows unexpected behavior and will be removed in the next major update.
        /// </param>
        [<Obsolete("Use {@link window.showTextDocument} instead.")>]
        abstract show: ?column: ViewColumn -> unit
        /// Hide the text editor.
        [<Obsolete("Use the command `workbench.action.closeActiveEditor` instead.
This method shows unexpected behavior and will be removed in the next major update.")>]
        abstract hide: unit -> unit

    /// <summary>Represents an end of line character sequence in a <see cref="TextDocument">document</see>.</summary>
    type [<RequireQualifiedAccess>] EndOfLine =
        /// <summary>The line feed <c>\n</c> character.</summary>
        | LF = 1
        /// <summary>The carriage return line feed <c>\r\n</c> sequence.</summary>
        | CRLF = 2

    /// <summary>
    /// A complex edit that will be applied in one transaction on a TextEditor.
    /// This holds a description of the edits and if the edits are valid (i.e. no overlapping regions, document was not changed in the meantime, etc.)
    /// they can be applied on a <see cref="TextDocument">document</see> associated with a <see cref="TextEditor">text editor</see>.
    /// </summary>
    type [<AllowNullLiteral>] TextEditorEdit =
        /// <summary>
        /// Replace a certain text region with a new value.
        /// You can use \r\n or \n in <c>value</c> and they will be normalized to the current <see cref="TextDocument">document</see>.
        /// </summary>
        /// <param name="location">The range this operation should remove.</param>
        /// <param name="value">The new text this operation should insert after removing <c>location</c>.</param>
        abstract replace: location: U3<Position, Range, Selection> * value: string -> unit
        /// <summary>
        /// Insert text at a location.
        /// You can use \r\n or \n in <c>value</c> and they will be normalized to the current <see cref="TextDocument">document</see>.
        /// Although the equivalent text edit can be made with <see cref="TextEditorEdit.replace">replace</see>, <c>insert</c> will produce a different resulting selection (it will get moved).
        /// </summary>
        /// <param name="location">The position where the new text should be inserted.</param>
        /// <param name="value">The new text this operation should insert.</param>
        abstract insert: location: Position * value: string -> unit
        /// <summary>Delete a certain text region.</summary>
        /// <param name="location">The range this operation should remove.</param>
        abstract delete: location: U2<Range, Selection> -> unit
        /// <summary>Set the end of line sequence.</summary>
        /// <param name="endOfLine">The new end of line for the <see cref="TextDocument">document</see>.</param>
        abstract setEndOfLine: endOfLine: EndOfLine -> unit

    /// A universal resource identifier representing either a file on disk
    /// or another resource, like untitled resources.
    type [<AllowNullLiteral>] Uri =
        /// <summary>
        /// Scheme is the <c>http</c> part of <c>http://www.example.com/some/path?query#fragment</c>.
        /// The part before the first colon.
        /// </summary>
        abstract scheme: string
        /// <summary>
        /// Authority is the <c>www.example.com</c> part of <c>http://www.example.com/some/path?query#fragment</c>.
        /// The part between the first double slashes and the next slash.
        /// </summary>
        abstract authority: string
        /// <summary>Path is the <c>/some/path</c> part of <c>http://www.example.com/some/path?query#fragment</c>.</summary>
        abstract path: string
        /// <summary>Query is the <c>query</c> part of <c>http://www.example.com/some/path?query#fragment</c>.</summary>
        abstract query: string
        /// <summary>Fragment is the <c>fragment</c> part of <c>http://www.example.com/some/path?query#fragment</c>.</summary>
        abstract fragment: string
        /// <summary>
        /// The string representing the corresponding file system path of this Uri.
        ///
        /// Will handle UNC paths and normalize windows drive letters to lower-case. Also
        /// uses the platform specific path separator.
        ///
        /// * Will *not* validate the path for invalid characters and semantics.
        /// * Will *not* look at the scheme of this Uri.
        /// * The resulting string shall *not* be used for display purposes but
        /// for disk operations, like <c>readFile</c> et al.
        ///
        /// The *difference* to the {@linkcode Uri.path path}-property is the use of the platform specific
        /// path separator and the handling of UNC paths. The sample below outlines the difference:
        /// <code lang="ts">
        /// const u = URI.parse('file://server/c$/folder/file.txt')
        /// u.authority === 'server'
        /// u.path === '/shares/c$/file.txt'
        /// u.fsPath === '\\server\c$\folder\file.txt'
        /// </code>
        /// </summary>
        abstract fsPath: string
        /// <summary>
        /// Derive a new Uri from this Uri.
        ///
        /// <code lang="ts">
        /// let file = Uri.parse('before:some/file/path');
        /// let other = file.with({ scheme: 'after' });
        /// assert.ok(other.toString() === 'after:some/file/path');
        /// </code>
        /// </summary>
        /// <param name="change">
        /// An object that describes a change to this Uri. To unset components use <c>null</c> or
        /// the empty string.
        /// </param>
        /// <returns>
        /// A new Uri that reflects the given change. Will return <c>this</c> Uri if the change
        /// is not changing anything.
        /// </returns>
        abstract ``with``: change: UriWithChange -> Uri
        /// <summary>
        /// Returns a string representation of this Uri. The representation and normalization
        /// of a URI depends on the scheme.
        ///
        /// * The resulting string can be safely used with <see cref="Uri.parse" />.
        /// * The resulting string shall *not* be used for display purposes.
        ///
        /// *Note* that the implementation will encode _aggressive_ which often leads to unexpected,
        /// but not incorrect, results. For instance, colons are encoded to <c>%3A</c> which might be unexpected
        /// in file-uri. Also <c>&amp;</c> and <c>=</c> will be encoded which might be unexpected for http-uris. For stability
        /// reasons this cannot be changed anymore. If you suffer from too aggressive encoding you should use
        /// the <c>skipEncoding</c>-argument: <c>uri.toString(true)</c>.
        /// </summary>
        /// <param name="skipEncoding">
        /// Do not percentage-encode the result, defaults to <c>false</c>. Note that
        /// the <c>#</c> and <c>?</c> characters occurring in the path will always be encoded.
        /// </param>
        /// <returns>A string representation of this Uri.</returns>
        abstract toString: ?skipEncoding: bool -> string
        /// <summary>Returns a JSON representation of this Uri.</summary>
        /// <returns>An object.</returns>
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
        /// <summary>
        /// Create an URI from a string, e.g. <c>http://www.example.com/some/path</c>,
        /// <c>file:///usr/home</c>, or <c>scheme:with/path</c>.
        ///
        /// *Note* that for a while uris without a <c>scheme</c> were accepted. That is not correct
        /// as all uris should have a scheme. To avoid breakage of existing code the optional
        /// <c>strict</c>-argument has been added. We *strongly* advise to use it, e.g. <c>Uri.parse('my:uri', true)</c>
        /// </summary>
        /// <seealso cref="Uri.toString" />
        /// <param name="value">The string value of an Uri.</param>
        /// <param name="strict">Throw an error when <c>value</c> is empty or when no <c>scheme</c> can be parsed.</param>
        /// <returns>A new Uri instance.</returns>
        abstract parse: value: string * ?strict: bool -> Uri
        /// <summary>
        /// Create an URI from a file system path. The <see cref="Uri.scheme">scheme</see>
        /// will be <c>file</c>.
        ///
        /// The *difference* between <see cref="Uri.parse" /> and <see cref="Uri.file" /> is that the latter treats the argument
        /// as path, not as stringified-uri. E.g. <c>Uri.file(path)</c> is *not* the same as
        /// <c>Uri.parse('file://' + path)</c> because the path might contain characters that are
        /// interpreted (# and ?). See the following sample:
        /// <code lang="ts">
        /// const good = URI.file('/coding/c#/project1');
        /// good.scheme === 'file';
        /// good.path === '/coding/c#/project1';
        /// good.fragment === '';
        ///
        /// const bad = URI.parse('file://' + '/coding/c#/project1');
        /// bad.scheme === 'file';
        /// bad.path === '/coding/c'; // path is now broken
        /// bad.fragment === '/project1';
        /// </code>
        /// </summary>
        /// <param name="path">A file system or UNC path.</param>
        /// <returns>A new Uri instance.</returns>
        abstract file: path: string -> Uri
        /// <summary>
        /// Create a new uri which path is the result of joining
        /// the path of the base uri with the provided path segments.
        ///
        /// - Note 1: <c>joinPath</c> only affects the path component
        /// and all other components (scheme, authority, query, and fragment) are
        /// left as they are.
        /// - Note 2: The base uri must have a path; an error is thrown otherwise.
        ///
        /// The path segments are normalized in the following ways:
        /// - sequences of path separators (<c>/</c> or <c>\</c>) are replaced with a single separator
        /// - for <c>file</c>-uris on windows, the backslash-character (<c>\</c>) is considered a path-separator
        /// - the <c>..</c>-segment denotes the parent segment, the <c>.</c> denotes the current segment
        /// - paths have a root which always remains, for instance on windows drive-letters are roots
        /// so that is true: <c>joinPath(Uri.file('file:///c:/root'), '../../other').fsPath === 'c:/other'</c>
        /// </summary>
        /// <param name="base">An uri. Must have a path.</param>
        /// <param name="pathSegments">One more more path fragments</param>
        /// <returns>A new uri which path is joined with the given fragments</returns>
        abstract joinPath: ``base``: Uri * [<ParamArray>] pathSegments: string[] -> Uri
        /// <summary>Create an URI from its component parts</summary>
        /// <seealso cref="Uri.toString" />
        /// <param name="components">The component parts of an Uri.</param>
        /// <returns>A new Uri instance.</returns>
        abstract from: components: UriStaticFromComponents -> Uri

    type [<AllowNullLiteral>] UriStaticFromComponents =
        abstract scheme: string
        abstract authority: string option
        abstract path: string option
        abstract query: string option
        abstract fragment: string option

    /// <summary>
    /// A cancellation token is passed to an asynchronous or long running
    /// operation to request cancellation, like cancelling a request
    /// for completion items because the user continued to type.
    ///
    /// To get an instance of a <c>CancellationToken</c> use a
    /// <see cref="CancellationTokenSource" />.
    /// </summary>
    type [<AllowNullLiteral>] CancellationToken =
        /// <summary>Is <c>true</c> when the token has been cancelled, <c>false</c> otherwise.</summary>
        abstract isCancellationRequested: bool with get, set
        /// <summary>An <see cref="Event" /> which fires upon cancellation.</summary>
        abstract onCancellationRequested: Event<obj option> with get, set

    /// <summary>A cancellation source creates and controls a <see cref="CancellationToken">cancellation token</see>.</summary>
    type [<AllowNullLiteral>] CancellationTokenSource =
        /// The cancellation token of this source.
        abstract token: CancellationToken with get, set
        /// Signal cancellation on the token.
        abstract cancel: unit -> unit
        /// Dispose object and free resources.
        abstract dispose: unit -> unit

    /// <summary>A cancellation source creates and controls a <see cref="CancellationToken">cancellation token</see>.</summary>
    type [<AllowNullLiteral>] CancellationTokenSourceStatic =
        [<EmitConstructor>] abstract Create: unit -> CancellationTokenSource

    /// <summary>
    /// An error type that should be used to signal cancellation of an operation.
    ///
    /// This type can be used in response to a <see cref="CancellationToken">cancellation token</see>
    /// being cancelled or when an operation is being cancelled by the
    /// executor of that operation.
    /// </summary>
    type [<ImportMember("vscode"); AllowNullLiteral; AbstractClass>] CancellationError =
        inherit Error

    /// <summary>
    /// An error type that should be used to signal cancellation of an operation.
    ///
    /// This type can be used in response to a <see cref="CancellationToken">cancellation token</see>
    /// being cancelled or when an operation is being cancelled by the
    /// executor of that operation.
    /// </summary>
    type [<AllowNullLiteral>] CancellationErrorStatic =
        /// Creates a new cancellation error.
        [<EmitConstructor>] abstract Create: unit -> CancellationError

    /// Represents a type which can release resources, such
    /// as event listening or a timer.
    type [<AllowNullLiteral>] Disposable =
        /// Dispose this object.
        abstract dispose: unit -> obj option

    /// Represents a type which can release resources, such
    /// as event listening or a timer.
    type [<AllowNullLiteral>] DisposableStatic =
        /// <summary>
        /// Combine many disposable-likes into one. You can use this method when having objects with
        /// a dispose function which aren't instances of <c>Disposable</c>.
        /// </summary>
        /// <param name="disposableLikes">
        /// Objects that have at least a <c>dispose</c>-function member. Note that asynchronous
        /// dispose-functions aren't awaited.
        /// </param>
        /// <returns>
        /// Returns a new disposable which, upon dispose, will
        /// dispose all provided disposables.
        /// </returns>
        abstract from: [<ParamArray>] disposableLikes: {| dispose: unit -> obj option |}[] -> Disposable
        /// <summary>
        /// Creates a new disposable that calls the provided function
        /// on dispose.
        ///
        /// *Note* that an asynchronous function is not awaited.
        /// </summary>
        /// <param name="callOnDispose">Function that disposes something.</param>
        [<EmitConstructor>] abstract Create: callOnDispose: (unit -> obj option) -> Disposable

    /// <summary>
    /// Represents a typed event.
    ///
    /// A function that represents an event to which you subscribe by calling it with
    /// a listener function as argument.
    /// </summary>
    /// <example>item.onDidChange(function(event) { console.log("Event happened: " + event); });</example>
    type [<AllowNullLiteral>] Event<'T> =
        /// <summary>
        /// A function that represents an event to which you subscribe by calling it with
        /// a listener function as argument.
        /// </summary>
        /// <param name="listener">The listener function will be called when the event happens.</param>
        /// <param name="thisArgs">The <c>this</c>-argument which will be used when calling the event listener.</param>
        /// <param name="disposables">An array to which a <see cref="Disposable" /> will be added.</param>
        /// <returns>A disposable which unsubscribes the event listener.</returns>
        [<Emit "$0($1...)">] abstract Invoke: listener: ('T -> obj option) * ?thisArgs: obj * ?disposables: ResizeArray<Disposable> -> Disposable

    /// <summary>
    /// An event emitter can be used to create and manage an <see cref="Event" /> for others
    /// to subscribe to. One emitter always owns one event.
    ///
    /// Use this class if you want to provide event from within your extension, for instance
    /// inside a <see cref="TextDocumentContentProvider" /> or when providing
    /// API to other extensions.
    /// </summary>
    type [<AllowNullLiteral>] EventEmitter<'T> =
        /// The event listeners can subscribe to.
        abstract ``event``: Event<'T> with get, set
        /// <summary>
        /// Notify all subscribers of the <see cref="EventEmitter.event">event</see>. Failure
        /// of one or more listener will not fail this function call.
        /// </summary>
        /// <param name="data">The event object.</param>
        abstract fire: data: 'T -> unit
        /// Dispose this object and free resources.
        abstract dispose: unit -> unit

    /// <summary>
    /// An event emitter can be used to create and manage an <see cref="Event" /> for others
    /// to subscribe to. One emitter always owns one event.
    ///
    /// Use this class if you want to provide event from within your extension, for instance
    /// inside a <see cref="TextDocumentContentProvider" /> or when providing
    /// API to other extensions.
    /// </summary>
    type [<AllowNullLiteral>] EventEmitterStatic =
        [<EmitConstructor>] abstract Create: unit -> EventEmitter<'T>

    /// <summary>
    /// A file system watcher notifies about changes to files and folders
    /// on disk or from other <see cref="FileSystemProvider">FileSystemProviders</see>.
    ///
    /// To get an instance of a <c>FileSystemWatcher</c> use
    /// <see cref="workspace.createFileSystemWatcher">createFileSystemWatcher</see>.
    /// </summary>
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

    /// <summary>
    /// A text document content provider allows to add readonly documents
    /// to the editor, such as source from a dll or generated html from md.
    ///
    /// Content providers are <see cref="workspace.registerTextDocumentContentProvider">registered</see>
    /// for a <see cref="Uri.scheme">uri-scheme</see>. When a uri with that scheme is to
    /// be <see cref="workspace.openTextDocument">loaded</see> the content provider is
    /// asked.
    /// </summary>
    type [<AllowNullLiteral>] TextDocumentContentProvider =
        /// An event to signal a resource has changed.
        abstract onDidChange: Event<Uri> option with get, set
        /// <summary>
        /// Provide textual content for a given uri.
        ///
        /// The editor will use the returned string-content to create a readonly
        /// <see cref="TextDocument">document</see>. Resources allocated should be released when
        /// the corresponding document has been <see cref="workspace.onDidCloseTextDocument">closed</see>.
        ///
        /// **Note**: The contents of the created <see cref="TextDocument">document</see> might not be
        /// identical to the provided text due to end-of-line-sequence normalization.
        /// </summary>
        /// <param name="uri">An uri which scheme matches the scheme this provider was <see cref="workspace.registerTextDocumentContentProvider">registered</see> for.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>A string or a thenable that resolves to such.</returns>
        abstract provideTextDocumentContent: uri: Uri * token: CancellationToken -> ProviderResult<string>

    /// <summary>The kind of <see cref="QuickPickItem">quick pick item</see>.</summary>
    type [<RequireQualifiedAccess>] QuickPickItemKind =
        /// <summary>
        /// When a <see cref="QuickPickItem" /> has a kind of <see cref="Separator" />, the item is just a visual separator and does not represent a real item.
        /// The only property that applies is <see cref="QuickPickItem.label">label </see>. All other properties on <see cref="QuickPickItem" /> will be ignored and have no effect.
        /// </summary>
        | Separator = -1
        /// <summary>The default <see cref="QuickPickItem.kind" /> is an item that can be selected in the quick pick.</summary>
        | Default = 0

    /// Represents an item that can be selected from
    /// a list of items.
    type [<AllowNullLiteral>] QuickPickItem =
        /// <summary>
        /// A human-readable string which is rendered prominent. Supports rendering of <see cref="ThemeIcon">theme icons</see> via
        /// the <c>$(&lt;name&gt;)</c>-syntax.
        /// </summary>
        abstract label: string with get, set
        /// <summary>
        /// The kind of QuickPickItem that will determine how this item is rendered in the quick pick. When not specified,
        /// the default is <see cref="QuickPickItemKind.Default" />.
        /// </summary>
        abstract kind: QuickPickItemKind option with get, set
        /// <summary>
        /// A human-readable string which is rendered less prominent in the same line. Supports rendering of
        /// <see cref="ThemeIcon">theme icons</see> via the <c>$(&lt;name&gt;)</c>-syntax.
        ///
        /// Note: this property is ignored when <see cref="QuickPickItem.kind">kind</see> is set to <see cref="QuickPickItemKind.Separator" />
        /// </summary>
        abstract description: string option with get, set
        /// <summary>
        /// A human-readable string which is rendered less prominent in a separate line. Supports rendering of
        /// <see cref="ThemeIcon">theme icons</see> via the <c>$(&lt;name&gt;)</c>-syntax.
        ///
        /// Note: this property is ignored when <see cref="QuickPickItem.kind">kind</see> is set to <see cref="QuickPickItemKind.Separator" />
        /// </summary>
        abstract detail: string option with get, set
        /// <summary>
        /// Optional flag indicating if this item is picked initially. This is only honored when using
        /// the <see cref="window.showQuickPick()" /> API. To do the same thing with the <see cref="window.createQuickPick()" /> API,
        /// simply set the <see cref="QuickPick.selectedItems" /> to the items you want picked initially.
        /// (*Note:* This is only honored when the picker allows multiple selections.)
        /// </summary>
        /// <seealso cref="QuickPickOptions.canPickMany">
        ///
        /// Note: this property is ignored when <see cref="QuickPickItem.kind">kind</see> is set to <see cref="QuickPickItemKind.Separator" />
        /// </seealso>
        abstract picked: bool option with get, set
        /// <summary>
        /// Always show this item.
        ///
        /// Note: this property is ignored when <see cref="QuickPickItem.kind">kind</see> is set to <see cref="QuickPickItemKind.Separator" />
        /// </summary>
        abstract alwaysShow: bool option with get, set
        /// <summary>
        /// Optional buttons that will be rendered on this particular item. These buttons will trigger
        /// an <see cref="QuickPickItemButtonEvent" /> when clicked. Buttons are only rendered when using a quickpick
        /// created by the <see cref="window.createQuickPick()" /> API. Buttons are not rendered when using
        /// the <see cref="window.showQuickPick()" /> API.
        ///
        /// Note: this property is ignored when <see cref="QuickPickItem.kind">kind</see> is set to <see cref="QuickPickItemKind.Separator" />
        /// </summary>
        abstract buttons: ResizeArray<QuickInputButton> option with get, set

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
        /// <summary>
        /// Set to <c>true</c> to keep the picker open when focus moves to another part of the editor or to another window.
        /// This setting is ignored on iPad and is always false.
        /// </summary>
        abstract ignoreFocusOut: bool option with get, set
        /// An optional flag to make the picker accept multiple selections, if true the result is an array of picks.
        abstract canPickMany: bool option with get, set
        /// An optional function that is invoked whenever an item is selected.
        abstract onDidSelectItem: item: U2<QuickPickItem, string> -> obj option

    /// <summary>Options to configure the behaviour of the <see cref="WorkspaceFolder">workspace folder</see> pick UI.</summary>
    type [<AllowNullLiteral>] WorkspaceFolderPickOptions =
        /// An optional string to show as placeholder in the input box to guide the user what to pick on.
        abstract placeHolder: string option with get, set
        /// <summary>
        /// Set to <c>true</c> to keep the picker open when focus moves to another part of the editor or to another window.
        /// This setting is ignored on iPad and is always false.
        /// </summary>
        abstract ignoreFocusOut: bool option with get, set

    /// <summary>
    /// Options to configure the behaviour of a file open dialog.
    ///
    /// * Note 1: On Windows and Linux, a file dialog cannot be both a file selector and a folder selector, so if you
    /// set both <c>canSelectFiles</c> and <c>canSelectFolders</c> to <c>true</c> on these platforms, a folder selector will be shown.
    /// * Note 2: Explicitly setting <c>canSelectFiles</c> and <c>canSelectFolders</c> to <c>false</c> is futile
    /// and the editor then silently adjusts the options to select files.
    /// </summary>
    type [<AllowNullLiteral>] OpenDialogOptions =
        /// The resource the dialog shows when opened.
        abstract defaultUri: Uri option with get, set
        /// A human-readable string for the open button.
        abstract openLabel: string option with get, set
        /// <summary>Allow to select files, defaults to <c>true</c>.</summary>
        abstract canSelectFiles: bool option with get, set
        /// <summary>Allow to select folders, defaults to <c>false</c>.</summary>
        abstract canSelectFolders: bool option with get, set
        /// Allow to select many files or folders.
        abstract canSelectMany: bool option with get, set
        /// A set of file filters that are used by the dialog. Each entry is a human-readable label,
        /// like "TypeScript", and an array of extensions, e.g.
        /// <code lang="ts">
        /// {
        ///      'Images': ['png', 'jpg']
        ///      'TypeScript': ['ts', 'tsx']
        /// }
        /// </code>
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
        /// <code lang="ts">
        /// {
        ///      'Images': ['png', 'jpg']
        ///      'TypeScript': ['ts', 'tsx']
        /// }
        /// </code>
        abstract filters: OpenDialogOptionsFilters option with get, set
        /// Dialog title.
        ///
        /// This parameter might be ignored, as not all operating systems display a title on save dialogs
        /// (for example, macOS).
        abstract title: string option with get, set

    /// <summary>
    /// Represents an action that is shown with an information, warning, or
    /// error message.
    /// </summary>
    /// <seealso cref="window.showInformationMessage">showInformationMessage</seealso>
    /// <seealso cref="window.showWarningMessage">showWarningMessage</seealso>
    /// <seealso cref="window.showErrorMessage">showErrorMessage</seealso>
    type [<AllowNullLiteral>] MessageItem =
        /// A short title like 'Retry', 'Open Log' etc.
        abstract title: string with get, set
        /// A hint for modal dialogs that the item should be triggered
        /// when the user cancels the dialog (e.g. by pressing the ESC
        /// key).
        ///
        /// Note: this option is ignored for non-modal messages.
        abstract isCloseAffordance: bool option with get, set

    /// <summary>Options to configure the behavior of the message.</summary>
    /// <seealso cref="window.showInformationMessage">showInformationMessage</seealso>
    /// <seealso cref="window.showWarningMessage">showWarningMessage</seealso>
    /// <seealso cref="window.showErrorMessage">showErrorMessage</seealso>
    type [<AllowNullLiteral>] MessageOptions =
        /// Indicates that this message should be modal.
        abstract modal: bool option with get, set
        /// <summary>
        /// Human-readable detail message that is rendered less prominent. _Note_ that detail
        /// is only shown for <see cref="MessageOptions.modal">modal</see> messages.
        /// </summary>
        abstract detail: string option with get, set

    /// Options to configure the behavior of the input box UI.
    type [<AllowNullLiteral>] InputBoxOptions =
        /// An optional string that represents the title of the input box.
        abstract title: string option with get, set
        /// The value to prefill in the input box.
        abstract value: string option with get, set
        /// <summary>
        /// Selection of the prefilled {@linkcode InputBoxOptions.value value}. Defined as tuple of two number where the
        /// first is the inclusive start index and the second the exclusive end index. When <c>undefined</c> the whole
        /// word will be selected, when empty (start equals end) only the cursor will be set,
        /// otherwise the defined range will be selected.
        /// </summary>
        abstract valueSelection: (float * float) option with get, set
        /// The text to display underneath the input box.
        abstract prompt: string option with get, set
        /// An optional string to show as placeholder in the input box to guide the user what to type.
        abstract placeHolder: string option with get, set
        /// Controls if a password input is shown. Password input hides the typed text.
        abstract password: bool option with get, set
        /// <summary>
        /// Set to <c>true</c> to keep the input box open when focus moves to another part of the editor or to another window.
        /// This setting is ignored on iPad and is always false.
        /// </summary>
        abstract ignoreFocusOut: bool option with get, set
        /// <summary>
        /// An optional function that will be called to validate input and to give a hint
        /// to the user.
        /// </summary>
        /// <param name="value">The current value of the input box.</param>
        /// <returns>
        /// A human-readable string which is presented as diagnostic message.
        /// Return <c>undefined</c>, <c>null</c>, or the empty string when 'value' is valid.
        /// </returns>
        abstract validateInput: (string -> U2<string, Thenable<string option>> option) with get, set

    /// <summary>
    /// A relative pattern is a helper to construct glob patterns that are matched
    /// relatively to a base file path. The base path can either be an absolute file
    /// path as string or uri or a <see cref="WorkspaceFolder">workspace folder</see>, which is the
    /// preferred way of creating the relative pattern.
    /// </summary>
    type [<AllowNullLiteral>] RelativePattern =
        /// A base file path to which this pattern will be matched against relatively.
        abstract baseUri: Uri with get, set
        /// <summary>
        /// A base file path to which this pattern will be matched against relatively.
        ///
        /// This matches the <c>fsPath</c> value of <see cref="RelativePattern.baseUri" />.
        ///
        /// *Note:* updating this value will update <see cref="RelativePattern.baseUri" /> to
        /// be a uri with <c>file</c> scheme.
        /// </summary>
        [<Obsolete("This property is deprecated, please use {@link RelativePattern.baseUri} instead.")>]
        abstract ``base``: string with get, set
        /// <summary>
        /// A file glob pattern like <c>*.{ts,js}</c> that will be matched on file paths
        /// relative to the base path.
        ///
        /// Example: Given a base of <c>/home/work/folder</c> and a file path of <c>/home/work/folder/index.js</c>,
        /// the file glob pattern will match on <c>index.js</c>.
        /// </summary>
        abstract pattern: string with get, set

    /// <summary>
    /// A relative pattern is a helper to construct glob patterns that are matched
    /// relatively to a base file path. The base path can either be an absolute file
    /// path as string or uri or a <see cref="WorkspaceFolder">workspace folder</see>, which is the
    /// preferred way of creating the relative pattern.
    /// </summary>
    type [<AllowNullLiteral>] RelativePatternStatic =
        /// <summary>
        /// Creates a new relative pattern object with a base file path and pattern to match. This pattern
        /// will be matched on file paths relative to the base.
        ///
        /// Example:
        /// <code lang="ts">
        /// const folder = vscode.workspace.workspaceFolders?.[0];
        /// if (folder) {
        ///
        ///    // Match any TypeScript file in the root of this workspace folder
        ///    const pattern1 = new vscode.RelativePattern(folder, '*.ts');
        ///
        ///    // Match any TypeScript file in `someFolder` inside this workspace folder
        ///    const pattern2 = new vscode.RelativePattern(folder, 'someFolder/*.ts');
        /// }
        /// </code>
        /// </summary>
        /// <param name="base">
        /// A base to which this pattern will be matched against relatively. It is recommended
        /// to pass in a <see cref="WorkspaceFolder">workspace folder</see> if the pattern should match inside the workspace.
        /// Otherwise, a uri or string should only be used if the pattern is for a file path outside the workspace.
        /// </param>
        /// <param name="pattern">A file glob pattern like <c>*.{ts,js}</c> that will be matched on paths relative to the base.</param>
        [<EmitConstructor>] abstract Create: ``base``: U3<WorkspaceFolder, Uri, string> * pattern: string -> RelativePattern

    /// <summary>
    /// A file glob pattern to match file paths against. This can either be a glob pattern string
    /// (like <c>**​/*.{ts,js}</c> or <c>*.{ts,js}</c>) or a <see cref="RelativePattern">relative pattern</see>.
    ///
    /// Glob patterns can have the following syntax:
    /// * <c>*</c> to match one or more characters in a path segment
    /// * <c>?</c> to match on one character in a path segment
    /// * <c>**</c> to match any number of path segments, including none
    /// * <c>{}</c> to group conditions (e.g. <c>**​/*.{ts,js}</c> matches all TypeScript and JavaScript files)
    /// * <c>[]</c> to declare a range of characters to match in a path segment (e.g., <c>example.[0-9]</c> to match on <c>example.0</c>, <c>example.1</c>, …)
    /// * <c>[!...]</c> to negate a range of characters to match in a path segment (e.g., <c>example.[!0-9]</c> to match on <c>example.a</c>, <c>example.b</c>, but not <c>example.0</c>)
    ///
    /// Note: a backslash (<c>\</c>) is not valid within a glob pattern. If you have an existing file
    /// path to match against, consider to use the <see cref="RelativePattern">relative pattern</see> support
    /// that takes care of converting any backslash into slash. Otherwise, make sure to convert
    /// any backslash to slash when creating the glob pattern.
    /// </summary>
    type GlobPattern =
        U2<string, RelativePattern>

    /// <summary>
    /// A document filter denotes a document by different properties like
    /// the <see cref="TextDocument.languageId">language</see>, the <see cref="Uri.scheme">scheme</see> of
    /// its resource, or a glob-pattern that is applied to the <see cref="TextDocument.fileName">path</see>.
    /// </summary>
    /// <example>
    /// &lt;caption&gt;A language filter that applies to typescript files on disk&lt;/caption&gt;
    /// { language: 'typescript', scheme: 'file' }
    /// </example>
    /// <example>
    /// &lt;caption&gt;A language filter that applies to all package.json paths&lt;/caption&gt;
    /// { language: 'json', pattern: '**​/package.json' }
    /// </example>
    type [<AllowNullLiteral>] TextDocumentFilter =
        /// <summary>A language id, like <c>typescript</c>.</summary>
        abstract language: string option with get, set
        /// <summary>A Uri <see cref="Uri.scheme">scheme</see>, like <c>file</c> or <c>untitled</c>.</summary>
        abstract scheme: string option with get, set
        /// <summary>
        /// A <see cref="GlobPattern">glob pattern</see> that is matched on the absolute path of the document. Use a <see cref="RelativePattern">relative pattern</see>
        /// to filter documents to a <see cref="WorkspaceFolder">workspace folder</see>.
        /// </summary>
        abstract pattern: GlobPattern option with get, set

    type NotebookDocumentFilter =
        /// <summary>
        /// The <see cref="NotebookDocument.notebookType">type</see> of a notebook, like <c>jupyter-notebook</c>. This allows
        /// to narrow down on the type of a notebook that a <see cref="NotebookCell.document">cell document</see> belongs to.
        ///
        /// *Note* that setting the <c>notebookType</c>-property changes how <c>scheme</c> and <c>pattern</c> are interpreted. When set
        /// they are evaluated against the <see cref="NotebookDocument.uri">notebook uri</see>, not the document uri.
        /// </summary>
        /// <example>
        /// &lt;caption&gt;Match python document inside jupyter notebook that aren't stored yet (<c>untitled</c>)&lt;/caption&gt;
        /// { language: 'python', notebookType: 'jupyter-notebook', scheme: 'untitled' }
        /// </example>
        abstract notebookType: string option with get, set
        abstract scheme : string option with get, set
        abstract pattern : GlobPattern option with get, set

    ///<summary>
    /// A notebook cell text document filter denotes a cell text document by different properties.
    /// @since 3.17.0
    ///</summary>
    type [<AllowNullLiteral>] NotebookCellTextDocumentFilter =

        ///A filter that matches against the notebook
        ///containing the notebook cell. If a string
        ///value is provided it matches against the
        ///notebook type. '*' matches every notebook.
        abstract notebook: U2<string, NotebookDocumentFilter> with get, set
        ///A language id like `python`.
        ///
        ///Will be matched against the language id of the
        ///notebook cell document. '*' matches every language.
        abstract language : string option with get, set


    type DocumentFilter = U2<TextDocumentFilter, NotebookCellTextDocumentFilter>

    /// <summary>
    /// A language selector is the combination of one or many language identifiers
    /// and <see cref="DocumentFilter">language filters</see>.
    ///
    /// *Note* that a document selector that is just a language identifier selects *all*
    /// documents, even those that are not saved on disk. Only use such selectors when
    /// a feature works without further context, e.g. without the need to resolve related
    /// 'files'.
    /// </summary>
    /// <example>let sel:DocumentSelector = { scheme: 'file', language: 'typescript' };</example>
    type DocumentSelector =
        U2<string, DocumentFilter>[]

    /// <summary>
    /// A provider result represents the values a provider, like the {@linkcode HoverProvider},
    /// may return. For once this is the actual result type <c>T</c>, like <c>Hover</c>, or a thenable that resolves
    /// to that type <c>T</c>. In addition, <c>null</c> and <c>undefined</c> can be returned - either directly or from a
    /// thenable.
    ///
    /// The snippets below are all valid implementations of the {@linkcode HoverProvider}:
    ///
    /// <code lang="ts">
    /// let a: HoverProvider = {
    ///      provideHover(doc, pos, token): ProviderResult&lt;Hover&gt; {
    ///          return new Hover('Hello World');
    ///      }
    /// }
    ///
    /// let b: HoverProvider = {
    ///      provideHover(doc, pos, token): ProviderResult&lt;Hover&gt; {
    ///          return new Promise(resolve =&gt; {
    ///              resolve(new Hover('Hello World'));
    ///           });
    ///      }
    /// }
    ///
    /// let c: HoverProvider = {
    ///      provideHover(doc, pos, token): ProviderResult&lt;Hover&gt; {
    ///          return; // undefined
    ///      }
    /// }
    /// </code>
    /// </summary>
    type ProviderResult<'T> =
        U2<'T, Thenable<'T option>> option

    /// <summary>
    /// Kind of a code action.
    ///
    /// Kinds are a hierarchical list of identifiers separated by <c>.</c>, e.g. <c>"refactor.extract.function"</c>.
    ///
    /// Code action kinds are used by the editor for UI elements such as the refactoring context menu. Users
    /// can also trigger code actions with a specific kind with the <c>editor.action.codeAction</c> command.
    /// </summary>
    type [<AllowNullLiteral>] CodeActionKind =
        /// <summary>String value of the kind, e.g. <c>"refactor.extract.function"</c>.</summary>
        abstract value: string
        /// Create a new kind by appending a more specific selector to the current kind.
        ///
        /// Does not modify the current kind.
        abstract append: parts: string -> CodeActionKind
        /// <summary>
        /// Checks if this code action kind intersects <c>other</c>.
        ///
        /// The kind <c>"refactor.extract"</c> for example intersects <c>refactor</c>, <c>"refactor.extract"</c> and <c></c>"refactor.extract.function"`,
        /// but not <c>"unicorn.refactor.extract"</c>, or <c>"refactor.extractAll"</c>.
        /// </summary>
        /// <param name="other">Kind to check.</param>
        abstract intersects: other: CodeActionKind -> bool
        /// <summary>
        /// Checks if <c>other</c> is a sub-kind of this <c>CodeActionKind</c>.
        ///
        /// The kind <c>"refactor.extract"</c> for example contains <c>"refactor.extract"</c> and <c></c>"refactor.extract.function"`,
        /// but not <c>"unicorn.refactor.extract"</c>, or <c>"refactor.extractAll"</c> or <c>refactor</c>.
        /// </summary>
        /// <param name="other">Kind to check.</param>
        abstract contains: other: CodeActionKind -> bool

    /// <summary>
    /// Kind of a code action.
    ///
    /// Kinds are a hierarchical list of identifiers separated by <c>.</c>, e.g. <c>"refactor.extract.function"</c>.
    ///
    /// Code action kinds are used by the editor for UI elements such as the refactoring context menu. Users
    /// can also trigger code actions with a specific kind with the <c>editor.action.codeAction</c> command.
    /// </summary>
    type [<AllowNullLiteral>] CodeActionKindStatic =
        /// Empty kind.
        abstract Empty: CodeActionKind
        /// <summary>
        /// Base kind for quickfix actions: <c>quickfix</c>.
        ///
        /// Quick fix actions address a problem in the code and are shown in the normal code action context menu.
        /// </summary>
        abstract QuickFix: CodeActionKind
        /// <summary>
        /// Base kind for refactoring actions: <c>refactor</c>
        ///
        /// Refactoring actions are shown in the refactoring context menu.
        /// </summary>
        abstract Refactor: CodeActionKind
        /// <summary>
        /// Base kind for refactoring extraction actions: <c>refactor.extract</c>
        ///
        /// Example extract actions:
        ///
        /// - Extract method
        /// - Extract function
        /// - Extract variable
        /// - Extract interface from class
        /// - ...
        /// </summary>
        abstract RefactorExtract: CodeActionKind
        /// <summary>
        /// Base kind for refactoring inline actions: <c>refactor.inline</c>
        ///
        /// Example inline actions:
        ///
        /// - Inline function
        /// - Inline variable
        /// - Inline constant
        /// - ...
        /// </summary>
        abstract RefactorInline: CodeActionKind
        /// <summary>
        /// Base kind for refactoring rewrite actions: <c>refactor.rewrite</c>
        ///
        /// Example rewrite actions:
        ///
        /// - Convert JavaScript function to class
        /// - Add or remove parameter
        /// - Encapsulate field
        /// - Make method static
        /// - Move method to base class
        /// - ...
        /// </summary>
        abstract RefactorRewrite: CodeActionKind
        /// <summary>
        /// Base kind for source actions: <c>source</c>
        ///
        /// Source code actions apply to the entire file. They must be explicitly requested and will not show in the
        /// normal <see href="https://code.visualstudio.com/docs/editor/editingevolved#_code-action">lightbulb</see> menu. Source actions
        /// can be run on save using <c>editor.codeActionsOnSave</c> and are also shown in the <c>source</c> context menu.
        /// </summary>
        abstract Source: CodeActionKind
        /// <summary>Base kind for an organize imports source action: <c>source.organizeImports</c>.</summary>
        abstract SourceOrganizeImports: CodeActionKind
        /// <summary>
        /// Base kind for auto-fix source actions: <c>source.fixAll</c>.
        ///
        /// Fix all actions automatically fix errors that have a clear fix that do not require user input.
        /// They should not suppress errors or perform unsafe fixes such as generating new types or classes.
        /// </summary>
        abstract SourceFixAll: CodeActionKind

    /// The reason why code actions were requested.
    type [<RequireQualifiedAccess>] CodeActionTriggerKind =
        /// Code actions were explicitly requested by the user or by an extension.
        | Invoke = 1
        /// Code actions were requested automatically.
        ///
        /// This typically happens when current selection in a file changes, but can
        /// also be triggered when file content changes.
        | Automatic = 2

    /// <summary>
    /// Contains additional diagnostic information about the context in which
    /// a <see cref="CodeActionProvider.provideCodeActions">code action</see> is run.
    /// </summary>
    type [<AllowNullLiteral>] CodeActionContext =
        /// The reason why code actions were requested.
        abstract triggerKind: CodeActionTriggerKind
        /// An array of diagnostics.
        abstract diagnostics: ResizeArray<Diagnostic>
        /// <summary>
        /// Requested kind of actions to return.
        ///
        /// Actions not of this kind are filtered out before being shown by the <see href="https://code.visualstudio.com/docs/editor/editingevolved#_code-action">lightbulb</see>.
        /// </summary>
        abstract only: CodeActionKind option

    /// <summary>
    /// A code action represents a change that can be performed in code, e.g. to fix a problem or
    /// to refactor code.
    ///
    /// A CodeAction must set either {@linkcode CodeAction.edit edit} and/or a {@linkcode CodeAction.command command}. If both are supplied, the <c>edit</c> is applied first, then the command is executed.
    /// </summary>
    type [<AllowNullLiteral>] CodeAction =
        /// A short, human-readable, title for this code action.
        abstract title: string with get, set
        /// <summary>A <see cref="WorkspaceEdit">workspace edit</see> this code action performs.</summary>
        abstract edit: WorkspaceEdit option with get, set
        /// <summary><see cref="Diagnostic">Diagnostics</see> that this code action resolves.</summary>
        abstract diagnostics: ResizeArray<Diagnostic> option with get, set
        /// <summary>
        /// A <see cref="Command" /> this code action executes.
        ///
        /// If this command throws an exception, the editor displays the exception message to users in the editor at the
        /// current cursor position.
        /// </summary>
        abstract command: Command option with get, set
        /// <summary>
        /// <see cref="CodeActionKind">Kind</see> of the code action.
        ///
        /// Used to filter code actions.
        /// </summary>
        abstract kind: CodeActionKind option with get, set
        /// <summary>
        /// Marks this as a preferred action. Preferred actions are used by the <c>auto fix</c> command and can be targeted
        /// by keybindings.
        ///
        /// A quick fix should be marked preferred if it properly addresses the underlying error.
        /// A refactoring should be marked preferred if it is the most reasonable choice of actions to take.
        /// </summary>
        abstract isPreferred: bool option with get, set
        /// <summary>
        /// Marks that the code action cannot currently be applied.
        ///
        /// - Disabled code actions are not shown in automatic <see href="https://code.visualstudio.com/docs/editor/editingevolved#_code-action">lightbulb</see>
        /// code action menu.
        ///
        /// - Disabled actions are shown as faded out in the code action menu when the user request a more specific type
        /// of code action, such as refactorings.
        ///
        /// - If the user has a <see href="https://code.visualstudio.com/docs/editor/refactoring#_keybindings-for-code-actions">keybinding</see>
        /// that auto applies a code action and only a disabled code actions are returned, the editor will show the user an
        /// error message with <c>reason</c> in the editor.
        /// </summary>
        abstract disabled: {| reason: string |} option with get, set

    /// <summary>
    /// A code action represents a change that can be performed in code, e.g. to fix a problem or
    /// to refactor code.
    ///
    /// A CodeAction must set either {@linkcode CodeAction.edit edit} and/or a {@linkcode CodeAction.command command}. If both are supplied, the <c>edit</c> is applied first, then the command is executed.
    /// </summary>
    type [<AllowNullLiteral>] CodeActionStatic =
        /// <summary>
        /// Creates a new code action.
        ///
        /// A code action must have at least a <see cref="CodeAction.title">title</see> and <see cref="CodeAction.edit">edits</see>
        /// and/or a <see cref="CodeAction.command">command</see>.
        /// </summary>
        /// <param name="title">The title of the code action.</param>
        /// <param name="kind">The kind of the code action.</param>
        [<EmitConstructor>] abstract Create: title: string * ?kind: CodeActionKind -> CodeAction

    /// <summary>
    /// The code action interface defines the contract between extensions and
    /// the <see href="https://code.visualstudio.com/docs/editor/editingevolved#_code-action">lightbulb</see> feature.
    ///
    /// A code action can be any command that is <see cref="commands.getCommands">known</see> to the system.
    /// </summary>
    type CodeActionProvider =
        CodeActionProvider<CodeAction>

    /// <summary>
    /// The code action interface defines the contract between extensions and
    /// the <see href="https://code.visualstudio.com/docs/editor/editingevolved#_code-action">lightbulb</see> feature.
    ///
    /// A code action can be any command that is <see cref="commands.getCommands">known</see> to the system.
    /// </summary>
    type [<AllowNullLiteral>] CodeActionProvider<'T when 'T :> CodeAction> =
        /// <summary>Provide commands for the given document and range.</summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="range">
        /// The selector or range for which the command was invoked. This will always be a selection if
        /// there is a currently active editor.
        /// </param>
        /// <param name="context">Context carrying additional information.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>
        /// An array of code actions, such as quick fixes or refactorings. The lack of a result can be signaled
        /// by returning <c>undefined</c>, <c>null</c>, or an empty array.
        ///
        /// We also support returning <c>Command</c> for legacy reasons, however all new extensions should return
        /// <c>CodeAction</c> object instead.
        /// </returns>
        abstract provideCodeActions: document: TextDocument * range: U2<Range, Selection> * context: CodeActionContext * token: CancellationToken -> ProviderResult<ResizeArray<U2<Command, 'T>>>
        /// <summary>
        /// Given a code action fill in its {@linkcode CodeAction.edit edit}-property. Changes to
        /// all other properties, like title, are ignored. A code action that has an edit
        /// will not be resolved.
        ///
        /// *Note* that a code action provider that returns commands, not code actions, cannot successfully
        /// implement this function. Returning commands is deprecated and instead code actions should be
        /// returned.
        /// </summary>
        /// <param name="codeAction">A code action.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>
        /// The resolved code action or a thenable that resolves to such. It is OK to return the given
        /// <c>item</c>. When no result is returned, the given <c>item</c> will be used.
        /// </returns>
        abstract resolveCodeAction: codeAction: 'T * token: CancellationToken -> ProviderResult<'T>

    /// <summary>Metadata about the type of code actions that a <see cref="CodeActionProvider" /> provides.</summary>
    type [<AllowNullLiteral>] CodeActionProviderMetadata =
        /// <summary>
        /// List of <see cref="CodeActionKind">CodeActionKinds</see> that a <see cref="CodeActionProvider" /> may return.
        ///
        /// This list is used to determine if a given <c>CodeActionProvider</c> should be invoked or not.
        /// To avoid unnecessary computation, every <c>CodeActionProvider</c> should list use <c>providedCodeActionKinds</c>. The
        /// list of kinds may either be generic, such as <c>[CodeActionKind.Refactor]</c>, or list out every kind provided,
        /// such as <c>[CodeActionKind.Refactor.Extract.append('function'), CodeActionKind.Refactor.Extract.append('constant'), ...]</c>.
        /// </summary>
        abstract providedCodeActionKinds: ResizeArray<CodeActionKind> option
        /// <summary>
        /// Static documentation for a class of code actions.
        ///
        /// Documentation from the provider is shown in the code actions menu if either:
        ///
        /// - Code actions of <c>kind</c> are requested by the editor. In this case, the editor will show the documentation that
        ///    most closely matches the requested code action kind. For example, if a provider has documentation for
        ///    both <c>Refactor</c> and <c>RefactorExtract</c>, when the user requests code actions for <c>RefactorExtract</c>,
        ///    the editor will use the documentation for <c>RefactorExtract</c> instead of the documentation for <c>Refactor</c>.
        ///
        /// - Any code actions of <c>kind</c> are returned by the provider.
        ///
        /// At most one documentation entry will be shown per provider.
        /// </summary>
        abstract documentation: ReadonlyArray<{| kind: CodeActionKind; command: Command |}> option

    /// <summary>
    /// A code lens represents a <see cref="Command" /> that should be shown along with
    /// source text, like the number of references, a way to run tests, etc.
    ///
    /// A code lens is _unresolved_ when no command is associated to it. For performance
    /// reasons the creation of a code lens and resolving should be done to two stages.
    /// </summary>
    /// <seealso cref="CodeLensProvider.provideCodeLenses" />
    /// <seealso cref="CodeLensProvider.resolveCodeLens" />
    type [<AllowNullLiteral>] CodeLens =
        /// The range in which this code lens is valid. Should only span a single line.
        abstract range: Range with get, set
        /// The command this code lens represents.
        abstract command: Command option with get, set
        /// <summary><c>true</c> when there is a command associated.</summary>
        abstract isResolved: bool

    /// <summary>
    /// A code lens represents a <see cref="Command" /> that should be shown along with
    /// source text, like the number of references, a way to run tests, etc.
    ///
    /// A code lens is _unresolved_ when no command is associated to it. For performance
    /// reasons the creation of a code lens and resolving should be done to two stages.
    /// </summary>
    /// <seealso cref="CodeLensProvider.provideCodeLenses" />
    /// <seealso cref="CodeLensProvider.resolveCodeLens" />
    type [<AllowNullLiteral>] CodeLensStatic =
        /// <summary>Creates a new code lens object.</summary>
        /// <param name="range">The range to which this code lens applies.</param>
        /// <param name="command">The command associated to this code lens.</param>
        [<EmitConstructor>] abstract Create: range: Range * ?command: Command -> CodeLens

    /// <summary>
    /// A code lens provider adds <see cref="Command">commands</see> to source text. The commands will be shown
    /// as dedicated horizontal lines in between the source text.
    /// </summary>
    type CodeLensProvider =
        CodeLensProvider<CodeLens>

    /// <summary>
    /// A code lens provider adds <see cref="Command">commands</see> to source text. The commands will be shown
    /// as dedicated horizontal lines in between the source text.
    /// </summary>
    type [<AllowNullLiteral>] CodeLensProvider<'T when 'T :> CodeLens> =
        /// An optional event to signal that the code lenses from this provider have changed.
        abstract onDidChangeCodeLenses: Event<unit> option with get, set
        /// <summary>
        /// Compute a list of <see cref="CodeLens">lenses</see>. This call should return as fast as possible and if
        /// computing the commands is expensive implementors should only return code lens objects with the
        /// range set and implement <see cref="CodeLensProvider.resolveCodeLens">resolve</see>.
        /// </summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>
        /// An array of code lenses or a thenable that resolves to such. The lack of a result can be
        /// signaled by returning <c>undefined</c>, <c>null</c>, or an empty array.
        /// </returns>
        abstract provideCodeLenses: document: TextDocument * token: CancellationToken -> ProviderResult<ResizeArray<'T>>
        /// <summary>
        /// This function will be called for each visible code lens, usually when scrolling and after
        /// calls to <see cref="CodeLensProvider.provideCodeLenses">compute</see>-lenses.
        /// </summary>
        /// <param name="codeLens">Code lens that must be resolved.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>The given, resolved code lens or thenable that resolves to such.</returns>
        abstract resolveCodeLens: codeLens: 'T * token: CancellationToken -> ProviderResult<'T>

    /// <summary>
    /// Information about where a symbol is defined.
    ///
    /// Provides additional metadata over normal <see cref="Location" /> definitions, including the range of
    /// the defining symbol
    /// </summary>
    type DefinitionLink =
        LocationLink

    /// <summary>
    /// The definition of a symbol represented as one or many <see cref="Location">locations</see>.
    /// For most programming languages there is only one location at which a symbol is
    /// defined.
    /// </summary>
    type Definition =
        U2<Location, ResizeArray<Location>>

    /// <summary>
    /// The definition provider interface defines the contract between extensions and
    /// the <see href="https://code.visualstudio.com/docs/editor/editingevolved#_go-to-definition">go to definition</see>
    /// and peek definition features.
    /// </summary>
    type [<AllowNullLiteral>] DefinitionProvider =
        /// <summary>Provide the definition of the symbol at the given position and document.</summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="position">The position at which the command was invoked.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>
        /// A definition or a thenable that resolves to such. The lack of a result can be
        /// signaled by returning <c>undefined</c> or <c>null</c>.
        /// </returns>
        abstract provideDefinition: document: TextDocument * position: Position * token: CancellationToken -> ProviderResult<U2<Definition, ResizeArray<DefinitionLink>>>

    /// The implementation provider interface defines the contract between extensions and
    /// the go to implementation feature.
    type [<AllowNullLiteral>] ImplementationProvider =
        /// <summary>Provide the implementations of the symbol at the given position and document.</summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="position">The position at which the command was invoked.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>
        /// A definition or a thenable that resolves to such. The lack of a result can be
        /// signaled by returning <c>undefined</c> or <c>null</c>.
        /// </returns>
        abstract provideImplementation: document: TextDocument * position: Position * token: CancellationToken -> ProviderResult<U2<Definition, ResizeArray<DefinitionLink>>>

    /// The type definition provider defines the contract between extensions and
    /// the go to type definition feature.
    type [<AllowNullLiteral>] TypeDefinitionProvider =
        /// <summary>Provide the type definition of the symbol at the given position and document.</summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="position">The position at which the command was invoked.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>
        /// A definition or a thenable that resolves to such. The lack of a result can be
        /// signaled by returning <c>undefined</c> or <c>null</c>.
        /// </returns>
        abstract provideTypeDefinition: document: TextDocument * position: Position * token: CancellationToken -> ProviderResult<U2<Definition, ResizeArray<DefinitionLink>>>

    /// <summary>
    /// The declaration of a symbol representation as one or many <see cref="Location">locations</see>
    /// or <see cref="LocationLink">location links</see>.
    /// </summary>
    type Declaration =
        U3<Location, ResizeArray<Location>, ResizeArray<LocationLink>>

    /// The declaration provider interface defines the contract between extensions and
    /// the go to declaration feature.
    type [<AllowNullLiteral>] DeclarationProvider =
        /// <summary>Provide the declaration of the symbol at the given position and document.</summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="position">The position at which the command was invoked.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>
        /// A declaration or a thenable that resolves to such. The lack of a result can be
        /// signaled by returning <c>undefined</c> or <c>null</c>.
        /// </returns>
        abstract provideDeclaration: document: TextDocument * position: Position * token: CancellationToken -> ProviderResult<Declaration>

    /// <summary>
    /// Human-readable text that supports formatting via the <see href="https://commonmark.org">markdown syntax</see>.
    ///
    /// Rendering of <see cref="ThemeIcon">theme icons</see> via the <c>$(&lt;name&gt;)</c>-syntax is supported
    /// when the {@linkcode supportThemeIcons} is set to <c>true</c>.
    ///
    /// Rendering of embedded html is supported when {@linkcode supportHtml} is set to <c>true</c>.
    /// </summary>
    type [<AllowNullLiteral>] MarkdownString =
        /// The markdown string.
        abstract value: string with get, set
        /// <summary>
        /// Indicates that this markdown string is from a trusted source. Only *trusted*
        /// markdown supports links that execute commands, e.g. <c>[Run it](command:myCommandId)</c>.
        /// </summary>
        abstract isTrusted: bool option with get, set
        /// <summary>Indicates that this markdown string can contain <see cref="ThemeIcon">ThemeIcons</see>, e.g. <c>$(zap)</c>.</summary>
        abstract supportThemeIcons: bool option with get, set
        /// <summary>
        /// Indicates that this markdown string can contain raw html tags. Defaults to <c>false</c>.
        ///
        /// When <c>supportHtml</c> is false, the markdown renderer will strip out any raw html tags
        /// that appear in the markdown text. This means you can only use markdown syntax for rendering.
        ///
        /// When <c>supportHtml</c> is true, the markdown render will also allow a safe subset of html tags
        /// and attributes to be rendered. See <see href="https://github.com/microsoft/vscode/blob/6d2920473c6f13759c978dd89104c4270a83422d/src/vs/base/browser/markdownRenderer.ts#L296" />
        /// for a list of all supported tags and attributes.
        /// </summary>
        abstract supportHtml: bool option with get, set
        /// <summary>
        /// Uri that relative paths are resolved relative to.
        ///
        /// If the <c>baseUri</c> ends with <c>/</c>, it is considered a directory and relative paths in the markdown are resolved relative to that directory:
        ///
        /// <code lang="ts">
        /// const md = new vscode.MarkdownString(`[link](./file.js)`);
        /// md.baseUri = vscode.Uri.file('/path/to/dir/');
        /// // Here 'link' in the rendered markdown resolves to '/path/to/dir/file.js'
        /// </code>
        ///
        /// If the <c>baseUri</c> is a file, relative paths in the markdown are resolved relative to the parent dir of that file:
        ///
        /// <code lang="ts">
        /// const md = new vscode.MarkdownString(`[link](./file.js)`);
        /// md.baseUri = vscode.Uri.file('/path/to/otherFile.js');
        /// // Here 'link' in the rendered markdown resolves to '/path/to/file.js'
        /// </code>
        /// </summary>
        abstract baseUri: Uri option with get, set
        /// <summary>Appends and escapes the given string to this markdown string.</summary>
        /// <param name="value">Plain text.</param>
        abstract appendText: value: string -> MarkdownString
        /// <summary>Appends the given string 'as is' to this markdown string. When {@linkcode MarkdownString.supportThemeIcons supportThemeIcons} is <c>true</c>, <see cref="ThemeIcon">ThemeIcons</see> in the <c>value</c> will be iconified.</summary>
        /// <param name="value">Markdown string.</param>
        abstract appendMarkdown: value: string -> MarkdownString
        /// <summary>Appends the given string as codeblock using the provided language.</summary>
        /// <param name="value">A code snippet.</param>
        /// <param name="language">An optional <see cref="languages.getLanguages">language identifier</see>.</param>
        abstract appendCodeblock: value: string * ?language: string -> MarkdownString

    /// <summary>
    /// Human-readable text that supports formatting via the <see href="https://commonmark.org">markdown syntax</see>.
    ///
    /// Rendering of <see cref="ThemeIcon">theme icons</see> via the <c>$(&lt;name&gt;)</c>-syntax is supported
    /// when the {@linkcode supportThemeIcons} is set to <c>true</c>.
    ///
    /// Rendering of embedded html is supported when {@linkcode supportHtml} is set to <c>true</c>.
    /// </summary>
    type [<AllowNullLiteral>] MarkdownStringStatic =
        /// <summary>Creates a new markdown string with the given value.</summary>
        /// <param name="value">Optional, initial value.</param>
        /// <param name="supportThemeIcons">Optional, Specifies whether <see cref="ThemeIcon">ThemeIcons</see> are supported within the {</param>
        [<EmitConstructor>] abstract Create: ?value: string * ?supportThemeIcons: bool -> MarkdownString

    /// <summary>
    /// MarkedString can be used to render human-readable text. It is either a markdown string
    /// or a code-block that provides a language and a code snippet. Note that
    /// markdown strings will be sanitized - that means html will be escaped.
    /// </summary>
    [<Obsolete("This type is deprecated, please use {")>]
    type MarkedString =
        U2<string, {| language: string; value: string |}>

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
        [<EmitConstructor>] abstract Create: contents: U3<MarkdownString, MarkedString, Array<U2<MarkdownString, MarkedString>>> * ?range: Range -> Hover

    /// <summary>
    /// The hover provider interface defines the contract between extensions and
    /// the <see href="https://code.visualstudio.com/docs/editor/intellisense">hover</see>-feature.
    /// </summary>
    type [<AllowNullLiteral>] HoverProvider =
        /// <summary>
        /// Provide a hover for the given position and document. Multiple hovers at the same
        /// position will be merged by the editor. A hover can have a range which defaults
        /// to the word range at the position when omitted.
        /// </summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="position">The position at which the command was invoked.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>
        /// A hover or a thenable that resolves to such. The lack of a result can be
        /// signaled by returning <c>undefined</c> or <c>null</c>.
        /// </returns>
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
        [<EmitConstructor>] abstract Create: range: Range * ?expression: string -> EvaluatableExpression

    /// The evaluatable expression provider interface defines the contract between extensions and
    /// the debug hover. In this contract the provider returns an evaluatable expression for a given position
    /// in a document and the editor evaluates this expression in the active debug session and shows the result in a debug hover.
    type [<AllowNullLiteral>] EvaluatableExpressionProvider =
        /// <summary>
        /// Provide an evaluatable expression for the given document and position.
        /// The editor will evaluate this expression in the active debug session and will show the result in the debug hover.
        /// The expression can be implicitly specified by the range in the underlying document or by explicitly returning an expression.
        /// </summary>
        /// <param name="document">The document for which the debug hover is about to appear.</param>
        /// <param name="position">The line and character position in the document where the debug hover is about to appear.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>
        /// An EvaluatableExpression or a thenable that resolves to such. The lack of a result can be
        /// signaled by returning <c>undefined</c> or <c>null</c>.
        /// </returns>
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
        [<EmitConstructor>] abstract Create: range: Range * text: string -> InlineValueText

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
        [<EmitConstructor>] abstract Create: range: Range * ?variableName: string * ?caseSensitiveLookup: bool -> InlineValueVariableLookup

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
        [<EmitConstructor>] abstract Create: range: Range * ?expression: string -> InlineValueEvaluatableExpression

    /// Inline value information can be provided by different means:
    /// - directly as a text value (class InlineValueText).
    /// - as a name to use for a variable lookup (class InlineValueVariableLookup)
    /// - as an evaluatable expression (class InlineValueEvaluatableExpression)
    /// The InlineValue types combines all inline value types into one type.
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
        /// <summary>An optional event to signal that inline values have changed.</summary>
        /// <seealso cref="EventEmitter" />
        abstract onDidChangeInlineValues: Event<unit> option with get, set
        /// <summary>
        /// Provide "inline value" information for a given document and range.
        /// The editor calls this method whenever debugging stops in the given document.
        /// The returned inline values information is rendered in the editor at the end of lines.
        /// </summary>
        /// <param name="document">The document for which the inline values information is needed.</param>
        /// <param name="viewPort">The visible document range for which inline values should be computed.</param>
        /// <param name="context">A bag containing contextual information like the current location.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>
        /// An array of InlineValueDescriptors or a thenable that resolves to such. The lack of a result can be
        /// signaled by returning <c>undefined</c> or <c>null</c>.
        /// </returns>
        abstract provideInlineValues: document: TextDocument * viewPort: Range * context: InlineValueContext * token: CancellationToken -> ProviderResult<ResizeArray<InlineValue>>

    /// A document highlight kind.
    type [<RequireQualifiedAccess>] DocumentHighlightKind =
        /// A textual occurrence.
        | Text = 0
        /// Read-access of a symbol, like reading a variable.
        | Read = 1
        /// Write-access of a symbol, like writing to a variable.
        | Write = 2

    /// A document highlight is a range inside a text document which deserves
    /// special attention. Usually a document highlight is visualized by changing
    /// the background color of its range.
    type [<AllowNullLiteral>] DocumentHighlight =
        /// The range this highlight applies to.
        abstract range: Range with get, set
        /// <summary>The highlight kind, default is <see cref="DocumentHighlightKind.Text">text</see>.</summary>
        abstract kind: DocumentHighlightKind option with get, set

    /// A document highlight is a range inside a text document which deserves
    /// special attention. Usually a document highlight is visualized by changing
    /// the background color of its range.
    type [<AllowNullLiteral>] DocumentHighlightStatic =
        /// <summary>Creates a new document highlight object.</summary>
        /// <param name="range">The range the highlight applies to.</param>
        /// <param name="kind">The highlight kind, default is <see cref="DocumentHighlightKind.Text">text</see>.</param>
        [<EmitConstructor>] abstract Create: range: Range * ?kind: DocumentHighlightKind -> DocumentHighlight

    /// The document highlight provider interface defines the contract between extensions and
    /// the word-highlight-feature.
    type [<AllowNullLiteral>] DocumentHighlightProvider =
        /// <summary>
        /// Provide a set of document highlights, like all occurrences of a variable or
        /// all exit-points of a function.
        /// </summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="position">The position at which the command was invoked.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>
        /// An array of document highlights or a thenable that resolves to such. The lack of a result can be
        /// signaled by returning <c>undefined</c>, <c>null</c>, or an empty array.
        /// </returns>
        abstract provideDocumentHighlights: document: TextDocument * position: Position * token: CancellationToken -> ProviderResult<ResizeArray<DocumentHighlight>>

    /// A symbol kind.
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

    /// Symbol tags are extra annotations that tweak the rendering of a symbol.
    type [<RequireQualifiedAccess>] SymbolTag =
        /// Render a symbol as obsolete, usually using a strike-out.
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
        [<EmitConstructor>] abstract Create: name: string * kind: SymbolKind * containerName: string * location: Location -> SymbolInformation
        /// <summary>Creates a new symbol information object.</summary>
        /// <param name="name">The name of the symbol.</param>
        /// <param name="kind">The kind of the symbol.</param>
        /// <param name="range">The range of the location of the symbol.</param>
        /// <param name="uri">The resource of the location of symbol, defaults to the current document.</param>
        /// <param name="containerName">The name of the symbol containing the symbol.</param>
        [<Obsolete("Please use the constructor taking a {@link Location} object.")>]
        [<EmitConstructor>] abstract Create: name: string * kind: SymbolKind * range: Range * ?uri: Uri * ?containerName: string -> SymbolInformation

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
        /// Must be contained by the {@linkcode DocumentSymbol.range range}.
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
        [<EmitConstructor>] abstract Create: name: string * detail: string * kind: SymbolKind * range: Range * selectionRange: Range -> DocumentSymbol

    /// <summary>
    /// The document symbol provider interface defines the contract between extensions and
    /// the <see href="https://code.visualstudio.com/docs/editor/editingevolved#_go-to-symbol">go to symbol</see>-feature.
    /// </summary>
    type [<AllowNullLiteral>] DocumentSymbolProvider =
        /// <summary>Provide symbol information for the given document.</summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>
        /// An array of document highlights or a thenable that resolves to such. The lack of a result can be
        /// signaled by returning <c>undefined</c>, <c>null</c>, or an empty array.
        /// </returns>
        abstract provideDocumentSymbols: document: TextDocument * token: CancellationToken -> ProviderResult<U2<ResizeArray<SymbolInformation>, ResizeArray<DocumentSymbol>>>

    /// Metadata about a document symbol provider.
    type [<AllowNullLiteral>] DocumentSymbolProviderMetadata =
        /// A human-readable string that is shown when multiple outlines trees show for one document.
        abstract label: string option with get, set

    /// <summary>
    /// The workspace symbol provider interface defines the contract between extensions and
    /// the <see href="https://code.visualstudio.com/docs/editor/editingevolved#_open-symbol-by-name">symbol search</see>-feature.
    /// </summary>
    type WorkspaceSymbolProvider =
        WorkspaceSymbolProvider<SymbolInformation>

    /// <summary>
    /// The workspace symbol provider interface defines the contract between extensions and
    /// the <see href="https://code.visualstudio.com/docs/editor/editingevolved#_open-symbol-by-name">symbol search</see>-feature.
    /// </summary>
    type [<AllowNullLiteral>] WorkspaceSymbolProvider<'T when 'T :> SymbolInformation> =
        /// <summary>
        /// Project-wide search for a symbol matching the given query string.
        ///
        /// The <c>query</c>-parameter should be interpreted in a *relaxed way* as the editor will apply its own highlighting
        /// and scoring on the results. A good rule of thumb is to match case-insensitive and to simply check that the
        /// characters of *query* appear in their order in a candidate symbol. Don't use prefix, substring, or similar
        /// strict matching.
        ///
        /// To improve performance implementors can implement <c>resolveWorkspaceSymbol</c> and then provide symbols with partial
        /// <see cref="SymbolInformation.location">location</see>-objects, without a <c>range</c> defined. The editor will then call
        /// <c>resolveWorkspaceSymbol</c> for selected symbols only, e.g. when opening a workspace symbol.
        /// </summary>
        /// <param name="query">A query string, can be the empty string in which case all symbols should be returned.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>
        /// An array of document highlights or a thenable that resolves to such. The lack of a result can be
        /// signaled by returning <c>undefined</c>, <c>null</c>, or an empty array.
        /// </returns>
        abstract provideWorkspaceSymbols: query: string * token: CancellationToken -> ProviderResult<ResizeArray<'T>>
        /// <summary>
        /// Given a symbol fill in its <see cref="SymbolInformation.location">location</see>. This method is called whenever a symbol
        /// is selected in the UI. Providers can implement this method and return incomplete symbols from
        /// {@linkcode WorkspaceSymbolProvider.provideWorkspaceSymbols provideWorkspaceSymbols} which often helps to improve
        /// performance.
        /// </summary>
        /// <param name="symbol">
        /// The symbol that is to be resolved. Guaranteed to be an instance of an object returned from an
        /// earlier call to <c>provideWorkspaceSymbols</c>.
        /// </param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>
        /// The resolved symbol or a thenable that resolves to that. When no result is returned,
        /// the given <c>symbol</c> is used.
        /// </returns>
        abstract resolveWorkspaceSymbol: symbol: 'T * token: CancellationToken -> ProviderResult<'T>

    /// Value-object that contains additional information when
    /// requesting references.
    type [<AllowNullLiteral>] ReferenceContext =
        /// Include the declaration of the current symbol.
        abstract includeDeclaration: bool with get, set

    /// <summary>
    /// The reference provider interface defines the contract between extensions and
    /// the <see href="https://code.visualstudio.com/docs/editor/editingevolved#_peek">find references</see>-feature.
    /// </summary>
    type [<AllowNullLiteral>] ReferenceProvider =
        /// <summary>Provide a set of project-wide references for the given position and document.</summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="position">The position at which the command was invoked.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>
        /// An array of locations or a thenable that resolves to such. The lack of a result can be
        /// signaled by returning <c>undefined</c>, <c>null</c>, or an empty array.
        /// </returns>
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
        /// <returns>A new text edit object.</returns>
        abstract replace: range: Range * newText: string -> TextEdit
        /// <summary>Utility to create an insert edit.</summary>
        /// <param name="position">A position, will become an empty range.</param>
        /// <param name="newText">A string.</param>
        /// <returns>A new text edit object.</returns>
        abstract insert: position: Position * newText: string -> TextEdit
        /// <summary>Utility to create a delete edit.</summary>
        /// <param name="range">A range.</param>
        /// <returns>A new text edit object.</returns>
        abstract delete: range: Range -> TextEdit
        /// <summary>Utility to create an eol-edit.</summary>
        /// <param name="eol">An eol-sequence</param>
        /// <returns>A new text edit object.</returns>
        abstract setEndOfLine: eol: EndOfLine -> TextEdit
        /// <summary>Create a new TextEdit.</summary>
        /// <param name="range">A range.</param>
        /// <param name="newText">A string.</param>
        [<EmitConstructor>] abstract Create: range: Range * newText: string -> TextEdit

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
        /// <summary>The icon path or <see cref="ThemeIcon" /> for the edit.</summary>
        abstract iconPath: U3<Uri, {| light: Uri; dark: Uri |}, ThemeIcon> option with get, set

    /// <summary>
    /// A workspace edit is a collection of textual and files changes for
    /// multiple resources and documents.
    ///
    /// Use the <see cref="workspace.applyEdit">applyEdit</see>-function to apply a workspace edit.
    /// </summary>
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
        /// <returns><c>true</c> if the given resource will be touched by this edit.</returns>
        abstract has: uri: Uri -> bool
        /// <summary>Set (and replace) text edits for a resource.</summary>
        /// <param name="uri">A resource identifier.</param>
        /// <param name="edits">An array of text edits.</param>
        abstract set: uri: Uri * edits: ResizeArray<TextEdit> -> unit
        /// <summary>Get the text edits for a resource.</summary>
        /// <param name="uri">A resource identifier.</param>
        /// <returns>An array of text edits.</returns>
        abstract get: uri: Uri -> ResizeArray<TextEdit>
        /// <summary>Create a regular file.</summary>
        /// <param name="uri">Uri of the new file..</param>
        /// <param name="options">
        /// Defines if an existing file should be overwritten or be
        /// ignored. When overwrite and ignoreIfExists are both set overwrite wins.
        /// When both are unset and when the file already exists then the edit cannot
        /// be applied successfully.
        /// </param>
        /// <param name="metadata">Optional metadata for the entry.</param>
        abstract createFile: uri: Uri * ?options: {| overwrite: bool option; ignoreIfExists: bool option |} * ?metadata: WorkspaceEditEntryMetadata -> unit
        /// <summary>Delete a file or folder.</summary>
        /// <param name="uri">The uri of the file that is to be deleted.</param>
        /// <param name="metadata">Optional metadata for the entry.</param>
        abstract deleteFile: uri: Uri * ?options: {| recursive: bool option; ignoreIfNotExists: bool option |} * ?metadata: WorkspaceEditEntryMetadata -> unit
        /// <summary>Rename a file or folder.</summary>
        /// <param name="oldUri">The existing file.</param>
        /// <param name="newUri">The new location.</param>
        /// <param name="options">
        /// Defines if existing files should be overwritten or be
        /// ignored. When overwrite and ignoreIfExists are both set overwrite wins.
        /// </param>
        /// <param name="metadata">Optional metadata for the entry.</param>
        abstract renameFile: oldUri: Uri * newUri: Uri * ?options: {| overwrite: bool option; ignoreIfExists: bool option |} * ?metadata: WorkspaceEditEntryMetadata -> unit
        /// <summary>Get all text edits grouped by resource.</summary>
        /// <returns>A shallow copy of <c>[Uri, TextEdit[]]</c>-tuples.</returns>
        abstract entries: unit -> ResizeArray<Uri * ResizeArray<TextEdit>>

    /// <summary>
    /// A workspace edit is a collection of textual and files changes for
    /// multiple resources and documents.
    ///
    /// Use the <see cref="workspace.applyEdit">applyEdit</see>-function to apply a workspace edit.
    /// </summary>
    type [<AllowNullLiteral>] WorkspaceEditStatic =
        [<EmitConstructor>] abstract Create: unit -> WorkspaceEdit

    /// <summary>
    /// A snippet string is a template which allows to insert text
    /// and to control the editor cursor when insertion happens.
    ///
    /// A snippet can define tab stops and placeholders with <c>$1</c>, <c>$2</c>
    /// and <c>${3:foo}</c>. <c>$0</c> defines the final tab stop, it defaults to
    /// the end of the snippet. Variables are defined with <c>$name</c> and
    /// <c>${name:default value}</c>. Also see
    /// <see href="https://code.visualstudio.com/docs/editor/userdefinedsnippets#_creating-your-own-snippets">the full snippet syntax</see>.
    /// </summary>
    type [<AllowNullLiteral>] SnippetString =
        /// The snippet string.
        abstract value: string with get, set
        /// <summary>
        /// Builder-function that appends the given string to
        /// the {@linkcode SnippetString.value value} of this snippet string.
        /// </summary>
        /// <param name="string">A value to append 'as given'. The string will be escaped.</param>
        /// <returns>This snippet string.</returns>
        abstract appendText: string: string -> SnippetString
        /// <summary>
        /// Builder-function that appends a tabstop (<c>$1</c>, <c>$2</c> etc) to
        /// the {@linkcode SnippetString.value value} of this snippet string.
        /// </summary>
        /// <param name="number">
        /// The number of this tabstop, defaults to an auto-increment
        /// value starting at 1.
        /// </param>
        /// <returns>This snippet string.</returns>
        abstract appendTabstop: ?number: float -> SnippetString
        /// <summary>
        /// Builder-function that appends a placeholder (<c>${1:value}</c>) to
        /// the {@linkcode SnippetString.value value} of this snippet string.
        /// </summary>
        /// <param name="value">
        /// The value of this placeholder - either a string or a function
        /// with which a nested snippet can be created.
        /// </param>
        /// <param name="number">
        /// The number of this tabstop, defaults to an auto-increment
        /// value starting at 1.
        /// </param>
        /// <returns>This snippet string.</returns>
        abstract appendPlaceholder: value: U2<string, (SnippetString -> obj option)> * ?number: float -> SnippetString
        /// <summary>
        /// Builder-function that appends a choice (<c>${1|a,b,c|}</c>) to
        /// the {@linkcode SnippetString.value value} of this snippet string.
        /// </summary>
        /// <param name="values">The values for choices - the array of strings</param>
        /// <param name="number">
        /// The number of this tabstop, defaults to an auto-increment
        /// value starting at 1.
        /// </param>
        /// <returns>This snippet string.</returns>
        abstract appendChoice: values: ResizeArray<string> * ?number: float -> SnippetString
        /// <summary>
        /// Builder-function that appends a variable (<c>${VAR}</c>) to
        /// the {@linkcode SnippetString.value value} of this snippet string.
        /// </summary>
        /// <param name="name">The name of the variable - excluding the <c>$</c>.</param>
        /// <param name="defaultValue">
        /// The default value which is used when the variable name cannot
        /// be resolved - either a string or a function with which a nested snippet can be created.
        /// </param>
        /// <returns>This snippet string.</returns>
        abstract appendVariable: name: string * defaultValue: U2<string, (SnippetString -> obj option)> -> SnippetString

    /// <summary>
    /// A snippet string is a template which allows to insert text
    /// and to control the editor cursor when insertion happens.
    ///
    /// A snippet can define tab stops and placeholders with <c>$1</c>, <c>$2</c>
    /// and <c>${3:foo}</c>. <c>$0</c> defines the final tab stop, it defaults to
    /// the end of the snippet. Variables are defined with <c>$name</c> and
    /// <c>${name:default value}</c>. Also see
    /// <see href="https://code.visualstudio.com/docs/editor/userdefinedsnippets#_creating-your-own-snippets">the full snippet syntax</see>.
    /// </summary>
    type [<AllowNullLiteral>] SnippetStringStatic =
        [<EmitConstructor>] abstract Create: ?value: string -> SnippetString

    /// <summary>
    /// The rename provider interface defines the contract between extensions and
    /// the <see href="https://code.visualstudio.com/docs/editor/editingevolved#_rename-symbol">rename</see>-feature.
    /// </summary>
    type [<AllowNullLiteral>] RenameProvider =
        /// <summary>
        /// Provide an edit that describes changes that have to be made to one
        /// or many resources to rename a symbol to a different name.
        /// </summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="position">The position at which the command was invoked.</param>
        /// <param name="newName">The new name of the symbol. If the given name is not valid, the provider must return a rejected promise.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>
        /// A workspace edit or a thenable that resolves to such. The lack of a result can be
        /// signaled by returning <c>undefined</c> or <c>null</c>.
        /// </returns>
        abstract provideRenameEdits: document: TextDocument * position: Position * newName: string * token: CancellationToken -> ProviderResult<WorkspaceEdit>
        /// <summary>
        /// Optional function for resolving and validating a position *before* running rename. The result can
        /// be a range or a range and a placeholder text. The placeholder text should be the identifier of the symbol
        /// which is being renamed - when omitted the text in the returned range is used.
        ///
        /// *Note: * This function should throw an error or return a rejected thenable when the provided location
        /// doesn't allow for a rename.
        /// </summary>
        /// <param name="document">The document in which rename will be invoked.</param>
        /// <param name="position">The position at which rename will be invoked.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>The range or range and placeholder text of the identifier that is to be renamed. The lack of a result can signaled by returning <c>undefined</c> or <c>null</c>.</returns>
        abstract prepareRename: document: TextDocument * position: Position * token: CancellationToken -> ProviderResult<U2<Range, {| range: Range; placeholder: string |}>>

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
        [<EmitConstructor>] abstract Create: tokenTypes: ResizeArray<string> * ?tokenModifiers: ResizeArray<string> -> SemanticTokensLegend

    /// <summary>
    /// A semantic tokens builder can help with creating a <c>SemanticTokens</c> instance
    /// which contains delta encoded semantic tokens.
    /// </summary>
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
        /// <summary>Finish and create a <c>SemanticTokens</c> instance.</summary>
        abstract build: ?resultId: string -> SemanticTokens

    /// <summary>
    /// A semantic tokens builder can help with creating a <c>SemanticTokens</c> instance
    /// which contains delta encoded semantic tokens.
    /// </summary>
    type [<AllowNullLiteral>] SemanticTokensBuilderStatic =
        [<EmitConstructor>] abstract Create: ?legend: SemanticTokensLegend -> SemanticTokensBuilder

    /// <summary>Represents semantic tokens, either in a range or in an entire document.</summary>
    /// <seealso cref="DocumentSemanticTokensProvider.provideDocumentSemanticTokens">provideDocumentSemanticTokens for an explanation of the format.</seealso>
    /// <seealso cref="SemanticTokensBuilder">for a helper to create an instance.</seealso>
    type [<AllowNullLiteral>] SemanticTokens =
        /// <summary>
        /// The result id of the tokens.
        ///
        /// This is the id that will be passed to <c>DocumentSemanticTokensProvider.provideDocumentSemanticTokensEdits</c> (if implemented).
        /// </summary>
        abstract resultId: string option
        /// <summary>The actual tokens data.</summary>
        /// <seealso cref="DocumentSemanticTokensProvider.provideDocumentSemanticTokens">provideDocumentSemanticTokens for an explanation of the format.</seealso>
        abstract data: Uint32Array

    /// <summary>Represents semantic tokens, either in a range or in an entire document.</summary>
    /// <seealso cref="DocumentSemanticTokensProvider.provideDocumentSemanticTokens">provideDocumentSemanticTokens for an explanation of the format.</seealso>
    /// <seealso cref="SemanticTokensBuilder">for a helper to create an instance.</seealso>
    type [<AllowNullLiteral>] SemanticTokensStatic =
        [<EmitConstructor>] abstract Create: data: Uint32Array * ?resultId: string -> SemanticTokens

    /// <summary>Represents edits to semantic tokens.</summary>
    /// <seealso cref="DocumentSemanticTokensProvider.provideDocumentSemanticTokensEdits">provideDocumentSemanticTokensEdits for an explanation of the format.</seealso>
    type [<AllowNullLiteral>] SemanticTokensEdits =
        /// <summary>
        /// The result id of the tokens.
        ///
        /// This is the id that will be passed to <c>DocumentSemanticTokensProvider.provideDocumentSemanticTokensEdits</c> (if implemented).
        /// </summary>
        abstract resultId: string option
        /// The edits to the tokens data.
        /// All edits refer to the initial data state.
        abstract edits: ResizeArray<SemanticTokensEdit>

    /// <summary>Represents edits to semantic tokens.</summary>
    /// <seealso cref="DocumentSemanticTokensProvider.provideDocumentSemanticTokensEdits">provideDocumentSemanticTokensEdits for an explanation of the format.</seealso>
    type [<AllowNullLiteral>] SemanticTokensEditsStatic =
        [<EmitConstructor>] abstract Create: edits: ResizeArray<SemanticTokensEdit> * ?resultId: string -> SemanticTokensEdits

    /// <summary>Represents an edit to semantic tokens.</summary>
    /// <seealso cref="DocumentSemanticTokensProvider.provideDocumentSemanticTokensEdits">provideDocumentSemanticTokensEdits for an explanation of the format.</seealso>
    type [<AllowNullLiteral>] SemanticTokensEdit =
        /// The start offset of the edit.
        abstract start: float
        /// The count of elements to remove.
        abstract deleteCount: float
        /// The elements to insert.
        abstract data: Uint32Array option

    /// <summary>Represents an edit to semantic tokens.</summary>
    /// <seealso cref="DocumentSemanticTokensProvider.provideDocumentSemanticTokensEdits">provideDocumentSemanticTokensEdits for an explanation of the format.</seealso>
    type [<AllowNullLiteral>] SemanticTokensEditStatic =
        [<EmitConstructor>] abstract Create: start: float * deleteCount: float * ?data: Uint32Array -> SemanticTokensEdit

    /// The document semantic tokens provider interface defines the contract between extensions and
    /// semantic tokens.
    type [<AllowNullLiteral>] DocumentSemanticTokensProvider =
        /// An optional event to signal that the semantic tokens from this provider have changed.
        abstract onDidChangeSemanticTokens: Event<unit> option with get, set
        /// <summary>
        /// Tokens in a file are represented as an array of integers. The position of each token is expressed relative to
        /// the token before it, because most tokens remain stable relative to each other when edits are made in a file.
        ///
        /// ---
        /// In short, each token takes 5 integers to represent, so a specific token <c>i</c> in the file consists of the following array indices:
        ///   - at index <c>5*i</c>   - <c>deltaLine</c>: token line number, relative to the previous token
        ///   - at index <c>5*i+1</c> - <c>deltaStart</c>: token start character, relative to the previous token (relative to 0 or the previous token's start if they are on the same line)
        ///   - at index <c>5*i+2</c> - <c>length</c>: the length of the token. A token cannot be multiline.
        ///   - at index <c>5*i+3</c> - <c>tokenType</c>: will be looked up in <c>SemanticTokensLegend.tokenTypes</c>. We currently ask that <c>tokenType</c> &lt; 65536.
        ///   - at index <c>5*i+4</c> - <c>tokenModifiers</c>: each set bit will be looked up in <c>SemanticTokensLegend.tokenModifiers</c>
        ///
        /// ---
        /// ### How to encode tokens
        ///
        /// Here is an example for encoding a file with 3 tokens in a uint32 array:
        /// <code>
        ///     { line: 2, startChar:  5, length: 3, tokenType: "property",  tokenModifiers: ["private", "static"] },
        ///     { line: 2, startChar: 10, length: 4, tokenType: "type",      tokenModifiers: [] },
        ///     { line: 5, startChar:  2, length: 7, tokenType: "class",     tokenModifiers: [] }
        /// </code>
        ///
        /// 1. First of all, a legend must be devised. This legend must be provided up-front and capture all possible token types.
        /// For this example, we will choose the following legend which must be passed in when registering the provider:
        /// <code>
        ///     tokenTypes: ['property', 'type', 'class'],
        ///     tokenModifiers: ['private', 'static']
        /// </code>
        ///
        /// 2. The first transformation step is to encode <c>tokenType</c> and <c>tokenModifiers</c> as integers using the legend. Token types are looked
        /// up by index, so a <c>tokenType</c> value of <c>1</c> means <c>tokenTypes[1]</c>. Multiple token modifiers can be set by using bit flags,
        /// so a <c>tokenModifier</c> value of <c>3</c> is first viewed as binary <c>0b00000011</c>, which means <c>[tokenModifiers[0], tokenModifiers[1]]</c> because
        /// bits 0 and 1 are set. Using this legend, the tokens now are:
        /// <code>
        ///     { line: 2, startChar:  5, length: 3, tokenType: 0, tokenModifiers: 3 },
        ///     { line: 2, startChar: 10, length: 4, tokenType: 1, tokenModifiers: 0 },
        ///     { line: 5, startChar:  2, length: 7, tokenType: 2, tokenModifiers: 0 }
        /// </code>
        ///
        /// 3. The next step is to represent each token relative to the previous token in the file. In this case, the second token
        /// is on the same line as the first token, so the <c>startChar</c> of the second token is made relative to the <c>startChar</c>
        /// of the first token, so it will be <c>10 - 5</c>. The third token is on a different line than the second token, so the
        /// <c>startChar</c> of the third token will not be altered:
        /// <code>
        ///     { deltaLine: 2, deltaStartChar: 5, length: 3, tokenType: 0, tokenModifiers: 3 },
        ///     { deltaLine: 0, deltaStartChar: 5, length: 4, tokenType: 1, tokenModifiers: 0 },
        ///     { deltaLine: 3, deltaStartChar: 2, length: 7, tokenType: 2, tokenModifiers: 0 }
        /// </code>
        ///
        /// 4. Finally, the last step is to inline each of the 5 fields for a token in a single array, which is a memory friendly representation:
        /// <code>
        ///     // 1st token,  2nd token,  3rd token
        ///     [  2,5,3,0,3,  0,5,4,1,0,  3,2,7,2,0 ]
        /// </code>
        /// </summary>
        /// <seealso cref="SemanticTokensBuilder">
        /// for a helper to encode tokens as integers.
        /// *NOTE*: When doing edits, it is possible that multiple edits occur until the editor decides to invoke the semantic tokens provider.
        /// *NOTE*: If the provider cannot temporarily compute semantic tokens, it can indicate this by throwing an error with the message 'Busy'.
        /// </seealso>
        abstract provideDocumentSemanticTokens: document: TextDocument * token: CancellationToken -> ProviderResult<SemanticTokens>
        /// <summary>
        /// Instead of always returning all the tokens in a file, it is possible for a <c>DocumentSemanticTokensProvider</c> to implement
        /// this method (<c>provideDocumentSemanticTokensEdits</c>) and then return incremental updates to the previously provided semantic tokens.
        ///
        /// ---
        /// ### How tokens change when the document changes
        ///
        /// Suppose that <c>provideDocumentSemanticTokens</c> has previously returned the following semantic tokens:
        /// <code>
        ///     // 1st token,  2nd token,  3rd token
        ///     [  2,5,3,0,3,  0,5,4,1,0,  3,2,7,2,0 ]
        /// </code>
        ///
        /// Also suppose that after some edits, the new semantic tokens in a file are:
        /// <code>
        ///     // 1st token,  2nd token,  3rd token
        ///     [  3,5,3,0,3,  0,5,4,1,0,  3,2,7,2,0 ]
        /// </code>
        /// It is possible to express these new tokens in terms of an edit applied to the previous tokens:
        /// <code>
        ///     [  2,5,3,0,3,  0,5,4,1,0,  3,2,7,2,0 ] // old tokens
        ///     [  3,5,3,0,3,  0,5,4,1,0,  3,2,7,2,0 ] // new tokens
        ///
        ///     edit: { start:  0, deleteCount: 1, data: [3] } // replace integer at offset 0 with 3
        /// </code>
        ///
        /// *NOTE*: If the provider cannot compute <c>SemanticTokensEdits</c>, it can "give up" and return all the tokens in the document again.
        /// *NOTE*: All edits in <c>SemanticTokensEdits</c> contain indices in the old integers array, so they all refer to the previous result state.
        /// </summary>
        abstract provideDocumentSemanticTokensEdits: document: TextDocument * previousResultId: string * token: CancellationToken -> ProviderResult<U2<SemanticTokens, SemanticTokensEdits>>

    /// The document range semantic tokens provider interface defines the contract between extensions and
    /// semantic tokens.
    type [<AllowNullLiteral>] DocumentRangeSemanticTokensProvider =
        /// <seealso cref="DocumentSemanticTokensProvider.provideDocumentSemanticTokens">provideDocumentSemanticTokens .</seealso>
        abstract provideDocumentRangeSemanticTokens: document: TextDocument * range: Range * token: CancellationToken -> ProviderResult<SemanticTokens>

    /// Value-object describing what options formatting should use.
    type [<AllowNullLiteral>] FormattingOptions =
        /// Size of a tab in spaces.
        abstract tabSize: float with get, set
        /// Prefer spaces over tabs.
        abstract insertSpaces: bool with get, set
        /// Signature for further properties.
        [<EmitIndexer>] abstract Item: key: string -> U3<bool, float, string> with get, set

    /// The document formatting provider interface defines the contract between extensions and
    /// the formatting-feature.
    type [<AllowNullLiteral>] DocumentFormattingEditProvider =
        /// <summary>Provide formatting edits for a whole document.</summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="options">Options controlling formatting.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>
        /// A set of text edits or a thenable that resolves to such. The lack of a result can be
        /// signaled by returning <c>undefined</c>, <c>null</c>, or an empty array.
        /// </returns>
        abstract provideDocumentFormattingEdits: document: TextDocument * options: FormattingOptions * token: CancellationToken -> ProviderResult<ResizeArray<TextEdit>>

    /// The document formatting provider interface defines the contract between extensions and
    /// the formatting-feature.
    type [<AllowNullLiteral>] DocumentRangeFormattingEditProvider =
        /// <summary>
        /// Provide formatting edits for a range in a document.
        ///
        /// The given range is a hint and providers can decide to format a smaller
        /// or larger range. Often this is done by adjusting the start and end
        /// of the range to full syntax nodes.
        /// </summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="range">The range which should be formatted.</param>
        /// <param name="options">Options controlling formatting.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>
        /// A set of text edits or a thenable that resolves to such. The lack of a result can be
        /// signaled by returning <c>undefined</c>, <c>null</c>, or an empty array.
        /// </returns>
        abstract provideDocumentRangeFormattingEdits: document: TextDocument * range: Range * options: FormattingOptions * token: CancellationToken -> ProviderResult<ResizeArray<TextEdit>>

    /// The document formatting provider interface defines the contract between extensions and
    /// the formatting-feature.
    type [<AllowNullLiteral>] OnTypeFormattingEditProvider =
        /// <summary>
        /// Provide formatting edits after a character has been typed.
        ///
        /// The given position and character should hint to the provider
        /// what range the position to expand to, like find the matching <c>{</c>
        /// when <c>}</c> has been entered.
        /// </summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="position">The position at which the command was invoked.</param>
        /// <param name="ch">The character that has been typed.</param>
        /// <param name="options">Options controlling formatting.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>
        /// A set of text edits or a thenable that resolves to such. The lack of a result can be
        /// signaled by returning <c>undefined</c>, <c>null</c>, or an empty array.
        /// </returns>
        abstract provideOnTypeFormattingEdits: document: TextDocument * position: Position * ch: string * options: FormattingOptions * token: CancellationToken -> ProviderResult<ResizeArray<TextEdit>>

    /// Represents a parameter of a callable-signature. A parameter can
    /// have a label and a doc-comment.
    type [<AllowNullLiteral>] ParameterInformation =
        /// <summary>
        /// The label of this signature.
        ///
        /// Either a string or inclusive start and exclusive end offsets within its containing
        /// <see cref="SignatureInformation.label">signature label</see>. *Note*: A label of type string must be
        /// a substring of its containing signature information's <see cref="SignatureInformation.label">label</see>.
        /// </summary>
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
        [<EmitConstructor>] abstract Create: label: U2<string, float * float> * ?documentation: U2<string, MarkdownString> -> ParameterInformation

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
        /// If provided, this is used in place of {@linkcode SignatureHelp.activeSignature}.
        abstract activeParameter: float option with get, set

    /// Represents the signature of something callable. A signature
    /// can have a label, like a function-name, a doc-comment, and
    /// a set of parameters.
    type [<AllowNullLiteral>] SignatureInformationStatic =
        /// <summary>Creates a new signature information object.</summary>
        /// <param name="label">A label string.</param>
        /// <param name="documentation">A doc string.</param>
        [<EmitConstructor>] abstract Create: label: string * ?documentation: U2<string, MarkdownString> -> SignatureInformation

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
        [<EmitConstructor>] abstract Create: unit -> SignatureHelp

    /// How a {@linkcode SignatureHelpProvider} was triggered.
    type [<RequireQualifiedAccess>] SignatureHelpTriggerKind =
        /// Signature help was invoked manually by the user or by a command.
        | Invoke = 1
        /// Signature help was triggered by a trigger character.
        | TriggerCharacter = 2
        /// Signature help was triggered by the cursor moving or by the document content changing.
        | ContentChange = 3

    /// Additional information about the context in which a
    /// {@linkcode SignatureHelpProvider.provideSignatureHelp SignatureHelpProvider} was triggered.
    type [<AllowNullLiteral>] SignatureHelpContext =
        /// Action that caused signature help to be triggered.
        abstract triggerKind: SignatureHelpTriggerKind
        /// <summary>
        /// Character that caused signature help to be triggered.
        ///
        /// This is <c>undefined</c> when signature help is not triggered by typing, such as when manually invoking
        /// signature help or when moving the cursor.
        /// </summary>
        abstract triggerCharacter: string option
        /// <summary>
        /// <c>true</c> if signature help was already showing when it was triggered.
        ///
        /// Retriggers occur when the signature help is already active and can be caused by actions such as
        /// typing a trigger character, a cursor move, or document content changes.
        /// </summary>
        abstract isRetrigger: bool
        /// <summary>
        /// The currently active {@linkcode SignatureHelp}.
        ///
        /// The <c>activeSignatureHelp</c> has its [<c>SignatureHelp.activeSignature</c>] field updated based on
        /// the user arrowing through available signatures.
        /// </summary>
        abstract activeSignatureHelp: SignatureHelp option

    /// <summary>
    /// The signature help provider interface defines the contract between extensions and
    /// the <see href="https://code.visualstudio.com/docs/editor/intellisense">parameter hints</see>-feature.
    /// </summary>
    type [<AllowNullLiteral>] SignatureHelpProvider =
        /// <summary>Provide help for the signature at the given position and document.</summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="position">The position at which the command was invoked.</param>
        /// <param name="token">A cancellation token.</param>
        /// <param name="context">Information about how signature help was triggered.</param>
        /// <returns>
        /// Signature help or a thenable that resolves to such. The lack of a result can be
        /// signaled by returning <c>undefined</c> or <c>null</c>.
        /// </returns>
        abstract provideSignatureHelp: document: TextDocument * position: Position * token: CancellationToken * context: SignatureHelpContext -> ProviderResult<SignatureHelp>

    /// Metadata about a registered {@linkcode SignatureHelpProvider}.
    type [<AllowNullLiteral>] SignatureHelpProviderMetadata =
        /// List of characters that trigger signature help.
        abstract triggerCharacters: ResizeArray<string>
        /// List of characters that re-trigger signature help.
        ///
        /// These trigger characters are only active when signature help is already showing. All trigger characters
        /// are also counted as re-trigger characters.
        abstract retriggerCharacters: ResizeArray<string>

    /// <summary>A structured label for a <see cref="CompletionItem">completion item</see>.</summary>
    type [<AllowNullLiteral>] CompletionItemLabel =
        /// The label of this completion item.
        ///
        /// By default this is also the text that is inserted when this completion is selected.
        abstract label: string with get, set
        /// <summary>
        /// An optional string which is rendered less prominently directly after <see cref="CompletionItemLabel.label">label</see>,
        /// without any spacing. Should be used for function signatures or type annotations.
        /// </summary>
        abstract detail: string option with get, set
        /// <summary>
        /// An optional string which is rendered less prominently after <see cref="CompletionItemLabel.detail" />. Should be used
        /// for fully qualified names or file path.
        /// </summary>
        abstract description: string option with get, set

    /// Completion item kinds.
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

    /// Completion item tags are extra annotations that tweak the rendering of a completion
    /// item.
    type [<RequireQualifiedAccess>] CompletionItemTag =
        /// Render a completion as obsolete, usually using a strike-out.
        | Deprecated = 1

    /// <summary>
    /// A completion item represents a text snippet that is proposed to complete text that is being typed.
    ///
    /// It is sufficient to create a completion item from just a <see cref="CompletionItem.label">label</see>. In that
    /// case the completion item will replace the <see cref="TextDocument.getWordRangeAtPosition">word</see>
    /// until the cursor with the given label or <see cref="CompletionItem.insertText">insertText</see>. Otherwise the
    /// given <see cref="CompletionItem.textEdit">edit</see> is used.
    ///
    /// When selecting a completion item in the editor its defined or synthesized text edit will be applied
    /// to *all* cursors/selections whereas <see cref="CompletionItem.additionalTextEdits">additionalTextEdits</see> will be
    /// applied as provided.
    /// </summary>
    /// <seealso cref="CompletionItemProvider.provideCompletionItems" />
    /// <seealso cref="CompletionItemProvider.resolveCompletionItem" />
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
        /// <summary>
        /// A string that should be used when comparing this item
        /// with other items. When <c>falsy</c> the <see cref="CompletionItem.label">label</see>
        /// is used.
        ///
        /// Note that <c>sortText</c> is only used for the initial ordering of completion
        /// items. When having a leading word (prefix) ordering is based on how
        /// well completions match that prefix and the initial ordering is only used
        /// when completions match equally well. The prefix is defined by the
        /// {@linkcode CompletionItem.range range}-property and can therefore be different
        /// for each completion.
        /// </summary>
        abstract sortText: string option with get, set
        /// <summary>
        /// A string that should be used when filtering a set of
        /// completion items. When <c>falsy</c> the <see cref="CompletionItem.label">label</see>
        /// is used.
        ///
        /// Note that the filter text is matched against the leading word (prefix) which is defined
        /// by the {@linkcode CompletionItem.range range}-property.
        /// </summary>
        abstract filterText: string option with get, set
        /// Select this item when showing. *Note* that only one completion item can be selected and
        /// that the editor decides which item that is. The rule is that the *first* item of those
        /// that match best is selected.
        abstract preselect: bool option with get, set
        /// <summary>
        /// A string or snippet that should be inserted in a document when selecting
        /// this completion. When <c>falsy</c> the <see cref="CompletionItem.label">label</see>
        /// is used.
        /// </summary>
        abstract insertText: U2<string, SnippetString> option with get, set
        /// <summary>
        /// A range or a insert and replace range selecting the text that should be replaced by this completion item.
        ///
        /// When omitted, the range of the <see cref="TextDocument.getWordRangeAtPosition">current word</see> is used as replace-range
        /// and as insert-range the start of the <see cref="TextDocument.getWordRangeAtPosition">current word</see> to the
        /// current position is used.
        ///
        /// *Note 1:* A range must be a <see cref="Range.isSingleLine">single line</see> and it must
        /// <see cref="Range.contains">contain</see> the position at which completion has been <see cref="CompletionItemProvider.provideCompletionItems">requested</see>.
        /// *Note 2:* A insert range must be a prefix of a replace range, that means it must be contained and starting at the same position.
        /// </summary>
        abstract range: U2<Range, {| inserting: Range; replacing: Range |}> option with get, set
        /// <summary>
        /// An optional set of characters that when pressed while this completion is active will accept it first and
        /// then type that character. *Note* that all commit characters should have <c>length=1</c> and that superfluous
        /// characters will be ignored.
        /// </summary>
        abstract commitCharacters: ResizeArray<string> option with get, set
        /// <summary>
        /// Keep whitespace of the <see cref="CompletionItem.insertText">insertText</see> as is. By default, the editor adjusts leading
        /// whitespace of new lines so that they match the indentation of the line for which the item is accepted - setting
        /// this to <c>true</c> will prevent that.
        /// </summary>
        abstract keepWhitespace: bool option with get, set
        [<Obsolete("Use `CompletionItem.insertText` and `CompletionItem.range` instead.

An {@link TextEdit edit} which is applied to a document when selecting
this completion. When an edit is provided the value of
{@link CompletionItem.insertText insertText} is ignored.

The {@link Range} of the edit must be single-line and on the same
line completions were {@link CompletionItemProvider.provideCompletionItems requested} at.")>]
        abstract textEdit: TextEdit option with get, set
        /// <summary>
        /// An optional array of additional <see cref="TextEdit">text edits</see> that are applied when
        /// selecting this completion. Edits must not overlap with the main <see cref="CompletionItem.textEdit">edit</see>
        /// nor with themselves.
        /// </summary>
        abstract additionalTextEdits: ResizeArray<TextEdit> option with get, set
        /// <summary>
        /// An optional <see cref="Command" /> that is executed *after* inserting this completion. *Note* that
        /// additional modifications to the current document should be described with the
        /// <see cref="CompletionItem.additionalTextEdits">additionalTextEdits</see>-property.
        /// </summary>
        abstract command: Command option with get, set

    /// <summary>
    /// A completion item represents a text snippet that is proposed to complete text that is being typed.
    ///
    /// It is sufficient to create a completion item from just a <see cref="CompletionItem.label">label</see>. In that
    /// case the completion item will replace the <see cref="TextDocument.getWordRangeAtPosition">word</see>
    /// until the cursor with the given label or <see cref="CompletionItem.insertText">insertText</see>. Otherwise the
    /// given <see cref="CompletionItem.textEdit">edit</see> is used.
    ///
    /// When selecting a completion item in the editor its defined or synthesized text edit will be applied
    /// to *all* cursors/selections whereas <see cref="CompletionItem.additionalTextEdits">additionalTextEdits</see> will be
    /// applied as provided.
    /// </summary>
    /// <seealso cref="CompletionItemProvider.provideCompletionItems" />
    /// <seealso cref="CompletionItemProvider.resolveCompletionItem" />
    type [<AllowNullLiteral>] CompletionItemStatic =
        /// <summary>
        /// Creates a new completion item.
        ///
        /// Completion items must have at least a <see cref="CompletionItem.label">label</see> which then
        /// will be used as insert text as well as for sorting and filtering.
        /// </summary>
        /// <param name="label">The label of the completion.</param>
        /// <param name="kind">The <see cref="CompletionItemKind">kind</see> of the completion.</param>
        [<EmitConstructor>] abstract Create: label: U2<string, CompletionItemLabel> * ?kind: CompletionItemKind -> CompletionItem

    /// <summary>
    /// Represents a collection of <see cref="CompletionItem">completion items</see> to be presented
    /// in the editor.
    /// </summary>
    type CompletionList =
        CompletionList<CompletionItem>

    /// <summary>
    /// Represents a collection of <see cref="CompletionItem">completion items</see> to be presented
    /// in the editor.
    /// </summary>
    type [<AllowNullLiteral>] CompletionList<'T when 'T :> CompletionItem> =
        /// This list is not complete. Further typing should result in recomputing
        /// this list.
        abstract isIncomplete: bool option with get, set
        /// The completion items.
        abstract items: ResizeArray<'T> with get, set

    /// <summary>
    /// Represents a collection of <see cref="CompletionItem">completion items</see> to be presented
    /// in the editor.
    /// </summary>
    type [<AllowNullLiteral>] CompletionListStatic =
        /// <summary>Creates a new completion list.</summary>
        /// <param name="items">The completion items.</param>
        /// <param name="isIncomplete">The list is not complete.</param>
        [<EmitConstructor>] abstract Create: ?items: ResizeArray<'T> * ?isIncomplete: bool -> CompletionList<'T>

    /// <summary>How a <see cref="CompletionItemProvider">completion provider</see> was triggered</summary>
    type [<RequireQualifiedAccess>] CompletionTriggerKind =
        /// Completion was triggered normally.
        | Invoke = 0
        /// Completion was triggered by a trigger character.
        | TriggerCharacter = 1
        /// Completion was re-triggered as current completion list is incomplete
        | TriggerForIncompleteCompletions = 2

    /// <summary>
    /// Contains additional information about the context in which
    /// <see cref="CompletionItemProvider.provideCompletionItems">completion provider</see> is triggered.
    /// </summary>
    type [<AllowNullLiteral>] CompletionContext =
        /// How the completion was triggered.
        abstract triggerKind: CompletionTriggerKind
        /// <summary>
        /// Character that triggered the completion item provider.
        ///
        /// <c>undefined</c> if the provider was not triggered by a character.
        ///
        /// The trigger character is already in the document when the completion provider is triggered.
        /// </summary>
        abstract triggerCharacter: string option

    /// <summary>
    /// The completion item provider interface defines the contract between extensions and
    /// <see href="https://code.visualstudio.com/docs/editor/intellisense">IntelliSense</see>.
    ///
    /// Providers can delay the computation of the {@linkcode CompletionItem.detail detail}
    /// and {@linkcode CompletionItem.documentation documentation} properties by implementing the
    /// {@linkcode CompletionItemProvider.resolveCompletionItem resolveCompletionItem}-function. However, properties that
    /// are needed for the initial sorting and filtering, like <c>sortText</c>, <c>filterText</c>, <c>insertText</c>, and <c>range</c>, must
    /// not be changed during resolve.
    ///
    /// Providers are asked for completions either explicitly by a user gesture or -depending on the configuration-
    /// implicitly when typing words or trigger characters.
    /// </summary>
    type CompletionItemProvider =
        CompletionItemProvider<CompletionItem>

    /// <summary>
    /// The completion item provider interface defines the contract between extensions and
    /// <see href="https://code.visualstudio.com/docs/editor/intellisense">IntelliSense</see>.
    ///
    /// Providers can delay the computation of the {@linkcode CompletionItem.detail detail}
    /// and {@linkcode CompletionItem.documentation documentation} properties by implementing the
    /// {@linkcode CompletionItemProvider.resolveCompletionItem resolveCompletionItem}-function. However, properties that
    /// are needed for the initial sorting and filtering, like <c>sortText</c>, <c>filterText</c>, <c>insertText</c>, and <c>range</c>, must
    /// not be changed during resolve.
    ///
    /// Providers are asked for completions either explicitly by a user gesture or -depending on the configuration-
    /// implicitly when typing words or trigger characters.
    /// </summary>
    type [<AllowNullLiteral>] CompletionItemProvider<'T when 'T :> CompletionItem> =
        /// <summary>Provide completion items for the given position and document.</summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="position">The position at which the command was invoked.</param>
        /// <param name="token">A cancellation token.</param>
        /// <param name="context">How the completion was triggered.</param>
        /// <returns>
        /// An array of completions, a <see cref="CompletionList">completion list</see>, or a thenable that resolves to either.
        /// The lack of a result can be signaled by returning <c>undefined</c>, <c>null</c>, or an empty array.
        /// </returns>
        abstract provideCompletionItems: document: TextDocument * position: Position * token: CancellationToken * context: CompletionContext -> ProviderResult<U2<ResizeArray<'T>, CompletionList<'T>>>
        /// <summary>
        /// Given a completion item fill in more data, like <see cref="CompletionItem.documentation">doc-comment</see>
        /// or <see cref="CompletionItem.detail">details</see>.
        ///
        /// The editor will only resolve a completion item once.
        ///
        /// *Note* that this function is called when completion items are already showing in the UI or when an item has been
        /// selected for insertion. Because of that, no property that changes the presentation (label, sorting, filtering etc)
        /// or the (primary) insert behaviour (<see cref="CompletionItem.insertText">insertText</see>) can be changed.
        ///
        /// This function may fill in <see cref="CompletionItem.additionalTextEdits">additionalTextEdits</see>. However, that means an item might be
        /// inserted *before* resolving is done and in that case the editor will do a best effort to still apply those additional
        /// text edits.
        /// </summary>
        /// <param name="item">A completion item currently active in the UI.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>
        /// The resolved completion item or a thenable that resolves to of such. It is OK to return the given
        /// <c>item</c>. When no result is returned, the given <c>item</c> will be used.
        /// </returns>
        abstract resolveCompletionItem: item: 'T * token: CancellationToken -> ProviderResult<'T>

    /// A document link is a range in a text document that links to an internal or external resource, like another
    /// text document or a web site.
    type [<AllowNullLiteral>] DocumentLink =
        /// The range this link applies to.
        abstract range: Range with get, set
        /// The uri this link points to.
        abstract target: Uri option with get, set
        /// <summary>
        /// The tooltip text when you hover over this link.
        ///
        /// If a tooltip is provided, is will be displayed in a string that includes instructions on how to
        /// trigger the link, such as <c>{0} (ctrl + click)</c>. The specific instructions vary depending on OS,
        /// user settings, and localization.
        /// </summary>
        abstract tooltip: string option with get, set

    /// A document link is a range in a text document that links to an internal or external resource, like another
    /// text document or a web site.
    type [<AllowNullLiteral>] DocumentLinkStatic =
        /// <summary>Creates a new document link.</summary>
        /// <param name="range">The range the document link applies to. Must not be empty.</param>
        /// <param name="target">The uri the document link points to.</param>
        [<EmitConstructor>] abstract Create: range: Range * ?target: Uri -> DocumentLink

    /// The document link provider defines the contract between extensions and feature of showing
    /// links in the editor.
    type DocumentLinkProvider =
        DocumentLinkProvider<DocumentLink>

    /// The document link provider defines the contract between extensions and feature of showing
    /// links in the editor.
    type [<AllowNullLiteral>] DocumentLinkProvider<'T when 'T :> DocumentLink> =
        /// <summary>
        /// Provide links for the given document. Note that the editor ships with a default provider that detects
        /// <c>http(s)</c> and <c>file</c> links.
        /// </summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>
        /// An array of <see cref="DocumentLink">document links</see> or a thenable that resolves to such. The lack of a result
        /// can be signaled by returning <c>undefined</c>, <c>null</c>, or an empty array.
        /// </returns>
        abstract provideDocumentLinks: document: TextDocument * token: CancellationToken -> ProviderResult<ResizeArray<'T>>
        /// <summary>
        /// Given a link fill in its <see cref="DocumentLink.target">target</see>. This method is called when an incomplete
        /// link is selected in the UI. Providers can implement this method and return incomplete links
        /// (without target) from the {@linkcode DocumentLinkProvider.provideDocumentLinks provideDocumentLinks} method which
        /// often helps to improve performance.
        /// </summary>
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
        [<EmitConstructor>] abstract Create: red: float * green: float * blue: float * alpha: float -> Color

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
        [<EmitConstructor>] abstract Create: range: Range * color: Color -> ColorInformation

    /// <summary>
    /// A color presentation object describes how a {@linkcode Color} should be represented as text and what
    /// edits are required to refer to it from source code.
    ///
    /// For some languages one color can have multiple presentations, e.g. css can represent the color red with
    /// the constant <c>Red</c>, the hex-value <c>#ff0000</c>, or in rgba and hsla forms. In csharp other representations
    /// apply, e.g. <c>System.Drawing.Color.Red</c>.
    /// </summary>
    type [<AllowNullLiteral>] ColorPresentation =
        /// The label of this color presentation. It will be shown on the color
        /// picker header. By default this is also the text that is inserted when selecting
        /// this color presentation.
        abstract label: string with get, set
        /// <summary>
        /// An <see cref="TextEdit">edit</see> which is applied to a document when selecting
        /// this presentation for the color.  When <c>falsy</c> the <see cref="ColorPresentation.label">label</see>
        /// is used.
        /// </summary>
        abstract textEdit: TextEdit option with get, set
        /// <summary>
        /// An optional array of additional <see cref="TextEdit">text edits</see> that are applied when
        /// selecting this color presentation. Edits must not overlap with the main <see cref="ColorPresentation.textEdit">edit</see> nor with themselves.
        /// </summary>
        abstract additionalTextEdits: ResizeArray<TextEdit> option with get, set

    /// <summary>
    /// A color presentation object describes how a {@linkcode Color} should be represented as text and what
    /// edits are required to refer to it from source code.
    ///
    /// For some languages one color can have multiple presentations, e.g. css can represent the color red with
    /// the constant <c>Red</c>, the hex-value <c>#ff0000</c>, or in rgba and hsla forms. In csharp other representations
    /// apply, e.g. <c>System.Drawing.Color.Red</c>.
    /// </summary>
    type [<AllowNullLiteral>] ColorPresentationStatic =
        /// <summary>Creates a new color presentation.</summary>
        /// <param name="label">The label of this color presentation.</param>
        [<EmitConstructor>] abstract Create: label: string -> ColorPresentation

    /// The document color provider defines the contract between extensions and feature of
    /// picking and modifying colors in the editor.
    type [<AllowNullLiteral>] DocumentColorProvider =
        /// <summary>Provide colors for the given document.</summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>
        /// An array of <see cref="ColorInformation">color information</see> or a thenable that resolves to such. The lack of a result
        /// can be signaled by returning <c>undefined</c>, <c>null</c>, or an empty array.
        /// </returns>
        abstract provideDocumentColors: document: TextDocument * token: CancellationToken -> ProviderResult<ResizeArray<ColorInformation>>
        /// <summary>Provide <see cref="ColorPresentation">representations</see> for a color.</summary>
        /// <param name="color">The color to show and insert.</param>
        /// <param name="context">A context object with additional information</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>
        /// An array of color presentations or a thenable that resolves to such. The lack of a result
        /// can be signaled by returning <c>undefined</c>, <c>null</c>, or an empty array.
        /// </returns>
        abstract provideColorPresentations: color: Color * context: {| document: TextDocument; range: Range |} * token: CancellationToken -> ProviderResult<ResizeArray<ColorPresentation>>

    /// Inlay hint kinds.
    ///
    /// The kind of an inline hint defines its appearance, e.g the corresponding foreground and background colors are being
    /// used.
    type [<RequireQualifiedAccess>] InlayHintKind =
        /// An inlay hint that for a type annotation.
        | Type = 1
        /// An inlay hint that is for a parameter.
        | Parameter = 2

    /// An inlay hint label part allows for interactive and composite labels of inlay hints.
    type [<AllowNullLiteral>] InlayHintLabelPart =
        /// The value of this label part.
        abstract value: string with get, set
        /// <summary>
        /// The tooltip text when you hover over this label part.
        ///
        /// *Note* that this property can be set late during
        /// <see cref="InlayHintsProvider.resolveInlayHint">resolving</see> of inlay hints.
        /// </summary>
        abstract tooltip: U2<string, MarkdownString> option with get, set
        /// <summary>
        /// An optional <see cref="Location">source code location</see> that represents this label
        /// part.
        ///
        /// The editor will use this location for the hover and for code navigation features: This
        /// part will become a clickable link that resolves to the definition of the symbol at the
        /// given location (not necessarily the location itself), it shows the hover that shows at
        /// the given location, and it shows a context menu with further code navigation commands.
        ///
        /// *Note* that this property can be set late during
        /// <see cref="InlayHintsProvider.resolveInlayHint">resolving</see> of inlay hints.
        /// </summary>
        abstract location: Location option with get, set
        /// <summary>
        /// An optional command for this label part.
        ///
        /// The editor renders parts with commands as clickable links. The command is added to the context menu
        /// when a label part defines <see cref="InlayHintLabelPart.location">location</see> and <see cref="InlayHintLabelPart.command">command</see> .
        ///
        /// *Note* that this property can be set late during
        /// <see cref="InlayHintsProvider.resolveInlayHint">resolving</see> of inlay hints.
        /// </summary>
        abstract command: Command option with get, set

    /// An inlay hint label part allows for interactive and composite labels of inlay hints.
    type [<AllowNullLiteral>] InlayHintLabelPartStatic =
        /// <summary>Creates a new inlay hint label part.</summary>
        /// <param name="value">The value of the part.</param>
        [<EmitConstructor>] abstract Create: value: string -> InlayHintLabelPart

    /// Inlay hint information.
    type [<AllowNullLiteral>] InlayHint =
        /// The position of this hint.
        abstract position: Position with get, set
        /// <summary>
        /// The label of this hint. A human readable string or an array of <see cref="InlayHintLabelPart">label parts</see>.
        ///
        /// *Note* that neither the string nor the label part can be empty.
        /// </summary>
        abstract label: U2<string, ResizeArray<InlayHintLabelPart>> with get, set
        /// <summary>
        /// The tooltip text when you hover over this item.
        ///
        /// *Note* that this property can be set late during
        /// <see cref="InlayHintsProvider.resolveInlayHint">resolving</see> of inlay hints.
        /// </summary>
        abstract tooltip: U2<string, MarkdownString> option with get, set
        /// The kind of this hint. The inlay hint kind defines the appearance of this inlay hint.
        abstract kind: InlayHintKind option with get, set
        /// <summary>
        /// Optional <see cref="TextEdit">text edits</see> that are performed when accepting this inlay hint. The default
        /// gesture for accepting an inlay hint is the double click.
        ///
        /// *Note* that edits are expected to change the document so that the inlay hint (or its nearest variant) is
        /// now part of the document and the inlay hint itself is now obsolete.
        ///
        /// *Note* that this property can be set late during
        /// <see cref="InlayHintsProvider.resolveInlayHint">resolving</see> of inlay hints.
        /// </summary>
        abstract textEdits: ResizeArray<TextEdit> option with get, set
        /// Render padding before the hint. Padding will use the editor's background color,
        /// not the background color of the hint itself. That means padding can be used to visually
        /// align/separate an inlay hint.
        abstract paddingLeft: bool option with get, set
        /// Render padding after the hint. Padding will use the editor's background color,
        /// not the background color of the hint itself. That means padding can be used to visually
        /// align/separate an inlay hint.
        abstract paddingRight: bool option with get, set

    /// Inlay hint information.
    type [<AllowNullLiteral>] InlayHintStatic =
        /// <summary>Creates a new inlay hint.</summary>
        /// <param name="position">The position of the hint.</param>
        /// <param name="label">The label of the hint.</param>
        /// <param name="kind">The <see cref="InlayHintKind">kind</see> of the hint.</param>
        [<EmitConstructor>] abstract Create: position: Position * label: U2<string, ResizeArray<InlayHintLabelPart>> * ?kind: InlayHintKind -> InlayHint

    /// The inlay hints provider interface defines the contract between extensions and
    /// the inlay hints feature.
    type InlayHintsProvider =
        InlayHintsProvider<InlayHint>

    /// The inlay hints provider interface defines the contract between extensions and
    /// the inlay hints feature.
    type [<AllowNullLiteral>] InlayHintsProvider<'T when 'T :> InlayHint> =
        /// An optional event to signal that inlay hints from this provider have changed.
        abstract onDidChangeInlayHints: Event<unit> option with get, set
        /// <summary>
        /// Provide inlay hints for the given range and document.
        ///
        /// *Note* that inlay hints that are not <see cref="Range.contains">contained</see> by the given range are ignored.
        /// </summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="range">The range for which inlay hints should be computed.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>An array of inlay hints or a thenable that resolves to such.</returns>
        abstract provideInlayHints: document: TextDocument * range: Range * token: CancellationToken -> ProviderResult<ResizeArray<'T>>
        /// <summary>
        /// Given an inlay hint fill in <see cref="InlayHint.tooltip">tooltip</see>, <see cref="InlayHint.textEdits">text edits</see>,
        /// or complete label <see cref="InlayHintLabelPart">parts</see>.
        ///
        /// *Note* that the editor will resolve an inlay hint at most once.
        /// </summary>
        /// <param name="hint">An inlay hint.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>The resolved inlay hint or a thenable that resolves to such. It is OK to return the given <c>item</c>. When no result is returned, the given <c>item</c> will be used.</returns>
        abstract resolveInlayHint: hint: 'T * token: CancellationToken -> ProviderResult<'T>

    /// A line based folding range. To be valid, start and end line must be bigger than zero and smaller than the number of lines in the document.
    /// Invalid ranges will be ignored.
    type [<AllowNullLiteral>] FoldingRange =
        /// The zero-based start line of the range to fold. The folded area starts after the line's last character.
        /// To be valid, the end must be zero or larger and smaller than the number of lines in the document.
        abstract start: float with get, set
        /// The zero-based end line of the range to fold. The folded area ends with the line's last character.
        /// To be valid, the end must be zero or larger and smaller than the number of lines in the document.
        abstract ``end``: float with get, set
        /// <summary>
        /// Describes the <see cref="FoldingRangeKind">Kind</see> of the folding range such as <see cref="FoldingRangeKind.Comment">Comment</see> or
        /// <see cref="FoldingRangeKind.Region">Region</see>. The kind is used to categorize folding ranges and used by commands
        /// like 'Fold all comments'. See
        /// <see cref="FoldingRangeKind" /> for an enumeration of all kinds.
        /// If not set, the range is originated from a syntax element.
        /// </summary>
        abstract kind: FoldingRangeKind option with get, set

    /// A line based folding range. To be valid, start and end line must be bigger than zero and smaller than the number of lines in the document.
    /// Invalid ranges will be ignored.
    type [<AllowNullLiteral>] FoldingRangeStatic =
        /// <summary>Creates a new folding range.</summary>
        /// <param name="start">The start line of the folded range.</param>
        /// <param name="end">The end line of the folded range.</param>
        /// <param name="kind">The kind of the folding range.</param>
        [<EmitConstructor>] abstract Create: start: float * ``end``: float * ?kind: FoldingRangeKind -> FoldingRange

    /// <summary>
    /// An enumeration of specific folding range kinds. The kind is an optional field of a <see cref="FoldingRange" />
    /// and is used to distinguish specific folding ranges such as ranges originated from comments. The kind is used by commands like
    /// <c>Fold all comments</c> or <c>Fold all regions</c>.
    /// If the kind is not set on the range, the range originated from a syntax element other than comments, imports or region markers.
    /// </summary>
    type [<RequireQualifiedAccess>] FoldingRangeKind =
        /// Kind for folding range representing a comment.
        | Comment = 1
        /// Kind for folding range representing a import.
        | Imports = 2
        /// <summary>Kind for folding range representing regions originating from folding markers like <c>#region</c> and <c>#endregion</c>.</summary>
        | Region = 3

    /// Folding context (for future use)
    type [<AllowNullLiteral>] FoldingContext =
        interface end

    /// <summary>
    /// The folding range provider interface defines the contract between extensions and
    /// <see href="https://code.visualstudio.com/docs/editor/codebasics#_folding">Folding</see> in the editor.
    /// </summary>
    type [<AllowNullLiteral>] FoldingRangeProvider =
        /// An optional event to signal that the folding ranges from this provider have changed.
        abstract onDidChangeFoldingRanges: Event<unit> option with get, set
        /// <summary>
        /// Returns a list of folding ranges or null and undefined if the provider
        /// does not want to participate or was cancelled.
        /// </summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="context">Additional context information (for future use)</param>
        /// <param name="token">A cancellation token.</param>
        abstract provideFoldingRanges: document: TextDocument * context: FoldingContext * token: CancellationToken -> ProviderResult<ResizeArray<FoldingRange>>

    /// A selection range represents a part of a selection hierarchy. A selection range
    /// may have a parent selection range that contains it.
    type [<AllowNullLiteral>] SelectionRange =
        /// <summary>The <see cref="Range" /> of this selection range.</summary>
        abstract range: Range with get, set
        /// The parent selection range containing this range.
        abstract parent: SelectionRange option with get, set

    /// A selection range represents a part of a selection hierarchy. A selection range
    /// may have a parent selection range that contains it.
    type [<AllowNullLiteral>] SelectionRangeStatic =
        /// <summary>Creates a new selection range.</summary>
        /// <param name="range">The range of the selection range.</param>
        /// <param name="parent">The parent of the selection range.</param>
        [<EmitConstructor>] abstract Create: range: Range * ?parent: SelectionRange -> SelectionRange

    type [<AllowNullLiteral>] SelectionRangeProvider =
        /// <summary>
        /// Provide selection ranges for the given positions.
        ///
        /// Selection ranges should be computed individually and independent for each position. The editor will merge
        /// and deduplicate ranges but providers must return hierarchies of selection ranges so that a range
        /// is <see cref="Range.contains">contained</see> by its parent.
        /// </summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="positions">The positions at which the command was invoked.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>
        /// Selection ranges or a thenable that resolves to such. The lack of a result can be
        /// signaled by returning <c>undefined</c> or <c>null</c>.
        /// </returns>
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
        /// Must be contained by the {@linkcode CallHierarchyItem.range range}.
        abstract selectionRange: Range with get, set

    /// Represents programming constructs like functions or constructors in the context
    /// of call hierarchy.
    type [<AllowNullLiteral>] CallHierarchyItemStatic =
        /// Creates a new call hierarchy item.
        [<EmitConstructor>] abstract Create: kind: SymbolKind * name: string * detail: string * uri: Uri * range: Range * selectionRange: Range -> CallHierarchyItem

    /// Represents an incoming call, e.g. a caller of a method or constructor.
    type [<AllowNullLiteral>] CallHierarchyIncomingCall =
        /// The item that makes the call.
        abstract from: CallHierarchyItem with get, set
        /// The range at which at which the calls appears. This is relative to the caller
        /// denoted by {@linkcode CallHierarchyIncomingCall.from this.from}.
        abstract fromRanges: ResizeArray<Range> with get, set

    /// Represents an incoming call, e.g. a caller of a method or constructor.
    type [<AllowNullLiteral>] CallHierarchyIncomingCallStatic =
        /// <summary>Create a new call object.</summary>
        /// <param name="item">The item making the call.</param>
        /// <param name="fromRanges">The ranges at which the calls appear.</param>
        [<EmitConstructor>] abstract Create: item: CallHierarchyItem * fromRanges: ResizeArray<Range> -> CallHierarchyIncomingCall

    /// Represents an outgoing call, e.g. calling a getter from a method or a method from a constructor etc.
    type [<AllowNullLiteral>] CallHierarchyOutgoingCall =
        /// The item that is called.
        abstract ``to``: CallHierarchyItem with get, set
        /// The range at which this item is called. This is the range relative to the caller, e.g the item
        /// passed to {@linkcode CallHierarchyProvider.provideCallHierarchyOutgoingCalls provideCallHierarchyOutgoingCalls}
        /// and not {@linkcode CallHierarchyOutgoingCall.to this.to}.
        abstract fromRanges: ResizeArray<Range> with get, set

    /// Represents an outgoing call, e.g. calling a getter from a method or a method from a constructor etc.
    type [<AllowNullLiteral>] CallHierarchyOutgoingCallStatic =
        /// <summary>Create a new call object.</summary>
        /// <param name="item">The item being called</param>
        /// <param name="fromRanges">The ranges at which the calls appear.</param>
        [<EmitConstructor>] abstract Create: item: CallHierarchyItem * fromRanges: ResizeArray<Range> -> CallHierarchyOutgoingCall

    /// The call hierarchy provider interface describes the contract between extensions
    /// and the call hierarchy feature which allows to browse calls and caller of function,
    /// methods, constructor etc.
    type [<AllowNullLiteral>] CallHierarchyProvider =
        /// <summary>
        /// Bootstraps call hierarchy by returning the item that is denoted by the given document
        /// and position. This item will be used as entry into the call graph. Providers should
        /// return <c>undefined</c> or <c>null</c> when there is no item at the given location.
        /// </summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="position">The position at which the command was invoked.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>
        /// One or multiple call hierarchy items or a thenable that resolves to such. The lack of a result can be
        /// signaled by returning <c>undefined</c>, <c>null</c>, or an empty array.
        /// </returns>
        abstract prepareCallHierarchy: document: TextDocument * position: Position * token: CancellationToken -> ProviderResult<U2<CallHierarchyItem, ResizeArray<CallHierarchyItem>>>
        /// <summary>
        /// Provide all incoming calls for an item, e.g all callers for a method. In graph terms this describes directed
        /// and annotated edges inside the call graph, e.g the given item is the starting node and the result is the nodes
        /// that can be reached.
        /// </summary>
        /// <param name="item">The hierarchy item for which incoming calls should be computed.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>
        /// A set of incoming calls or a thenable that resolves to such. The lack of a result can be
        /// signaled by returning <c>undefined</c> or <c>null</c>.
        /// </returns>
        abstract provideCallHierarchyIncomingCalls: item: CallHierarchyItem * token: CancellationToken -> ProviderResult<ResizeArray<CallHierarchyIncomingCall>>
        /// <summary>
        /// Provide all outgoing calls for an item, e.g call calls to functions, methods, or constructors from the given item. In
        /// graph terms this describes directed and annotated edges inside the call graph, e.g the given item is the starting
        /// node and the result is the nodes that can be reached.
        /// </summary>
        /// <param name="item">The hierarchy item for which outgoing calls should be computed.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>
        /// A set of outgoing calls or a thenable that resolves to such. The lack of a result can be
        /// signaled by returning <c>undefined</c> or <c>null</c>.
        /// </returns>
        abstract provideCallHierarchyOutgoingCalls: item: CallHierarchyItem * token: CancellationToken -> ProviderResult<ResizeArray<CallHierarchyOutgoingCall>>

    /// Represents an item of a type hierarchy, like a class or an interface.
    type [<AllowNullLiteral>] TypeHierarchyItem =
        /// The name of this item.
        abstract name: string with get, set
        /// The kind of this item.
        abstract kind: SymbolKind with get, set
        /// Tags for this item.
        abstract tags: ReadonlyArray<SymbolTag> option with get, set
        /// More detail for this item, e.g. the signature of a function.
        abstract detail: string option with get, set
        /// The resource identifier of this item.
        abstract uri: Uri with get, set
        /// The range enclosing this symbol not including leading/trailing whitespace
        /// but everything else, e.g. comments and code.
        abstract range: Range with get, set
        /// <summary>
        /// The range that should be selected and revealed when this symbol is being
        /// picked, e.g. the name of a class. Must be contained by the <see cref="TypeHierarchyItem.range">range</see>-property.
        /// </summary>
        abstract selectionRange: Range with get, set

    /// Represents an item of a type hierarchy, like a class or an interface.
    type [<AllowNullLiteral>] TypeHierarchyItemStatic =
        /// <summary>Creates a new type hierarchy item.</summary>
        /// <param name="kind">The kind of the item.</param>
        /// <param name="name">The name of the item.</param>
        /// <param name="detail">The details of the item.</param>
        /// <param name="uri">The Uri of the item.</param>
        /// <param name="range">The whole range of the item.</param>
        /// <param name="selectionRange">The selection range of the item.</param>
        [<EmitConstructor>] abstract Create: kind: SymbolKind * name: string * detail: string * uri: Uri * range: Range * selectionRange: Range -> TypeHierarchyItem

    /// The type hierarchy provider interface describes the contract between extensions
    /// and the type hierarchy feature.
    type [<AllowNullLiteral>] TypeHierarchyProvider =
        /// <summary>
        /// Bootstraps type hierarchy by returning the item that is denoted by the given document
        /// and position. This item will be used as entry into the type graph. Providers should
        /// return <c>undefined</c> or <c>null</c> when there is no item at the given location.
        /// </summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="position">The position at which the command was invoked.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>
        /// One or multiple type hierarchy items or a thenable that resolves to such. The lack of a result can be
        /// signaled by returning <c>undefined</c>, <c>null</c>, or an empty array.
        /// </returns>
        abstract prepareTypeHierarchy: document: TextDocument * position: Position * token: CancellationToken -> ProviderResult<U2<TypeHierarchyItem, ResizeArray<TypeHierarchyItem>>>
        /// <summary>
        /// Provide all supertypes for an item, e.g all types from which a type is derived/inherited. In graph terms this describes directed
        /// and annotated edges inside the type graph, e.g the given item is the starting node and the result is the nodes
        /// that can be reached.
        /// </summary>
        /// <param name="item">The hierarchy item for which super types should be computed.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>
        /// A set of direct supertypes or a thenable that resolves to such. The lack of a result can be
        /// signaled by returning <c>undefined</c> or <c>null</c>.
        /// </returns>
        abstract provideTypeHierarchySupertypes: item: TypeHierarchyItem * token: CancellationToken -> ProviderResult<ResizeArray<TypeHierarchyItem>>
        /// <summary>
        /// Provide all subtypes for an item, e.g all types which are derived/inherited from the given item. In
        /// graph terms this describes directed and annotated edges inside the type graph, e.g the given item is the starting
        /// node and the result is the nodes that can be reached.
        /// </summary>
        /// <param name="item">The hierarchy item for which subtypes should be computed.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>
        /// A set of direct subtypes or a thenable that resolves to such. The lack of a result can be
        /// signaled by returning <c>undefined</c> or <c>null</c>.
        /// </returns>
        abstract provideTypeHierarchySubtypes: item: TypeHierarchyItem * token: CancellationToken -> ProviderResult<ResizeArray<TypeHierarchyItem>>

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
        [<EmitConstructor>] abstract Create: ranges: ResizeArray<Range> * ?wordPattern: RegExp -> LinkedEditingRanges

    /// The linked editing range provider interface defines the contract between extensions and
    /// the linked editing feature.
    type [<AllowNullLiteral>] LinkedEditingRangeProvider =
        /// <summary>
        /// For a given position in a document, returns the range of the symbol at the position and all ranges
        /// that have the same content. A change to one of the ranges can be applied to all other ranges if the new content
        /// is valid. An optional word pattern can be returned with the result to describe valid contents.
        /// If no result-specific word pattern is provided, the word pattern from the language configuration is used.
        /// </summary>
        /// <param name="document">The document in which the provider was invoked.</param>
        /// <param name="position">The position at which the provider was invoked.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>A list of ranges that can be edited together</returns>
        abstract provideLinkedEditingRanges: document: TextDocument * position: Position * token: CancellationToken -> ProviderResult<LinkedEditingRanges>

    /// A tuple of two characters, like a pair of
    /// opening and closing brackets.
    type CharacterPair =
        string * string

    /// Describes how comments for a language work.
    type [<AllowNullLiteral>] CommentRule =
        /// <summary>The line comment token, like <c>// this is a comment</c></summary>
        abstract lineComment: string option with get, set
        /// <summary>The block comment character pair, like <c>/* block comment *&amp;#47;</c></summary>
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

    /// Describes what to do with the indentation when pressing Enter.
    type [<RequireQualifiedAccess>] IndentAction =
        /// Insert new line and copy the previous line's indentation.
        | None = 0
        /// Insert new line and indent once (relative to the previous line's indentation).
        | Indent = 1
        /// Insert two new lines:
        ///   - the first one indented which will hold the cursor
        ///   - the second one at the same indentation level
        | IndentOutdent = 2
        /// Insert new line and outdent once (relative to the previous line's indentation).
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
        [<Obsolete("Will be replaced by a better API soon.")>]
        abstract __electricCharacterSupport: {| brackets: obj option; docComment: {| scope: string; ``open``: string; lineStart: string; close: string option |} option |} option with get, set
        /// **Deprecated** Do not use.
        [<Obsolete("Use the autoClosingPairs property in the language configuration file instead.")>]
        abstract __characterPairSupport: {| autoClosingPairs: ResizeArray<{| ``open``: string; close: string; notIn: ResizeArray<string> option |}> |} option with get, set

    /// The configuration target
    type [<RequireQualifiedAccess>] ConfigurationTarget =
        /// Global configuration
        | Global = 1
        /// Workspace configuration
        | Workspace = 2
        /// Workspace folder configuration
        | WorkspaceFolder = 3

    /// <summary>
    /// Represents the configuration. It is a merged view of
    ///
    /// - *Default Settings*
    /// - *Global (User) Settings*
    /// - *Workspace settings*
    /// - *Workspace Folder settings* - From one of the <see cref="workspace.workspaceFolders">Workspace Folders</see> under which requested resource belongs to.
    /// - *Language settings* - Settings defined under requested language.
    ///
    /// The *effective* value (returned by {@linkcode WorkspaceConfiguration.get get}) is computed by overriding or merging the values in the following order:
    ///
    /// 1. <c>defaultValue</c> (if defined in <c>package.json</c> otherwise derived from the value's type)
    /// 1. <c>globalValue</c> (if defined)
    /// 1. <c>workspaceValue</c> (if defined)
    /// 1. <c>workspaceFolderValue</c> (if defined)
    /// 1. <c>defaultLanguageValue</c> (if defined)
    /// 1. <c>globalLanguageValue</c> (if defined)
    /// 1. <c>workspaceLanguageValue</c> (if defined)
    /// 1. <c>workspaceFolderLanguageValue</c> (if defined)
    ///
    /// **Note:** Only <c>object</c> value types are merged and all other value types are overridden.
    ///
    /// Example 1: Overriding
    ///
    /// <code lang="ts">
    /// defaultValue = 'on';
    /// globalValue = 'relative'
    /// workspaceFolderValue = 'off'
    /// value = 'off'
    /// </code>
    ///
    /// Example 2: Language Values
    ///
    /// <code lang="ts">
    /// defaultValue = 'on';
    /// globalValue = 'relative'
    /// workspaceFolderValue = 'off'
    /// globalLanguageValue = 'on'
    /// value = 'on'
    /// </code>
    ///
    /// Example 3: Object Values
    ///
    /// <code lang="ts">
    /// defaultValue = { "a": 1, "b": 2 };
    /// globalValue = { "b": 3, "c": 4 };
    /// value = { "a": 1, "b": 3, "c": 4 };
    /// </code>
    ///
    /// *Note:* Workspace and Workspace Folder configurations contains <c>launch</c> and <c>tasks</c> settings. Their basename will be
    /// part of the section identifier. The following snippets shows how to retrieve all configurations
    /// from <c>launch.json</c>:
    ///
    /// <code lang="ts">
    /// // launch.json configuration
    /// const config = workspace.getConfiguration('launch', vscode.workspace.workspaceFolders[0].uri);
    ///
    /// // retrieve values
    /// const values = config.get('configurations');
    /// </code>
    ///
    /// Refer to <see href="https://code.visualstudio.com/docs/getstarted/settings">Settings</see> for more information.
    /// </summary>
    type [<AllowNullLiteral>] WorkspaceConfiguration =
        /// <summary>Return a value from this configuration.</summary>
        /// <param name="section">Configuration name, supports _dotted_ names.</param>
        /// <returns>The value <c>section</c> denotes or <c>undefined</c>.</returns>
        abstract get: section: string -> 'T option
        /// <summary>Return a value from this configuration.</summary>
        /// <param name="section">Configuration name, supports _dotted_ names.</param>
        /// <param name="defaultValue">A value should be returned when no value could be found, is <c>undefined</c>.</param>
        /// <returns>The value <c>section</c> denotes or the default.</returns>
        abstract get: section: string * defaultValue: 'T -> 'T
        /// <summary>Check if this configuration has a certain value.</summary>
        /// <param name="section">Configuration name, supports _dotted_ names.</param>
        /// <returns><c>true</c> if the section doesn't resolve to <c>undefined</c>.</returns>
        abstract has: section: string -> bool
        /// <summary>
        /// Retrieve all information about a configuration setting. A configuration value
        /// often consists of a *default* value, a global or installation-wide value,
        /// a workspace-specific value, folder-specific value
        /// and language-specific values (if <see cref="WorkspaceConfiguration" /> is scoped to a language).
        ///
        /// Also provides all language ids under which the given configuration setting is defined.
        ///
        /// *Note:* The configuration name must denote a leaf in the configuration tree
        /// (<c>editor.fontSize</c> vs <c>editor</c>) otherwise no result is returned.
        /// </summary>
        /// <param name="section">Configuration name, supports _dotted_ names.</param>
        /// <returns>Information about a configuration setting or <c>undefined</c>.</returns>
        abstract inspect: section: string -> WorkspaceConfigurationInspect<'T> option
        /// <summary>
        /// Update a configuration value. The updated configuration values are persisted.
        ///
        /// A value can be changed in
        ///
        /// - <see cref="ConfigurationTarget.Global">Global settings</see>: Changes the value for all instances of the editor.
        /// - <see cref="ConfigurationTarget.Workspace">Workspace settings</see>: Changes the value for current workspace, if available.
        /// - <see cref="ConfigurationTarget.WorkspaceFolder">Workspace folder settings</see>: Changes the value for settings from one of the <see cref="workspace.workspaceFolders">Workspace Folders</see> under which the requested resource belongs to.
        /// - Language settings: Changes the value for the requested languageId.
        ///
        /// *Note:* To remove a configuration value use <c>undefined</c>, like so: <c>config.update('somekey', undefined)</c>
        /// </summary>
        /// <param name="section">Configuration name, supports _dotted_ names.</param>
        /// <param name="value">The new value.</param>
        /// <param name="configurationTarget">
        /// The <see cref="ConfigurationTarget">configuration target</see> or a boolean value.
        /// - If <c>true</c> updates <see cref="ConfigurationTarget.Global">Global settings</see>.
        /// - If <c>false</c> updates <see cref="ConfigurationTarget.Workspace">Workspace settings</see>.
        /// - If <c>undefined</c> or <c>null</c> updates to <see cref="ConfigurationTarget.WorkspaceFolder">Workspace folder settings</see> if configuration is resource specific,
        /// otherwise to <see cref="ConfigurationTarget.Workspace">Workspace settings</see>.
        /// </param>
        /// <param name="overrideInLanguage">
        /// Whether to update the value in the scope of requested languageId or not.
        /// - If <c>true</c> updates the value under the requested languageId.
        /// - If <c>undefined</c> updates the value under the requested languageId only if the configuration is defined for the language.
        /// </param>
        /// <exception cref="">
        /// error while updating
        /// - configuration which is not registered.
        /// - window configuration to workspace folder
        /// - configuration to workspace or workspace folder when no workspace is opened.
        /// - configuration to workspace folder when there is no workspace folder settings.
        /// - configuration to workspace folder when <see cref="WorkspaceConfiguration" /> is not scoped to a resource.
        /// </exception>
        abstract update: section: string * value: obj option * ?configurationTarget: U2<ConfigurationTarget, bool> * ?overrideInLanguage: bool -> Thenable<unit>
        /// Readable dictionary that backs this configuration.
        [<EmitIndexer>] abstract Item: key: string -> obj option

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
        [<EmitConstructor>] abstract Create: uri: Uri * rangeOrPosition: U2<Range, Position> -> Location

    /// <summary>
    /// Represents the connection of two locations. Provides additional metadata over normal <see cref="Location">locations</see>,
    /// including an origin range.
    /// </summary>
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

    /// Represents the severity of diagnostics.
    type [<RequireQualifiedAccess>] DiagnosticSeverity =
        /// Something not allowed by the rules of a language or other means.
        | Error = 0
        /// Something suspicious but allowed.
        | Warning = 1
        /// Something to inform about but not a problem.
        | Information = 2
        /// Something to hint to a better way of doing it, like proposing
        /// a refactoring.
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
        [<EmitConstructor>] abstract Create: location: Location * message: string -> DiagnosticRelatedInformation

    /// Additional metadata about the type of a diagnostic.
    type [<RequireQualifiedAccess>] DiagnosticTag =
        /// <summary>
        /// Unused or unnecessary code.
        ///
        /// Diagnostics with this tag are rendered faded out. The amount of fading
        /// is controlled by the <c>"editorUnnecessaryCode.opacity"</c> theme color. For
        /// example, <c>"editorUnnecessaryCode.opacity": "#000000c0"</c> will render the
        /// code with 75% opacity. For high contrast themes, use the
        /// <c>"editorUnnecessaryCode.border"</c> theme color to underline unnecessary code
        /// instead of fading it out.
        /// </summary>
        | Unnecessary = 1
        /// Deprecated or obsolete code.
        ///
        /// Diagnostics with this tag are rendered with a strike through.
        | Deprecated = 2

    /// Represents a diagnostic, such as a compiler error or warning. Diagnostic objects
    /// are only valid in the scope of a file.
    type [<AllowNullLiteral>] Diagnostic =
        /// The range to which this diagnostic applies.
        abstract range: Range with get, set
        /// The human-readable message.
        abstract message: string with get, set
        /// <summary>The severity, default is <see cref="DiagnosticSeverity.Error">error</see>.</summary>
        abstract severity: DiagnosticSeverity with get, set
        /// A human-readable string describing the source of this
        /// diagnostic, e.g. 'typescript' or 'super lint'.
        abstract source: string option with get, set
        /// <summary>
        /// A code or identifier for this diagnostic.
        /// Should be used for later processing, e.g. when providing <see cref="CodeActionContext">code actions</see>.
        /// </summary>
        abstract code: U3<string, float, {| value: U2<string, float>; target: Uri |}> option with get, set
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
        /// <param name="severity">The severity, default is <see cref="DiagnosticSeverity.Error">error</see>.</param>
        [<EmitConstructor>] abstract Create: range: Range * message: string * ?severity: DiagnosticSeverity -> Diagnostic

    /// <summary>
    /// A diagnostics collection is a container that manages a set of
    /// <see cref="Diagnostic">diagnostics</see>. Diagnostics are always scopes to a
    /// diagnostics collection and a resource.
    ///
    /// To get an instance of a <c>DiagnosticCollection</c> use
    /// <see cref="languages.createDiagnosticCollection">createDiagnosticCollection</see>.
    /// </summary>
    type [<AllowNullLiteral>] DiagnosticCollection =
        /// <summary>
        /// The name of this diagnostic collection, for instance <c>typescript</c>. Every diagnostic
        /// from this collection will be associated with this name. Also, the task framework uses this
        /// name when defining <see href="https://code.visualstudio.com/docs/editor/tasks#_defining-a-problem-matcher">problem matchers</see>.
        /// </summary>
        abstract name: string
        /// <summary>
        /// Assign diagnostics for given resource. Will replace
        /// existing diagnostics for that resource.
        /// </summary>
        /// <param name="uri">A resource identifier.</param>
        /// <param name="diagnostics">Array of diagnostics or <c>undefined</c></param>
        abstract set: uri: Uri * diagnostics: ResizeArray<Diagnostic> option -> unit
        /// <summary>
        /// Replace diagnostics for multiple resources in this collection.
        ///
        ///   _Note_ that multiple tuples of the same uri will be merged, e.g
        /// <c>[[file1, [d1]], [file1, [d2]]]</c> is equivalent to <c>[[file1, [d1, d2]]]</c>.
        /// If a diagnostics item is <c>undefined</c> as in <c>[file1, undefined]</c>
        /// all previous but not subsequent diagnostics are removed.
        /// </summary>
        /// <param name="entries">An array of tuples, like <c>[[file1, [d1, d2]], [file2, [d3, d4, d5]]]</c>, or <c>undefined</c>.</param>
        abstract set: entries: ResizeArray<Uri * ResizeArray<Diagnostic> option> -> unit
        /// <summary>
        /// Remove all diagnostics from this collection that belong
        /// to the provided <c>uri</c>. The same as <c>#set(uri, undefined)</c>.
        /// </summary>
        /// <param name="uri">A resource identifier.</param>
        abstract delete: uri: Uri -> unit
        /// <summary>
        /// Remove all diagnostics from this collection. The same
        /// as calling <c>#set(undefined)</c>;
        /// </summary>
        abstract clear: unit -> unit
        /// <summary>Iterate over each entry in this collection.</summary>
        /// <param name="callback">Function to execute for each entry.</param>
        /// <param name="thisArg">The <c>this</c> context used when invoking the handler function.</param>
        abstract forEach: callback: (Uri -> ResizeArray<Diagnostic> -> DiagnosticCollection -> obj option) * ?thisArg: obj -> unit
        /// <summary>
        /// Get the diagnostics for a given resource. *Note* that you cannot
        /// modify the diagnostics-array returned from this call.
        /// </summary>
        /// <param name="uri">A resource identifier.</param>
        /// <returns>An immutable array of <see cref="Diagnostic">diagnostics</see> or <c>undefined</c>.</returns>
        abstract get: uri: Uri -> ResizeArray<Diagnostic> option
        /// <summary>
        /// Check if this collection contains diagnostics for a
        /// given resource.
        /// </summary>
        /// <param name="uri">A resource identifier.</param>
        /// <returns><c>true</c> if this collection has diagnostic for the given resource.</returns>
        abstract has: uri: Uri -> bool
        /// <summary>
        /// Dispose and free associated resources. Calls
        /// <see cref="DiagnosticCollection.clear">clear</see>.
        /// </summary>
        abstract dispose: unit -> unit

    /// Represents the severity of a language status item.
    type [<RequireQualifiedAccess>] LanguageStatusSeverity =
        | Information = 0
        | Warning = 1
        | Error = 2

    /// A language status item is the preferred way to present language status reports for the active text editors,
    /// such as selected linter or notifying about a configuration problem.
    type [<AllowNullLiteral>] LanguageStatusItem =
        /// The identifier of this item.
        abstract id: string
        /// The short name of this item, like 'Java Language Status', etc.
        abstract name: string option with get, set
        /// <summary>
        /// A <see cref="DocumentSelector">selector</see> that defines for what editors
        /// this item shows.
        /// </summary>
        abstract selector: DocumentSelector with get, set
        /// <summary>
        /// The severity of this item.
        ///
        /// Defaults to <see cref="LanguageStatusSeverity.Information">information</see>. You can use this property to
        /// signal to users that there is a problem that needs attention, like a missing executable or an
        /// invalid configuration.
        /// </summary>
        abstract severity: LanguageStatusSeverity with get, set
        /// <summary>
        /// The text to show for the entry. You can embed icons in the text by leveraging the syntax:
        ///
        /// <c>My text $(icon-name) contains icons like $(icon-name) this one.</c>
        ///
        /// Where the icon-name is taken from the ThemeIcon <see href="https://code.visualstudio.com/api/references/icons-in-labels#icon-listing">icon set</see>, e.g.
        /// <c>light-bulb</c>, <c>thumbsup</c>, <c>zap</c> etc.
        /// </summary>
        abstract text: string with get, set
        /// Optional, human-readable details for this item.
        abstract detail: string option with get, set
        /// <summary>Controls whether the item is shown as "busy". Defaults to <c>false</c>.</summary>
        abstract busy: bool with get, set
        /// A {@linkcode Command command} for this item.
        abstract command: Command option with get, set
        /// Accessibility information used when a screen reader interacts with this item
        abstract accessibilityInformation: AccessibilityInformation option with get, set
        /// Dispose and free associated resources.
        abstract dispose: unit -> unit

    /// Denotes a location of an editor in the window. Editors can be arranged in a grid
    /// and each column represents one editor location in that grid by counting the editors
    /// in order of their appearance.
    type [<RequireQualifiedAccess>] ViewColumn =
        /// <summary>
        /// A *symbolic* editor column representing the currently active column. This value
        /// can be used when opening editors, but the *resolved* <see cref="TextEditor.viewColumn">viewColumn</see>-value
        /// of editors will always be <c>One</c>, <c>Two</c>, <c>Three</c>,... or <c>undefined</c> but never <c>Active</c>.
        /// </summary>
        | Active = -1
        /// <summary>
        /// A *symbolic* editor column representing the column to the side of the active one. This value
        /// can be used when opening editors, but the *resolved* <see cref="TextEditor.viewColumn">viewColumn</see>-value
        /// of editors will always be <c>One</c>, <c>Two</c>, <c>Three</c>,... or <c>undefined</c> but never <c>Beside</c>.
        /// </summary>
        | Beside = -2
        /// The first editor column.
        | One = 1
        /// The second editor column.
        | Two = 2
        /// The third editor column.
        | Three = 3
        /// The fourth editor column.
        | Four = 4
        /// The fifth editor column.
        | Five = 5
        /// The sixth editor column.
        | Six = 6
        /// The seventh editor column.
        | Seven = 7
        /// The eighth editor column.
        | Eight = 8
        /// The ninth editor column.
        | Nine = 9

    /// <summary>
    /// An output channel is a container for readonly textual information.
    ///
    /// To get an instance of an <c>OutputChannel</c> use
    /// <see cref="window.createOutputChannel">createOutputChannel</see>.
    /// </summary>
    type [<AllowNullLiteral>] OutputChannel =
        /// The human-readable name of this output channel.
        abstract name: string
        /// <summary>Append the given value to the channel.</summary>
        /// <param name="value">A string, falsy values will not be printed.</param>
        abstract append: value: string -> unit
        /// <summary>
        /// Append the given value and a line feed character
        /// to the channel.
        /// </summary>
        /// <param name="value">A string, falsy values will be printed.</param>
        abstract appendLine: value: string -> unit
        /// <summary>Replaces all output from the channel with the given value.</summary>
        /// <param name="value">A string, falsy values will not be printed.</param>
        abstract replace: value: string -> unit
        /// Removes all output from the channel.
        abstract clear: unit -> unit
        /// <summary>Reveal this channel in the UI.</summary>
        /// <param name="preserveFocus">When <c>true</c> the channel will not take focus.</param>
        abstract show: ?preserveFocus: bool -> unit
        /// <summary>Reveal this channel in the UI.</summary>
        /// <param name="column">This argument is **deprecated** and will be ignored.</param>
        /// <param name="preserveFocus">When <c>true</c> the channel will not take focus.</param>
        [<Obsolete("Use the overload with just one parameter (`show(preserveFocus?: boolean): void`).")>]
        abstract show: ?column: ViewColumn * ?preserveFocus: bool -> unit
        /// Hide this channel from the UI.
        abstract hide: unit -> unit
        /// Dispose and free associated resources.
        abstract dispose: unit -> unit

    /// Accessibility information which controls screen reader behavior.
    type [<AllowNullLiteral>] AccessibilityInformation =
        /// Label to be read out by a screen reader once the item has focus.
        abstract label: string
        /// <summary>
        /// Role of the widget which defines how a screen reader interacts with it.
        /// The role should be set in special cases when for example a tree-like element behaves like a checkbox.
        /// If role is not specified the editor will pick the appropriate role automatically.
        /// More about aria roles can be found here <see href="https://w3c.github.io/aria/#widget_roles" />
        /// </summary>
        abstract role: string option

    /// Represents the alignment of status bar items.
    type [<RequireQualifiedAccess>] StatusBarAlignment =
        /// Aligned to the left side.
        | Left = 1
        /// Aligned to the right side.
        | Right = 2

    /// A status bar item is a status bar contribution that can
    /// show text and icons and run a command on click.
    type [<AllowNullLiteral>] StatusBarItem =
        /// <summary>
        /// The identifier of this item.
        ///
        /// *Note*: if no identifier was provided by the {@linkcode window.createStatusBarItem}
        /// method, the identifier will match the <see cref="Extension.id">extension identifier</see>.
        /// </summary>
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
        /// <summary>
        /// The text to show for the entry. You can embed icons in the text by leveraging the syntax:
        ///
        /// <c>My text $(icon-name) contains icons like $(icon-name) this one.</c>
        ///
        /// Where the icon-name is taken from the ThemeIcon <see href="https://code.visualstudio.com/api/references/icons-in-labels#icon-listing">icon set</see>, e.g.
        /// <c>light-bulb</c>, <c>thumbsup</c>, <c>zap</c> etc.
        /// </summary>
        abstract text: string with get, set
        /// The tooltip text when you hover over this entry.
        abstract tooltip: U2<string, MarkdownString> option with get, set
        /// The foreground color for this entry.
        abstract color: U2<string, ThemeColor> option with get, set
        /// <summary>
        /// The background color for this entry.
        ///
        /// *Note*: only the following colors are supported:
        /// * <c>new ThemeColor('statusBarItem.errorBackground')</c>
        /// * <c>new ThemeColor('statusBarItem.warningBackground')</c>
        ///
        /// More background colors may be supported in the future.
        ///
        /// *Note*: when a background color is set, the statusbar may override
        /// the <c>color</c> choice to ensure the entry is readable in all themes.
        /// </summary>
        abstract backgroundColor: ThemeColor option with get, set
        /// <summary>
        /// {@linkcode Command} or identifier of a command to run on click.
        ///
        /// The command must be <see cref="commands.getCommands">known</see>.
        ///
        /// Note that if this is a {@linkcode Command} object, only the {@linkcode Command.command command} and {@linkcode Command.arguments arguments}
        /// are used by the editor.
        /// </summary>
        abstract command: U2<string, Command> option with get, set
        /// Accessibility information used when a screen reader interacts with this StatusBar item
        abstract accessibilityInformation: AccessibilityInformation option with get, set
        /// Shows the entry in the status bar.
        abstract show: unit -> unit
        /// Hide the entry in the status bar.
        abstract hide: unit -> unit
        /// <summary>
        /// Dispose and free associated resources. Call
        /// <see cref="StatusBarItem.hide">hide</see>.
        /// </summary>
        abstract dispose: unit -> unit

    /// Defines a generalized way of reporting progress updates.
    type [<AllowNullLiteral>] Progress<'T> =
        /// <summary>Report a progress update.</summary>
        /// <param name="value">
        /// A progress item, like a message and/or an
        /// report on how much work finished
        /// </param>
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
        /// <code lang="typescript">
        /// window.onDidCloseTerminal(t => {
        ///    if (t.exitStatus && t.exitStatus.code) {
        ///        vscode.window.showInformationMessage(`Exit code: ${t.exitStatus.code}`);
        ///    }
        /// });
        /// </code>
        abstract exitStatus: TerminalExitStatus option
        /// <summary>The current state of the <see cref="Terminal" />.</summary>
        abstract state: TerminalState
        /// <summary>
        /// Send text to the terminal. The text is written to the stdin of the underlying pty process
        /// (shell) of the terminal.
        /// </summary>
        /// <param name="text">The text to send.</param>
        /// <param name="addNewLine">
        /// Whether to add a new line to the text being sent, this is normally
        /// required to run a command in the terminal. The character(s) added are \n or \r\n
        /// depending on the platform. This defaults to <c>true</c>.
        /// </param>
        abstract sendText: text: string * ?addNewLine: bool -> unit
        /// <summary>Show the terminal panel and reveal this terminal in the UI.</summary>
        /// <param name="preserveFocus">When <c>true</c> the terminal will not take focus.</param>
        abstract show: ?preserveFocus: bool -> unit
        /// Hide the terminal panel if this terminal is currently showing.
        abstract hide: unit -> unit
        /// Dispose and free associated resources.
        abstract dispose: unit -> unit

    /// The location of the terminal.
    type [<RequireQualifiedAccess>] TerminalLocation =
        /// In the terminal view
        | Panel = 1
        /// In the editor area
        | Editor = 2

    /// <summary>
    /// Assumes a <see cref="TerminalLocation" /> of editor and allows specifying a <see cref="ViewColumn" /> and
    /// <see cref="TerminalEditorLocationOptions.preserveFocus">preserveFocus </see> property
    /// </summary>
    type [<AllowNullLiteral>] TerminalEditorLocationOptions =
        /// <summary>
        /// A view column in which the <see cref="Terminal">terminal</see> should be shown in the editor area.
        /// Use <see cref="ViewColumn.Active">active</see> to open in the active editor group, other values are
        /// adjusted to be <c>Min(column, columnCount + 1)</c>, the
        /// <see cref="ViewColumn.Active">active</see>-column is not adjusted. Use
        /// {@linkcode ViewColumn.Beside} to open the editor to the side of the currently active one.
        /// </summary>
        abstract viewColumn: ViewColumn with get, set
        /// <summary>An optional flag that when <c>true</c> will stop the <see cref="Terminal" /> from taking focus.</summary>
        abstract preserveFocus: bool option with get, set

    /// <summary>Uses the parent <see cref="Terminal" />'s location for the terminal</summary>
    type [<AllowNullLiteral>] TerminalSplitLocationOptions =
        /// The parent terminal to split this terminal beside. This works whether the parent terminal
        /// is in the panel or the editor area.
        abstract parentTerminal: Terminal with get, set

    /// <summary>Represents the state of a <see cref="Terminal" />.</summary>
    type [<AllowNullLiteral>] TerminalState =
        /// <summary>
        /// Whether the <see cref="Terminal" /> has been interacted with. Interaction means that the
        /// terminal has sent data to the process which depending on the terminal's _mode_. By
        /// default input is sent when a key is pressed or when a command or extension sends text,
        /// but based on the terminal's mode it can also happen on:
        ///
        /// - a pointer click event
        /// - a pointer scroll event
        /// - a pointer move event
        /// - terminal focus in/out
        ///
        /// For more information on events that can send data see "DEC Private Mode Set (DECSET)" on
        /// <see href="https://invisible-island.net/xterm/ctlseqs/ctlseqs.html" />
        /// </summary>
        abstract isInteractedWith: bool

    /// Provides information on a line in a terminal in order to provide links for it.
    type [<AllowNullLiteral>] TerminalLinkContext =
        /// This is the text from the unwrapped line in the terminal.
        abstract line: string with get, set
        /// The terminal the link belongs to.
        abstract terminal: Terminal with get, set

    /// A provider that enables detection and handling of links within terminals.
    type TerminalLinkProvider =
        TerminalLinkProvider<TerminalLink>

    /// A provider that enables detection and handling of links within terminals.
    type [<AllowNullLiteral>] TerminalLinkProvider<'T when 'T :> TerminalLink> =
        /// <summary>
        /// Provide terminal links for the given context. Note that this can be called multiple times
        /// even before previous calls resolve, make sure to not share global objects (eg. <c>RegExp</c>)
        /// that could have problems when asynchronous usage may overlap.
        /// </summary>
        /// <param name="context">Information about what links are being provided for.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>A list of terminal links for the given line.</returns>
        abstract provideTerminalLinks: context: TerminalLinkContext * token: CancellationToken -> ProviderResult<ResizeArray<'T>>
        /// <summary>Handle an activated terminal link.</summary>
        /// <param name="link">The link to handle.</param>
        abstract handleTerminalLink: link: 'T -> ProviderResult<unit>

    /// A link on a terminal line.
    type [<AllowNullLiteral>] TerminalLink =
        /// <summary>The start index of the link on <see cref="TerminalLinkContext.line" />.</summary>
        abstract startIndex: float with get, set
        /// <summary>The length of the link on <see cref="TerminalLinkContext.line" />.</summary>
        abstract length: float with get, set
        /// <summary>
        /// The tooltip text when you hover over this link.
        ///
        /// If a tooltip is provided, is will be displayed in a string that includes instructions on
        /// how to trigger the link, such as <c>{0} (ctrl + click)</c>. The specific instructions vary
        /// depending on OS, user settings, and localization.
        /// </summary>
        abstract tooltip: string option with get, set

    /// A link on a terminal line.
    type [<AllowNullLiteral>] TerminalLinkStatic =
        /// <summary>Creates a new terminal link.</summary>
        /// <param name="startIndex">The start index of the link on <see cref="TerminalLinkContext.line" />.</param>
        /// <param name="length">The length of the link on <see cref="TerminalLinkContext.line" />.</param>
        /// <param name="tooltip">
        /// The tooltip text when you hover over this link.
        ///
        /// If a tooltip is provided, is will be displayed in a string that includes instructions on
        /// how to trigger the link, such as <c>{0} (ctrl + click)</c>. The specific instructions vary
        /// depending on OS, user settings, and localization.
        /// </param>
        [<EmitConstructor>] abstract Create: startIndex: float * length: float * ?tooltip: string -> TerminalLink

    /// Provides a terminal profile for the contributed terminal profile when launched via the UI or
    /// command.
    type [<AllowNullLiteral>] TerminalProfileProvider =
        /// <summary>Provide the terminal profile.</summary>
        /// <param name="token">A cancellation token that indicates the result is no longer needed.</param>
        /// <returns>The terminal profile.</returns>
        abstract provideTerminalProfile: token: CancellationToken -> ProviderResult<TerminalProfile>

    /// A terminal profile defines how a terminal will be launched.
    type [<AllowNullLiteral>] TerminalProfile =
        /// The options that the terminal will launch with.
        abstract options: U2<TerminalOptions, ExtensionTerminalOptions> with get, set

    /// A terminal profile defines how a terminal will be launched.
    type [<AllowNullLiteral>] TerminalProfileStatic =
        /// <summary>Creates a new terminal profile.</summary>
        /// <param name="options">The options that the terminal will launch with.</param>
        [<EmitConstructor>] abstract Create: options: U2<TerminalOptions, ExtensionTerminalOptions> -> TerminalProfile

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
        [<EmitConstructor>] abstract Create: ?badge: string * ?tooltip: string * ?color: ThemeColor -> FileDecoration

    /// The decoration provider interfaces defines the contract between extensions and
    /// file decorations.
    type [<AllowNullLiteral>] FileDecorationProvider =
        /// <summary>
        /// An optional event to signal that decorations for one or many files have changed.
        ///
        /// *Note* that this event should be used to propagate information about children.
        /// </summary>
        /// <seealso cref="EventEmitter" />
        abstract onDidChangeFileDecorations: Event<U2<Uri, ResizeArray<Uri>> option> option with get, set
        /// <summary>
        /// Provide decorations for a given uri.
        ///
        /// *Note* that this function is only called when a file gets rendered in the UI.
        /// This means a decoration from a descendent that propagates upwards must be signaled
        /// to the editor via the <see cref="FileDecorationProvider.onDidChangeFileDecorations">onDidChangeFileDecorations</see>-event.
        /// </summary>
        /// <param name="uri">The uri of the file to provide a decoration for.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>A decoration or a thenable that resolves to such.</returns>
        abstract provideFileDecoration: uri: Uri * token: CancellationToken -> ProviderResult<FileDecoration>

    /// In a remote window the extension kind describes if an extension
    /// runs where the UI (window) runs or if an extension runs remotely.
    type [<RequireQualifiedAccess>] ExtensionKind =
        /// Extension runs where the UI runs.
        | UI = 1
        /// Extension runs where the remote extension host runs.
        | Workspace = 2

    /// <summary>
    /// Represents an extension.
    ///
    /// To get an instance of an <c>Extension</c> use <see cref="extensions.getExtension">getExtension</see>.
    /// </summary>
    type [<AllowNullLiteral>] Extension<'T> =
        /// <summary>The canonical extension identifier in the form of: <c>publisher.name</c>.</summary>
        abstract id: string
        /// The uri of the directory containing the extension.
        abstract extensionUri: Uri
        /// <summary>
        /// The absolute file path of the directory containing this extension. Shorthand
        /// notation for <see cref="Extension.extensionUri">Extension.extensionUri.fsPath</see> (independent of the uri scheme).
        /// </summary>
        abstract extensionPath: string
        /// <summary><c>true</c> if the extension has been activated.</summary>
        abstract isActive: bool
        /// The parsed contents of the extension's package.json.
        abstract packageJSON: obj option
        /// <summary>
        /// The extension kind describes if an extension runs where the UI runs
        /// or if an extension runs where the remote extension host runs. The extension kind
        /// is defined in the <c>package.json</c>-file of extensions but can also be refined
        /// via the <c>remote.extensionKind</c>-setting. When no remote extension host exists,
        /// the value is {@linkcode ExtensionKind.UI}.
        /// </summary>
        abstract extensionKind: ExtensionKind with get, set
        /// <summary>
        /// The public API exported by this extension (return value of <c>activate</c>).
        /// It is an invalid action to access this field before this extension has been activated.
        /// </summary>
        abstract exports: 'T
        /// <summary>Activates this extension and returns its public API.</summary>
        /// <returns>A promise that will resolve when this extension has been activated.</returns>
        abstract activate: unit -> Thenable<'T>

    /// <summary>
    /// The ExtensionMode is provided on the <c>ExtensionContext</c> and indicates the
    /// mode the specific extension is running in.
    /// </summary>
    type [<RequireQualifiedAccess>] ExtensionMode =
        /// The extension is installed normally (for example, from the marketplace
        /// or VSIX) in the editor.
        | Production = 1
        /// <summary>
        /// The extension is running from an <c>--extensionDevelopmentPath</c> provided
        /// when launching the editor.
        /// </summary>
        | Development = 2
        /// <summary>
        /// The extension is running from an <c>--extensionTestsPath</c> and
        /// the extension host is running unit tests.
        /// </summary>
        | Test = 3

    /// <summary>
    /// An extension context is a collection of utilities private to an
    /// extension.
    ///
    /// An instance of an <c>ExtensionContext</c> is provided as the first
    /// parameter to the <c>activate</c>-call of an extension.
    /// </summary>
    type [<AllowNullLiteral>] ExtensionContext =
        /// An array to which disposables can be added. When this
        /// extension is deactivated the disposables will be disposed.
        ///
        /// *Note* that asynchronous dispose-functions aren't awaited.
        abstract subscriptions: ResizeArray<{| dispose: unit -> obj option |}>
        /// <summary>
        /// A memento object that stores state in the context
        /// of the currently opened <see cref="workspace.workspaceFolders">workspace</see>.
        /// </summary>
        abstract workspaceState: Memento
        /// <summary>
        /// A memento object that stores state independent
        /// of the current opened <see cref="workspace.workspaceFolders">workspace</see>.
        /// </summary>
        abstract globalState: obj
        /// <summary>
        /// A storage utility for secrets. Secrets are persisted across reloads and are independent of the
        /// current opened <see cref="workspace.workspaceFolders">workspace</see>.
        /// </summary>
        abstract secrets: SecretStorage
        /// The uri of the directory containing the extension.
        abstract extensionUri: Uri
        /// <summary>
        /// The absolute file path of the directory containing the extension. Shorthand
        /// notation for <see cref="TextDocument.uri">ExtensionContext.extensionUri.fsPath</see> (independent of the uri scheme).
        /// </summary>
        abstract extensionPath: string
        /// Gets the extension's environment variable collection for this workspace, enabling changes
        /// to be applied to terminal environment variables.
        abstract environmentVariableCollection: EnvironmentVariableCollection
        /// <summary>
        /// Get the absolute path of a resource contained in the extension.
        ///
        /// *Note* that an absolute uri can be constructed via {@linkcode Uri.joinPath} and
        /// {@linkcode ExtensionContext.extensionUri extensionUri}, e.g. <c>vscode.Uri.joinPath(context.extensionUri, relativePath);</c>
        /// </summary>
        /// <param name="relativePath">A relative path to a resource contained in the extension.</param>
        /// <returns>The absolute path of the resource.</returns>
        abstract asAbsolutePath: relativePath: string -> string
        /// <summary>
        /// The uri of a workspace specific directory in which the extension
        /// can store private state. The directory might not exist and creation is
        /// up to the extension. However, the parent directory is guaranteed to be existent.
        /// The value is <c>undefined</c> when no workspace nor folder has been opened.
        ///
        /// Use {@linkcode ExtensionContext.workspaceState workspaceState} or
        /// {@linkcode ExtensionContext.globalState globalState} to store key value data.
        /// </summary>
        /// <seealso cref="{" />
        abstract storageUri: Uri option
        /// An absolute file path of a workspace specific directory in which the extension
        /// can store private state. The directory might not exist on disk and creation is
        /// up to the extension. However, the parent directory is guaranteed to be existent.
        ///
        /// Use {@linkcode ExtensionContext.workspaceState workspaceState} or
        /// {@linkcode ExtensionContext.globalState globalState} to store key value data.
        [<Obsolete("Use {@link ExtensionContext.storageUri storageUri} instead.")>]
        abstract storagePath: string option
        /// <summary>
        /// The uri of a directory in which the extension can store global state.
        /// The directory might not exist on disk and creation is
        /// up to the extension. However, the parent directory is guaranteed to be existent.
        ///
        /// Use {@linkcode ExtensionContext.globalState globalState} to store key value data.
        /// </summary>
        /// <seealso cref="{" />
        abstract globalStorageUri: Uri
        /// An absolute file path in which the extension can store global state.
        /// The directory might not exist on disk and creation is
        /// up to the extension. However, the parent directory is guaranteed to be existent.
        ///
        /// Use {@linkcode ExtensionContext.globalState globalState} to store key value data.
        [<Obsolete("Use {@link ExtensionContext.globalStorageUri globalStorageUri} instead.")>]
        abstract globalStoragePath: string
        /// <summary>
        /// The uri of a directory in which the extension can create log files.
        /// The directory might not exist on disk and creation is up to the extension. However,
        /// the parent directory is guaranteed to be existent.
        /// </summary>
        /// <seealso cref="{" />
        abstract logUri: Uri
        /// An absolute file path of a directory in which the extension can create log files.
        /// The directory might not exist on disk and creation is up to the extension. However,
        /// the parent directory is guaranteed to be existent.
        [<Obsolete("Use {@link ExtensionContext.logUri logUri} instead.")>]
        abstract logPath: string
        /// <summary>
        /// The mode the extension is running in. This is specific to the current
        /// extension. One extension may be in <c>ExtensionMode.Development</c> while
        /// other extensions in the host run in <c>ExtensionMode.Release</c>.
        /// </summary>
        abstract extensionMode: ExtensionMode
        /// <summary>The current <c>Extension</c> instance.</summary>
        abstract extension: Extension<obj option>

    /// A memento represents a storage utility. It can store and retrieve
    /// values.
    type [<AllowNullLiteral>] Memento =
        /// <summary>Returns the stored keys.</summary>
        /// <returns>The stored keys.</returns>
        abstract keys: unit -> ResizeArray<string>
        /// <summary>Return a value.</summary>
        /// <param name="key">A string.</param>
        /// <returns>The stored value or <c>undefined</c>.</returns>
        abstract get: key: string -> 'T option
        /// <summary>Return a value.</summary>
        /// <param name="key">A string.</param>
        /// <param name="defaultValue">
        /// A value that should be returned when there is no
        /// value (<c>undefined</c>) with the given key.
        /// </param>
        /// <returns>The stored value or the defaultValue.</returns>
        abstract get: key: string * defaultValue: 'T -> 'T
        /// <summary>
        /// Store a value. The value must be JSON-stringifyable.
        ///
        /// *Note* that using <c>undefined</c> as value removes the key from the underlying
        /// storage.
        /// </summary>
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
        /// <summary>
        /// Retrieve a secret that was stored with key. Returns undefined if there
        /// is no password matching that key.
        /// </summary>
        /// <param name="key">The key the secret was stored under.</param>
        /// <returns>The stored value or <c>undefined</c>.</returns>
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

    /// Represents a color theme kind.
    type [<RequireQualifiedAccess>] ColorThemeKind =
        | Light = 1
        | Dark = 2
        | HighContrast = 3
        | HighContrastLight = 4

    /// Represents a color theme.
    type [<AllowNullLiteral>] ColorTheme =
        /// The kind of this color theme: light, dark, high contrast dark and high contrast light.
        abstract kind: ColorThemeKind

    /// Controls the behaviour of the terminal's visibility.
    type [<RequireQualifiedAccess>] TaskRevealKind =
        /// Always brings the terminal to front if the task is executed.
        | Always = 1
        /// Only brings the terminal to front if a problem is detected executing the task
        /// (e.g. the task couldn't be started because).
        | Silent = 2
        /// The terminal never comes to front when the task is executed.
        | Never = 3

    /// Controls how the task channel is used between tasks
    type [<RequireQualifiedAccess>] TaskPanelKind =
        /// Shares a panel with other tasks. This is the default.
        | Shared = 1
        /// Uses a dedicated panel for this tasks. The panel is not
        /// shared with other tasks.
        | Dedicated = 2
        /// Creates a new panel whenever this task is executed.
        | New = 3

    /// Controls how the task is presented in the UI.
    type [<AllowNullLiteral>] TaskPresentationOptions =
        /// <summary>
        /// Controls whether the task output is reveal in the user interface.
        /// Defaults to <c>RevealKind.Always</c>.
        /// </summary>
        abstract reveal: TaskRevealKind option with get, set
        /// Controls whether the command associated with the task is echoed
        /// in the user interface.
        abstract echo: bool option with get, set
        /// Controls whether the panel showing the task output is taking focus.
        abstract focus: bool option with get, set
        /// <summary>
        /// Controls if the task panel is used for this task only (dedicated),
        /// shared between tasks (shared) or if a new panel is created on
        /// every task execution (new). Defaults to <c>TaskInstanceKind.Shared</c>
        /// </summary>
        abstract panel: TaskPanelKind option with get, set
        /// Controls whether to show the "Terminal will be reused by tasks, press any key to close it" message.
        abstract showReuseMessage: bool option with get, set
        /// Controls whether the terminal is cleared before executing the task.
        abstract clear: bool option with get, set

    /// A grouping for tasks. The editor by default supports the
    /// 'Clean', 'Build', 'RebuildAll' and 'Test' group.
    type [<AllowNullLiteral>] TaskGroup =
        /// Whether the task that is part of this group is the default for the group.
        /// This property cannot be set through API, and is controlled by a user's task configurations.
        abstract isDefault: bool option
        /// The ID of the task group. Is one of TaskGroup.Clean.id, TaskGroup.Build.id, TaskGroup.Rebuild.id, or TaskGroup.Test.id.
        abstract id: string

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
        /// <code lang="typescript">
        /// interface NpmTaskDefinition extends TaskDefinition {
        ///      script: string;
        /// }
        /// </code>
        ///
        /// Note that type identifier starting with a '$' are reserved for internal
        /// usages and shouldn't be used by extensions.
        abstract ``type``: string
        /// Additional attributes of a concrete task definition.
        [<EmitIndexer>] abstract Item: name: string -> obj option with get, set

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
        [<EmitConstructor>] abstract Create: ``process``: string * ?options: ProcessExecutionOptions -> ProcessExecution
        /// <summary>Creates a process execution.</summary>
        /// <param name="process">The process to start.</param>
        /// <param name="args">Arguments to be passed to the process.</param>
        /// <param name="options">Optional options for the started process.</param>
        [<EmitConstructor>] abstract Create: ``process``: string * args: ResizeArray<string> * ?options: ProcessExecutionOptions -> ProcessExecution

    /// The shell quoting options.
    type [<AllowNullLiteral>] ShellQuotingOptions =
        /// <summary>
        /// The character used to do character escaping. If a string is provided only spaces
        /// are escaped. If a <c>{ escapeChar, charsToEscape }</c> literal is provide all characters
        /// in <c>charsToEscape</c> are escaped using the <c>escapeChar</c>.
        /// </summary>
        abstract escape: U2<string, {| escapeChar: string; charsToEscape: string |}> option with get, set
        /// The character used for strong quoting. The string's length must be 1.
        abstract strong: string option with get, set
        /// The character used for weak quoting. The string's length must be 1.
        abstract weak: string option with get, set

    /// Options for a shell execution
    type [<AllowNullLiteral>] ShellExecutionOptions =
        /// The shell executable.
        abstract executable: string option with get, set
        /// <summary>
        /// The arguments to be passed to the shell executable used to run the task. Most shells
        /// require special arguments to execute a command. For  example <c>bash</c> requires the <c>-c</c>
        /// argument to execute a command, <c>PowerShell</c> requires <c>-Command</c> and <c>cmd</c> requires both
        /// <c>/d</c> and <c>/c</c>.
        /// </summary>
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

    /// Defines how an argument should be quoted if it contains
    /// spaces or unsupported characters.
    type [<RequireQualifiedAccess>] ShellQuoting =
        /// Character escaping should be used. This for example
        /// uses \ on bash and ` on PowerShell.
        | Escape = 1
        /// <summary>
        /// Strong string quoting should be used. This for example
        /// uses " for Windows cmd and ' for bash and PowerShell.
        /// Strong quoting treats arguments as literal strings.
        /// Under PowerShell echo 'The value is $(2 * 3)' will
        /// print <c>The value is $(2 * 3)</c>
        /// </summary>
        | Strong = 2
        /// <summary>
        /// Weak string quoting should be used. This for example
        /// uses " for Windows cmd, bash and PowerShell. Weak quoting
        /// still performs some kind of evaluation inside the quoted
        /// string.  Under PowerShell echo "The value is $(2 * 3)"
        /// will print <c>The value is 6</c>
        /// </summary>
        | Weak = 3

    /// A string that will be quoted depending on the used shell.
    type [<AllowNullLiteral>] ShellQuotedString =
        /// The actual string value.
        abstract value: string with get, set
        /// The quoting style to use.
        abstract quoting: ShellQuoting with get, set

    type [<AllowNullLiteral>] ShellExecution =
        /// <summary>The shell command line. Is <c>undefined</c> if created with a command and arguments.</summary>
        abstract commandLine: string option with get, set
        /// <summary>The shell command. Is <c>undefined</c> if created with a full command line.</summary>
        abstract command: U2<string, ShellQuotedString> with get, set
        /// <summary>The shell args. Is <c>undefined</c> if created with a full command line.</summary>
        abstract args: ResizeArray<U2<string, ShellQuotedString>> with get, set
        /// The shell options used when the command line is executed in a shell.
        /// Defaults to undefined.
        abstract options: ShellExecutionOptions option with get, set

    type [<AllowNullLiteral>] ShellExecutionStatic =
        /// <summary>Creates a shell execution with a full command line.</summary>
        /// <param name="commandLine">The command line to execute.</param>
        /// <param name="options">Optional options for the started the shell.</param>
        [<EmitConstructor>] abstract Create: commandLine: string * ?options: ShellExecutionOptions -> ShellExecution
        /// <summary>
        /// Creates a shell execution with a command and arguments. For the real execution the editor will
        /// construct a command line from the command and the arguments. This is subject to interpretation
        /// especially when it comes to quoting. If full control over the command line is needed please
        /// use the constructor that creates a <c>ShellExecution</c> with the full command line.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        /// <param name="args">The command arguments.</param>
        /// <param name="options">Optional options for the started the shell.</param>
        [<EmitConstructor>] abstract Create: command: U2<string, ShellQuotedString> * args: ResizeArray<U2<string, ShellQuotedString>> * ?options: ShellExecutionOptions -> ShellExecution

    /// Class used to execute an extension callback as a task.
    type [<AllowNullLiteral>] CustomExecution =
        interface end

    /// Class used to execute an extension callback as a task.
    type [<AllowNullLiteral>] CustomExecutionStatic =
        /// <summary>
        /// Constructs a CustomExecution task object. The callback will be executed when the task is run, at which point the
        /// extension should return the Pseudoterminal it will "run in". The task should wait to do further execution until
        /// <see cref="Pseudoterminal.open" /> is called. Task cancellation should be handled using
        /// <see cref="Pseudoterminal.close" />. When the task is complete fire
        /// <see cref="Pseudoterminal.onDidClose" />.
        /// </summary>
        /// <param name="callback">
        /// The callback that will be called when the task is started by a user. Any ${} style variables that
        /// were in the task definition will be resolved and passed into the callback as <c>resolvedDefinition</c>.
        /// </param>
        [<EmitConstructor>] abstract Create: callback: (TaskDefinition -> Thenable<Pseudoterminal>) -> CustomExecution

    /// The scope of a task.
    type [<RequireQualifiedAccess>] TaskScope =
        /// The task is a global task. Global tasks are currently not supported.
        | Global = 1
        /// The task is a workspace task
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
        /// <summary>
        /// A human-readable string which is rendered less prominently on a separate line in places
        /// where the task's name is displayed. Supports rendering of <see cref="ThemeIcon">theme icons</see>
        /// via the <c>$(&lt;name&gt;)</c>-syntax.
        /// </summary>
        abstract detail: string option with get, set
        /// The task's execution engine
        abstract execution: U3<ProcessExecution, ShellExecution, CustomExecution> option with get, set
        /// Whether the task is a background task or not.
        abstract isBackground: bool with get, set
        /// <summary>
        /// A human-readable string describing the source of this shell task, e.g. 'gulp'
        /// or 'npm'. Supports rendering of <see cref="ThemeIcon">theme icons</see> via the <c>$(&lt;name&gt;)</c>-syntax.
        /// </summary>
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
        /// <param name="taskDefinition">The task definition as defined in the taskDefinitions extension point.</param>
        /// <param name="scope">Specifies the task's scope. It is either a global or a workspace task or a task for a specific workspace folder. Global tasks are currently not supported.</param>
        /// <param name="name">The task's name. Is presented in the user interface.</param>
        /// <param name="source">The task's source (e.g. 'gulp', 'npm', ...). Is presented in the user interface.</param>
        /// <param name="execution">The process or shell execution.</param>
        /// <param name="problemMatchers">
        /// the names of problem matchers to use, like '$tsc'
        /// or '$eslint'. Problem matchers can be contributed by an extension using
        /// the <c>problemMatchers</c> extension point.
        /// </param>
        [<EmitConstructor>] abstract Create: taskDefinition: TaskDefinition * scope: U2<WorkspaceFolder, TaskScope> * name: string * source: string * ?execution: U3<ProcessExecution, ShellExecution, CustomExecution> * ?problemMatchers: U2<string, ResizeArray<string>> -> Task
        /// <summary>Creates a new task.</summary>
        /// <param name="taskDefinition">The task definition as defined in the taskDefinitions extension point.</param>
        /// <param name="name">The task's name. Is presented in the user interface.</param>
        /// <param name="source">The task's source (e.g. 'gulp', 'npm', ...). Is presented in the user interface.</param>
        /// <param name="execution">The process or shell execution.</param>
        /// <param name="problemMatchers">
        /// the names of problem matchers to use, like '$tsc'
        /// or '$eslint'. Problem matchers can be contributed by an extension using
        /// the <c>problemMatchers</c> extension point.
        /// </param>
        [<Obsolete("Use the new constructors that allow specifying a scope for the task.")>]
        [<EmitConstructor>] abstract Create: taskDefinition: TaskDefinition * name: string * source: string * ?execution: U2<ProcessExecution, ShellExecution> * ?problemMatchers: U2<string, ResizeArray<string>> -> Task

    /// <summary>
    /// A task provider allows to add tasks to the task service.
    /// A task provider is registered via <see cref="tasks.registerTaskProvider" />.
    /// </summary>
    type TaskProvider =
        TaskProvider<Task>

    /// <summary>
    /// A task provider allows to add tasks to the task service.
    /// A task provider is registered via <see cref="tasks.registerTaskProvider" />.
    /// </summary>
    type [<AllowNullLiteral>] TaskProvider<'T when 'T :> Task> =
        /// <summary>Provides tasks.</summary>
        /// <param name="token">A cancellation token.</param>
        /// <returns>an array of tasks</returns>
        abstract provideTasks: token: CancellationToken -> ProviderResult<ResizeArray<'T>>
        /// <summary>
        /// Resolves a task that has no {@linkcode Task.execution execution} set. Tasks are
        /// often created from information found in the <c>tasks.json</c>-file. Such tasks miss
        /// the information on how to execute them and a task provider must fill in
        /// the missing information in the <c>resolveTask</c>-method. This method will not be
        /// called for tasks returned from the above <c>provideTasks</c> method since those
        /// tasks are always fully resolved. A valid default implementation for the
        /// <c>resolveTask</c> method is to return <c>undefined</c>.
        ///
        /// Note that when filling in the properties of <c>task</c>, you _must_ be sure to
        /// use the exact same <c>TaskDefinition</c> and not create a new one. Other properties
        /// may be changed.
        /// </summary>
        /// <param name="task">The task to resolve.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>The resolved task</returns>
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
        /// <summary>The process's exit code. Will be <c>undefined</c> when the task is terminated.</summary>
        abstract exitCode: float option

    type [<AllowNullLiteral>] TaskFilter =
        /// The task version as used in the tasks.json file.
        /// The string support the package.json semver notation.
        abstract version: string option with get, set
        /// The task type to return;
        abstract ``type``: string option with get, set

    /// Namespace for tasks functionality.
    module Tasks =

        type [<AllowNullLiteral>] IExports =
            /// <summary>Register a task provider.</summary>
            /// <param name="type">The task kind type this provider is registered for.</param>
            /// <param name="provider">A task provider.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            abstract registerTaskProvider: ``type``: string * provider: TaskProvider -> Disposable
            /// <summary>
            /// Fetches all tasks available in the systems. This includes tasks
            /// from <c>tasks.json</c> files as well as tasks from task providers
            /// contributed through extensions.
            /// </summary>
            /// <param name="filter">Optional filter to select tasks of a certain type or version.</param>
            abstract fetchTasks: ?filter: TaskFilter -> Thenable<ResizeArray<Task>>
            /// <summary>
            /// Executes a task that is managed by the editor. The returned
            /// task execution can be used to terminate the task.
            /// </summary>
            /// <exception cref="">
            /// When running a ShellExecution or a ProcessExecution
            /// task in an environment where a new process cannot be started.
            /// In such an environment, only CustomExecution tasks can be run.
            /// </exception>
            /// <param name="task">the task to execute</param>
            abstract executeTask: task: Task -> Thenable<TaskExecution>
            /// The currently active task executions or an empty array.
            abstract taskExecutions: ResizeArray<TaskExecution>
            /// Fires when a task starts.
            abstract onDidStartTask: Event<TaskStartEvent>
            /// Fires when a task ends.
            abstract onDidEndTask: Event<TaskEndEvent>
            /// Fires when the underlying process has been started.
            /// This event will not fire for tasks that don't
            /// execute an underlying process.
            abstract onDidStartTaskProcess: Event<TaskProcessStartEvent>
            /// Fires when the underlying process has ended.
            /// This event will not fire for tasks that don't
            /// execute an underlying process.
            abstract onDidEndTaskProcess: Event<TaskProcessEndEvent>

    /// <summary>
    /// Enumeration of file types. The types <c>File</c> and <c>Directory</c> can also be
    /// a symbolic links, in that case use <c>FileType.File | FileType.SymbolicLink</c> and
    /// <c>FileType.Directory | FileType.SymbolicLink</c>.
    /// </summary>
    type [<RequireQualifiedAccess>] FileType =
        /// The file type is unknown.
        | Unknown = 0
        /// A regular file.
        | File = 1
        /// A directory.
        | Directory = 2
        /// A symbolic link to a file.
        | SymbolicLink = 64

    type [<RequireQualifiedAccess>] FilePermission =
        /// <summary>
        /// The file is readonly.
        ///
        /// *Note:* All <c>FileStat</c> from a <c>FileSystemProvider</c> that is registered with
        /// the option <c>isReadonly: true</c> will be implicitly handled as if <c>FilePermission.Readonly</c>
        /// is set. As a consequence, it is not possible to have a readonly file system provider
        /// registered where some <c>FileStat</c> are not readonly.
        /// </summary>
        | Readonly = 1

    /// <summary>The <c>FileStat</c>-type represents metadata about a file</summary>
    type [<AllowNullLiteral>] FileStat =
        /// <summary>
        /// The type of the file, e.g. is a regular file, a directory, or symbolic link
        /// to a file.
        ///
        /// *Note:* This value might be a bitmask, e.g. <c>FileType.File | FileType.SymbolicLink</c>.
        /// </summary>
        abstract ``type``: FileType with get, set
        /// The creation timestamp in milliseconds elapsed since January 1, 1970 00:00:00 UTC.
        abstract ctime: float with get, set
        /// <summary>
        /// The modification timestamp in milliseconds elapsed since January 1, 1970 00:00:00 UTC.
        ///
        /// *Note:* If the file changed, it is important to provide an updated <c>mtime</c> that advanced
        /// from the previous value. Otherwise there may be optimizations in place that will not show
        /// the updated file contents in an editor for example.
        /// </summary>
        abstract mtime: float with get, set
        /// <summary>
        /// The size in bytes.
        ///
        /// *Note:* If the file changed, it is important to provide an updated <c>size</c>. Otherwise there
        /// may be optimizations in place that will not show the updated file contents in an editor for
        /// example.
        /// </summary>
        abstract size: float with get, set
        /// <summary>
        /// The permissions of the file, e.g. whether the file is readonly.
        ///
        /// *Note:* This value might be a bitmask, e.g. <c>FilePermission.Readonly | FilePermission.Other</c>.
        /// </summary>
        abstract permissions: FilePermission option with get, set

    /// <summary>
    /// A type that filesystem providers should use to signal errors.
    ///
    /// This class has factory methods for common error-cases, like <c>FileNotFound</c> when
    /// a file or folder doesn't exist, use them like so: <c>throw vscode.FileSystemError.FileNotFound(someUri);</c>
    /// </summary>
    type [<ImportMember("vscode"); AllowNullLiteral; AbstractClass>] FileSystemError =
        inherit Error
        /// <summary>
        /// A code that identifies this error.
        ///
        /// Possible values are names of errors, like {@linkcode FileSystemError.FileNotFound FileNotFound},
        /// or <c>Unknown</c> for unspecified errors.
        /// </summary>
        abstract code: string

    /// <summary>
    /// A type that filesystem providers should use to signal errors.
    ///
    /// This class has factory methods for common error-cases, like <c>FileNotFound</c> when
    /// a file or folder doesn't exist, use them like so: <c>throw vscode.FileSystemError.FileNotFound(someUri);</c>
    /// </summary>
    type [<AllowNullLiteral>] FileSystemErrorStatic =
        /// <summary>Create an error to signal that a file or folder wasn't found.</summary>
        /// <param name="messageOrUri">Message or uri.</param>
        abstract FileNotFound: ?messageOrUri: U2<string, Uri> -> FileSystemError
        /// <summary>
        /// Create an error to signal that a file or folder already exists, e.g. when
        /// creating but not overwriting a file.
        /// </summary>
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
        /// <summary>
        /// Create an error to signal that the file system is unavailable or too busy to
        /// complete a request.
        /// </summary>
        /// <param name="messageOrUri">Message or uri.</param>
        abstract Unavailable: ?messageOrUri: U2<string, Uri> -> FileSystemError
        /// <summary>Creates a new filesystem error.</summary>
        /// <param name="messageOrUri">Message or uri.</param>
        [<EmitConstructor>] abstract Create: ?messageOrUri: U2<string, Uri> -> FileSystemError

    /// Enumeration of file change types.
    type [<RequireQualifiedAccess>] FileChangeType =
        /// The contents or metadata of a file have changed.
        | Changed = 1
        /// A file has been created.
        | Created = 2
        /// A file has been deleted.
        | Deleted = 3

    /// The event filesystem providers must use to signal a file change.
    type [<AllowNullLiteral>] FileChangeEvent =
        /// The type of change.
        abstract ``type``: FileChangeType
        /// The uri of the file that has changed.
        abstract uri: Uri

    /// <summary>
    /// The filesystem provider defines what the editor needs to read, write, discover,
    /// and to manage files and folders. It allows extensions to serve files from remote places,
    /// like ftp-servers, and to seamlessly integrate those into the editor.
    ///
    /// * *Note 1:* The filesystem provider API works with <see cref="Uri">uris</see> and assumes hierarchical
    /// paths, e.g. <c>foo:/my/path</c> is a child of <c>foo:/my/</c> and a parent of <c>foo:/my/path/deeper</c>.
    /// * *Note 2:* There is an activation event <c>onFileSystem:&lt;scheme&gt;</c> that fires when a file
    /// or folder is being accessed.
    /// * *Note 3:* The word 'file' is often used to denote all <see cref="FileType">kinds</see> of files, e.g.
    /// folders, symbolic links, and regular files.
    /// </summary>
    type [<AllowNullLiteral>] FileSystemProvider =
        /// <summary>
        /// An event to signal that a resource has been created, changed, or deleted. This
        /// event should fire for resources that are being <see cref="FileSystemProvider.watch">watched</see>
        /// by clients of this provider.
        ///
        /// *Note:* It is important that the metadata of the file that changed provides an
        /// updated <c>mtime</c> that advanced from the previous value in the <see cref="FileStat">stat</see> and a
        /// correct <c>size</c> value. Otherwise there may be optimizations in place that will not show
        /// the change in an editor for example.
        /// </summary>
        abstract onDidChangeFile: Event<ResizeArray<FileChangeEvent>>
        /// <summary>
        /// Subscribes to file change events in the file or folder denoted by <c>uri</c>. For folders,
        /// the option <c>recursive</c> indicates whether subfolders, sub-subfolders, etc. should
        /// be watched for file changes as well. With <c>recursive: false</c>, only changes to the
        /// files that are direct children of the folder should trigger an event.
        ///
        /// The <c>excludes</c> array is used to indicate paths that should be excluded from file
        /// watching. It is typically derived from the <c>files.watcherExclude</c> setting that
        /// is configurable by the user. Each entry can be be:
        /// - the absolute path to exclude
        /// - a relative path to exclude (for example <c>build/output</c>)
        /// - a simple glob pattern (for example <c>**​/build</c>, <c>output/**</c>)
        ///
        /// It is the file system provider's job to call {@linkcode FileSystemProvider.onDidChangeFile onDidChangeFile}
        /// for every change given these rules. No event should be emitted for files that match any of the provided
        /// excludes.
        /// </summary>
        /// <param name="uri">The uri of the file or folder to be watched.</param>
        /// <param name="options">Configures the watch.</param>
        /// <returns>A disposable that tells the provider to stop watching the <c>uri</c>.</returns>
        abstract watch: uri: Uri * options: {| recursive: bool; excludes: ResizeArray<string> |} -> Disposable
        /// <summary>
        /// Retrieve metadata about a file.
        ///
        /// Note that the metadata for symbolic links should be the metadata of the file they refer to.
        /// Still, the <see cref="FileType.SymbolicLink">SymbolicLink</see>-type must be used in addition to the actual type, e.g.
        /// <c>FileType.SymbolicLink | FileType.Directory</c>.
        /// </summary>
        /// <param name="uri">The uri of the file to retrieve metadata about.</param>
        /// <returns>The file metadata about the file.</returns>
        /// <exception cref="">{</exception>
        abstract stat: uri: Uri -> U2<FileStat, Thenable<FileStat>>
        /// <summary>Retrieve all entries of a <see cref="FileType.Directory">directory</see>.</summary>
        /// <param name="uri">The uri of the folder.</param>
        /// <returns>An array of name/type-tuples or a thenable that resolves to such.</returns>
        /// <exception cref="">{</exception>
        abstract readDirectory: uri: Uri -> U2<ResizeArray<string * FileType>, Thenable<ResizeArray<string * FileType>>>
        /// <summary>Create a new directory (Note, that new files are created via <c>write</c>-calls).</summary>
        /// <param name="uri">The uri of the new folder.</param>
        /// <exception cref="">{</exception>
        /// <exception cref="">{</exception>
        /// <exception cref="">{</exception>
        abstract createDirectory: uri: Uri -> U2<unit, Thenable<unit>>
        /// <summary>Read the entire contents of a file.</summary>
        /// <param name="uri">The uri of the file.</param>
        /// <returns>An array of bytes or a thenable that resolves to such.</returns>
        /// <exception cref="">{</exception>
        abstract readFile: uri: Uri -> U2<Uint8Array, Thenable<Uint8Array>>
        /// <summary>Write data to a file, replacing its entire contents.</summary>
        /// <param name="uri">The uri of the file.</param>
        /// <param name="content">The new content of the file.</param>
        /// <param name="options">Defines if missing files should or must be created.</param>
        /// <exception cref="">{</exception>
        /// <exception cref="">{</exception>
        /// <exception cref="">{</exception>
        /// <exception cref="">{</exception>
        abstract writeFile: uri: Uri * content: Uint8Array * options: {| create: bool; overwrite: bool |} -> U2<unit, Thenable<unit>>
        /// <summary>Delete a file.</summary>
        /// <param name="uri">The resource that is to be deleted.</param>
        /// <param name="options">Defines if deletion of folders is recursive.</param>
        /// <exception cref="">{</exception>
        /// <exception cref="">{</exception>
        abstract delete: uri: Uri * options: {| recursive: bool |} -> U2<unit, Thenable<unit>>
        /// <summary>Rename a file or folder.</summary>
        /// <param name="oldUri">The existing file.</param>
        /// <param name="newUri">The new location.</param>
        /// <param name="options">Defines if existing files should be overwritten.</param>
        /// <exception cref="">{</exception>
        /// <exception cref="">{</exception>
        /// <exception cref="">{</exception>
        /// <exception cref="">{</exception>
        abstract rename: oldUri: Uri * newUri: Uri * options: {| overwrite: bool |} -> U2<unit, Thenable<unit>>
        /// <summary>
        /// Copy files or folders. Implementing this function is optional but it will speedup
        /// the copy operation.
        /// </summary>
        /// <param name="source">The existing file.</param>
        /// <param name="destination">The destination location.</param>
        /// <param name="options">Defines if existing files should be overwritten.</param>
        /// <exception cref="">{</exception>
        /// <exception cref="">{</exception>
        /// <exception cref="">{</exception>
        /// <exception cref="">{</exception>
        abstract copy: source: Uri * destination: Uri * options: {| overwrite: bool |} -> U2<unit, Thenable<unit>>

    /// <summary>
    /// The file system interface exposes the editor's built-in and contributed
    /// <see cref="FileSystemProvider">file system providers</see>. It allows extensions to work
    /// with files from the local disk as well as files from remote places, like the
    /// remote extension host or ftp-servers.
    ///
    /// *Note* that an instance of this interface is available as {@linkcode workspace.fs}.
    /// </summary>
    type [<AllowNullLiteral>] FileSystem =
        /// <summary>Retrieve metadata about a file.</summary>
        /// <param name="uri">The uri of the file to retrieve metadata about.</param>
        /// <returns>The file metadata about the file.</returns>
        abstract stat: uri: Uri -> Thenable<FileStat>
        /// <summary>Retrieve all entries of a <see cref="FileType.Directory">directory</see>.</summary>
        /// <param name="uri">The uri of the folder.</param>
        /// <returns>An array of name/type-tuples or a thenable that resolves to such.</returns>
        abstract readDirectory: uri: Uri -> Thenable<ResizeArray<string * FileType>>
        /// <summary>
        /// Create a new directory (Note, that new files are created via <c>write</c>-calls).
        ///
        /// *Note* that missing directories are created automatically, e.g this call has
        /// <c>mkdirp</c> semantics.
        /// </summary>
        /// <param name="uri">The uri of the new folder.</param>
        abstract createDirectory: uri: Uri -> Thenable<unit>
        /// <summary>Read the entire contents of a file.</summary>
        /// <param name="uri">The uri of the file.</param>
        /// <returns>An array of bytes or a thenable that resolves to such.</returns>
        abstract readFile: uri: Uri -> Thenable<Uint8Array>
        /// <summary>Write data to a file, replacing its entire contents.</summary>
        /// <param name="uri">The uri of the file.</param>
        /// <param name="content">The new content of the file.</param>
        abstract writeFile: uri: Uri * content: Uint8Array -> Thenable<unit>
        /// <summary>Delete a file.</summary>
        /// <param name="uri">The resource that is to be deleted.</param>
        /// <param name="options">Defines if trash can should be used and if deletion of folders is recursive</param>
        abstract delete: uri: Uri * ?options: {| recursive: bool option; useTrash: bool option |} -> Thenable<unit>
        /// <summary>Rename a file or folder.</summary>
        /// <param name="source">The existing file.</param>
        /// <param name="target">The new location.</param>
        /// <param name="options">Defines if existing files should be overwritten.</param>
        abstract rename: source: Uri * target: Uri * ?options: {| overwrite: bool option |} -> Thenable<unit>
        /// <summary>Copy files or folders.</summary>
        /// <param name="source">The existing file.</param>
        /// <param name="target">The destination location.</param>
        /// <param name="options">Defines if existing files should be overwritten.</param>
        abstract copy: source: Uri * target: Uri * ?options: {| overwrite: bool option |} -> Thenable<unit>
        /// <summary>
        /// Check if a given file system supports writing files.
        ///
        /// Keep in mind that just because a file system supports writing, that does
        /// not mean that writes will always succeed. There may be permissions issues
        /// or other errors that prevent writing a file.
        /// </summary>
        /// <param name="scheme">The scheme of the filesystem, for example <c>file</c> or <c>git</c>.</param>
        /// <returns>
        /// <c>true</c> if the file system supports writing, <c>false</c> if it does not
        /// support writing (i.e. it is readonly), and <c>undefined</c> if the editor does not
        /// know about the filesystem.
        /// </returns>
        abstract isWritableFileSystem: scheme: string -> bool option

    /// Defines a port mapping used for localhost inside the webview.
    type [<AllowNullLiteral>] WebviewPortMapping =
        /// Localhost port to remap inside the webview.
        abstract webviewPort: float
        /// <summary>Destination port. The <c>webviewPort</c> is resolved to this port.</summary>
        abstract extensionHostPort: float

    /// Content settings for a webview.
    type [<AllowNullLiteral>] WebviewOptions =
        /// Controls whether scripts are enabled in the webview content or not.
        ///
        /// Defaults to false (scripts-disabled).
        abstract enableScripts: bool option
        /// <summary>
        /// Controls whether forms are enabled in the webview content or not.
        ///
        /// Defaults to true if <see cref="WebviewOptions.enableScripts">scripts are enabled</see>. Otherwise defaults to false.
        /// Explicitly setting this property to either true or false overrides the default.
        /// </summary>
        abstract enableForms: bool option
        /// Controls whether command uris are enabled in webview content or not.
        ///
        /// Defaults to false.
        abstract enableCommandUris: bool option
        /// <summary>
        /// Root paths from which the webview can load local (filesystem) resources using uris from <c>asWebviewUri</c>
        ///
        /// Default to the root folders of the current workspace plus the extension's install directory.
        ///
        /// Pass in an empty array to disallow access to any local resources.
        /// </summary>
        abstract localResourceRoots: ResizeArray<Uri> option
        /// <summary>
        /// Mappings of localhost ports used inside the webview.
        ///
        /// Port mapping allow webviews to transparently define how localhost ports are resolved. This can be used
        /// to allow using a static localhost port inside the webview that is resolved to random port that a service is
        /// running on.
        ///
        /// If a webview accesses localhost content, we recommend that you specify port mappings even if
        /// the <c>webviewPort</c> and <c>extensionHostPort</c> ports are the same.
        ///
        /// *Note* that port mappings only work for <c>http</c> or <c>https</c> urls. Websocket urls (e.g. <c>ws://localhost:3000</c>)
        /// cannot be mapped to another port.
        /// </summary>
        abstract portMapping: ResizeArray<WebviewPortMapping> option

    /// Displays html content, similarly to an iframe.
    type [<AllowNullLiteral>] Webview =
        /// Content settings for the webview.
        abstract options: WebviewOptions with get, set
        /// <summary>
        /// HTML contents of the webview.
        ///
        /// This should be a complete, valid html document. Changing this property causes the webview to be reloaded.
        ///
        /// Webviews are sandboxed from normal extension process, so all communication with the webview must use
        /// message passing. To send a message from the extension to the webview, use {@linkcode Webview.postMessage postMessage}.
        /// To send message from the webview back to an extension, use the <c>acquireVsCodeApi</c> function inside the webview
        /// to get a handle to the editor's api and then call <c>.postMessage()</c>:
        ///
        /// <code lang="html">
        /// &lt;script&gt;
        ///      const vscode = acquireVsCodeApi(); // acquireVsCodeApi can only be invoked once
        ///      vscode.postMessage({ message: 'hello!' });
        /// &lt;/script&gt;
        /// </code>
        ///
        /// To load a resources from the workspace inside a webview, use the {@linkcode Webview.asWebviewUri asWebviewUri} method
        /// and ensure the resource's directory is listed in {@linkcode WebviewOptions.localResourceRoots}.
        ///
        /// Keep in mind that even though webviews are sandboxed, they still allow running scripts and loading arbitrary content,
        /// so extensions must follow all standard web security best practices when working with webviews. This includes
        /// properly sanitizing all untrusted input (including content from the workspace) and
        /// setting a <see href="https://aka.ms/vscode-api-webview-csp">content security policy</see>.
        /// </summary>
        abstract html: string with get, set
        /// <summary>
        /// Fired when the webview content posts a message.
        ///
        /// Webview content can post strings or json serializable objects back to an extension. They cannot
        /// post <c>Blob</c>, <c>File</c>, <c>ImageData</c> and other DOM specific objects since the extension that receives the
        /// message does not run in a browser environment.
        /// </summary>
        abstract onDidReceiveMessage: Event<obj option>
        /// <summary>
        /// Post a message to the webview content.
        ///
        /// Messages are only delivered if the webview is live (either visible or in the
        /// background with <c>retainContextWhenHidden</c>).
        /// </summary>
        /// <param name="message">
        /// Body of the message. This must be a string or other json serializable object.
        ///
        /// For older versions of vscode, if an <c>ArrayBuffer</c> is included in <c>message</c>,
        /// it will not be serialized properly and will not be received by the webview.
        /// Similarly any TypedArrays, such as a <c>Uint8Array</c>, will be very inefficiently
        /// serialized and will also not be recreated as a typed array inside the webview.
        ///
        /// However if your extension targets vscode 1.57+ in the <c>engines</c> field of its
        /// <c>package.json</c>, any <c>ArrayBuffer</c> values that appear in <c>message</c> will be more
        /// efficiently transferred to the webview and will also be correctly recreated inside
        /// of the webview.
        /// </param>
        abstract postMessage: message: obj option -> Thenable<bool>
        /// <summary>
        /// Convert a uri for the local file system to one that can be used inside webviews.
        ///
        /// Webviews cannot directly load resources from the workspace or local file system using <c>file:</c> uris. The
        /// <c>asWebviewUri</c> function takes a local <c>file:</c> uri and converts it into a uri that can be used inside of
        /// a webview to load the same resource:
        ///
        /// <code lang="ts">
        /// webview.html = `&lt;img src="${webview.asWebviewUri(vscode.Uri.file('/Users/codey/workspace/cat.gif'))}"&gt;`
        /// </code>
        /// </summary>
        abstract asWebviewUri: localResource: Uri -> Uri
        /// Content security policy source for webview resources.
        ///
        /// This is the origin that should be used in a content security policy rule:
        ///
        /// <code lang="ts">
        /// `img-src https: ${webview.cspSource} ...;`
        /// </code>
        abstract cspSource: string

    /// Content settings for a webview panel.
    type [<AllowNullLiteral>] WebviewPanelOptions =
        /// <summary>
        /// Controls if the find widget is enabled in the panel.
        ///
        /// Defaults to <c>false</c>.
        /// </summary>
        abstract enableFindWidget: bool option
        /// <summary>
        /// Controls if the webview panel's content (iframe) is kept around even when the panel
        /// is no longer visible.
        ///
        /// Normally the webview panel's html context is created when the panel becomes visible
        /// and destroyed when it is hidden. Extensions that have complex state
        /// or UI can set the <c>retainContextWhenHidden</c> to make the editor keep the webview
        /// context around, even when the webview moves to a background tab. When a webview using
        /// <c>retainContextWhenHidden</c> becomes hidden, its scripts and other dynamic content are suspended.
        /// When the panel becomes visible again, the context is automatically restored
        /// in the exact same state it was in originally. You cannot send messages to a
        /// hidden webview, even with <c>retainContextWhenHidden</c> enabled.
        ///
        /// <c>retainContextWhenHidden</c> has a high memory overhead and should only be used if
        /// your panel's context cannot be quickly saved and restored.
        /// </summary>
        abstract retainContextWhenHidden: bool option

    /// A panel that contains a webview.
    type [<AllowNullLiteral>] WebviewPanel =
        /// <summary>Identifies the type of the webview panel, such as <c>'markdown.preview'</c>.</summary>
        abstract viewType: string
        /// Title of the panel shown in UI.
        abstract title: string with get, set
        /// Icon for the panel shown in UI.
        abstract iconPath: U2<Uri, {| light: Uri; dark: Uri |}> option with get, set
        /// {@linkcode Webview} belonging to the panel.
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
        /// <summary>
        /// Fired when the panel is disposed.
        ///
        /// This may be because the user closed the panel or because <c>.dispose()</c> was
        /// called on it.
        ///
        /// Trying to use the panel after it has been disposed throws an exception.
        /// </summary>
        abstract onDidDispose: Event<unit>
        /// <summary>
        /// Show the webview panel in a given column.
        ///
        /// A webview panel may only show in a single column at a time. If it is already showing, this
        /// method moves it to a new column.
        /// </summary>
        /// <param name="viewColumn">View column to show the panel in. Shows in the current <c>viewColumn</c> if undefined.</param>
        /// <param name="preserveFocus">When <c>true</c>, the webview will not take focus.</param>
        abstract reveal: ?viewColumn: ViewColumn * ?preserveFocus: bool -> unit
        /// <summary>
        /// Dispose of the webview panel.
        ///
        /// This closes the panel if it showing and disposes of the resources owned by the webview.
        /// Webview panels are also disposed when the user closes the webview panel. Both cases
        /// fire the <c>onDispose</c> event.
        /// </summary>
        abstract dispose: unit -> obj option

    /// Event fired when a webview panel's view state changes.
    type [<AllowNullLiteral>] WebviewPanelOnDidChangeViewStateEvent =
        /// Webview panel whose view state changed.
        abstract webviewPanel: WebviewPanel

    /// <summary>
    /// Restore webview panels that have been persisted when vscode shuts down.
    ///
    /// There are two types of webview persistence:
    ///
    /// - Persistence within a session.
    /// - Persistence across sessions (across restarts of the editor).
    ///
    /// A <c>WebviewPanelSerializer</c> is only required for the second case: persisting a webview across sessions.
    ///
    /// Persistence within a session allows a webview to save its state when it becomes hidden
    /// and restore its content from this state when it becomes visible again. It is powered entirely
    /// by the webview content itself. To save off a persisted state, call <c>acquireVsCodeApi().setState()</c> with
    /// any json serializable object. To restore the state again, call <c>getState()</c>
    ///
    /// <code lang="js">
    /// // Within the webview
    /// const vscode = acquireVsCodeApi();
    ///
    /// // Get existing state
    /// const oldState = vscode.getState() || { value: 0 };
    ///
    /// // Update state
    /// setState({ value: oldState.value + 1 })
    /// </code>
    ///
    /// A <c>WebviewPanelSerializer</c> extends this persistence across restarts of the editor. When the editor is shutdown,
    /// it will save off the state from <c>setState</c> of all webviews that have a serializer. When the
    /// webview first becomes visible after the restart, this state is passed to <c>deserializeWebviewPanel</c>.
    /// The extension can then restore the old <c>WebviewPanel</c> from this state.
    /// </summary>
    /// <param name="T">Type of the webview's state.</param>
    type WebviewPanelSerializer =
        WebviewPanelSerializer<obj>

    /// <summary>
    /// Restore webview panels that have been persisted when vscode shuts down.
    ///
    /// There are two types of webview persistence:
    ///
    /// - Persistence within a session.
    /// - Persistence across sessions (across restarts of the editor).
    ///
    /// A <c>WebviewPanelSerializer</c> is only required for the second case: persisting a webview across sessions.
    ///
    /// Persistence within a session allows a webview to save its state when it becomes hidden
    /// and restore its content from this state when it becomes visible again. It is powered entirely
    /// by the webview content itself. To save off a persisted state, call <c>acquireVsCodeApi().setState()</c> with
    /// any json serializable object. To restore the state again, call <c>getState()</c>
    ///
    /// <code lang="js">
    /// // Within the webview
    /// const vscode = acquireVsCodeApi();
    ///
    /// // Get existing state
    /// const oldState = vscode.getState() || { value: 0 };
    ///
    /// // Update state
    /// setState({ value: oldState.value + 1 })
    /// </code>
    ///
    /// A <c>WebviewPanelSerializer</c> extends this persistence across restarts of the editor. When the editor is shutdown,
    /// it will save off the state from <c>setState</c> of all webviews that have a serializer. When the
    /// webview first becomes visible after the restart, this state is passed to <c>deserializeWebviewPanel</c>.
    /// The extension can then restore the old <c>WebviewPanel</c> from this state.
    /// </summary>
    /// <typeparam name="T">Type of the webview's state.</typeparam>
    type [<AllowNullLiteral>] WebviewPanelSerializer<'T> =
        /// <summary>
        /// Restore a webview panel from its serialized <c>state</c>.
        ///
        /// Called when a serialized webview first becomes visible.
        /// </summary>
        /// <param name="webviewPanel">
        /// Webview panel to restore. The serializer should take ownership of this panel. The
        /// serializer must restore the webview's <c>.html</c> and hook up all webview events.
        /// </param>
        /// <param name="state">Persisted state from the webview content.</param>
        /// <returns>Thenable indicating that the webview has been fully restored.</returns>
        abstract deserializeWebviewPanel: webviewPanel: WebviewPanel * state: 'T -> Thenable<unit>

    /// A webview based view.
    type [<AllowNullLiteral>] WebviewView =
        /// <summary>Identifies the type of the webview view, such as <c>'hexEditor.dataView'</c>.</summary>
        abstract viewType: string
        /// The underlying webview for the view.
        abstract webview: Webview
        /// <summary>
        /// View title displayed in the UI.
        ///
        /// The view title is initially taken from the extension <c>package.json</c> contribution.
        /// </summary>
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
        /// <summary>
        /// Event fired when the visibility of the view changes.
        ///
        /// Actions that trigger a visibility change:
        ///
        /// - The view is collapsed or expanded.
        /// - The user switches to a different view group in the sidebar or panel.
        ///
        /// Note that hiding a view using the context menu instead disposes of the view and fires <c>onDidDispose</c>.
        /// </summary>
        abstract onDidChangeVisibility: Event<unit>
        /// <summary>
        /// Reveal the view in the UI.
        ///
        /// If the view is collapsed, this will expand it.
        /// </summary>
        /// <param name="preserveFocus">When <c>true</c> the view will not take focus.</param>
        abstract show: ?preserveFocus: bool -> unit

    /// <summary>Additional information the webview view being resolved.</summary>
    /// <param name="T">Type of the webview's state.</param>
    type WebviewViewResolveContext =
        WebviewViewResolveContext<obj>

    /// <summary>Additional information the webview view being resolved.</summary>
    /// <typeparam name="T">Type of the webview's state.</typeparam>
    type [<AllowNullLiteral>] WebviewViewResolveContext<'T> =
        /// <summary>
        /// Persisted state from the webview content.
        ///
        /// To save resources, the editor normally deallocates webview documents (the iframe content) that are not visible.
        /// For example, when the user collapse a view or switches to another top level activity in the sidebar, the
        /// <c>WebviewView</c> itself is kept alive but the webview's underlying document is deallocated. It is recreated when
        /// the view becomes visible again.
        ///
        /// You can prevent this behavior by setting <c>retainContextWhenHidden</c> in the <c>WebviewOptions</c>. However this
        /// increases resource usage and should be avoided wherever possible. Instead, you can use persisted state to
        /// save off a webview's state so that it can be quickly recreated as needed.
        ///
        /// To save off a persisted state, inside the webview call <c>acquireVsCodeApi().setState()</c> with
        /// any json serializable object. To restore the state again, call <c>getState()</c>. For example:
        ///
        /// <code lang="js">
        /// // Within the webview
        /// const vscode = acquireVsCodeApi();
        ///
        /// // Get existing state
        /// const oldState = vscode.getState() || { value: 0 };
        ///
        /// // Update state
        /// setState({ value: oldState.value + 1 })
        /// </code>
        ///
        /// The editor ensures that the persisted state is saved correctly when a webview is hidden and across
        /// editor restarts.
        /// </summary>
        abstract state: 'T option

    /// <summary>Provider for creating <c>WebviewView</c> elements.</summary>
    type [<AllowNullLiteral>] WebviewViewProvider =
        /// <summary>
        /// Revolves a webview view.
        ///
        /// <c>resolveWebviewView</c> is called when a view first becomes visible. This may happen when the view is
        /// first loaded or when the user hides and then shows a view again.
        /// </summary>
        /// <param name="webviewView">
        /// Webview view to restore. The provider should take ownership of this view. The
        /// provider must set the webview's <c>.html</c> and hook up all webview events it is interested in.
        /// </param>
        /// <param name="context">Additional metadata about the view being resolved.</param>
        /// <param name="token">Cancellation token indicating that the view being provided is no longer needed.</param>
        /// <returns>Optional thenable indicating that the view has been fully resolved.</returns>
        abstract resolveWebviewView: webviewView: WebviewView * context: WebviewViewResolveContext * token: CancellationToken -> U2<Thenable<unit>, unit>

    /// <summary>
    /// Provider for text based custom editors.
    ///
    /// Text based custom editors use a {@linkcode TextDocument} as their data model. This considerably simplifies
    /// implementing a custom editor as it allows the editor to handle many common operations such as
    /// undo and backup. The provider is responsible for synchronizing text changes between the webview and the <c>TextDocument</c>.
    /// </summary>
    type [<AllowNullLiteral>] CustomTextEditorProvider =
        /// <summary>
        /// Resolve a custom editor for a given text resource.
        ///
        /// This is called when a user first opens a resource for a <c>CustomTextEditorProvider</c>, or if they reopen an
        /// existing editor using this <c>CustomTextEditorProvider</c>.
        /// </summary>
        /// <param name="document">Document for the resource to resolve.</param>
        /// <param name="webviewPanel">
        /// The webview panel used to display the editor UI for this resource.
        ///
        /// During resolve, the provider must fill in the initial html for the content webview panel and hook up all
        /// the event listeners on it that it is interested in. The provider can also hold onto the <c>WebviewPanel</c> to
        /// use later for example in a command. See {
        /// </param>
        /// <param name="token">A cancellation token that indicates the result is no longer needed.</param>
        /// <returns>Thenable indicating that the custom editor has been resolved.</returns>
        abstract resolveCustomTextEditor: document: TextDocument * webviewPanel: WebviewPanel * token: CancellationToken -> U2<Thenable<unit>, unit>

    /// <summary>
    /// Represents a custom document used by a {@linkcode CustomEditorProvider}.
    ///
    /// Custom documents are only used within a given <c>CustomEditorProvider</c>. The lifecycle of a <c>CustomDocument</c> is
    /// managed by the editor. When no more references remain to a <c>CustomDocument</c>, it is disposed of.
    /// </summary>
    type [<AllowNullLiteral>] CustomDocument =
        /// The associated uri for this document.
        abstract uri: Uri
        /// <summary>
        /// Dispose of the custom document.
        ///
        /// This is invoked by the editor when there are no more references to a given <c>CustomDocument</c> (for example when
        /// all editors associated with the document have been closed.)
        /// </summary>
        abstract dispose: unit -> unit

    /// <summary>Event triggered by extensions to signal to the editor that an edit has occurred on an {@linkcode CustomDocument}.</summary>
    /// <seealso cref="{" />
    type CustomDocumentEditEvent =
        CustomDocumentEditEvent<CustomDocument>

    /// <summary>Event triggered by extensions to signal to the editor that an edit has occurred on an {@linkcode CustomDocument}.</summary>
    /// <seealso cref="{" />
    type [<AllowNullLiteral>] CustomDocumentEditEvent<'T when 'T :> CustomDocument> =
        /// The document that the edit is for.
        abstract document: 'T
        /// <summary>
        /// Undo the edit operation.
        ///
        /// This is invoked by the editor when the user undoes this edit. To implement <c>undo</c>, your
        /// extension should restore the document and editor to the state they were in just before this
        /// edit was added to the editor's internal edit stack by <c>onDidChangeCustomDocument</c>.
        /// </summary>
        abstract undo: unit -> U2<Thenable<unit>, unit>
        /// <summary>
        /// Redo the edit operation.
        ///
        /// This is invoked by the editor when the user redoes this edit. To implement <c>redo</c>, your
        /// extension should restore the document and editor to the state they were in just after this
        /// edit was added to the editor's internal edit stack by <c>onDidChangeCustomDocument</c>.
        /// </summary>
        abstract redo: unit -> U2<Thenable<unit>, unit>
        /// Display name describing the edit.
        ///
        /// This will be shown to users in the UI for undo/redo operations.
        abstract label: string option

    /// <summary>
    /// Event triggered by extensions to signal to the editor that the content of a {@linkcode CustomDocument}
    /// has changed.
    /// </summary>
    /// <seealso cref="{" />
    type CustomDocumentContentChangeEvent =
        CustomDocumentContentChangeEvent<CustomDocument>

    /// <summary>
    /// Event triggered by extensions to signal to the editor that the content of a {@linkcode CustomDocument}
    /// has changed.
    /// </summary>
    /// <seealso cref="{" />
    type [<AllowNullLiteral>] CustomDocumentContentChangeEvent<'T when 'T :> CustomDocument> =
        /// The document that the change is for.
        abstract document: 'T

    /// A backup for an {@linkcode CustomDocument}.
    type [<AllowNullLiteral>] CustomDocumentBackup =
        /// <summary>
        /// Unique identifier for the backup.
        ///
        /// This id is passed back to your extension in <c>openCustomDocument</c> when opening a custom editor from a backup.
        /// </summary>
        abstract id: string
        /// Delete the current backup.
        ///
        /// This is called by the editor when it is clear the current backup is no longer needed, such as when a new backup
        /// is made or when the file is saved.
        abstract delete: unit -> unit

    /// Additional information used to implement {@linkcode CustomEditableDocument.backup}.
    type [<AllowNullLiteral>] CustomDocumentBackupContext =
        /// <summary>
        /// Suggested file location to write the new backup.
        ///
        /// Note that your extension is free to ignore this and use its own strategy for backup.
        ///
        /// If the editor is for a resource from the current workspace, <c>destination</c> will point to a file inside
        /// <c>ExtensionContext.storagePath</c>. The parent folder of <c>destination</c> may not exist, so make sure to created it
        /// before writing the backup to this location.
        /// </summary>
        abstract destination: Uri

    /// Additional information about the opening custom document.
    type [<AllowNullLiteral>] CustomDocumentOpenContext =
        /// <summary>
        /// The id of the backup to restore the document from or <c>undefined</c> if there is no backup.
        ///
        /// If this is provided, your extension should restore the editor from the backup instead of reading the file
        /// from the user's workspace.
        /// </summary>
        abstract backupId: string option
        /// If the URI is an untitled file, this will be populated with the byte data of that file
        ///
        /// If this is provided, your extension should utilize this byte data rather than executing fs APIs on the URI passed in
        abstract untitledDocumentData: Uint8Array option

    /// <summary>
    /// Provider for readonly custom editors that use a custom document model.
    ///
    /// Custom editors use {@linkcode CustomDocument} as their document model instead of a {@linkcode TextDocument}.
    ///
    /// You should use this type of custom editor when dealing with binary files or more complex scenarios. For simple
    /// text based documents, use {@linkcode CustomTextEditorProvider} instead.
    /// </summary>
    /// <param name="T">Type of the custom document returned by this provider.</param>
    type CustomReadonlyEditorProvider =
        CustomReadonlyEditorProvider<CustomDocument>

    /// <summary>
    /// Provider for readonly custom editors that use a custom document model.
    ///
    /// Custom editors use {@linkcode CustomDocument} as their document model instead of a {@linkcode TextDocument}.
    ///
    /// You should use this type of custom editor when dealing with binary files or more complex scenarios. For simple
    /// text based documents, use {@linkcode CustomTextEditorProvider} instead.
    /// </summary>
    /// <typeparam name="T">Type of the custom document returned by this provider.</typeparam>
    type [<AllowNullLiteral>] CustomReadonlyEditorProvider<'T when 'T :> CustomDocument> =
        /// <summary>
        /// Create a new document for a given resource.
        ///
        /// <c>openCustomDocument</c> is called when the first time an editor for a given resource is opened. The opened
        /// document is then passed to <c>resolveCustomEditor</c> so that the editor can be shown to the user.
        ///
        /// Already opened <c>CustomDocument</c> are re-used if the user opened additional editors. When all editors for a
        /// given resource are closed, the <c>CustomDocument</c> is disposed of. Opening an editor at this point will
        /// trigger another call to <c>openCustomDocument</c>.
        /// </summary>
        /// <param name="uri">Uri of the document to open.</param>
        /// <param name="openContext">Additional information about the opening custom document.</param>
        /// <param name="token">A cancellation token that indicates the result is no longer needed.</param>
        /// <returns>The custom document.</returns>
        abstract openCustomDocument: uri: Uri * openContext: CustomDocumentOpenContext * token: CancellationToken -> U2<Thenable<'T>, 'T>
        /// <summary>
        /// Resolve a custom editor for a given resource.
        ///
        /// This is called whenever the user opens a new editor for this <c>CustomEditorProvider</c>.
        /// </summary>
        /// <param name="document">Document for the resource being resolved.</param>
        /// <param name="webviewPanel">
        /// The webview panel used to display the editor UI for this resource.
        ///
        /// During resolve, the provider must fill in the initial html for the content webview panel and hook up all
        /// the event listeners on it that it is interested in. The provider can also hold onto the <c>WebviewPanel</c> to
        /// use later for example in a command. See {
        /// </param>
        /// <param name="token">A cancellation token that indicates the result is no longer needed.</param>
        /// <returns>Optional thenable indicating that the custom editor has been resolved.</returns>
        abstract resolveCustomEditor: document: 'T * webviewPanel: WebviewPanel * token: CancellationToken -> U2<Thenable<unit>, unit>

    /// <summary>
    /// Provider for editable custom editors that use a custom document model.
    ///
    /// Custom editors use {@linkcode CustomDocument} as their document model instead of a {@linkcode TextDocument}.
    /// This gives extensions full control over actions such as edit, save, and backup.
    ///
    /// You should use this type of custom editor when dealing with binary files or more complex scenarios. For simple
    /// text based documents, use {@linkcode CustomTextEditorProvider} instead.
    /// </summary>
    /// <param name="T">Type of the custom document returned by this provider.</param>
    type CustomEditorProvider =
        CustomEditorProvider<CustomDocument>

    /// <summary>
    /// Provider for editable custom editors that use a custom document model.
    ///
    /// Custom editors use {@linkcode CustomDocument} as their document model instead of a {@linkcode TextDocument}.
    /// This gives extensions full control over actions such as edit, save, and backup.
    ///
    /// You should use this type of custom editor when dealing with binary files or more complex scenarios. For simple
    /// text based documents, use {@linkcode CustomTextEditorProvider} instead.
    /// </summary>
    /// <typeparam name="T">Type of the custom document returned by this provider.</typeparam>
    type [<AllowNullLiteral>] CustomEditorProvider<'T when 'T :> CustomDocument> =
        inherit CustomReadonlyEditorProvider<'T>
        /// <summary>
        /// Signal that an edit has occurred inside a custom editor.
        ///
        /// This event must be fired by your extension whenever an edit happens in a custom editor. An edit can be
        /// anything from changing some text, to cropping an image, to reordering a list. Your extension is free to
        /// define what an edit is and what data is stored on each edit.
        ///
        /// Firing <c>onDidChange</c> causes the editors to be marked as being dirty. This is cleared when the user either
        /// saves or reverts the file.
        ///
        /// Editors that support undo/redo must fire a <c>CustomDocumentEditEvent</c> whenever an edit happens. This allows
        /// users to undo and redo the edit using the editor's standard keyboard shortcuts. The editor will also mark
        /// the editor as no longer being dirty if the user undoes all edits to the last saved state.
        ///
        /// Editors that support editing but cannot use the editor's standard undo/redo mechanism must fire a <c>CustomDocumentContentChangeEvent</c>.
        /// The only way for a user to clear the dirty state of an editor that does not support undo/redo is to either
        /// <c>save</c> or <c>revert</c> the file.
        ///
        /// An editor should only ever fire <c>CustomDocumentEditEvent</c> events, or only ever fire <c>CustomDocumentContentChangeEvent</c> events.
        /// </summary>
        abstract onDidChangeCustomDocument: U2<Event<CustomDocumentEditEvent<'T>>, Event<CustomDocumentContentChangeEvent<'T>>>
        /// <summary>
        /// Save a custom document.
        ///
        /// This method is invoked by the editor when the user saves a custom editor. This can happen when the user
        /// triggers save while the custom editor is active, by commands such as <c>save all</c>, or by auto save if enabled.
        ///
        /// To implement <c>save</c>, the implementer must persist the custom editor. This usually means writing the
        /// file data for the custom document to disk. After <c>save</c> completes, any associated editor instances will
        /// no longer be marked as dirty.
        /// </summary>
        /// <param name="document">Document to save.</param>
        /// <param name="cancellation">Token that signals the save is no longer required (for example, if another save was triggered).</param>
        /// <returns>Thenable signaling that saving has completed.</returns>
        abstract saveCustomDocument: document: 'T * cancellation: CancellationToken -> Thenable<unit>
        /// <summary>
        /// Save a custom document to a different location.
        ///
        /// This method is invoked by the editor when the user triggers 'save as' on a custom editor. The implementer must
        /// persist the custom editor to <c>destination</c>.
        ///
        /// When the user accepts save as, the current editor is be replaced by an non-dirty editor for the newly saved file.
        /// </summary>
        /// <param name="document">Document to save.</param>
        /// <param name="destination">Location to save to.</param>
        /// <param name="cancellation">Token that signals the save is no longer required.</param>
        /// <returns>Thenable signaling that saving has completed.</returns>
        abstract saveCustomDocumentAs: document: 'T * destination: Uri * cancellation: CancellationToken -> Thenable<unit>
        /// <summary>
        /// Revert a custom document to its last saved state.
        ///
        /// This method is invoked by the editor when the user triggers <c>File: Revert File</c> in a custom editor. (Note that
        /// this is only used using the editor's <c>File: Revert File</c> command and not on a <c>git revert</c> of the file).
        ///
        /// To implement <c>revert</c>, the implementer must make sure all editor instances (webviews) for <c>document</c>
        /// are displaying the document in the same state is saved in. This usually means reloading the file from the
        /// workspace.
        /// </summary>
        /// <param name="document">Document to revert.</param>
        /// <param name="cancellation">Token that signals the revert is no longer required.</param>
        /// <returns>Thenable signaling that the change has completed.</returns>
        abstract revertCustomDocument: document: 'T * cancellation: CancellationToken -> Thenable<unit>
        /// <summary>
        /// Back up a dirty custom document.
        ///
        /// Backups are used for hot exit and to prevent data loss. Your <c>backup</c> method should persist the resource in
        /// its current state, i.e. with the edits applied. Most commonly this means saving the resource to disk in
        /// the <c>ExtensionContext.storagePath</c>. When the editor reloads and your custom editor is opened for a resource,
        /// your extension should first check to see if any backups exist for the resource. If there is a backup, your
        /// extension should load the file contents from there instead of from the resource in the workspace.
        ///
        /// <c>backup</c> is triggered approximately one second after the user stops editing the document. If the user
        /// rapidly edits the document, <c>backup</c> will not be invoked until the editing stops.
        ///
        /// <c>backup</c> is not invoked when <c>auto save</c> is enabled (since auto save already persists the resource).
        /// </summary>
        /// <param name="document">Document to backup.</param>
        /// <param name="context">Information that can be used to backup the document.</param>
        /// <param name="cancellation">
        /// Token that signals the current backup since a new backup is coming in. It is up to your
        /// extension to decided how to respond to cancellation. If for example your extension is backing up a large file
        /// in an operation that takes time to complete, your extension may decide to finish the ongoing backup rather
        /// than cancelling it to ensure that the editor has some valid backup.
        /// </param>
        abstract backupCustomDocument: document: 'T * context: CustomDocumentBackupContext * cancellation: CancellationToken -> Thenable<CustomDocumentBackup>

    /// The clipboard provides read and write access to the system's clipboard.
    type [<AllowNullLiteral>] Clipboard =
        /// <summary>Read the current clipboard contents as text.</summary>
        /// <returns>A thenable that resolves to a string.</returns>
        abstract readText: unit -> Thenable<string>
        /// <summary>Writes text into the clipboard.</summary>
        /// <returns>A thenable that resolves when writing happened.</returns>
        abstract writeText: value: string -> Thenable<unit>

    /// Possible kinds of UI that can use extensions.
    type [<RequireQualifiedAccess>] UIKind =
        /// Extensions are accessed from a desktop application.
        | Desktop = 1
        /// Extensions are accessed from a web browser.
        | Web = 2

    /// Namespace describing the environment the editor runs in.
    module Env =

        type [<AllowNullLiteral>] IExports =
            /// The application name of the editor, like 'VS Code'.
            abstract appName: string
            /// The application root folder from which the editor is running.
            ///
            /// *Note* that the value is the empty string when running in an
            /// environment that has no representation of an application root folder.
            abstract appRoot: string
            /// The hosted location of the application
            /// On desktop this is 'desktop'
            /// In the web this is the specified embedder i.e. 'github.dev', 'codespaces', or 'web' if the embedder
            /// does not provide that information
            abstract appHost: string
            /// The custom uri scheme the editor registers to in the operating system.
            abstract uriScheme: string
            /// <summary>Represents the preferred user-language, like <c>de-CH</c>, <c>fr</c>, or <c>en-US</c>.</summary>
            abstract language: string
            /// The system clipboard.
            abstract clipboard: Clipboard
            /// A unique identifier for the computer.
            abstract machineId: string
            /// A unique identifier for the current session.
            /// Changes each time the editor is started.
            abstract sessionId: string
            /// <summary>
            /// Indicates that this is a fresh install of the application.
            /// <c>true</c> if within the first day of installation otherwise <c>false</c>.
            /// </summary>
            abstract isNewAppInstall: bool
            /// Indicates whether the users has telemetry enabled.
            /// Can be observed to determine if the extension should send telemetry.
            abstract isTelemetryEnabled: bool
            /// <summary>
            /// An <see cref="Event" /> which fires when the user enabled or disables telemetry.
            /// <c>true</c> if the user has enabled telemetry or <c>false</c> if the user has disabled telemetry.
            /// </summary>
            abstract onDidChangeTelemetryEnabled: Event<bool>
            /// <summary>
            /// The name of a remote. Defined by extensions, popular samples are <c>wsl</c> for the Windows
            /// Subsystem for Linux or <c>ssh-remote</c> for remotes using a secure shell.
            ///
            /// *Note* that the value is <c>undefined</c> when there is no remote extension host but that the
            /// value is defined in all extension hosts (local and remote) in case a remote extension host
            /// exists. Use <see cref="Extension.extensionKind" /> to know if
            /// a specific extension runs remote or not.
            /// </summary>
            abstract remoteName: string option
            /// <summary>
            /// The detected default shell for the extension host, this is overridden by the
            /// <c>terminal.integrated.defaultProfile</c> setting for the extension host's platform. Note that in
            /// environments that do not support a shell the value is the empty string.
            /// </summary>
            abstract shell: string
            /// The UI kind property indicates from which UI extensions
            /// are accessed from. For example, extensions could be accessed
            /// from a desktop application or a web browser.
            abstract uiKind: UIKind
            /// <summary>
            /// Opens a link externally using the default application. Depending on the
            /// used scheme this can be:
            /// * a browser (<c>http:</c>, <c>https:</c>)
            /// * a mail client (<c>mailto:</c>)
            /// * VSCode itself (<c>vscode:</c> from <c>vscode.env.uriScheme</c>)
            ///
            /// *Note* that {@linkcode window.showTextDocument showTextDocument} is the right
            /// way to open a text document inside the editor, not this function.
            /// </summary>
            /// <param name="target">The uri that should be opened.</param>
            /// <returns>A promise indicating if open was successful.</returns>
            abstract openExternal: target: Uri -> Thenable<bool>
            /// <summary>
            /// Resolves a uri to a form that is accessible externally.
            ///
            /// #### <c>http:</c> or <c>https:</c> scheme
            ///
            /// Resolves an *external* uri, such as a <c>http:</c> or <c>https:</c> link, from where the extension is running to a
            /// uri to the same resource on the client machine.
            ///
            /// This is a no-op if the extension is running on the client machine.
            ///
            /// If the extension is running remotely, this function automatically establishes a port forwarding tunnel
            /// from the local machine to <c>target</c> on the remote and returns a local uri to the tunnel. The lifetime of
            /// the port forwarding tunnel is managed by the editor and the tunnel can be closed by the user.
            ///
            /// *Note* that uris passed through <c>openExternal</c> are automatically resolved and you should not call <c>asExternalUri</c> on them.
            ///
            /// #### <c>vscode.env.uriScheme</c>
            ///
            /// Creates a uri that - if opened in a browser (e.g. via <c>openExternal</c>) - will result in a registered <see cref="UriHandler" />
            /// to trigger.
            ///
            /// Extensions should not make any assumptions about the resulting uri and should not alter it in any way.
            /// Rather, extensions can e.g. use this uri in an authentication flow, by adding the uri as callback query
            /// argument to the server to authenticate to.
            ///
            /// *Note* that if the server decides to add additional query parameters to the uri (e.g. a token or secret), it
            /// will appear in the uri that is passed to the <see cref="UriHandler" />.
            ///
            /// **Example** of an authentication flow:
            /// <code lang="typescript">
            /// vscode.window.registerUriHandler({
            ///    handleUri(uri: vscode.Uri): vscode.ProviderResult&lt;void&gt; {
            ///      if (uri.path === '/did-authenticate') {
            ///        console.log(uri.toString());
            ///      }
            ///    }
            /// });
            ///
            /// const callableUri = await vscode.env.asExternalUri(vscode.Uri.parse(`${vscode.env.uriScheme}://my.extension/did-authenticate`));
            /// await vscode.env.openExternal(callableUri);
            /// </code>
            ///
            /// *Note* that extensions should not cache the result of <c>asExternalUri</c> as the resolved uri may become invalid due to
            /// a system or user action — for example, in remote cases, a user may close a port forwarding tunnel that was opened by
            /// <c>asExternalUri</c>.
            ///
            /// #### Any other scheme
            ///
            /// Any other scheme will be handled as if the provided URI is a workspace URI. In that case, the method will return
            /// a URI which, when handled, will make the editor open the workspace.
            /// </summary>
            /// <returns>A uri that can be used on the client machine.</returns>
            abstract asExternalUri: target: Uri -> Thenable<Uri>

    /// <summary>
    /// Namespace for dealing with commands. In short, a command is a function with a
    /// unique identifier. The function is sometimes also called _command handler_.
    ///
    /// Commands can be added to the editor using the <see cref="commands.registerCommand">registerCommand</see>
    /// and <see cref="commands.registerTextEditorCommand">registerTextEditorCommand</see> functions. Commands
    /// can be executed <see cref="commands.executeCommand">manually</see> or from a UI gesture. Those are:
    ///
    /// * palette - Use the <c>commands</c>-section in <c>package.json</c> to make a command show in
    /// the <see href="https://code.visualstudio.com/docs/getstarted/userinterface#_command-palette">command palette</see>.
    /// * keybinding - Use the <c>keybindings</c>-section in <c>package.json</c> to enable
    /// <see href="https://code.visualstudio.com/docs/getstarted/keybindings#_customizing-shortcuts">keybindings</see>
    /// for your extension.
    ///
    /// Commands from other extensions and from the editor itself are accessible to an extension. However,
    /// when invoking an editor command not all argument types are supported.
    ///
    /// This is a sample that registers a command handler and adds an entry for that command to the palette. First
    /// register a command handler with the identifier <c>extension.sayHello</c>.
    /// <code lang="javascript">
    /// commands.registerCommand('extension.sayHello', () =&gt; {
    ///      window.showInformationMessage('Hello World!');
    /// });
    /// </code>
    /// Second, bind the command identifier to a title under which it will show in the palette (<c>package.json</c>).
    /// <code lang="json">
    /// {
    ///      "contributes": {
    ///          "commands": [{
    ///              "command": "extension.sayHello",
    ///              "title": "Hello World"
    ///          }]
    ///      }
    /// }
    /// </code>
    /// </summary>
    module Commands =

        type [<AllowNullLiteral>] IExports =
            /// <summary>
            /// Registers a command that can be invoked via a keyboard shortcut,
            /// a menu item, an action, or directly.
            ///
            /// Registering a command with an existing command identifier twice
            /// will cause an error.
            /// </summary>
            /// <param name="command">A unique identifier for the command.</param>
            /// <param name="callback">A command handler function.</param>
            /// <param name="thisArg">The <c>this</c> context used when invoking the handler function.</param>
            /// <returns>Disposable which unregisters this command on disposal.</returns>
            abstract registerCommand: command: string * callback: (ResizeArray<obj option> -> obj option) * ?thisArg: obj -> Disposable
            /// <summary>
            /// Registers a text editor command that can be invoked via a keyboard shortcut,
            /// a menu item, an action, or directly.
            ///
            /// Text editor commands are different from ordinary <see cref="commands.registerCommand">commands</see> as
            /// they only execute when there is an active editor when the command is called. Also, the
            /// command handler of an editor command has access to the active editor and to an
            /// <see cref="TextEditorEdit">edit</see>-builder. Note that the edit-builder is only valid while the
            /// callback executes.
            /// </summary>
            /// <param name="command">A unique identifier for the command.</param>
            /// <param name="callback">A command handler function with access to an <see cref="TextEditor">editor</see> and an <see cref="TextEditorEdit">edit</see>.</param>
            /// <param name="thisArg">The <c>this</c> context used when invoking the handler function.</param>
            /// <returns>Disposable which unregisters this command on disposal.</returns>
            abstract registerTextEditorCommand: command: string * callback: (TextEditor -> TextEditorEdit -> ResizeArray<obj option> -> unit) * ?thisArg: obj -> Disposable
            /// <summary>
            /// Executes the command denoted by the given command identifier.
            ///
            /// * *Note 1:* When executing an editor command not all types are allowed to
            /// be passed as arguments. Allowed are the primitive types <c>string</c>, <c>boolean</c>,
            /// <c>number</c>, <c>undefined</c>, and <c>null</c>, as well as {@linkcode Position}, {@linkcode Range}, {@linkcode Uri} and {@linkcode Location}.
            /// * *Note 2:* There are no restrictions when executing commands that have been contributed
            /// by extensions.
            /// </summary>
            /// <param name="command">Identifier of the command to execute.</param>
            /// <param name="rest">Parameters passed to the command function.</param>
            /// <returns>
            /// A thenable that resolves to the returned value of the given command. Returns <c>undefined</c> when
            /// the command handler function doesn't return anything.
            /// </returns>
            abstract executeCommand: command: string * [<ParamArray>] rest: obj option[] -> Thenable<'T>
            /// <summary>
            /// Retrieve the list of all available commands. Commands starting with an underscore are
            /// treated as internal commands.
            /// </summary>
            /// <param name="filterInternal">Set <c>true</c> to not see internal commands (starting with an underscore)</param>
            /// <returns>Thenable that resolves to a list of command ids.</returns>
            abstract getCommands: ?filterInternal: bool -> Thenable<ResizeArray<string>>

    /// Represents the state of a window.
    type [<AllowNullLiteral>] WindowState =
        /// Whether the current window is focused.
        abstract focused: bool

    /// <summary>A uri handler is responsible for handling system-wide <see cref="Uri">uris</see>.</summary>
    /// <seealso cref="window.registerUriHandler">.</seealso>
    type [<AllowNullLiteral>] UriHandler =
        /// <summary>Handle the provided system-wide <see cref="Uri" />.</summary>
        /// <seealso cref="window.registerUriHandler">.</seealso>
        abstract handleUri: uri: Uri -> ProviderResult<unit>

    /// Namespace for dealing with the current window of the editor. That is visible
    /// and active editors, as well as, UI elements to show messages, selections, and
    /// asking for user input.
    module Window =

        type [<AllowNullLiteral>] IExports =
            /// <summary>
            /// The currently active editor or <c>undefined</c>. The active editor is the one
            /// that currently has focus or, when none has focus, the one that has changed
            /// input most recently.
            /// </summary>
            abstract activeTextEditor: TextEditor option with get, set
            /// The currently visible editors or an empty array.
            abstract visibleTextEditors: ResizeArray<TextEditor> with get, set
            /// <summary>
            /// An <see cref="Event" /> which fires when the <see cref="window.activeTextEditor">active editor</see>
            /// has changed. *Note* that the event also fires when the active editor changes
            /// to <c>undefined</c>.
            /// </summary>
            abstract onDidChangeActiveTextEditor: Event<TextEditor option>
            /// <summary>
            /// An <see cref="Event" /> which fires when the array of <see cref="window.visibleTextEditors">visible editors</see>
            /// has changed.
            /// </summary>
            abstract onDidChangeVisibleTextEditors: Event<ResizeArray<TextEditor>>
            /// <summary>An <see cref="Event" /> which fires when the selection in an editor has changed.</summary>
            abstract onDidChangeTextEditorSelection: Event<TextEditorSelectionChangeEvent>
            /// <summary>An <see cref="Event" /> which fires when the visible ranges of an editor has changed.</summary>
            abstract onDidChangeTextEditorVisibleRanges: Event<TextEditorVisibleRangesChangeEvent>
            /// <summary>An <see cref="Event" /> which fires when the options of an editor have changed.</summary>
            abstract onDidChangeTextEditorOptions: Event<TextEditorOptionsChangeEvent>
            /// <summary>An <see cref="Event" /> which fires when the view column of an editor has changed.</summary>
            abstract onDidChangeTextEditorViewColumn: Event<TextEditorViewColumnChangeEvent>
            /// The currently opened terminals or an empty array.
            abstract terminals: ResizeArray<Terminal>
            /// <summary>
            /// The currently active terminal or <c>undefined</c>. The active terminal is the one that
            /// currently has focus or most recently had focus.
            /// </summary>
            abstract activeTerminal: Terminal option
            /// <summary>
            /// An <see cref="Event" /> which fires when the <see cref="window.activeTerminal">active terminal</see>
            /// has changed. *Note* that the event also fires when the active terminal changes
            /// to <c>undefined</c>.
            /// </summary>
            abstract onDidChangeActiveTerminal: Event<Terminal option>
            /// <summary>
            /// An <see cref="Event" /> which fires when a terminal has been created, either through the
            /// <see cref="window.createTerminal">createTerminal</see> API or commands.
            /// </summary>
            abstract onDidOpenTerminal: Event<Terminal>
            /// <summary>An <see cref="Event" /> which fires when a terminal is disposed.</summary>
            abstract onDidCloseTerminal: Event<Terminal>
            /// <summary>An <see cref="Event" /> which fires when a <see cref="Terminal.state">terminal's state</see> has changed.</summary>
            abstract onDidChangeTerminalState: Event<Terminal>
            /// Represents the current window's state.
            abstract state: WindowState
            /// <summary>
            /// An <see cref="Event" /> which fires when the focus state of the current window
            /// changes. The value of the event represents whether the window is focused.
            /// </summary>
            abstract onDidChangeWindowState: Event<WindowState>
            /// <summary>
            /// Show the given document in a text editor. A <see cref="ViewColumn">column</see> can be provided
            /// to control where the editor is being shown. Might change the <see cref="window.activeTextEditor">active editor</see>.
            /// </summary>
            /// <param name="document">A text document to be shown.</param>
            /// <param name="column">
            /// A view column in which the <see cref="TextEditor">editor</see> should be shown. The default is the <see cref="ViewColumn.Active">active</see>, other values
            /// are adjusted to be <c>Min(column, columnCount + 1)</c>, the <see cref="ViewColumn.Active">active</see>-column is not adjusted. Use {
            /// </param>
            /// <param name="preserveFocus">When <c>true</c> the editor will not take focus.</param>
            /// <returns>A promise that resolves to an <see cref="TextEditor">editor</see>.</returns>
            abstract showTextDocument: document: TextDocument * ?column: ViewColumn * ?preserveFocus: bool -> Thenable<TextEditor>
            /// <summary>
            /// Show the given document in a text editor. <see cref="TextDocumentShowOptions">Options</see> can be provided
            /// to control options of the editor is being shown. Might change the <see cref="window.activeTextEditor">active editor</see>.
            /// </summary>
            /// <param name="document">A text document to be shown.</param>
            /// <param name="options" />
            /// <returns>A promise that resolves to an <see cref="TextEditor">editor</see>.</returns>
            abstract showTextDocument: document: TextDocument * ?options: TextDocumentShowOptions -> Thenable<TextEditor>
            /// <summary>A short-hand for <c>openTextDocument(uri).then(document =&gt; showTextDocument(document, options))</c>.</summary>
            /// <seealso cref="workspace.openTextDocument" />
            /// <param name="uri">A resource identifier.</param>
            /// <param name="options" />
            /// <returns>A promise that resolves to an <see cref="TextEditor">editor</see>.</returns>
            abstract showTextDocument: uri: Uri * ?options: TextDocumentShowOptions -> Thenable<TextEditor>
            /// <summary>Create a TextEditorDecorationType that can be used to add decorations to text editors.</summary>
            /// <param name="options">Rendering options for the decoration type.</param>
            /// <returns>A new decoration type instance.</returns>
            abstract createTextEditorDecorationType: options: DecorationRenderOptions -> TextEditorDecorationType
            /// <summary>
            /// Show an information message to users. Optionally provide an array of items which will be presented as
            /// clickable buttons.
            /// </summary>
            /// <param name="message">The message to show.</param>
            /// <param name="items">A set of items that will be rendered as actions in the message.</param>
            /// <returns>A thenable that resolves to the selected item or <c>undefined</c> when being dismissed.</returns>
            abstract showInformationMessage: message: string * [<ParamArray>] items: string[] -> Thenable<string option>
            /// <summary>
            /// Show an information message to users. Optionally provide an array of items which will be presented as
            /// clickable buttons.
            /// </summary>
            /// <param name="message">The message to show.</param>
            /// <param name="options">Configures the behaviour of the message.</param>
            /// <param name="items">A set of items that will be rendered as actions in the message.</param>
            /// <returns>A thenable that resolves to the selected item or <c>undefined</c> when being dismissed.</returns>
            abstract showInformationMessage: message: string * options: MessageOptions * [<ParamArray>] items: string[] -> Thenable<string option>
            /// <summary>Show an information message.</summary>
            /// <seealso cref="window.showInformationMessage">showInformationMessage</seealso>
            /// <param name="message">The message to show.</param>
            /// <param name="items">A set of items that will be rendered as actions in the message.</param>
            /// <returns>A thenable that resolves to the selected item or <c>undefined</c> when being dismissed.</returns>
            abstract showInformationMessage: message: string * [<ParamArray>] items: 'T[] -> Thenable<'T option> when 'T :> MessageItem
            /// <summary>Show an information message.</summary>
            /// <seealso cref="window.showInformationMessage">showInformationMessage</seealso>
            /// <param name="message">The message to show.</param>
            /// <param name="options">Configures the behaviour of the message.</param>
            /// <param name="items">A set of items that will be rendered as actions in the message.</param>
            /// <returns>A thenable that resolves to the selected item or <c>undefined</c> when being dismissed.</returns>
            abstract showInformationMessage: message: string * options: MessageOptions * [<ParamArray>] items: 'T[] -> Thenable<'T option> when 'T :> MessageItem
            /// <summary>Show a warning message.</summary>
            /// <seealso cref="window.showInformationMessage">showInformationMessage</seealso>
            /// <param name="message">The message to show.</param>
            /// <param name="items">A set of items that will be rendered as actions in the message.</param>
            /// <returns>A thenable that resolves to the selected item or <c>undefined</c> when being dismissed.</returns>
            abstract showWarningMessage: message: string * [<ParamArray>] items: string[] -> Thenable<string option>
            /// <summary>Show a warning message.</summary>
            /// <seealso cref="window.showInformationMessage">showInformationMessage</seealso>
            /// <param name="message">The message to show.</param>
            /// <param name="options">Configures the behaviour of the message.</param>
            /// <param name="items">A set of items that will be rendered as actions in the message.</param>
            /// <returns>A thenable that resolves to the selected item or <c>undefined</c> when being dismissed.</returns>
            abstract showWarningMessage: message: string * options: MessageOptions * [<ParamArray>] items: string[] -> Thenable<string option>
            /// <summary>Show a warning message.</summary>
            /// <seealso cref="window.showInformationMessage">showInformationMessage</seealso>
            /// <param name="message">The message to show.</param>
            /// <param name="items">A set of items that will be rendered as actions in the message.</param>
            /// <returns>A thenable that resolves to the selected item or <c>undefined</c> when being dismissed.</returns>
            abstract showWarningMessage: message: string * [<ParamArray>] items: 'T[] -> Thenable<'T option> when 'T :> MessageItem
            /// <summary>Show a warning message.</summary>
            /// <seealso cref="window.showInformationMessage">showInformationMessage</seealso>
            /// <param name="message">The message to show.</param>
            /// <param name="options">Configures the behaviour of the message.</param>
            /// <param name="items">A set of items that will be rendered as actions in the message.</param>
            /// <returns>A thenable that resolves to the selected item or <c>undefined</c> when being dismissed.</returns>
            abstract showWarningMessage: message: string * options: MessageOptions * [<ParamArray>] items: 'T[] -> Thenable<'T option> when 'T :> MessageItem
            /// <summary>Show an error message.</summary>
            /// <seealso cref="window.showInformationMessage">showInformationMessage</seealso>
            /// <param name="message">The message to show.</param>
            /// <param name="items">A set of items that will be rendered as actions in the message.</param>
            /// <returns>A thenable that resolves to the selected item or <c>undefined</c> when being dismissed.</returns>
            abstract showErrorMessage: message: string * [<ParamArray>] items: string[] -> Thenable<string option>
            /// <summary>Show an error message.</summary>
            /// <seealso cref="window.showInformationMessage">showInformationMessage</seealso>
            /// <param name="message">The message to show.</param>
            /// <param name="options">Configures the behaviour of the message.</param>
            /// <param name="items">A set of items that will be rendered as actions in the message.</param>
            /// <returns>A thenable that resolves to the selected item or <c>undefined</c> when being dismissed.</returns>
            abstract showErrorMessage: message: string * options: MessageOptions * [<ParamArray>] items: string[] -> Thenable<string option>
            /// <summary>Show an error message.</summary>
            /// <seealso cref="window.showInformationMessage">showInformationMessage</seealso>
            /// <param name="message">The message to show.</param>
            /// <param name="items">A set of items that will be rendered as actions in the message.</param>
            /// <returns>A thenable that resolves to the selected item or <c>undefined</c> when being dismissed.</returns>
            abstract showErrorMessage: message: string * [<ParamArray>] items: 'T[] -> Thenable<'T option> when 'T :> MessageItem
            /// <summary>Show an error message.</summary>
            /// <seealso cref="window.showInformationMessage">showInformationMessage</seealso>
            /// <param name="message">The message to show.</param>
            /// <param name="options">Configures the behaviour of the message.</param>
            /// <param name="items">A set of items that will be rendered as actions in the message.</param>
            /// <returns>A thenable that resolves to the selected item or <c>undefined</c> when being dismissed.</returns>
            abstract showErrorMessage: message: string * options: MessageOptions * [<ParamArray>] items: 'T[] -> Thenable<'T option> when 'T :> MessageItem
            /// <summary>Shows a selection list allowing multiple selections.</summary>
            /// <param name="items">An array of strings, or a promise that resolves to an array of strings.</param>
            /// <param name="options">Configures the behavior of the selection list.</param>
            /// <param name="token">A token that can be used to signal cancellation.</param>
            /// <returns>A promise that resolves to the selected items or <c>undefined</c>.</returns>
            abstract showQuickPick: items: U2<ResizeArray<string>, Thenable<ResizeArray<string>>> * options: obj * ?token: CancellationToken -> Thenable<ResizeArray<string> option>
            /// <summary>Shows a selection list.</summary>
            /// <param name="items">An array of strings, or a promise that resolves to an array of strings.</param>
            /// <param name="options">Configures the behavior of the selection list.</param>
            /// <param name="token">A token that can be used to signal cancellation.</param>
            /// <returns>A promise that resolves to the selection or <c>undefined</c>.</returns>
            abstract showQuickPick: items: U2<ResizeArray<string>, Thenable<ResizeArray<string>>> * ?options: QuickPickOptions * ?token: CancellationToken -> Thenable<string option>
            /// <summary>Shows a selection list allowing multiple selections.</summary>
            /// <param name="items">An array of items, or a promise that resolves to an array of items.</param>
            /// <param name="options">Configures the behavior of the selection list.</param>
            /// <param name="token">A token that can be used to signal cancellation.</param>
            /// <returns>A promise that resolves to the selected items or <c>undefined</c>.</returns>
            abstract showQuickPick: items: U2<ResizeArray<'T>, Thenable<ResizeArray<'T>>> * options: obj * ?token: CancellationToken -> Thenable<ResizeArray<'T> option> when 'T :> QuickPickItem
            /// <summary>Shows a selection list.</summary>
            /// <param name="items">An array of items, or a promise that resolves to an array of items.</param>
            /// <param name="options">Configures the behavior of the selection list.</param>
            /// <param name="token">A token that can be used to signal cancellation.</param>
            /// <returns>A promise that resolves to the selected item or <c>undefined</c>.</returns>
            abstract showQuickPick: items: U2<ResizeArray<'T>, Thenable<ResizeArray<'T>>> * ?options: QuickPickOptions * ?token: CancellationToken -> Thenable<'T option> when 'T :> QuickPickItem
            /// <summary>
            /// Shows a selection list of <see cref="workspace.workspaceFolders">workspace folders</see> to pick from.
            /// Returns <c>undefined</c> if no folder is open.
            /// </summary>
            /// <param name="options">Configures the behavior of the workspace folder list.</param>
            /// <returns>A promise that resolves to the workspace folder or <c>undefined</c>.</returns>
            abstract showWorkspaceFolderPick: ?options: WorkspaceFolderPickOptions -> Thenable<WorkspaceFolder option>
            /// <summary>
            /// Shows a file open dialog to the user which allows to select a file
            /// for opening-purposes.
            /// </summary>
            /// <param name="options">Options that control the dialog.</param>
            /// <returns>A promise that resolves to the selected resources or <c>undefined</c>.</returns>
            abstract showOpenDialog: ?options: OpenDialogOptions -> Thenable<ResizeArray<Uri> option>
            /// <summary>
            /// Shows a file save dialog to the user which allows to select a file
            /// for saving-purposes.
            /// </summary>
            /// <param name="options">Options that control the dialog.</param>
            /// <returns>A promise that resolves to the selected resource or <c>undefined</c>.</returns>
            abstract showSaveDialog: ?options: SaveDialogOptions -> Thenable<Uri option>
            /// <summary>
            /// Opens an input box to ask the user for input.
            ///
            /// The returned value will be <c>undefined</c> if the input box was canceled (e.g. pressing ESC). Otherwise the
            /// returned value will be the string typed by the user or an empty string if the user did not type
            /// anything but dismissed the input box with OK.
            /// </summary>
            /// <param name="options">Configures the behavior of the input box.</param>
            /// <param name="token">A token that can be used to signal cancellation.</param>
            /// <returns>A promise that resolves to a string the user provided or to <c>undefined</c> in case of dismissal.</returns>
            abstract showInputBox: ?options: InputBoxOptions * ?token: CancellationToken -> Thenable<string option>
            /// <summary>
            /// Creates a <see cref="QuickPick" /> to let the user pick an item from a list
            /// of items of type T.
            ///
            /// Note that in many cases the more convenient <see cref="window.showQuickPick" />
            /// is easier to use. <see cref="window.createQuickPick" /> should be used
            /// when <see cref="window.showQuickPick" /> does not offer the required flexibility.
            /// </summary>
            /// <returns>A new <see cref="QuickPick" />.</returns>
            abstract createQuickPick: unit -> QuickPick<'T> when 'T :> QuickPickItem
            /// <summary>
            /// Creates a <see cref="InputBox" /> to let the user enter some text input.
            ///
            /// Note that in many cases the more convenient <see cref="window.showInputBox" />
            /// is easier to use. <see cref="window.createInputBox" /> should be used
            /// when <see cref="window.showInputBox" /> does not offer the required flexibility.
            /// </summary>
            /// <returns>A new <see cref="InputBox" />.</returns>
            abstract createInputBox: unit -> InputBox
            /// <summary>
            /// Creates a new <see cref="OutputChannel">output channel</see> with the given name and language id
            /// If language id is not provided, then **Log** is used as default language id.
            ///
            /// You can access the visible or active output channel as a <see cref="TextDocument">text document</see> from <see cref="window.visibleTextEditors">visible editors</see> or <see cref="window.activeTextEditor">active editor</see>
            /// and use the langage id to contribute language features like syntax coloring, code lens etc.,
            /// </summary>
            /// <param name="name">Human-readable string which will be used to represent the channel in the UI.</param>
            /// <param name="languageId">The identifier of the language associated with the channel.</param>
            abstract createOutputChannel: name: string * ?languageId: string -> OutputChannel
            /// <summary>Create and show a new webview panel.</summary>
            /// <param name="viewType">Identifies the type of the webview panel.</param>
            /// <param name="title">Title of the panel.</param>
            /// <param name="showOptions">Where to show the webview in the editor. If preserveFocus is set, the new webview will not take focus.</param>
            /// <param name="options">Settings for the new panel.</param>
            /// <returns>New webview panel.</returns>
            abstract createWebviewPanel: viewType: string * title: string * showOptions: U2<ViewColumn, {| viewColumn: ViewColumn; preserveFocus: bool option |}> * ?options: obj -> WebviewPanel
            /// <summary>
            /// Set a message to the status bar. This is a short hand for the more powerful
            /// status bar <see cref="window.createStatusBarItem">items</see>.
            /// </summary>
            /// <param name="text">The message to show, supports icon substitution as in status bar <see cref="StatusBarItem.text">items</see>.</param>
            /// <param name="hideAfterTimeout">Timeout in milliseconds after which the message will be disposed.</param>
            /// <returns>A disposable which hides the status bar message.</returns>
            abstract setStatusBarMessage: text: string * hideAfterTimeout: float -> Disposable
            /// <summary>
            /// Set a message to the status bar. This is a short hand for the more powerful
            /// status bar <see cref="window.createStatusBarItem">items</see>.
            /// </summary>
            /// <param name="text">The message to show, supports icon substitution as in status bar <see cref="StatusBarItem.text">items</see>.</param>
            /// <param name="hideWhenDone">Thenable on which completion (resolve or reject) the message will be disposed.</param>
            /// <returns>A disposable which hides the status bar message.</returns>
            abstract setStatusBarMessage: text: string * hideWhenDone: Thenable<obj option> -> Disposable
            /// <summary>
            /// Set a message to the status bar. This is a short hand for the more powerful
            /// status bar <see cref="window.createStatusBarItem">items</see>.
            ///
            /// *Note* that status bar messages stack and that they must be disposed when no
            /// longer used.
            /// </summary>
            /// <param name="text">The message to show, supports icon substitution as in status bar <see cref="StatusBarItem.text">items</see>.</param>
            /// <returns>A disposable which hides the status bar message.</returns>
            abstract setStatusBarMessage: text: string -> Disposable
            /// <summary>
            /// Show progress in the Source Control viewlet while running the given callback and while
            /// its returned promise isn't resolve or rejected.
            /// </summary>
            /// <param name="task">
            /// A callback returning a promise. Progress increments can be reported with
            /// the provided <see cref="Progress" />-object.
            /// </param>
            /// <returns>The thenable the task did return.</returns>
            [<Obsolete("Use `withProgress` instead.")>]
            abstract withScmProgress: task: (Progress<float> -> Thenable<'R>) -> Thenable<'R>
            /// <summary>
            /// Show progress in the editor. Progress is shown while running the given callback
            /// and while the promise it returned isn't resolved nor rejected. The location at which
            /// progress should show (and other details) is defined via the passed {@linkcode ProgressOptions}.
            /// </summary>
            /// <param name="task">
            /// A callback returning a promise. Progress state can be reported with
            /// the provided <see cref="Progress" />-object.
            ///
            /// To report discrete progress, use <c>increment</c> to indicate how much work has been completed. Each call with
            /// a <c>increment</c> value will be summed up and reflected as overall progress until 100% is reached (a value of
            /// e.g. <c>10</c> accounts for <c>10%</c> of work done).
            /// Note that currently only <c>ProgressLocation.Notification</c> is capable of showing discrete progress.
            ///
            /// To monitor if the operation has been cancelled by the user, use the provided {
            /// </param>
            /// <returns>The thenable the task-callback returned.</returns>
            abstract withProgress: options: ProgressOptions * task: (Progress<{| message: string option; increment: float option |}> -> CancellationToken -> Thenable<'R>) -> Thenable<'R>
            /// <summary>Creates a status bar <see cref="StatusBarItem">item</see>.</summary>
            /// <param name="alignment">The alignment of the item.</param>
            /// <param name="priority">The priority of the item. Higher values mean the item should be shown more to the left.</param>
            /// <returns>A new status bar item.</returns>
            abstract createStatusBarItem: ?alignment: StatusBarAlignment * ?priority: float -> StatusBarItem
            /// <summary>Creates a status bar <see cref="StatusBarItem">item</see>.</summary>
            /// <param name="id">The unique identifier of the item.</param>
            /// <param name="alignment">The alignment of the item.</param>
            /// <param name="priority">The priority of the item. Higher values mean the item should be shown more to the left.</param>
            /// <returns>A new status bar item.</returns>
            abstract createStatusBarItem: id: string * ?alignment: StatusBarAlignment * ?priority: float -> StatusBarItem
            /// <summary>
            /// Creates a <see cref="Terminal" /> with a backing shell process. The cwd of the terminal will be the workspace
            /// directory if it exists.
            /// </summary>
            /// <param name="name">Optional human-readable string which will be used to represent the terminal in the UI.</param>
            /// <param name="shellPath">Optional path to a custom shell executable to be used in the terminal.</param>
            /// <param name="shellArgs">
            /// Optional args for the custom shell executable. A string can be used on Windows only which
            /// allows specifying shell args in
            /// <see href="https://msdn.microsoft.com/en-au/08dfcab2-eb6e-49a4-80eb-87d4076c98c6">command-line format</see>.
            /// </param>
            /// <returns>A new Terminal.</returns>
            /// <exception cref="">When running in an environment where a new process cannot be started.</exception>
            abstract createTerminal: ?name: string * ?shellPath: string * ?shellArgs: U2<ResizeArray<string>, string> -> Terminal
            /// <summary>Creates a <see cref="Terminal" /> with a backing shell process.</summary>
            /// <param name="options">A TerminalOptions object describing the characteristics of the new terminal.</param>
            /// <returns>A new Terminal.</returns>
            /// <exception cref="">When running in an environment where a new process cannot be started.</exception>
            abstract createTerminal: options: TerminalOptions -> Terminal
            /// <summary>Creates a <see cref="Terminal" /> where an extension controls its input and output.</summary>
            /// <param name="options">
            /// An <see cref="ExtensionTerminalOptions" /> object describing
            /// the characteristics of the new terminal.
            /// </param>
            /// <returns>A new Terminal.</returns>
            abstract createTerminal: options: ExtensionTerminalOptions -> Terminal
            /// <summary>
            /// Register a <see cref="TreeDataProvider" /> for the view contributed using the extension point <c>views</c>.
            /// This will allow you to contribute data to the <see cref="TreeView" /> and update if the data changes.
            ///
            /// **Note:** To get access to the <see cref="TreeView" /> and perform operations on it, use <see cref="window.createTreeView">createTreeView</see>.
            /// </summary>
            /// <param name="viewId">Id of the view contributed using the extension point <c>views</c>.</param>
            /// <param name="treeDataProvider">A <see cref="TreeDataProvider" /> that provides tree data for the view</param>
            abstract registerTreeDataProvider: viewId: string * treeDataProvider: TreeDataProvider<'T> -> Disposable
            /// <summary>Create a <see cref="TreeView" /> for the view contributed using the extension point <c>views</c>.</summary>
            /// <param name="viewId">Id of the view contributed using the extension point <c>views</c>.</param>
            /// <param name="options">Options for creating the <see cref="TreeView" /></param>
            /// <returns>a <see cref="TreeView" />.</returns>
            abstract createTreeView: viewId: string * options: TreeViewOptions<'T> -> TreeView<'T>
            /// <summary>
            /// Registers a <see cref="UriHandler">uri handler</see> capable of handling system-wide <see cref="Uri">uris</see>.
            /// In case there are multiple windows open, the topmost window will handle the uri.
            /// A uri handler is scoped to the extension it is contributed from; it will only
            /// be able to handle uris which are directed to the extension itself. A uri must respect
            /// the following rules:
            ///
            /// - The uri-scheme must be <c>vscode.env.uriScheme</c>;
            /// - The uri-authority must be the extension id (e.g. <c>my.extension</c>);
            /// - The uri-path, -query and -fragment parts are arbitrary.
            ///
            /// For example, if the <c>my.extension</c> extension registers a uri handler, it will only
            /// be allowed to handle uris with the prefix <c>product-name://my.extension</c>.
            ///
            /// An extension can only register a single uri handler in its entire activation lifetime.
            ///
            /// * *Note:* There is an activation event <c>onUri</c> that fires when a uri directed for
            /// the current extension is about to be handled.
            /// </summary>
            /// <param name="handler">The uri handler to register for this extension.</param>
            abstract registerUriHandler: handler: UriHandler -> Disposable
            /// <summary>
            /// Registers a webview panel serializer.
            ///
            /// Extensions that support reviving should have an <c>"onWebviewPanel:viewType"</c> activation event and
            /// make sure that <c>registerWebviewPanelSerializer</c> is called during activation.
            ///
            /// Only a single serializer may be registered at a time for a given <c>viewType</c>.
            /// </summary>
            /// <param name="viewType">Type of the webview panel that can be serialized.</param>
            /// <param name="serializer">Webview serializer.</param>
            abstract registerWebviewPanelSerializer: viewType: string * serializer: WebviewPanelSerializer -> Disposable
            /// <summary>Register a new provider for webview views.</summary>
            /// <param name="viewId">
            /// Unique id of the view. This should match the <c>id</c> from the
            /// <c>views</c> contribution in the package.json.
            /// </param>
            /// <param name="provider">Provider for the webview views.</param>
            /// <returns>Disposable that unregisters the provider.</returns>
            abstract registerWebviewViewProvider: viewId: string * provider: WebviewViewProvider * ?options: {| webviewOptions: {| retainContextWhenHidden: bool option |} option |} -> Disposable
            /// <summary>
            /// Register a provider for custom editors for the <c>viewType</c> contributed by the <c>customEditors</c> extension point.
            ///
            /// When a custom editor is opened, an <c>onCustomEditor:viewType</c> activation event is fired. Your extension
            /// must register a {@linkcode CustomTextEditorProvider}, {@linkcode CustomReadonlyEditorProvider},
            /// {@linkcode CustomEditorProvider}for <c>viewType</c> as part of activation.
            /// </summary>
            /// <param name="viewType">
            /// Unique identifier for the custom editor provider. This should match the <c>viewType</c> from the
            /// <c>customEditors</c> contribution point.
            /// </param>
            /// <param name="provider">Provider that resolves custom editors.</param>
            /// <param name="options">Options for the provider.</param>
            /// <returns>Disposable that unregisters the provider.</returns>
            abstract registerCustomEditorProvider: viewType: string * provider: U3<CustomTextEditorProvider, CustomReadonlyEditorProvider, CustomEditorProvider> * ?options: {| webviewOptions: WebviewPanelOptions option; supportsMultipleEditorsPerDocument: bool option |} -> Disposable
            /// <summary>Register provider that enables the detection and handling of links within the terminal.</summary>
            /// <param name="provider">The provider that provides the terminal links.</param>
            /// <returns>Disposable that unregisters the provider.</returns>
            abstract registerTerminalLinkProvider: provider: TerminalLinkProvider -> Disposable
            /// <summary>Registers a provider for a contributed terminal profile.</summary>
            /// <param name="id">The ID of the contributed terminal profile.</param>
            /// <param name="provider">The terminal profile provider.</param>
            abstract registerTerminalProfileProvider: id: string * provider: TerminalProfileProvider -> Disposable
            /// <summary>Register a file decoration provider.</summary>
            /// <param name="provider">A <see cref="FileDecorationProvider" />.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters the provider.</returns>
            abstract registerFileDecorationProvider: provider: FileDecorationProvider -> Disposable
            /// <summary>
            /// The currently active color theme as configured in the settings. The active
            /// theme can be changed via the <c>workbench.colorTheme</c> setting.
            /// </summary>
            abstract activeColorTheme: ColorTheme with get, set
            /// <summary>An <see cref="Event" /> which fires when the active color theme is changed or has changes.</summary>
            abstract onDidChangeActiveColorTheme: Event<ColorTheme>

    /// <summary>Options for creating a <see cref="TreeView" /></summary>
    type [<AllowNullLiteral>] TreeViewOptions<'T> =
        /// A data provider that provides tree data.
        abstract treeDataProvider: TreeDataProvider<'T> with get, set
        /// Whether to show collapse all action or not.
        abstract showCollapseAll: bool option with get, set
        /// Whether the tree supports multi-select. When the tree supports multi-select and a command is executed from the tree,
        /// the first argument to the command is the tree item that the command was executed on and the second argument is an
        /// array containing all selected tree items.
        abstract canSelectMany: bool option with get, set
        /// An optional interface to implement drag and drop in the tree view.
        abstract dragAndDropController: TreeDragAndDropController<'T> option with get, set

    /// <summary>The event that is fired when an element in the <see cref="TreeView" /> is expanded or collapsed</summary>
    type [<AllowNullLiteral>] TreeViewExpansionEvent<'T> =
        /// Element that is expanded or collapsed.
        abstract element: 'T

    /// <summary>The event that is fired when there is a change in <see cref="TreeView.selection">tree view's selection</see></summary>
    type [<AllowNullLiteral>] TreeViewSelectionChangeEvent<'T> =
        /// Selected elements.
        abstract selection: ResizeArray<'T>

    /// <summary>The event that is fired when there is a change in <see cref="TreeView.visible">tree view's visibility</see></summary>
    type [<AllowNullLiteral>] TreeViewVisibilityChangeEvent =
        /// <summary><c>true</c> if the <see cref="TreeView">tree view</see> is visible otherwise <c>false</c>.</summary>
        abstract visible: bool

    /// <summary>
    /// A class for encapsulating data transferred during a drag and drop event.
    ///
    /// You can use the <c>value</c> of the <c>DataTransferItem</c> to get back the object you put into it
    /// so long as the extension that created the <c>DataTransferItem</c> runs in the same extension host.
    /// </summary>
    type [<AllowNullLiteral>] DataTransferItem =
        abstract asString: unit -> Thenable<string>
        abstract value: obj option

    /// <summary>
    /// A class for encapsulating data transferred during a drag and drop event.
    ///
    /// You can use the <c>value</c> of the <c>DataTransferItem</c> to get back the object you put into it
    /// so long as the extension that created the <c>DataTransferItem</c> runs in the same extension host.
    /// </summary>
    type [<AllowNullLiteral>] DataTransferItemStatic =
        [<EmitConstructor>] abstract Create: value: obj option -> DataTransferItem

    /// <summary>
    /// A map containing a mapping of the mime type of the corresponding transferred data.
    ///
    /// Drag and drop controllers that implement <see cref="TreeDragAndDropController.handleDrag"><c>handleDrag</c></see> can add additional mime types to the
    /// data transfer. These additional mime types will only be included in the <c>handleDrop</c> when the the drag was initiated from
    /// an element in the same drag and drop controller.
    /// </summary>
    type [<AllowNullLiteral>] DataTransfer =
        /// <summary>Retrieves the data transfer item for a given mime type.</summary>
        /// <param name="mimeType">
        /// The mime type to get the data transfer item for, such as <c>text/plain</c> or <c>image/png</c>.
        ///
        /// Special mime types:
        /// - <c>text/uri-list</c> — A string with <c>toString()</c>ed Uris separated by newlines. To specify a cursor position in the file,
        /// set the Uri's fragment to <c>L3,5</c>, where 3 is the line number and 5 is the column number.
        /// </param>
        abstract get: mimeType: string -> DataTransferItem option
        /// <summary>Sets a mime type to data transfer item mapping.</summary>
        /// <param name="mimeType">The mime type to set the data for.</param>
        /// <param name="value">The data transfer item for the given mime type.</param>
        abstract set: mimeType: string * value: DataTransferItem -> unit
        /// <summary>Allows iteration through the data transfer items.</summary>
        /// <param name="callbackfn">Callback for iteration through the data transfer items.</param>
        abstract forEach: callbackfn: (DataTransferItem -> string -> unit) -> unit

    /// <summary>
    /// A map containing a mapping of the mime type of the corresponding transferred data.
    ///
    /// Drag and drop controllers that implement <see cref="TreeDragAndDropController.handleDrag"><c>handleDrag</c></see> can add additional mime types to the
    /// data transfer. These additional mime types will only be included in the <c>handleDrop</c> when the the drag was initiated from
    /// an element in the same drag and drop controller.
    /// </summary>
    type [<AllowNullLiteral>] DataTransferStatic =
        [<EmitConstructor>] abstract Create: unit -> DataTransfer

    /// <summary>Provides support for drag and drop in <c>TreeView</c>.</summary>
    type [<AllowNullLiteral>] TreeDragAndDropController<'T> =
        /// <summary>
        /// The mime types that the <see cref="TreeDragAndDropController.handleDrop"><c>handleDrop</c></see> method of this <c>DragAndDropController</c> supports.
        /// This could be well-defined, existing, mime types, and also mime types defined by the extension.
        ///
        /// To support drops from trees, you will need to add the mime type of that tree.
        /// This includes drops from within the same tree.
        /// The mime type of a tree is recommended to be of the format <c>application/vnd.code.tree.&lt;treeidlowercase&gt;</c>.
        ///
        /// To learn the mime type of a dragged item:
        /// 1. Set up your <c>DragAndDropController</c>
        /// 2. Use the Developer: Set Log Level... command to set the level to "Debug"
        /// 3. Open the developer tools and drag the item with unknown mime type over your tree. The mime types will be logged to the developer console
        ///
        /// Note that mime types that cannot be sent to the extension will be omitted.
        /// </summary>
        abstract dropMimeTypes: ResizeArray<string>
        /// <summary>
        /// The mime types that the <see cref="TreeDragAndDropController.handleDrag"><c>handleDrag</c></see> method of this <c>TreeDragAndDropController</c> may add to the tree data transfer.
        /// This could be well-defined, existing, mime types, and also mime types defined by the extension.
        ///
        /// The recommended mime type of the tree (<c>application/vnd.code.tree.&lt;treeidlowercase&gt;</c>) will be automatically added.
        /// </summary>
        abstract dragMimeTypes: ResizeArray<string>
        /// <summary>
        /// When the user starts dragging items from this <c>DragAndDropController</c>, <c>handleDrag</c> will be called.
        /// Extensions can use <c>handleDrag</c> to add their <see cref="DataTransferItem"><c>DataTransferItem</c></see> items to the drag and drop.
        ///
        /// When the items are dropped on **another tree item** in **the same tree**, your <c>DataTransferItem</c> objects
        /// will be preserved. Use the recommended mime type for the tree (<c>application/vnd.code.tree.&lt;treeidlowercase&gt;</c>) to add
        /// tree objects in a data transfer. See the documentation for <c>DataTransferItem</c> for how best to take advantage of this.
        ///
        /// To add a data transfer item that can be dragged into the editor, use the application specific mime type "text/uri-list".
        /// The data for "text/uri-list" should be a string with <c>toString()</c>ed Uris separated by newlines. To specify a cursor position in the file,
        /// set the Uri's fragment to <c>L3,5</c>, where 3 is the line number and 5 is the column number.
        /// </summary>
        /// <param name="source">The source items for the drag and drop operation.</param>
        /// <param name="dataTransfer">The data transfer associated with this drag.</param>
        /// <param name="token">A cancellation token indicating that drag has been cancelled.</param>
        abstract handleDrag: source: ResizeArray<'T> * dataTransfer: DataTransfer * token: CancellationToken -> U2<Thenable<unit>, unit>
        /// <summary>
        /// Called when a drag and drop action results in a drop on the tree that this <c>DragAndDropController</c> belongs to.
        ///
        /// Extensions should fire <see cref="TreeDataProvider.onDidChangeTreeData">onDidChangeTreeData</see> for any elements that need to be refreshed.
        /// </summary>
        /// <param name="dataTransfer">The data transfer items of the source of the drag.</param>
        /// <param name="target">The target tree element that the drop is occurring on. When undefined, the target is the root.</param>
        /// <param name="token">A cancellation token indicating that the drop has been cancelled.</param>
        abstract handleDrop: target: 'T option * dataTransfer: DataTransfer * token: CancellationToken -> U2<Thenable<unit>, unit>

    /// Represents a Tree view
    type [<AllowNullLiteral>] TreeView<'T> =
        inherit Disposable
        /// Event that is fired when an element is expanded
        abstract onDidExpandElement: Event<TreeViewExpansionEvent<'T>>
        /// Event that is fired when an element is collapsed
        abstract onDidCollapseElement: Event<TreeViewExpansionEvent<'T>>
        /// Currently selected elements.
        abstract selection: ResizeArray<'T>
        /// <summary>Event that is fired when the <see cref="TreeView.selection">selection</see> has changed</summary>
        abstract onDidChangeSelection: Event<TreeViewSelectionChangeEvent<'T>>
        /// <summary><c>true</c> if the <see cref="TreeView">tree view</see> is visible otherwise <c>false</c>.</summary>
        abstract visible: bool
        /// <summary>Event that is fired when <see cref="TreeView.visible">visibility</see> has changed</summary>
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
        /// <summary>
        /// Reveals the given element in the tree view.
        /// If the tree view is not visible then the tree view is shown and element is revealed.
        ///
        /// By default revealed element is selected.
        /// In order to not to select, set the option <c>select</c> to <c>false</c>.
        /// In order to focus, set the option <c>focus</c> to <c>true</c>.
        /// In order to expand the revealed element, set the option <c>expand</c> to <c>true</c>. To expand recursively set <c>expand</c> to the number of levels to expand.
        /// **NOTE:** You can expand only to 3 levels maximum.
        ///
        /// **NOTE:** The <see cref="TreeDataProvider" /> that the <c>TreeView</c> <see cref="window.createTreeView">is registered with</see> with must implement <see cref="TreeDataProvider.getParent">getParent</see> method to access this API.
        /// </summary>
        abstract reveal: element: 'T * ?options: {| select: bool option; focus: bool option; expand: U2<bool, float> option |} -> Thenable<unit>

    /// A data provider that provides tree data
    type [<AllowNullLiteral>] TreeDataProvider<'T> =
        /// <summary>
        /// An optional event to signal that an element or root has changed.
        /// This will trigger the view to update the changed element/root and its children recursively (if shown).
        /// To signal that root has changed, do not pass any argument or pass <c>undefined</c> or <c>null</c>.
        /// </summary>
        abstract onDidChangeTreeData: Event<U3<'T, ResizeArray<'T>, unit> option> option with get, set
        /// <summary>Get <see cref="TreeItem" /> representation of the <c>element</c></summary>
        /// <param name="element">The element for which <see cref="TreeItem" /> representation is asked for.</param>
        /// <returns>TreeItem representation of the element.</returns>
        abstract getTreeItem: element: 'T -> U2<TreeItem, Thenable<TreeItem>>
        /// <summary>Get the children of <c>element</c> or root if no element is passed.</summary>
        /// <param name="element">The element from which the provider gets children. Can be <c>undefined</c>.</param>
        /// <returns>Children of <c>element</c> or root if no element is passed.</returns>
        abstract getChildren: ?element: 'T -> ProviderResult<ResizeArray<'T>>
        /// <summary>
        /// Optional method to return the parent of <c>element</c>.
        /// Return <c>null</c> or <c>undefined</c> if <c>element</c> is a child of root.
        ///
        /// **NOTE:** This method should be implemented in order to access <see cref="TreeView.reveal">reveal</see> API.
        /// </summary>
        /// <param name="element">The element for which the parent has to be returned.</param>
        /// <returns>Parent of <c>element</c>.</returns>
        abstract getParent: element: 'T -> ProviderResult<'T>
        /// <summary>
        /// Called on hover to resolve the <see cref="TreeItem.tooltip">TreeItem</see> property if it is undefined.
        /// Called on tree item click/open to resolve the <see cref="TreeItem.command">TreeItem</see> property if it is undefined.
        /// Only properties that were undefined can be resolved in <c>resolveTreeItem</c>.
        /// Functionality may be expanded later to include being called to resolve other missing
        /// properties on selection and/or on open.
        ///
        /// Will only ever be called once per TreeItem.
        ///
        /// onDidChangeTreeData should not be triggered from within resolveTreeItem.
        ///
        /// *Note* that this function is called when tree items are already showing in the UI.
        /// Because of that, no property that changes the presentation (label, description, etc.)
        /// can be changed.
        /// </summary>
        /// <param name="item">Undefined properties of <c>item</c> should be set then <c>item</c> should be returned.</param>
        /// <param name="element">The object associated with the TreeItem.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>
        /// The resolved tree item or a thenable that resolves to such. It is OK to return the given
        /// <c>item</c>. When no result is returned, the given <c>item</c> will be used.
        /// </returns>
        abstract resolveTreeItem: item: TreeItem * element: 'T * token: CancellationToken -> ProviderResult<TreeItem>

    type [<AllowNullLiteral>] TreeItem =
        /// <summary>A human-readable string describing this item. When <c>falsy</c>, it is derived from <see cref="TreeItem.resourceUri">resourceUri</see>.</summary>
        abstract label: U2<string, TreeItemLabel> option with get, set
        /// Optional id for the tree item that has to be unique across tree. The id is used to preserve the selection and expansion state of the tree item.
        ///
        /// If not provided, an id is generated using the tree item's label. **Note** that when labels change, ids will change and that selection and expansion state cannot be kept stable anymore.
        abstract id: string option with get, set
        /// <summary>
        /// The icon path or <see cref="ThemeIcon" /> for the tree item.
        /// When <c>falsy</c>, <see cref="ThemeIcon.Folder">Folder Theme Icon</see> is assigned, if item is collapsible otherwise <see cref="ThemeIcon.File">File Theme Icon</see>.
        /// When a file or folder <see cref="ThemeIcon" /> is specified, icon is derived from the current file icon theme for the specified theme icon using <see cref="TreeItem.resourceUri">resourceUri</see> (if provided).
        /// </summary>
        abstract iconPath: U4<string, Uri, {| light: U2<string, Uri>; dark: U2<string, Uri> |}, ThemeIcon> option with get, set
        /// <summary>
        /// A human-readable string which is rendered less prominent.
        /// When <c>true</c>, it is derived from <see cref="TreeItem.resourceUri">resourceUri</see> and when <c>falsy</c>, it is not shown.
        /// </summary>
        abstract description: U2<string, bool> option with get, set
        /// <summary>
        /// The <see cref="Uri" /> of the resource representing this item.
        ///
        /// Will be used to derive the <see cref="TreeItem.label">label</see>, when it is not provided.
        /// Will be used to derive the icon from current file icon theme, when <see cref="TreeItem.iconPath">iconPath</see> has <see cref="ThemeIcon" /> value.
        /// </summary>
        abstract resourceUri: Uri option with get, set
        /// The tooltip text when you hover over this item.
        abstract tooltip: U2<string, MarkdownString> option with get, set
        /// <summary>
        /// The <see cref="Command" /> that should be executed when the tree item is selected.
        ///
        /// Please use <c>vscode.open</c> or <c>vscode.diff</c> as command IDs when the tree item is opening
        /// something in the editor. Using these commands ensures that the resulting editor will
        /// appear consistent with how other built-in trees open editors.
        /// </summary>
        abstract command: Command option with get, set
        /// <summary><see cref="TreeItemCollapsibleState" /> of the tree item.</summary>
        abstract collapsibleState: TreeItemCollapsibleState option with get, set
        /// <summary>
        /// Context value of the tree item. This can be used to contribute item specific actions in the tree.
        /// For example, a tree item is given a context value as <c>folder</c>. When contributing actions to <c>view/item/context</c>
        /// using <c>menus</c> extension point, you can specify context value for key <c>viewItem</c> in <c>when</c> expression like <c>viewItem == folder</c>.
        /// <code lang="json">
        /// "contributes": {
        ///    "menus": {
        ///      "view/item/context": [
        ///        {
        ///          "command": "extension.deleteFolder",
        ///          "when": "viewItem == folder"
        ///        }
        ///      ]
        ///    }
        /// }
        /// </code>
        /// This will show action <c>extension.deleteFolder</c> only for items with <c>contextValue</c> is <c>folder</c>.
        /// </summary>
        abstract contextValue: string option with get, set
        /// <summary>
        /// Accessibility information used when screen reader interacts with this tree item.
        /// Generally, a TreeItem has no need to set the <c>role</c> of the accessibilityInformation;
        /// however, there are cases where a TreeItem is not displayed in a tree-like way where setting the <c>role</c> may make sense.
        /// </summary>
        abstract accessibilityInformation: AccessibilityInformation option with get, set

    type [<AllowNullLiteral>] TreeItemStatic =
        /// <param name="label">A human-readable string describing this item</param>
        /// <param name="collapsibleState" />
        [<EmitConstructor>] abstract Create: label: U2<string, TreeItemLabel> * ?collapsibleState: TreeItemCollapsibleState -> TreeItem
        /// <param name="resourceUri">The <see cref="Uri" /> of the resource representing this item.</param>
        /// <param name="collapsibleState" />
        [<EmitConstructor>] abstract Create: resourceUri: Uri * ?collapsibleState: TreeItemCollapsibleState -> TreeItem

    /// Collapsible state of the tree item
    type [<RequireQualifiedAccess>] TreeItemCollapsibleState =
        /// Determines an item can be neither collapsed nor expanded. Implies it has no children.
        | None = 0
        /// Determines an item is collapsed
        | Collapsed = 1
        /// Determines an item is expanded
        | Expanded = 2

    /// <summary>Label describing the <see cref="TreeItem">Tree item</see></summary>
    type [<AllowNullLiteral>] TreeItemLabel =
        /// <summary>A human-readable string describing the <see cref="TreeItem">Tree item</see>.</summary>
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
        /// <summary>
        /// Args for the custom shell executable. A string can be used on Windows only which allows
        /// specifying shell args in <see href="https://msdn.microsoft.com/en-au/08dfcab2-eb6e-49a4-80eb-87d4076c98c6">command-line format</see>.
        /// </summary>
        abstract shellArgs: U2<ResizeArray<string>, string> option with get, set
        /// A path or Uri for the current working directory to be used for the terminal.
        abstract cwd: U2<string, Uri> option with get, set
        /// Object with environment variables that will be added to the editor process.
        abstract env: TerminalOptionsEnv option with get, set
        /// <summary>
        /// Whether the terminal process environment should be exactly as provided in
        /// <c>TerminalOptions.env</c>. When this is false (default), the environment will be based on the
        /// window's environment and also apply configured platform settings like
        /// <c>terminal.integrated.windows.env</c> on top. When this is true, the complete environment
        /// must be provided as nothing will be inherited from the process or any configuration.
        /// </summary>
        abstract strictEnv: bool option with get, set
        /// <summary>
        /// When enabled the terminal will run the process as normal but not be surfaced to the user
        /// until <c>Terminal.show</c> is called. The typical usage for this is when you need to run
        /// something that may need interactivity but only want to tell the user about it when
        /// interaction is needed. Note that the terminals will still be exposed to all extensions
        /// as normal.
        /// </summary>
        abstract hideFromUser: bool option with get, set
        /// A message to write to the terminal on first launch, note that this is not sent to the
        /// process but, rather written directly to the terminal. This supports escape sequences such
        /// a setting text style.
        abstract message: string option with get, set
        /// <summary>The icon path or <see cref="ThemeIcon" /> for the terminal.</summary>
        abstract iconPath: U3<Uri, {| light: Uri; dark: Uri |}, ThemeIcon> option with get, set
        /// <summary>
        /// The icon <see cref="ThemeColor" /> for the terminal.
        /// The <c>terminal.ansi*</c> theme keys are
        /// recommended for the best contrast and consistency across themes.
        /// </summary>
        abstract color: ThemeColor option with get, set
        /// <summary>The <see cref="TerminalLocation" /> or <see cref="TerminalEditorLocationOptions" /> or <see cref="TerminalSplitLocationOptions" /> for the terminal.</summary>
        abstract location: U3<TerminalLocation, TerminalEditorLocationOptions, TerminalSplitLocationOptions> option with get, set
        /// <summary>
        /// Opt-out of the default terminal persistence on restart and reload.
        /// This will only take effect when <c>terminal.integrated.enablePersistentSessions</c> is enabled.
        /// </summary>
        abstract isTransient: bool option with get, set

    /// Value-object describing what options a virtual process terminal should use.
    type [<AllowNullLiteral>] ExtensionTerminalOptions =
        /// A human-readable string which will be used to represent the terminal in the UI.
        abstract name: string with get, set
        /// <summary>
        /// An implementation of <see cref="Pseudoterminal" /> that allows an extension to
        /// control a terminal.
        /// </summary>
        abstract pty: Pseudoterminal with get, set
        /// <summary>The icon path or <see cref="ThemeIcon" /> for the terminal.</summary>
        abstract iconPath: U3<Uri, {| light: Uri; dark: Uri |}, ThemeIcon> option with get, set
        /// <summary>
        /// The icon <see cref="ThemeColor" /> for the terminal.
        /// The standard <c>terminal.ansi*</c> theme keys are
        /// recommended for the best contrast and consistency across themes.
        /// </summary>
        abstract color: ThemeColor option with get, set
        /// <summary>The <see cref="TerminalLocation" /> or <see cref="TerminalEditorLocationOptions" /> or <see cref="TerminalSplitLocationOptions" /> for the terminal.</summary>
        abstract location: U3<TerminalLocation, TerminalEditorLocationOptions, TerminalSplitLocationOptions> option with get, set
        /// <summary>
        /// Opt-out of the default terminal persistence on restart and reload.
        /// This will only take effect when <c>terminal.integrated.enablePersistentSessions</c> is enabled.
        /// </summary>
        abstract isTransient: bool option with get, set

    /// Defines the interface of a terminal pty, enabling extensions to control a terminal.
    type [<AllowNullLiteral>] Pseudoterminal =
        /// <summary>
        /// An event that when fired will write data to the terminal. Unlike
        /// <see cref="Terminal.sendText" /> which sends text to the underlying child
        /// pseudo-device (the child), this will write the text to parent pseudo-device (the
        /// _terminal_ itself).
        ///
        /// Note writing <c>\n</c> will just move the cursor down 1 row, you need to write <c>\r</c> as well
        /// to move the cursor to the left-most cell.
        ///
        /// Events fired before <see cref="Pseudoterminal.open" /> is called will be be ignored.
        ///
        /// **Example:** Write red text to the terminal
        /// <code lang="typescript">
        /// const writeEmitter = new vscode.EventEmitter&lt;string&gt;();
        /// const pty: vscode.Pseudoterminal = {
        ///    onDidWrite: writeEmitter.event,
        ///    open: () =&gt; writeEmitter.fire('\x1b[31mHello world\x1b[0m'),
        ///    close: () =&gt; {}
        /// };
        /// vscode.window.createTerminal({ name: 'My terminal', pty });
        /// </code>
        ///
        /// **Example:** Move the cursor to the 10th row and 20th column and write an asterisk
        /// <code lang="typescript">
        /// writeEmitter.fire('\x1b[10;20H*');
        /// </code>
        /// </summary>
        abstract onDidWrite: Event<string> with get, set
        /// <summary>
        /// An event that when fired allows overriding the <see cref="Pseudoterminal.setDimensions">dimensions</see> of the
        /// terminal. Note that when set, the overridden dimensions will only take effect when they
        /// are lower than the actual dimensions of the terminal (ie. there will never be a scroll
        /// bar). Set to <c>undefined</c> for the terminal to go back to the regular dimensions (fit to
        /// the size of the panel).
        ///
        /// Events fired before <see cref="Pseudoterminal.open" /> is called will be be ignored.
        ///
        /// **Example:** Override the dimensions of a terminal to 20 columns and 10 rows
        /// <code lang="typescript">
        /// const dimensionsEmitter = new vscode.EventEmitter&lt;vscode.TerminalDimensions&gt;();
        /// const pty: vscode.Pseudoterminal = {
        ///    onDidWrite: writeEmitter.event,
        ///    onDidOverrideDimensions: dimensionsEmitter.event,
        ///    open: () =&gt; {
        ///      dimensionsEmitter.fire({
        ///        columns: 20,
        ///        rows: 10
        ///      });
        ///    },
        ///    close: () =&gt; {}
        /// };
        /// vscode.window.createTerminal({ name: 'My terminal', pty });
        /// </code>
        /// </summary>
        abstract onDidOverrideDimensions: Event<TerminalDimensions option> option with get, set
        /// <summary>
        /// An event that when fired will signal that the pty is closed and dispose of the terminal.
        ///
        /// Events fired before <see cref="Pseudoterminal.open" /> is called will be be ignored.
        ///
        /// A number can be used to provide an exit code for the terminal. Exit codes must be
        /// positive and a non-zero exit codes signals failure which shows a notification for a
        /// regular terminal and allows dependent tasks to proceed when used with the
        /// <c>CustomExecution</c> API.
        ///
        /// **Example:** Exit the terminal when "y" is pressed, otherwise show a notification.
        /// <code lang="typescript">
        /// const writeEmitter = new vscode.EventEmitter&lt;string&gt;();
        /// const closeEmitter = new vscode.EventEmitter&lt;vscode.TerminalDimensions&gt;();
        /// const pty: vscode.Pseudoterminal = {
        ///    onDidWrite: writeEmitter.event,
        ///    onDidClose: closeEmitter.event,
        ///    open: () =&gt; writeEmitter.fire('Press y to exit successfully'),
        ///    close: () =&gt; {},
        ///    handleInput: data =&gt; {
        ///      if (data !== 'y') {
        ///        vscode.window.showInformationMessage('Something went wrong');
        ///      }
        ///      closeEmitter.fire();
        ///    }
        /// };
        /// vscode.window.createTerminal({ name: 'Exit example', pty });
        /// </code>
        /// </summary>
        abstract onDidClose: Event<U2<unit, float>> option with get, set
        /// <summary>
        /// An event that when fired allows changing the name of the terminal.
        ///
        /// Events fired before <see cref="Pseudoterminal.open" /> is called will be be ignored.
        ///
        /// **Example:** Change the terminal name to "My new terminal".
        /// <code lang="typescript">
        /// const writeEmitter = new vscode.EventEmitter&lt;string&gt;();
        /// const changeNameEmitter = new vscode.EventEmitter&lt;string&gt;();
        /// const pty: vscode.Pseudoterminal = {
        ///    onDidWrite: writeEmitter.event,
        ///    onDidChangeName: changeNameEmitter.event,
        ///    open: () =&gt; changeNameEmitter.fire('My new terminal'),
        ///    close: () =&gt; {}
        /// };
        /// vscode.window.createTerminal({ name: 'My terminal', pty });
        /// </code>
        /// </summary>
        abstract onDidChangeName: Event<string> option with get, set
        /// <summary>Implement to handle when the pty is open and ready to start firing events.</summary>
        /// <param name="initialDimensions">
        /// The dimensions of the terminal, this will be undefined if the
        /// terminal panel has not been opened before this is called.
        /// </param>
        abstract ``open``: initialDimensions: TerminalDimensions option -> unit
        /// Implement to handle when the terminal is closed by an act of the user.
        abstract close: unit -> unit
        /// <summary>
        /// Implement to handle incoming keystrokes in the terminal or when an extension calls
        /// <see cref="Terminal.sendText" />. <c>data</c> contains the keystrokes/text serialized into
        /// their corresponding VT sequence representation.
        /// </summary>
        /// <param name="data">
        /// The incoming data.
        ///
        /// **Example:** Echo input in the terminal. The sequence for enter (<c>\r</c>) is translated to
        /// CRLF to go to a new line and move the cursor to the start of the line.
        /// <code lang="typescript">
        /// const writeEmitter = new vscode.EventEmitter&lt;string&gt;();
        /// const pty: vscode.Pseudoterminal = {
        /// onDidWrite: writeEmitter.event,
        /// open: () =&gt; {},
        /// close: () =&gt; {},
        /// handleInput: data =&gt; writeEmitter.fire(data === '\r' ? '\r\n' : data)
        /// };
        /// vscode.window.createTerminal({ name: 'Local echo', pty });
        /// </code>
        /// </param>
        abstract handleInput: data: string -> unit
        /// <summary>
        /// Implement to handle when the number of rows and columns that fit into the terminal panel
        /// changes, for example when font size changes or when the panel is resized. The initial
        /// state of a terminal's dimensions should be treated as <c>undefined</c> until this is triggered
        /// as the size of a terminal isn't known until it shows up in the user interface.
        ///
        /// When dimensions are overridden by
        /// <see cref="Pseudoterminal.onDidOverrideDimensions">onDidOverrideDimensions</see>, <c>setDimensions</c> will
        /// continue to be called with the regular panel dimensions, allowing the extension continue
        /// to react dimension changes.
        /// </summary>
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
        /// <summary>
        /// The exit code that a terminal exited with, it can have the following values:
        /// - Zero: the terminal process or custom execution succeeded.
        /// - Non-zero: the terminal process or custom execution failed.
        /// - <c>undefined</c>: the user forcibly closed the terminal or a custom execution exited
        ///    without providing an exit code.
        /// </summary>
        abstract code: float option

    /// A type of mutation that can be applied to an environment variable.
    type [<RequireQualifiedAccess>] EnvironmentVariableMutatorType =
        /// Replace the variable's existing value.
        | Replace = 1
        /// Append to the end of the variable's existing value.
        | Append = 2
        /// Prepend to the start of the variable's existing value.
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
        /// <summary>
        /// Replace an environment variable with a value.
        ///
        /// Note that an extension can only make a single change to any one variable, so this will
        /// overwrite any previous calls to replace, append or prepend.
        /// </summary>
        /// <param name="variable">The variable to replace.</param>
        /// <param name="value">The value to replace the variable with.</param>
        abstract replace: variable: string * value: string -> unit
        /// <summary>
        /// Append a value to an environment variable.
        ///
        /// Note that an extension can only make a single change to any one variable, so this will
        /// overwrite any previous calls to replace, append or prepend.
        /// </summary>
        /// <param name="variable">The variable to append to.</param>
        /// <param name="value">The value to append to the variable.</param>
        abstract append: variable: string * value: string -> unit
        /// <summary>
        /// Prepend a value to an environment variable.
        ///
        /// Note that an extension can only make a single change to any one variable, so this will
        /// overwrite any previous calls to replace, append or prepend.
        /// </summary>
        /// <param name="variable">The variable to prepend.</param>
        /// <param name="value">The value to prepend to the variable.</param>
        abstract prepend: variable: string * value: string -> unit
        /// <summary>Gets the mutator that this collection applies to a variable, if any.</summary>
        /// <param name="variable">The variable to get the mutator for.</param>
        abstract get: variable: string -> EnvironmentVariableMutator option
        /// <summary>Iterate over each mutator in this collection.</summary>
        /// <param name="callback">Function to execute for each entry.</param>
        /// <param name="thisArg">The <c>this</c> context used when invoking the handler function.</param>
        abstract forEach: callback: (string -> EnvironmentVariableMutator -> EnvironmentVariableCollection -> obj option) * ?thisArg: obj -> unit
        /// <summary>Deletes this collection's mutator for a variable.</summary>
        /// <param name="variable">The variable to delete the mutator for.</param>
        abstract delete: variable: string -> unit
        /// Clears all mutators from this collection.
        abstract clear: unit -> unit

    /// A location in the editor at which progress information can be shown. It depends on the
    /// location how progress is visually represented.
    type [<RequireQualifiedAccess>] ProgressLocation =
        /// Show progress for the source control viewlet, as overlay for the icon and as progress bar
        /// inside the viewlet (when visible). Neither supports cancellation nor discrete progress nor
        /// a label to describe the operation.
        | SourceControl = 1
        /// <summary>
        /// Show progress in the status bar of the editor. Neither supports cancellation nor discrete progress.
        /// Supports rendering of <see cref="ThemeIcon">theme icons</see> via the <c>$(&lt;name&gt;)</c>-syntax in the progress label.
        /// </summary>
        | Window = 10
        /// Show progress as notification with an optional cancel button. Supports to show infinite and discrete
        /// progress but does not support rendering of icons.
        | Notification = 15

    /// Value-object describing where and how progress should show.
    type [<AllowNullLiteral>] ProgressOptions =
        /// The location at which progress should show.
        abstract location: U2<ProgressLocation, {| viewId: string |}> with get, set
        /// A human-readable string which will be used to describe the
        /// operation.
        abstract title: string option with get, set
        /// <summary>
        /// Controls if a cancel button should show to allow the user to
        /// cancel the long running operation.  Note that currently only
        /// <c>ProgressLocation.Notification</c> is supporting to show a cancel
        /// button.
        /// </summary>
        abstract cancellable: bool option with get, set

    /// <summary>
    /// A light-weight user input UI that is initially not visible. After
    /// configuring it through its properties the extension can make it
    /// visible by calling <see cref="QuickInput.show" />.
    ///
    /// There are several reasons why this UI might have to be hidden and
    /// the extension will be notified through <see cref="QuickInput.onDidHide" />.
    /// (Examples include: an explicit call to <see cref="QuickInput.hide" />,
    /// the user pressing Esc, some other input UI opening, etc.)
    ///
    /// A user pressing Enter or some other gesture implying acceptance
    /// of the current state does not automatically hide this UI component.
    /// It is up to the extension to decide whether to accept the user's input
    /// and if the UI should indeed be hidden through a call to <see cref="QuickInput.hide" />.
    ///
    /// When the extension no longer needs this input UI, it should
    /// <see cref="QuickInput.dispose" /> it to allow for freeing up
    /// any resources associated with it.
    ///
    /// See <see cref="QuickPick" /> and <see cref="InputBox" /> for concrete UIs.
    /// </summary>
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
        /// <summary>
        /// Makes the input UI visible in its current configuration. Any other input
        /// UI will first fire an <see cref="QuickInput.onDidHide" /> event.
        /// </summary>
        abstract show: unit -> unit
        /// <summary>
        /// Hides this input UI. This will also fire an <see cref="QuickInput.onDidHide" />
        /// event.
        /// </summary>
        abstract hide: unit -> unit
        /// <summary>
        /// An event signaling when this input UI is hidden.
        ///
        /// There are several reasons why this UI might have to be hidden and
        /// the extension will be notified through <see cref="QuickInput.onDidHide" />.
        /// (Examples include: an explicit call to <see cref="QuickInput.hide" />,
        /// the user pressing Esc, some other input UI opening, etc.)
        /// </summary>
        abstract onDidHide: Event<unit> with get, set
        /// Dispose of this input UI and any associated resources. If it is still
        /// visible, it is first hidden. After this call the input UI is no longer
        /// functional and no additional methods or properties on it should be
        /// accessed. Instead a new input UI should be created.
        abstract dispose: unit -> unit

    /// <summary>
    /// A concrete <see cref="QuickInput" /> to let the user pick an item from a
    /// list of items of type T. The items can be filtered through a filter text field and
    /// there is an option <see cref="QuickPick.canSelectMany">canSelectMany</see> to allow for
    /// selecting multiple items.
    ///
    /// Note that in many cases the more convenient <see cref="window.showQuickPick" />
    /// is easier to use. <see cref="window.createQuickPick" /> should be used
    /// when <see cref="window.showQuickPick" /> does not offer the required flexibility.
    /// </summary>
    type [<AllowNullLiteral>] QuickPick<'T when 'T :> QuickPickItem> =
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
        /// <summary>
        /// An event signaling when a button in the title bar was triggered.
        /// This event does not fire for buttons on a <see cref="QuickPickItem" />.
        /// </summary>
        abstract onDidTriggerButton: Event<QuickInputButton>
        /// <summary>
        /// An event signaling when a button in a particular <see cref="QuickPickItem" /> was triggered.
        /// This event does not fire for buttons in the title bar.
        /// </summary>
        abstract onDidTriggerItemButton: Event<QuickPickItemButtonEvent<'T>>
        /// Items to pick from. This can be read and updated by the extension.
        abstract items: ResizeArray<'T> with get, set
        /// If multiple items can be selected at the same time. Defaults to false.
        abstract canSelectMany: bool with get, set
        /// If the filter text should also be matched against the description of the items. Defaults to false.
        abstract matchOnDescription: bool with get, set
        /// If the filter text should also be matched against the detail of the items. Defaults to false.
        abstract matchOnDetail: bool with get, set
        abstract keepScrollPosition: bool option with get, set
        /// Active items. This can be read and updated by the extension.
        abstract activeItems: ResizeArray<'T> with get, set
        /// An event signaling when the active items have changed.
        abstract onDidChangeActive: Event<ResizeArray<'T>>
        /// Selected items. This can be read and updated by the extension.
        abstract selectedItems: ResizeArray<'T> with get, set
        /// An event signaling when the selected items have changed.
        abstract onDidChangeSelection: Event<ResizeArray<'T>>

    /// <summary>
    /// A concrete <see cref="QuickInput" /> to let the user input a text value.
    ///
    /// Note that in many cases the more convenient <see cref="window.showInputBox" />
    /// is easier to use. <see cref="window.createInputBox" /> should be used
    /// when <see cref="window.showInputBox" /> does not offer the required flexibility.
    /// </summary>
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

    /// <summary>Button for an action in a <see cref="QuickPick" /> or <see cref="InputBox" />.</summary>
    type [<AllowNullLiteral>] QuickInputButton =
        /// Icon for the button.
        abstract iconPath: U3<Uri, {| light: Uri; dark: Uri |}, ThemeIcon>
        /// An optional tooltip.
        abstract tooltip: string option

    /// <summary>Predefined buttons for <see cref="QuickPick" /> and <see cref="InputBox" />.</summary>
    type [<AllowNullLiteral>] QuickInputButtons =
        interface end

    /// <summary>Predefined buttons for <see cref="QuickPick" /> and <see cref="InputBox" />.</summary>
    type [<AllowNullLiteral>] QuickInputButtonsStatic =
        /// <summary>
        /// A back button for <see cref="QuickPick" /> and <see cref="InputBox" />.
        ///
        /// When a navigation 'back' button is needed this one should be used for consistency.
        /// It comes with a predefined icon, tooltip and location.
        /// </summary>
        abstract Back: QuickInputButton

    /// <summary>
    /// An event signaling when a button in a particular <see cref="QuickPickItem" /> was triggered.
    /// This event does not fire for buttons in the title bar.
    /// </summary>
    type [<AllowNullLiteral>] QuickPickItemButtonEvent<'T when 'T :> QuickPickItem> =
        /// The button that was clicked.
        abstract button: QuickInputButton
        /// The item that the button belongs to.
        abstract item: 'T

    /// <summary>An event describing an individual change in the text of a <see cref="TextDocument">document</see>.</summary>
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
        /// The text change is caused by an undo operation.
        | Undo = 1
        /// The text change is caused by an redo operation.
        | Redo = 2

    /// <summary>An event describing a transactional <see cref="TextDocument">document</see> change.</summary>
    type [<AllowNullLiteral>] TextDocumentChangeEvent =
        /// The affected document.
        abstract document: TextDocument
        /// An array of content changes.
        abstract contentChanges: ResizeArray<TextDocumentContentChangeEvent>
        /// <summary>
        /// The reason why the document was changed.
        /// Is <c>undefined</c> if the reason is not known.
        /// </summary>
        abstract reason: TextDocumentChangeReason option

    /// Represents reasons why a text document is saved.
    type [<RequireQualifiedAccess>] TextDocumentSaveReason =
        /// Manually triggered, e.g. by the user pressing save, by starting debugging,
        /// or by an API call.
        | Manual = 1
        /// Automatic after a delay.
        | AfterDelay = 2
        /// When the editor lost focus.
        | FocusOut = 3

    /// <summary>
    /// An event that is fired when a <see cref="TextDocument">document</see> will be saved.
    ///
    /// To make modifications to the document before it is being saved, call the
    /// {@linkcode TextDocumentWillSaveEvent.waitUntil waitUntil}-function with a thenable
    /// that resolves to an array of <see cref="TextEdit">text edits</see>.
    /// </summary>
    type [<AllowNullLiteral>] TextDocumentWillSaveEvent =
        /// The document that will be saved.
        abstract document: TextDocument
        /// The reason why save was triggered.
        abstract reason: TextDocumentSaveReason
        /// <summary>
        /// Allows to pause the event loop and to apply <see cref="TextEdit">pre-save-edits</see>.
        /// Edits of subsequent calls to this function will be applied in order. The
        /// edits will be *ignored* if concurrent modifications of the document happened.
        ///
        /// *Note:* This function can only be called during event dispatch and not
        /// in an asynchronous manner:
        ///
        /// <code lang="ts">
        /// workspace.onWillSaveTextDocument(event =&gt; {
        ///      // async, will *throw* an error
        ///      setTimeout(() =&gt; event.waitUntil(promise));
        ///
        ///      // sync, OK
        ///      event.waitUntil(promise);
        /// })
        /// </code>
        /// </summary>
        /// <param name="thenable">A thenable that resolves to <see cref="TextEdit">pre-save-edits</see>.</param>
        abstract waitUntil: thenable: Thenable<ResizeArray<TextEdit>> -> unit
        /// <summary>
        /// Allows to pause the event loop until the provided thenable resolved.
        ///
        /// *Note:* This function can only be called during event dispatch.
        /// </summary>
        /// <param name="thenable">A thenable that delays saving.</param>
        abstract waitUntil: thenable: Thenable<obj option> -> unit

    /// <summary>
    /// An event that is fired when files are going to be created.
    ///
    /// To make modifications to the workspace before the files are created,
    /// call the {@linkcode FileWillCreateEvent.waitUntil waitUntil}-function with a
    /// thenable that resolves to a <see cref="WorkspaceEdit">workspace edit</see>.
    /// </summary>
    type [<AllowNullLiteral>] FileWillCreateEvent =
        /// A cancellation token.
        abstract token: CancellationToken
        /// The files that are going to be created.
        abstract files: ResizeArray<Uri>
        /// <summary>
        /// Allows to pause the event and to apply a <see cref="WorkspaceEdit">workspace edit</see>.
        ///
        /// *Note:* This function can only be called during event dispatch and not
        /// in an asynchronous manner:
        ///
        /// <code lang="ts">
        /// workspace.onWillCreateFiles(event =&gt; {
        ///      // async, will *throw* an error
        ///      setTimeout(() =&gt; event.waitUntil(promise));
        ///
        ///      // sync, OK
        ///      event.waitUntil(promise);
        /// })
        /// </code>
        /// </summary>
        /// <param name="thenable">A thenable that delays saving.</param>
        abstract waitUntil: thenable: Thenable<WorkspaceEdit> -> unit
        /// <summary>
        /// Allows to pause the event until the provided thenable resolves.
        ///
        /// *Note:* This function can only be called during event dispatch.
        /// </summary>
        /// <param name="thenable">A thenable that delays saving.</param>
        abstract waitUntil: thenable: Thenable<obj option> -> unit

    /// An event that is fired after files are created.
    type [<AllowNullLiteral>] FileCreateEvent =
        /// The files that got created.
        abstract files: ResizeArray<Uri>

    /// <summary>
    /// An event that is fired when files are going to be deleted.
    ///
    /// To make modifications to the workspace before the files are deleted,
    /// call the <see cref="FileWillCreateEvent.waitUntil">`waitUntil</see>-function with a
    /// thenable that resolves to a <see cref="WorkspaceEdit">workspace edit</see>.
    /// </summary>
    type [<AllowNullLiteral>] FileWillDeleteEvent =
        /// A cancellation token.
        abstract token: CancellationToken
        /// The files that are going to be deleted.
        abstract files: ResizeArray<Uri>
        /// <summary>
        /// Allows to pause the event and to apply a <see cref="WorkspaceEdit">workspace edit</see>.
        ///
        /// *Note:* This function can only be called during event dispatch and not
        /// in an asynchronous manner:
        ///
        /// <code lang="ts">
        /// workspace.onWillCreateFiles(event =&gt; {
        ///      // async, will *throw* an error
        ///      setTimeout(() =&gt; event.waitUntil(promise));
        ///
        ///      // sync, OK
        ///      event.waitUntil(promise);
        /// })
        /// </code>
        /// </summary>
        /// <param name="thenable">A thenable that delays saving.</param>
        abstract waitUntil: thenable: Thenable<WorkspaceEdit> -> unit
        /// <summary>
        /// Allows to pause the event until the provided thenable resolves.
        ///
        /// *Note:* This function can only be called during event dispatch.
        /// </summary>
        /// <param name="thenable">A thenable that delays saving.</param>
        abstract waitUntil: thenable: Thenable<obj option> -> unit

    /// An event that is fired after files are deleted.
    type [<AllowNullLiteral>] FileDeleteEvent =
        /// The files that got deleted.
        abstract files: ResizeArray<Uri>

    /// <summary>
    /// An event that is fired when files are going to be renamed.
    ///
    /// To make modifications to the workspace before the files are renamed,
    /// call the <see cref="FileWillCreateEvent.waitUntil">`waitUntil</see>-function with a
    /// thenable that resolves to a <see cref="WorkspaceEdit">workspace edit</see>.
    /// </summary>
    type [<AllowNullLiteral>] FileWillRenameEvent =
        /// A cancellation token.
        abstract token: CancellationToken
        /// The files that are going to be renamed.
        abstract files: ReadonlyArray<{| oldUri: Uri; newUri: Uri |}>
        /// <summary>
        /// Allows to pause the event and to apply a <see cref="WorkspaceEdit">workspace edit</see>.
        ///
        /// *Note:* This function can only be called during event dispatch and not
        /// in an asynchronous manner:
        ///
        /// <code lang="ts">
        /// workspace.onWillCreateFiles(event =&gt; {
        ///      // async, will *throw* an error
        ///      setTimeout(() =&gt; event.waitUntil(promise));
        ///
        ///      // sync, OK
        ///      event.waitUntil(promise);
        /// })
        /// </code>
        /// </summary>
        /// <param name="thenable">A thenable that delays saving.</param>
        abstract waitUntil: thenable: Thenable<WorkspaceEdit> -> unit
        /// <summary>
        /// Allows to pause the event until the provided thenable resolves.
        ///
        /// *Note:* This function can only be called during event dispatch.
        /// </summary>
        /// <param name="thenable">A thenable that delays saving.</param>
        abstract waitUntil: thenable: Thenable<obj option> -> unit

    /// An event that is fired after files are renamed.
    type [<AllowNullLiteral>] FileRenameEvent =
        /// The files that got renamed.
        abstract files: ReadonlyArray<{| oldUri: Uri; newUri: Uri |}>

    /// <summary>An event describing a change to the set of <see cref="workspace.workspaceFolders">workspace folders</see>.</summary>
    type [<AllowNullLiteral>] WorkspaceFoldersChangeEvent =
        /// Added workspace folders.
        abstract added: ResizeArray<WorkspaceFolder>
        /// Removed workspace folders.
        abstract removed: ResizeArray<WorkspaceFolder>

    /// A workspace folder is one of potentially many roots opened by the editor. All workspace folders
    /// are equal which means there is no notion of an active or primary workspace folder.
    type [<AllowNullLiteral>] WorkspaceFolder =
        /// <summary>
        /// The associated uri for this workspace folder.
        ///
        /// *Note:* The <see cref="Uri" />-type was intentionally chosen such that future releases of the editor can support
        /// workspace folders that are not stored on the local disk, e.g. <c>ftp://server/workspaces/foo</c>.
        /// </summary>
        abstract uri: Uri
        /// <summary>
        /// The name of this workspace folder. Defaults to
        /// the basename of its <see cref="Uri.path">uri-path</see>
        /// </summary>
        abstract name: string
        /// The ordinal number of this workspace folder.
        abstract index: float

    /// <summary>
    /// Namespace for dealing with the current workspace. A workspace is the collection of one
    /// or more folders that are opened in an editor window (instance).
    ///
    /// It is also possible to open an editor without a workspace. For example, when you open a
    /// new editor window by selecting a file from your platform's File menu, you will not be
    /// inside a workspace. In this mode, some of the editor's capabilities are reduced but you can
    /// still open text files and edit them.
    ///
    /// Refer to <see href="https://code.visualstudio.com/docs/editor/workspaces" /> for more information on
    /// the concept of workspaces.
    ///
    /// The workspace offers support for <see cref="workspace.createFileSystemWatcher">listening</see> to fs
    /// events and for <see cref="workspace.findFiles">finding</see> files. Both perform well and run _outside_
    /// the editor-process so that they should be always used instead of nodejs-equivalents.
    /// </summary>
    module Workspace =

        type [<AllowNullLiteral>] IExports =
            /// <summary>
            /// A <see cref="FileSystem">file system</see> instance that allows to interact with local and remote
            /// files, e.g. <c>vscode.workspace.fs.readDirectory(someUri)</c> allows to retrieve all entries
            /// of a directory or <c>vscode.workspace.fs.stat(anotherUri)</c> returns the meta data for a
            /// file.
            /// </summary>
            abstract fs: FileSystem
            /// <summary>
            /// The uri of the first entry of {@linkcode workspace.workspaceFolders workspaceFolders}
            /// as <c>string</c>. <c>undefined</c> if there is no first entry.
            ///
            /// Refer to <see href="https://code.visualstudio.com/docs/editor/workspaces" /> for more information
            /// on workspaces.
            /// </summary>
            [<Obsolete("Use {")>]
            abstract rootPath: string option
            /// <summary>
            /// List of workspace folders (0-N) that are open in the editor. <c>undefined</c> when no workspace
            /// has been opened.
            ///
            /// Refer to <see href="https://code.visualstudio.com/docs/editor/workspaces" /> for more information
            /// on workspaces.
            /// </summary>
            abstract workspaceFolders: ResizeArray<WorkspaceFolder> option
            /// <summary>
            /// The name of the workspace. <c>undefined</c> when no workspace
            /// has been opened.
            ///
            /// Refer to <see href="https://code.visualstudio.com/docs/editor/workspaces" /> for more information on
            /// the concept of workspaces.
            /// </summary>
            abstract name: string option
            /// <summary>
            /// The location of the workspace file, for example:
            ///
            /// <c>file:///Users/name/Development/myProject.code-workspace</c>
            ///
            /// or
            ///
            /// <c>untitled:1555503116870</c>
            ///
            /// for a workspace that is untitled and not yet saved.
            ///
            /// Depending on the workspace that is opened, the value will be:
            ///   * <c>undefined</c> when no workspace is opened
            ///   * the path of the workspace file as <c>Uri</c> otherwise. if the workspace
            /// is untitled, the returned URI will use the <c>untitled:</c> scheme
            ///
            /// The location can e.g. be used with the <c>vscode.openFolder</c> command to
            /// open the workspace again after it has been closed.
            ///
            /// **Example:**
            /// <code lang="typescript">
            /// vscode.commands.executeCommand('vscode.openFolder', uriOfWorkspace);
            /// </code>
            ///
            /// Refer to <see href="https://code.visualstudio.com/docs/editor/workspaces" /> for more information on
            /// the concept of workspaces.
            ///
            /// **Note:** it is not advised to use <c>workspace.workspaceFile</c> to write
            /// configuration data into the file. You can use <c>workspace.getConfiguration().update()</c>
            /// for that purpose which will work both when a single folder is opened as
            /// well as an untitled or saved workspace.
            /// </summary>
            abstract workspaceFile: Uri option
            /// <summary>
            /// An event that is emitted when a workspace folder is added or removed.
            ///
            /// **Note:** this event will not fire if the first workspace folder is added, removed or changed,
            /// because in that case the currently executing extensions (including the one that listens to this
            /// event) will be terminated and restarted so that the (deprecated) <c>rootPath</c> property is updated
            /// to point to the first workspace folder.
            /// </summary>
            abstract onDidChangeWorkspaceFolders: Event<WorkspaceFoldersChangeEvent>
            /// <summary>
            /// Returns the <see cref="WorkspaceFolder">workspace folder</see> that contains a given uri.
            /// * returns <c>undefined</c> when the given uri doesn't match any workspace folder
            /// * returns the *input* when the given uri is a workspace folder itself
            /// </summary>
            /// <param name="uri">An uri.</param>
            /// <returns>A workspace folder or <c>undefined</c></returns>
            abstract getWorkspaceFolder: uri: Uri -> WorkspaceFolder option
            /// <summary>
            /// Returns a path that is relative to the workspace folder or folders.
            ///
            /// When there are no <see cref="workspace.workspaceFolders">workspace folders</see> or when the path
            /// is not contained in them, the input is returned.
            /// </summary>
            /// <param name="pathOrUri">A path or uri. When a uri is given its <see cref="Uri.fsPath">fsPath</see> is used.</param>
            /// <param name="includeWorkspaceFolder">
            /// When <c>true</c> and when the given path is contained inside a
            /// workspace folder the name of the workspace is prepended. Defaults to <c>true</c> when there are
            /// multiple workspace folders and <c>false</c> otherwise.
            /// </param>
            /// <returns>A path relative to the root or the input.</returns>
            abstract asRelativePath: pathOrUri: U2<string, Uri> * ?includeWorkspaceFolder: bool -> string
            /// <summary>
            /// This method replaces <c>deleteCount</c> <see cref="workspace.workspaceFolders">workspace folders</see> starting at index <c>start</c>
            /// by an optional set of <c>workspaceFoldersToAdd</c> on the <c>vscode.workspace.workspaceFolders</c> array. This "splice"
            /// behavior can be used to add, remove and change workspace folders in a single operation.
            ///
            /// If the first workspace folder is added, removed or changed, the currently executing extensions (including the
            /// one that called this method) will be terminated and restarted so that the (deprecated) <c>rootPath</c> property is
            /// updated to point to the first workspace folder.
            ///
            /// Use the {@linkcode onDidChangeWorkspaceFolders onDidChangeWorkspaceFolders()} event to get notified when the
            /// workspace folders have been updated.
            ///
            /// **Example:** adding a new workspace folder at the end of workspace folders
            /// <code lang="typescript">
            /// workspace.updateWorkspaceFolders(workspace.workspaceFolders ? workspace.workspaceFolders.length : 0, null, { uri: ...});
            /// </code>
            ///
            /// **Example:** removing the first workspace folder
            /// <code lang="typescript">
            /// workspace.updateWorkspaceFolders(0, 1);
            /// </code>
            ///
            /// **Example:** replacing an existing workspace folder with a new one
            /// <code lang="typescript">
            /// workspace.updateWorkspaceFolders(0, 1, { uri: ...});
            /// </code>
            ///
            /// It is valid to remove an existing workspace folder and add it again with a different name
            /// to rename that folder.
            ///
            /// **Note:** it is not valid to call <see cref="updateWorkspaceFolders">updateWorkspaceFolders()</see> multiple times
            /// without waiting for the {@linkcode onDidChangeWorkspaceFolders onDidChangeWorkspaceFolders()} to fire.
            /// </summary>
            /// <param name="start">
            /// the zero-based location in the list of currently opened <see cref="WorkspaceFolder">workspace folders</see>
            /// from which to start deleting workspace folders.
            /// </param>
            /// <param name="deleteCount">the optional number of workspace folders to remove.</param>
            /// <param name="workspaceFoldersToAdd">
            /// the optional variable set of workspace folders to add in place of the deleted ones.
            /// Each workspace is identified with a mandatory URI and an optional name.
            /// </param>
            /// <returns>
            /// true if the operation was successfully started and false otherwise if arguments were used that would result
            /// in invalid workspace folder state (e.g. 2 folders with the same URI).
            /// </returns>
            abstract updateWorkspaceFolders: start: float * deleteCount: float option * [<ParamArray>] workspaceFoldersToAdd: {| uri: Uri; name: string option |}[] -> bool
            /// <summary>
            /// Creates a file system watcher that is notified on file events (create, change, delete)
            /// depending on the parameters provided.
            ///
            /// By default, all opened <see cref="workspace.workspaceFolders">workspace folders</see> will be watched
            /// for file changes recursively.
            ///
            /// Additional folders can be added for file watching by providing a <see cref="RelativePattern" /> with
            /// a <c>base</c> that is outside of any of the currently opened workspace folders. If the <c>pattern</c> is
            /// complex (e.g. contains <c>**</c> or path segments), the folder will be watched recursively and
            /// otherwise will be watched non-recursively (i.e. only changes to the first level of the path
            /// will be reported).
            ///
            /// Providing a <c>string</c> as <c>globPattern</c> acts as convenience method for watching file events in
            /// all opened workspace folders. It cannot be used to add more folders for file watching, nor will
            /// it report any file events from folders that are not part of the opened workspace folders.
            ///
            /// Optionally, flags to ignore certain kinds of events can be provided.
            ///
            /// To stop listening to events the watcher must be disposed.
            ///
            /// *Note* that file events from file watchers may be excluded based on user configuration.
            /// The setting <c>files.watcherExclude</c> helps to reduce the overhead of file events from folders
            /// that are known to produce many file changes at once (such as <c>node_modules</c> folders). As such,
            /// it is highly recommended to watch with simple patterns that do not require recursive watchers.
            ///
            /// *Note* that symbolic links are not automatically followed for file watching unless the path to
            /// watch itself is a symbolic link.
            ///
            /// *Note* that file changes for the path to be watched may not be delivered when the path itself
            /// changes. For example, when watching a path <c>/Users/somename/Desktop</c> and the path itself is
            /// being deleted, the watcher may not report an event and may not work anymore from that moment on.
            /// The underlying behaviour depends on the path that is provided for watching:
            /// * if the path is within any of the workspace folders, deletions are tracked and reported unless
            ///    excluded via <c>files.watcherExclude</c> setting
            /// * if the path is equal to any of the workspace folders, deletions are not tracked
            /// * if the path is outside of any of the workspace folders, deletions are not tracked
            ///
            /// If you are interested in being notified when the watched path itself is being deleted, you have
            /// to watch it's parent folder. Make sure to use a simple <c>pattern</c> (such as putting the name of the
            /// folder) to not accidentally watch all sibling folders recursively.
            ///
            /// *Note* that the file paths that are reported for having changed may have a different path casing
            /// compared to the actual casing on disk on case-insensitive platforms (typically macOS and Windows
            /// but not Linux). We allow a user to open a workspace folder with any desired path casing and try
            /// to preserve that. This means:
            /// * if the path is within any of the workspace folders, the path will match the casing of the
            ///    workspace folder up to that portion of the path and match the casing on disk for children
            /// * if the path is outside of any of the workspace folders, the casing will match the case of the
            ///    path that was provided for watching
            /// In the same way, symbolic links are preserved, i.e. the file event will report the path of the
            /// symbolic link as it was provided for watching and not the target.
            ///
            /// ### Examples
            ///
            /// The basic anatomy of a file watcher is as follows:
            ///
            /// <code lang="ts">
            /// const watcher = vscode.workspace.createFileSystemWatcher(new vscode.RelativePattern(&lt;folder&gt;, &lt;pattern&gt;));
            ///
            /// watcher.onDidChange(uri =&gt; { ... }); // listen to files being changed
            /// watcher.onDidCreate(uri =&gt; { ... }); // listen to files/folders being created
            /// watcher.onDidDelete(uri =&gt; { ... }); // listen to files/folders getting deleted
            ///
            /// watcher.dispose(); // dispose after usage
            /// </code>
            ///
            /// #### Workspace file watching
            ///
            /// If you only care about file events in a specific workspace folder:
            ///
            /// <code lang="ts">
            /// vscode.workspace.createFileSystemWatcher(new vscode.RelativePattern(vscode.workspace.workspaceFolders[0], '**​/*.js'));
            /// </code>
            ///
            /// If you want to monitor file events across all opened workspace folders:
            ///
            /// <code lang="ts">
            /// vscode.workspace.createFileSystemWatcher('**​/*.js'));
            /// </code>
            ///
            /// *Note:* the array of workspace folders can be empy if no workspace is opened (empty window).
            ///
            /// #### Out of workspace file watching
            ///
            /// To watch a folder for changes to *.js files outside the workspace (non recursively), pass in a <c>Uri</c> to such
            /// a folder:
            ///
            /// <code lang="ts">
            /// vscode.workspace.createFileSystemWatcher(new vscode.RelativePattern(vscode.Uri.file(&lt;path to folder outside workspace&gt;), '*.js'));
            /// </code>
            ///
            /// And use a complex glob pattern to watch recursively:
            ///
            /// <code lang="ts">
            /// vscode.workspace.createFileSystemWatcher(new vscode.RelativePattern(vscode.Uri.file(&lt;path to folder outside workspace&gt;), '**​/*.js'));
            /// </code>
            ///
            /// Here is an example for watching the active editor for file changes:
            ///
            /// <code lang="ts">
            /// vscode.workspace.createFileSystemWatcher(new vscode.RelativePattern(vscode.window.activeTextEditor.document.uri, '*'));
            /// </code>
            /// </summary>
            /// <param name="globPattern">A <see cref="GlobPattern">glob pattern</see> that controls which file events the watcher should report.</param>
            /// <param name="ignoreCreateEvents">Ignore when files have been created.</param>
            /// <param name="ignoreChangeEvents">Ignore when files have been changed.</param>
            /// <param name="ignoreDeleteEvents">Ignore when files have been deleted.</param>
            /// <returns>A new file system watcher instance. Must be disposed when no longer needed.</returns>
            abstract createFileSystemWatcher: globPattern: GlobPattern * ?ignoreCreateEvents: bool * ?ignoreChangeEvents: bool * ?ignoreDeleteEvents: bool -> FileSystemWatcher
            /// <summary>Find files across all <see cref="workspace.workspaceFolders">workspace folders</see> in the workspace.</summary>
            /// <example>findFiles('**​/*.js', '**​/node_modules/**', 10)</example>
            /// <param name="include">
            /// A <see cref="GlobPattern">glob pattern</see> that defines the files to search for. The glob pattern
            /// will be matched against the file paths of resulting matches relative to their workspace. Use a <see cref="RelativePattern">relative pattern</see>
            /// to restrict the search results to a <see cref="WorkspaceFolder">workspace folder</see>.
            /// </param>
            /// <param name="exclude">
            /// A <see cref="GlobPattern">glob pattern</see> that defines files and folders to exclude. The glob pattern
            /// will be matched against the file paths of resulting matches relative to their workspace. When <c>undefined</c>, default file-excludes (e.g. the <c>files.exclude</c>-setting
            /// but not <c>search.exclude</c>) will apply. When <c>null</c>, no excludes will apply.
            /// </param>
            /// <param name="maxResults">An upper-bound for the result.</param>
            /// <param name="token">A token that can be used to signal cancellation to the underlying search engine.</param>
            /// <returns>
            /// A thenable that resolves to an array of resource identifiers. Will return no results if no
            /// <see cref="workspace.workspaceFolders">workspace folders</see> are opened.
            /// </returns>
            abstract findFiles: ``include``: GlobPattern * ?exclude: GlobPattern * ?maxResults: float * ?token: CancellationToken -> Thenable<ResizeArray<Uri>>
            /// <summary>Save all dirty files.</summary>
            /// <param name="includeUntitled">Also save files that have been created during this session.</param>
            /// <returns>
            /// A thenable that resolves when the files have been saved. Will return <c>false</c>
            /// for any file that failed to save.
            /// </returns>
            abstract saveAll: ?includeUntitled: bool -> Thenable<bool>
            /// <summary>
            /// Make changes to one or many resources or create, delete, and rename resources as defined by the given
            /// <see cref="WorkspaceEdit">workspace edit</see>.
            ///
            /// All changes of a workspace edit are applied in the same order in which they have been added. If
            /// multiple textual inserts are made at the same position, these strings appear in the resulting text
            /// in the order the 'inserts' were made, unless that are interleaved with resource edits. Invalid sequences
            /// like 'delete file a' -&gt; 'insert text in file a' cause failure of the operation.
            ///
            /// When applying a workspace edit that consists only of text edits an 'all-or-nothing'-strategy is used.
            /// A workspace edit with resource creations or deletions aborts the operation, e.g. consecutive edits will
            /// not be attempted, when a single edit fails.
            /// </summary>
            /// <param name="edit">A workspace edit.</param>
            /// <returns>A thenable that resolves when the edit could be applied.</returns>
            abstract applyEdit: edit: WorkspaceEdit -> Thenable<bool>
            /// All text documents currently known to the editor.
            abstract textDocuments: ResizeArray<TextDocument>
            /// <summary>
            /// Opens a document. Will return early if this document is already open. Otherwise
            /// the document is loaded and the <see cref="workspace.onDidOpenTextDocument">didOpen</see>-event fires.
            ///
            /// The document is denoted by an <see cref="Uri" />. Depending on the <see cref="Uri.scheme">scheme</see> the
            /// following rules apply:
            /// * <c>file</c>-scheme: Open a file on disk (<c>openTextDocument(Uri.file(path))</c>). Will be rejected if the file
            /// does not exist or cannot be loaded.
            /// * <c>untitled</c>-scheme: Open a blank untitled file with associated path (<c>openTextDocument(Uri.file(path).with({ scheme: 'untitled' }))</c>).
            /// The language will be derived from the file name.
            /// * For all other schemes contributed <see cref="TextDocumentContentProvider">text document content providers</see> and
            /// <see cref="FileSystemProvider">file system providers</see> are consulted.
            ///
            /// *Note* that the lifecycle of the returned document is owned by the editor and not by the extension. That means an
            /// {@linkcode workspace.onDidCloseTextDocument onDidClose}-event can occur at any time after opening it.
            /// </summary>
            /// <param name="uri">Identifies the resource to open.</param>
            /// <returns>A promise that resolves to a <see cref="TextDocument">document</see>.</returns>
            abstract openTextDocument: uri: Uri -> Thenable<TextDocument>
            /// <summary>A short-hand for <c>openTextDocument(Uri.file(fileName))</c>.</summary>
            /// <seealso cref="workspace.openTextDocument" />
            /// <param name="fileName">A name of a file on disk.</param>
            /// <returns>A promise that resolves to a <see cref="TextDocument">document</see>.</returns>
            abstract openTextDocument: fileName: string -> Thenable<TextDocument>
            /// <summary>
            /// Opens an untitled text document. The editor will prompt the user for a file
            /// path when the document is to be saved. The <c>options</c> parameter allows to
            /// specify the *language* and/or the *content* of the document.
            /// </summary>
            /// <param name="options">Options to control how the document will be created.</param>
            /// <returns>A promise that resolves to a <see cref="TextDocument">document</see>.</returns>
            abstract openTextDocument: ?options: {| language: string option; content: string option |} -> Thenable<TextDocument>
            /// <summary>
            /// Register a text document content provider.
            ///
            /// Only one provider can be registered per scheme.
            /// </summary>
            /// <param name="scheme">The uri-scheme to register for.</param>
            /// <param name="provider">A content provider.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            abstract registerTextDocumentContentProvider: scheme: string * provider: TextDocumentContentProvider -> Disposable
            /// <summary>
            /// An event that is emitted when a <see cref="TextDocument">text document</see> is opened or when the language id
            /// of a text document <see cref="languages.setTextDocumentLanguage">has been changed</see>.
            ///
            /// To add an event listener when a visible text document is opened, use the <see cref="TextEditor" /> events in the
            /// <see cref="window" /> namespace. Note that:
            ///
            /// - The event is emitted before the <see cref="TextDocument">document</see> is updated in the
            /// <see cref="window.activeTextEditor">active text editor</see>
            /// - When a <see cref="TextDocument">text document</see> is already open (e.g.: open in another <see cref="window.visibleTextEditors">visible text editor</see>) this event is not emitted
            /// </summary>
            abstract onDidOpenTextDocument: Event<TextDocument>
            /// <summary>
            /// An event that is emitted when a <see cref="TextDocument">text document</see> is disposed or when the language id
            /// of a text document <see cref="languages.setTextDocumentLanguage">has been changed</see>.
            ///
            /// *Note 1:* There is no guarantee that this event fires when an editor tab is closed, use the
            /// {@linkcode window.onDidChangeVisibleTextEditors onDidChangeVisibleTextEditors}-event to know when editors change.
            ///
            /// *Note 2:* A document can be open but not shown in an editor which means this event can fire
            /// for a document that has not been shown in an editor.
            /// </summary>
            abstract onDidCloseTextDocument: Event<TextDocument>
            /// <summary>
            /// An event that is emitted when a <see cref="TextDocument">text document</see> is changed. This usually happens
            /// when the <see cref="TextDocument.getText">contents</see> changes but also when other things like the
            /// <see cref="TextDocument.isDirty">dirty</see>-state changes.
            /// </summary>
            abstract onDidChangeTextDocument: Event<TextDocumentChangeEvent>
            /// <summary>
            /// An event that is emitted when a <see cref="TextDocument">text document</see> will be saved to disk.
            ///
            /// *Note 1:* Subscribers can delay saving by registering asynchronous work. For the sake of data integrity the editor
            /// might save without firing this event. For instance when shutting down with dirty files.
            ///
            /// *Note 2:* Subscribers are called sequentially and they can <see cref="TextDocumentWillSaveEvent.waitUntil">delay</see> saving
            /// by registering asynchronous work. Protection against misbehaving listeners is implemented as such:
            ///   * there is an overall time budget that all listeners share and if that is exhausted no further listener is called
            ///   * listeners that take a long time or produce errors frequently will not be called anymore
            ///
            /// The current thresholds are 1.5 seconds as overall time budget and a listener can misbehave 3 times before being ignored.
            /// </summary>
            abstract onWillSaveTextDocument: Event<TextDocumentWillSaveEvent>
            /// <summary>An event that is emitted when a <see cref="TextDocument">text document</see> is saved to disk.</summary>
            abstract onDidSaveTextDocument: Event<TextDocument>
            /// All notebook documents currently known to the editor.
            abstract notebookDocuments: ResizeArray<NotebookDocument>
            /// <summary>
            /// Open a notebook. Will return early if this notebook is already <see cref="notebook.notebookDocuments">loaded</see>. Otherwise
            /// the notebook is loaded and the {@linkcode notebook.onDidOpenNotebookDocument onDidOpenNotebookDocument}-event fires.
            ///
            /// *Note* that the lifecycle of the returned notebook is owned by the editor and not by the extension. That means an
            /// {@linkcode notebook.onDidCloseNotebookDocument onDidCloseNotebookDocument}-event can occur at any time after.
            ///
            /// *Note* that opening a notebook does not show a notebook editor. This function only returns a notebook document which
            /// can be showns in a notebook editor but it can also be used for other things.
            /// </summary>
            /// <param name="uri">The resource to open.</param>
            /// <returns>A promise that resolves to a <see cref="NotebookDocument">notebook</see></returns>
            abstract openNotebookDocument: uri: Uri -> Thenable<NotebookDocument>
            /// <summary>
            /// Open an untitled notebook. The editor will prompt the user for a file
            /// path when the document is to be saved.
            /// </summary>
            /// <seealso cref="workspace.openNotebookDocument" />
            /// <param name="notebookType">The notebook type that should be used.</param>
            /// <param name="content">The initial contents of the notebook.</param>
            /// <returns>A promise that resolves to a <see cref="NotebookDocument">notebook</see>.</returns>
            abstract openNotebookDocument: notebookType: string * ?content: NotebookData -> Thenable<NotebookDocument>
            /// <summary>
            /// Register a <see cref="NotebookSerializer">notebook serializer</see>.
            ///
            /// A notebook serializer must be contributed through the <c>notebooks</c> extension point. When opening a notebook file, the editor will send
            /// the <c>onNotebook:&lt;notebookType&gt;</c> activation event, and extensions must register their serializer in return.
            /// </summary>
            /// <param name="notebookType">A notebook.</param>
            /// <param name="serializer">A notebook serialzier.</param>
            /// <param name="options">Optional context options that define what parts of a notebook should be persisted</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this serializer when being disposed.</returns>
            abstract registerNotebookSerializer: notebookType: string * serializer: NotebookSerializer * ?options: NotebookDocumentContentOptions -> Disposable
            /// <summary>An event that is emitted when a <see cref="NotebookDocument">notebook</see> is opened.</summary>
            abstract onDidOpenNotebookDocument: Event<NotebookDocument>
            /// <summary>
            /// An event that is emitted when a <see cref="NotebookDocument">notebook</see> is disposed.
            ///
            /// *Note 1:* There is no guarantee that this event fires when an editor tab is closed.
            ///
            /// *Note 2:* A notebook can be open but not shown in an editor which means this event can fire
            /// for a notebook that has not been shown in an editor.
            /// </summary>
            abstract onDidCloseNotebookDocument: Event<NotebookDocument>
            /// An event that is emitted when files are being created.
            ///
            /// *Note 1:* This event is triggered by user gestures, like creating a file from the
            /// explorer, or from the {@linkcode workspace.applyEdit}-api. This event is *not* fired when
            /// files change on disk, e.g triggered by another application, or when using the
            /// {@linkcode FileSystem workspace.fs}-api.
            ///
            /// *Note 2:* When this event is fired, edits to files that are are being created cannot be applied.
            abstract onWillCreateFiles: Event<FileWillCreateEvent>
            /// An event that is emitted when files have been created.
            ///
            /// *Note:* This event is triggered by user gestures, like creating a file from the
            /// explorer, or from the {@linkcode workspace.applyEdit}-api, but this event is *not* fired when
            /// files change on disk, e.g triggered by another application, or when using the
            /// {@linkcode FileSystem workspace.fs}-api.
            abstract onDidCreateFiles: Event<FileCreateEvent>
            /// An event that is emitted when files are being deleted.
            ///
            /// *Note 1:* This event is triggered by user gestures, like deleting a file from the
            /// explorer, or from the {@linkcode workspace.applyEdit}-api, but this event is *not* fired when
            /// files change on disk, e.g triggered by another application, or when using the
            /// {@linkcode FileSystem workspace.fs}-api.
            ///
            /// *Note 2:* When deleting a folder with children only one event is fired.
            abstract onWillDeleteFiles: Event<FileWillDeleteEvent>
            /// An event that is emitted when files have been deleted.
            ///
            /// *Note 1:* This event is triggered by user gestures, like deleting a file from the
            /// explorer, or from the {@linkcode workspace.applyEdit}-api, but this event is *not* fired when
            /// files change on disk, e.g triggered by another application, or when using the
            /// {@linkcode FileSystem workspace.fs}-api.
            ///
            /// *Note 2:* When deleting a folder with children only one event is fired.
            abstract onDidDeleteFiles: Event<FileDeleteEvent>
            /// An event that is emitted when files are being renamed.
            ///
            /// *Note 1:* This event is triggered by user gestures, like renaming a file from the
            /// explorer, and from the {@linkcode workspace.applyEdit}-api, but this event is *not* fired when
            /// files change on disk, e.g triggered by another application, or when using the
            /// {@linkcode FileSystem workspace.fs}-api.
            ///
            /// *Note 2:* When renaming a folder with children only one event is fired.
            abstract onWillRenameFiles: Event<FileWillRenameEvent>
            /// An event that is emitted when files have been renamed.
            ///
            /// *Note 1:* This event is triggered by user gestures, like renaming a file from the
            /// explorer, and from the {@linkcode workspace.applyEdit}-api, but this event is *not* fired when
            /// files change on disk, e.g triggered by another application, or when using the
            /// {@linkcode FileSystem workspace.fs}-api.
            ///
            /// *Note 2:* When renaming a folder with children only one event is fired.
            abstract onDidRenameFiles: Event<FileRenameEvent>
            /// <summary>
            /// Get a workspace configuration object.
            ///
            /// When a section-identifier is provided only that part of the configuration
            /// is returned. Dots in the section-identifier are interpreted as child-access,
            /// like <c>{ myExt: { setting: { doIt: true }}}</c> and <c>getConfiguration('myExt.setting').get('doIt') === true</c>.
            ///
            /// When a scope is provided configuration confined to that scope is returned. Scope can be a resource or a language identifier or both.
            /// </summary>
            /// <param name="section">A dot-separated identifier.</param>
            /// <param name="scope">A scope for which the configuration is asked for.</param>
            /// <returns>The full configuration or a subset.</returns>
            abstract getConfiguration: ?section: string * ?scope: ConfigurationScope -> WorkspaceConfiguration
            /// <summary>An event that is emitted when the <see cref="WorkspaceConfiguration">configuration</see> changed.</summary>
            abstract onDidChangeConfiguration: Event<ConfigurationChangeEvent>
            /// <summary>Register a task provider.</summary>
            /// <param name="type">The task kind type this provider is registered for.</param>
            /// <param name="provider">A task provider.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            [<Obsolete("Use the corresponding function on the `tasks` namespace instead")>]
            abstract registerTaskProvider: ``type``: string * provider: TaskProvider -> Disposable
            /// <summary>
            /// Register a filesystem provider for a given scheme, e.g. <c>ftp</c>.
            ///
            /// There can only be one provider per scheme and an error is being thrown when a scheme
            /// has been claimed by another provider or when it is reserved.
            /// </summary>
            /// <param name="scheme">The uri-<see cref="Uri.scheme">scheme</see> the provider registers for.</param>
            /// <param name="provider">The filesystem provider.</param>
            /// <param name="options">Immutable metadata about the provider.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            abstract registerFileSystemProvider: scheme: string * provider: FileSystemProvider * ?options: {| isCaseSensitive: bool option; isReadonly: bool option |} -> Disposable
            /// When true, the user has explicitly trusted the contents of the workspace.
            abstract isTrusted: bool
            /// Event that fires when the current workspace has been trusted.
            abstract onDidGrantWorkspaceTrust: Event<unit>

    /// <summary>
    /// The configuration scope which can be a
    /// a 'resource' or a languageId or both or
    /// a '<see cref="TextDocument" />' or
    /// a '<see cref="WorkspaceFolder" />'
    /// </summary>
    type ConfigurationScope =
        U4<Uri, TextDocument, WorkspaceFolder, {| uri: Uri option; languageId: string |}>

    /// An event describing the change in Configuration
    type [<AllowNullLiteral>] ConfigurationChangeEvent =
        /// <summary>
        /// Checks if the given section has changed.
        /// If scope is provided, checks if the section has changed for resources under the given scope.
        /// </summary>
        /// <param name="section">Configuration name, supports _dotted_ names.</param>
        /// <param name="scope">A scope in which to check.</param>
        /// <returns><c>true</c> if the given section has changed.</returns>
        abstract affectsConfiguration: section: string * ?scope: ConfigurationScope -> bool

    /// <summary>
    /// Namespace for participating in language-specific editor <see href="https://code.visualstudio.com/docs/editor/editingevolved">features</see>,
    /// like IntelliSense, code actions, diagnostics etc.
    ///
    /// Many programming languages exist and there is huge variety in syntaxes, semantics, and paradigms. Despite that, features
    /// like automatic word-completion, code navigation, or code checking have become popular across different tools for different
    /// programming languages.
    ///
    /// The editor provides an API that makes it simple to provide such common features by having all UI and actions already in place and
    /// by allowing you to participate by providing data only. For instance, to contribute a hover all you have to do is provide a function
    /// that can be called with a <see cref="TextDocument" /> and a <see cref="Position" /> returning hover info. The rest, like tracking the
    /// mouse, positioning the hover, keeping the hover stable etc. is taken care of by the editor.
    ///
    /// <code lang="javascript">
    /// languages.registerHoverProvider('javascript', {
    ///      provideHover(document, position, token) {
    ///          return new Hover('I am a hover!');
    ///      }
    /// });
    /// </code>
    ///
    /// Registration is done using a <see cref="DocumentSelector">document selector</see> which is either a language id, like <c>javascript</c> or
    /// a more complex <see cref="DocumentFilter">filter</see> like <c>{ language: 'typescript', scheme: 'file' }</c>. Matching a document against such
    /// a selector will result in a <see cref="languages.match">score</see> that is used to determine if and how a provider shall be used. When
    /// scores are equal the provider that came last wins. For features that allow full arity, like <see cref="languages.registerHoverProvider">hover</see>,
    /// the score is only checked to be <c>&gt;0</c>, for other features, like <see cref="languages.registerCompletionItemProvider">IntelliSense</see> the
    /// score is used for determining the order in which providers are asked to participate.
    /// </summary>
    module Languages =

        type [<AllowNullLiteral>] IExports =
            /// <summary>Return the identifiers of all known languages.</summary>
            /// <returns>Promise resolving to an array of identifier strings.</returns>
            abstract getLanguages: unit -> Thenable<ResizeArray<string>>
            /// <summary>
            /// Set (and change) the <see cref="TextDocument.languageId">language</see> that is associated
            /// with the given document.
            ///
            /// *Note* that calling this function will trigger the {@linkcode workspace.onDidCloseTextDocument onDidCloseTextDocument} event
            /// followed by the {@linkcode workspace.onDidOpenTextDocument onDidOpenTextDocument} event.
            /// </summary>
            /// <param name="document">The document which language is to be changed</param>
            /// <param name="languageId">The new language identifier.</param>
            /// <returns>A thenable that resolves with the updated document.</returns>
            abstract setTextDocumentLanguage: document: TextDocument * languageId: string -> Thenable<TextDocument>
            /// <summary>
            /// Compute the match between a document <see cref="DocumentSelector">selector</see> and a document. Values
            /// greater than zero mean the selector matches the document.
            ///
            /// A match is computed according to these rules:
            /// 1. When {@linkcode DocumentSelector} is an array, compute the match for each contained <c>DocumentFilter</c> or language identifier and take the maximum value.
            /// 2. A string will be desugared to become the <c>language</c>-part of a {@linkcode DocumentFilter}, so <c>"fooLang"</c> is like <c>{ language: "fooLang" }</c>.
            /// 3. A {@linkcode DocumentFilter} will be matched against the document by comparing its parts with the document. The following rules apply:
            ///     1. When the <c>DocumentFilter</c> is empty (<c>{}</c>) the result is <c>0</c>
            ///     2. When <c>scheme</c>, <c>language</c>, <c>pattern</c>, or <c>notebook</c> are defined but one doesn't match, the result is <c>0</c>
            ///     3. Matching against <c>*</c> gives a score of <c>5</c>, matching via equality or via a glob-pattern gives a score of <c>10</c>
            ///     4. The result is the maximum value of each match
            ///
            /// Samples:
            /// <code lang="js">
            /// // default document from disk (file-scheme)
            /// doc.uri; //'file:///my/file.js'
            /// doc.languageId; // 'javascript'
            /// match('javascript', doc); // 10;
            /// match({ language: 'javascript' }, doc); // 10;
            /// match({ language: 'javascript', scheme: 'file' }, doc); // 10;
            /// match('*', doc); // 5
            /// match('fooLang', doc); // 0
            /// match(['fooLang', '*'], doc); // 5
            ///
            /// // virtual document, e.g. from git-index
            /// doc.uri; // 'git:/my/file.js'
            /// doc.languageId; // 'javascript'
            /// match('javascript', doc); // 10;
            /// match({ language: 'javascript', scheme: 'git' }, doc); // 10;
            /// match('*', doc); // 5
            ///
            /// // notebook cell document
            /// doc.uri; // `vscode-notebook-cell:///my/notebook.ipynb#gl65s2pmha`;
            /// doc.languageId; // 'python'
            /// match({ notebookType: 'jupyter-notebook' }, doc) // 10
            /// match({ notebookType: 'fooNotebook', language: 'python' }, doc) // 0
            /// match({ language: 'python' }, doc) // 10
            /// match({ notebookType: '*' }, doc) // 5
            /// </code>
            /// </summary>
            /// <param name="selector">A document selector.</param>
            /// <param name="document">A text document.</param>
            /// <returns>A number <c>&gt;0</c> when the selector matches and <c>0</c> when the selector does not match.</returns>
            abstract ``match``: selector: DocumentSelector * document: TextDocument -> float
            /// <summary>
            /// An <see cref="Event" /> which fires when the global set of diagnostics changes. This is
            /// newly added and removed diagnostics.
            /// </summary>
            abstract onDidChangeDiagnostics: Event<DiagnosticChangeEvent>
            /// <summary>Get all diagnostics for a given resource.</summary>
            /// <param name="resource">A resource</param>
            /// <returns>An array of <see cref="Diagnostic">diagnostics</see> objects or an empty array.</returns>
            abstract getDiagnostics: resource: Uri -> ResizeArray<Diagnostic>
            /// <summary>Get all diagnostics.</summary>
            /// <returns>An array of uri-diagnostics tuples or an empty array.</returns>
            abstract getDiagnostics: unit -> ResizeArray<Uri * ResizeArray<Diagnostic>>
            /// <summary>Create a diagnostics collection.</summary>
            /// <param name="name">The <see cref="DiagnosticCollection.name">name</see> of the collection.</param>
            /// <returns>A new diagnostic collection.</returns>
            abstract createDiagnosticCollection: ?name: string -> DiagnosticCollection
            /// <summary>Creates a new <see cref="LanguageStatusItem">language status item</see>.</summary>
            /// <param name="id">The identifier of the item.</param>
            /// <param name="selector">The document selector that defines for what editors the item shows.</param>
            abstract createLanguageStatusItem: id: string * selector: DocumentSelector -> LanguageStatusItem
            /// <summary>
            /// Register a completion provider.
            ///
            /// Multiple providers can be registered for a language. In that case providers are sorted
            /// by their <see cref="languages.match">score</see> and groups of equal score are sequentially asked for
            /// completion items. The process stops when one or many providers of a group return a
            /// result. A failing provider (rejected promise or exception) will not fail the whole
            /// operation.
            ///
            /// A completion item provider can be associated with a set of <c>triggerCharacters</c>. When trigger
            /// characters are being typed, completions are requested but only from providers that registered
            /// the typed character. Because of that trigger characters should be different than <see cref="LanguageConfiguration.wordPattern">word characters</see>,
            /// a common trigger character is <c>.</c> to trigger member completions.
            /// </summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A completion provider.</param>
            /// <param name="triggerCharacters">Trigger completion when the user types one of the characters.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            abstract registerCompletionItemProvider: selector: DocumentSelector * provider: CompletionItemProvider * [<ParamArray>] triggerCharacters: string[] -> Disposable
            /// <summary>
            /// Register a code action provider.
            ///
            /// Multiple providers can be registered for a language. In that case providers are asked in
            /// parallel and the results are merged. A failing provider (rejected promise or exception) will
            /// not cause a failure of the whole operation.
            /// </summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A code action provider.</param>
            /// <param name="metadata">Metadata about the kind of code actions the provider provides.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            abstract registerCodeActionsProvider: selector: DocumentSelector * provider: CodeActionProvider * ?metadata: CodeActionProviderMetadata -> Disposable
            /// <summary>
            /// Register a code lens provider.
            ///
            /// Multiple providers can be registered for a language. In that case providers are asked in
            /// parallel and the results are merged. A failing provider (rejected promise or exception) will
            /// not cause a failure of the whole operation.
            /// </summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A code lens provider.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            abstract registerCodeLensProvider: selector: DocumentSelector * provider: CodeLensProvider -> Disposable
            /// <summary>
            /// Register a definition provider.
            ///
            /// Multiple providers can be registered for a language. In that case providers are asked in
            /// parallel and the results are merged. A failing provider (rejected promise or exception) will
            /// not cause a failure of the whole operation.
            /// </summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A definition provider.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            abstract registerDefinitionProvider: selector: DocumentSelector * provider: DefinitionProvider -> Disposable
            /// <summary>
            /// Register an implementation provider.
            ///
            /// Multiple providers can be registered for a language. In that case providers are asked in
            /// parallel and the results are merged. A failing provider (rejected promise or exception) will
            /// not cause a failure of the whole operation.
            /// </summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">An implementation provider.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            abstract registerImplementationProvider: selector: DocumentSelector * provider: ImplementationProvider -> Disposable
            /// <summary>
            /// Register a type definition provider.
            ///
            /// Multiple providers can be registered for a language. In that case providers are asked in
            /// parallel and the results are merged. A failing provider (rejected promise or exception) will
            /// not cause a failure of the whole operation.
            /// </summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A type definition provider.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            abstract registerTypeDefinitionProvider: selector: DocumentSelector * provider: TypeDefinitionProvider -> Disposable
            /// <summary>
            /// Register a declaration provider.
            ///
            /// Multiple providers can be registered for a language. In that case providers are asked in
            /// parallel and the results are merged. A failing provider (rejected promise or exception) will
            /// not cause a failure of the whole operation.
            /// </summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A declaration provider.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            abstract registerDeclarationProvider: selector: DocumentSelector * provider: DeclarationProvider -> Disposable
            /// <summary>
            /// Register a hover provider.
            ///
            /// Multiple providers can be registered for a language. In that case providers are asked in
            /// parallel and the results are merged. A failing provider (rejected promise or exception) will
            /// not cause a failure of the whole operation.
            /// </summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A hover provider.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            abstract registerHoverProvider: selector: DocumentSelector * provider: HoverProvider -> Disposable
            /// <summary>
            /// Register a provider that locates evaluatable expressions in text documents.
            /// The editor will evaluate the expression in the active debug session and will show the result in the debug hover.
            ///
            /// If multiple providers are registered for a language an arbitrary provider will be used.
            /// </summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">An evaluatable expression provider.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            abstract registerEvaluatableExpressionProvider: selector: DocumentSelector * provider: EvaluatableExpressionProvider -> Disposable
            /// <summary>
            /// Register a provider that returns data for the debugger's 'inline value' feature.
            /// Whenever the generic debugger has stopped in a source file, providers registered for the language of the file
            /// are called to return textual data that will be shown in the editor at the end of lines.
            ///
            /// Multiple providers can be registered for a language. In that case providers are asked in
            /// parallel and the results are merged. A failing provider (rejected promise or exception) will
            /// not cause a failure of the whole operation.
            /// </summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">An inline values provider.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            abstract registerInlineValuesProvider: selector: DocumentSelector * provider: InlineValuesProvider -> Disposable
            /// <summary>
            /// Register a document highlight provider.
            ///
            /// Multiple providers can be registered for a language. In that case providers are sorted
            /// by their <see cref="languages.match">score</see> and groups sequentially asked for document highlights.
            /// The process stops when a provider returns a <c>non-falsy</c> or <c>non-failure</c> result.
            /// </summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A document highlight provider.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            abstract registerDocumentHighlightProvider: selector: DocumentSelector * provider: DocumentHighlightProvider -> Disposable
            /// <summary>
            /// Register a document symbol provider.
            ///
            /// Multiple providers can be registered for a language. In that case providers are asked in
            /// parallel and the results are merged. A failing provider (rejected promise or exception) will
            /// not cause a failure of the whole operation.
            /// </summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A document symbol provider.</param>
            /// <param name="metaData">metadata about the provider</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            abstract registerDocumentSymbolProvider: selector: DocumentSelector * provider: DocumentSymbolProvider * ?metaData: DocumentSymbolProviderMetadata -> Disposable
            /// <summary>
            /// Register a workspace symbol provider.
            ///
            /// Multiple providers can be registered. In that case providers are asked in parallel and
            /// the results are merged. A failing provider (rejected promise or exception) will not cause
            /// a failure of the whole operation.
            /// </summary>
            /// <param name="provider">A workspace symbol provider.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            abstract registerWorkspaceSymbolProvider: provider: WorkspaceSymbolProvider -> Disposable
            /// <summary>
            /// Register a reference provider.
            ///
            /// Multiple providers can be registered for a language. In that case providers are asked in
            /// parallel and the results are merged. A failing provider (rejected promise or exception) will
            /// not cause a failure of the whole operation.
            /// </summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A reference provider.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            abstract registerReferenceProvider: selector: DocumentSelector * provider: ReferenceProvider -> Disposable
            /// <summary>
            /// Register a rename provider.
            ///
            /// Multiple providers can be registered for a language. In that case providers are sorted
            /// by their <see cref="languages.match">score</see> and asked in sequence. The first provider producing a result
            /// defines the result of the whole operation.
            /// </summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A rename provider.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            abstract registerRenameProvider: selector: DocumentSelector * provider: RenameProvider -> Disposable
            /// <summary>
            /// Register a semantic tokens provider for a whole document.
            ///
            /// Multiple providers can be registered for a language. In that case providers are sorted
            /// by their <see cref="languages.match">score</see> and the best-matching provider is used. Failure
            /// of the selected provider will cause a failure of the whole operation.
            /// </summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A document semantic tokens provider.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            abstract registerDocumentSemanticTokensProvider: selector: DocumentSelector * provider: DocumentSemanticTokensProvider * legend: SemanticTokensLegend -> Disposable
            /// <summary>
            /// Register a semantic tokens provider for a document range.
            ///
            /// *Note:* If a document has both a <c>DocumentSemanticTokensProvider</c> and a <c>DocumentRangeSemanticTokensProvider</c>,
            /// the range provider will be invoked only initially, for the time in which the full document provider takes
            /// to resolve the first request. Once the full document provider resolves the first request, the semantic tokens
            /// provided via the range provider will be discarded and from that point forward, only the document provider
            /// will be used.
            ///
            /// Multiple providers can be registered for a language. In that case providers are sorted
            /// by their <see cref="languages.match">score</see> and the best-matching provider is used. Failure
            /// of the selected provider will cause a failure of the whole operation.
            /// </summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A document range semantic tokens provider.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            abstract registerDocumentRangeSemanticTokensProvider: selector: DocumentSelector * provider: DocumentRangeSemanticTokensProvider * legend: SemanticTokensLegend -> Disposable
            /// <summary>
            /// Register a formatting provider for a document.
            ///
            /// Multiple providers can be registered for a language. In that case providers are sorted
            /// by their <see cref="languages.match">score</see> and the best-matching provider is used. Failure
            /// of the selected provider will cause a failure of the whole operation.
            /// </summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A document formatting edit provider.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            abstract registerDocumentFormattingEditProvider: selector: DocumentSelector * provider: DocumentFormattingEditProvider -> Disposable
            /// <summary>
            /// Register a formatting provider for a document range.
            ///
            /// *Note:* A document range provider is also a <see cref="DocumentFormattingEditProvider">document formatter</see>
            /// which means there is no need to <see cref="languages.registerDocumentFormattingEditProvider">register</see> a document
            /// formatter when also registering a range provider.
            ///
            /// Multiple providers can be registered for a language. In that case providers are sorted
            /// by their <see cref="languages.match">score</see> and the best-matching provider is used. Failure
            /// of the selected provider will cause a failure of the whole operation.
            /// </summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A document range formatting edit provider.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            abstract registerDocumentRangeFormattingEditProvider: selector: DocumentSelector * provider: DocumentRangeFormattingEditProvider -> Disposable
            /// <summary>
            /// Register a formatting provider that works on type. The provider is active when the user enables the setting <c>editor.formatOnType</c>.
            ///
            /// Multiple providers can be registered for a language. In that case providers are sorted
            /// by their <see cref="languages.match">score</see> and the best-matching provider is used. Failure
            /// of the selected provider will cause a failure of the whole operation.
            /// </summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">An on type formatting edit provider.</param>
            /// <param name="firstTriggerCharacter">A character on which formatting should be triggered, like <c>}</c>.</param>
            /// <param name="moreTriggerCharacter">More trigger characters.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            abstract registerOnTypeFormattingEditProvider: selector: DocumentSelector * provider: OnTypeFormattingEditProvider * firstTriggerCharacter: string * [<ParamArray>] moreTriggerCharacter: string[] -> Disposable
            /// <summary>
            /// Register a signature help provider.
            ///
            /// Multiple providers can be registered for a language. In that case providers are sorted
            /// by their <see cref="languages.match">score</see> and called sequentially until a provider returns a
            /// valid result.
            /// </summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A signature help provider.</param>
            /// <param name="triggerCharacters">Trigger signature help when the user types one of the characters, like <c>,</c> or <c>(</c>.</param>
            /// <param name="metadata">Information about the provider.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            abstract registerSignatureHelpProvider: selector: DocumentSelector * provider: SignatureHelpProvider * [<ParamArray>] triggerCharacters: string[] -> Disposable
            abstract registerSignatureHelpProvider: selector: DocumentSelector * provider: SignatureHelpProvider * metadata: SignatureHelpProviderMetadata -> Disposable
            /// <summary>
            /// Register a document link provider.
            ///
            /// Multiple providers can be registered for a language. In that case providers are asked in
            /// parallel and the results are merged. A failing provider (rejected promise or exception) will
            /// not cause a failure of the whole operation.
            /// </summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A document link provider.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            abstract registerDocumentLinkProvider: selector: DocumentSelector * provider: DocumentLinkProvider -> Disposable
            /// <summary>
            /// Register a color provider.
            ///
            /// Multiple providers can be registered for a language. In that case providers are asked in
            /// parallel and the results are merged. A failing provider (rejected promise or exception) will
            /// not cause a failure of the whole operation.
            /// </summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A color provider.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            abstract registerColorProvider: selector: DocumentSelector * provider: DocumentColorProvider -> Disposable
            /// <summary>
            /// Register a inlay hints provider.
            ///
            /// Multiple providers can be registered for a language. In that case providers are asked in
            /// parallel and the results are merged. A failing provider (rejected promise or exception) will
            /// not cause a failure of the whole operation.
            /// </summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">An inlay hints provider.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            abstract registerInlayHintsProvider: selector: DocumentSelector * provider: InlayHintsProvider -> Disposable
            /// <summary>
            /// Register a folding range provider.
            ///
            /// Multiple providers can be registered for a language. In that case providers are asked in
            /// parallel and the results are merged.
            /// If multiple folding ranges start at the same position, only the range of the first registered provider is used.
            /// If a folding range overlaps with an other range that has a smaller position, it is also ignored.
            ///
            /// A failing provider (rejected promise or exception) will
            /// not cause a failure of the whole operation.
            /// </summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A folding range provider.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            abstract registerFoldingRangeProvider: selector: DocumentSelector * provider: FoldingRangeProvider -> Disposable
            /// <summary>
            /// Register a selection range provider.
            ///
            /// Multiple providers can be registered for a language. In that case providers are asked in
            /// parallel and the results are merged. A failing provider (rejected promise or exception) will
            /// not cause a failure of the whole operation.
            /// </summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A selection range provider.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            abstract registerSelectionRangeProvider: selector: DocumentSelector * provider: SelectionRangeProvider -> Disposable
            /// <summary>Register a call hierarchy provider.</summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A call hierarchy provider.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            abstract registerCallHierarchyProvider: selector: DocumentSelector * provider: CallHierarchyProvider -> Disposable
            /// <summary>Register a type hierarchy provider.</summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A type hierarchy provider.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            abstract registerTypeHierarchyProvider: selector: DocumentSelector * provider: TypeHierarchyProvider -> Disposable
            /// <summary>
            /// Register a linked editing range provider.
            ///
            /// Multiple providers can be registered for a language. In that case providers are sorted
            /// by their <see cref="languages.match">score</see> and the best-matching provider that has a result is used. Failure
            /// of the selected provider will cause a failure of the whole operation.
            /// </summary>
            /// <param name="selector">A selector that defines the documents this provider is applicable to.</param>
            /// <param name="provider">A linked editing range provider.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            abstract registerLinkedEditingRangeProvider: selector: DocumentSelector * provider: LinkedEditingRangeProvider -> Disposable
            /// <summary>Set a <see cref="LanguageConfiguration">language configuration</see> for a language.</summary>
            /// <param name="language">A language identifier like <c>typescript</c>.</param>
            /// <param name="configuration">Language configuration.</param>
            /// <returns>A <see cref="Disposable" /> that unsets this configuration.</returns>
            abstract setLanguageConfiguration: language: string * configuration: LanguageConfiguration -> Disposable

    /// A notebook cell kind.
    type [<RequireQualifiedAccess>] NotebookCellKind =
        /// A markup-cell is formatted source that is used for display.
        | Markup = 1
        /// <summary>
        /// A code-cell is source that can be <see cref="NotebookController">executed</see> and that
        /// produces <see cref="NotebookCellOutput">output</see>.
        /// </summary>
        | Code = 2

    /// <summary>
    /// Represents a cell of a <see cref="NotebookDocument">notebook</see>, either a <see cref="NotebookCellKind.Code">code</see>-cell
    /// or <see cref="NotebookCellKind.Markup">markup</see>-cell.
    ///
    /// NotebookCell instances are immutable and are kept in sync for as long as they are part of their notebook.
    /// </summary>
    type [<AllowNullLiteral>] NotebookCell =
        /// <summary>
        /// The index of this cell in its <see cref="NotebookDocument.cellAt">containing notebook</see>. The
        /// index is updated when a cell is moved within its notebook. The index is <c>-1</c>
        /// when the cell has been removed from its notebook.
        /// </summary>
        abstract index: float
        /// <summary>The <see cref="NotebookDocument">notebook</see> that contains this cell.</summary>
        abstract notebook: NotebookDocument
        /// The kind of this cell.
        abstract kind: NotebookCellKind
        /// <summary>The <see cref="TextDocument">text</see> of this cell, represented as text document.</summary>
        abstract document: TextDocument
        /// The metadata of this cell. Can be anything but must be JSON-stringifyable.
        abstract metadata: NotebookCellMetadata
        /// The outputs of this cell.
        abstract outputs: ResizeArray<NotebookCellOutput>
        /// <summary>The most recent <see cref="NotebookCellExecutionSummary">execution summary</see> for this cell.</summary>
        abstract executionSummary: NotebookCellExecutionSummary option

    /// <summary>
    /// Represents a notebook editor that is attached to a <see cref="NotebookDocument">notebook</see>.
    /// Additional properties of the NotebookEditor are available in the proposed
    /// API, which will be finalized later.
    /// </summary>
    type [<AllowNullLiteral>] NotebookEditor =
        interface end

    /// <summary>Renderer messaging is used to communicate with a single renderer. It's returned from <see cref="notebooks.createRendererMessaging" />.</summary>
    type [<AllowNullLiteral>] NotebookRendererMessaging =
        /// An event that fires when a message is received from a renderer.
        abstract onDidReceiveMessage: Event<{| editor: NotebookEditor; message: obj option |}>
        /// <summary>Send a message to one or all renderer.</summary>
        /// <param name="message">Message to send</param>
        /// <param name="editor">
        /// Editor to target with the message. If not provided, the
        /// message is sent to all renderers.
        /// </param>
        /// <returns>
        /// a boolean indicating whether the message was successfully
        /// delivered to any renderer.
        /// </returns>
        abstract postMessage: message: obj option * ?editor: NotebookEditor -> Thenable<bool>

    /// <summary>
    /// Represents a notebook which itself is a sequence of <see cref="NotebookCell">code or markup cells</see>. Notebook documents are
    /// created from <see cref="NotebookData">notebook data</see>.
    /// </summary>
    type [<AllowNullLiteral>] NotebookDocument =
        /// <summary>
        /// The associated uri for this notebook.
        ///
        /// *Note* that most notebooks use the <c>file</c>-scheme, which means they are files on disk. However, **not** all notebooks are
        /// saved on disk and therefore the <c>scheme</c> must be checked before trying to access the underlying file or siblings on disk.
        /// </summary>
        /// <seealso cref="FileSystemProvider" />
        abstract uri: Uri
        /// The type of notebook.
        abstract notebookType: string
        /// The version number of this notebook (it will strictly increase after each
        /// change, including undo/redo).
        abstract version: float
        /// <summary><c>true</c> if there are unpersisted changes.</summary>
        abstract isDirty: bool
        /// Is this notebook representing an untitled file which has not been saved yet.
        abstract isUntitled: bool
        /// <summary>
        /// <c>true</c> if the notebook has been closed. A closed notebook isn't synchronized anymore
        /// and won't be re-used when the same resource is opened again.
        /// </summary>
        abstract isClosed: bool
        /// Arbitrary metadata for this notebook. Can be anything but must be JSON-stringifyable.
        abstract metadata: NotebookCellMetadata
        /// The number of cells in the notebook.
        abstract cellCount: float
        /// <summary>Return the cell at the specified index. The index will be adjusted to the notebook.</summary>
        /// <param name="index">The index of the cell to retrieve.</param>
        /// <returns>A <see cref="NotebookCell">cell</see>.</returns>
        abstract cellAt: index: float -> NotebookCell
        /// <summary>
        /// Get the cells of this notebook. A subset can be retrieved by providing
        /// a range. The range will be adjusted to the notebook.
        /// </summary>
        /// <param name="range">A notebook range.</param>
        /// <returns>The cells contained by the range or all cells.</returns>
        abstract getCells: ?range: NotebookRange -> ResizeArray<NotebookCell>
        /// <summary>Save the document. The saving will be handled by the corresponding <see cref="NotebookSerializer">serializer</see>.</summary>
        /// <returns>
        /// A promise that will resolve to true when the document
        /// has been saved. Will return false if the file was not dirty or when save failed.
        /// </returns>
        abstract save: unit -> Thenable<bool>

    /// The summary of a notebook cell execution.
    type [<AllowNullLiteral>] NotebookCellExecutionSummary =
        /// The order in which the execution happened.
        abstract executionOrder: float option
        /// If the execution finished successfully.
        abstract success: bool option
        /// The times at which execution started and ended, as unix timestamps
        abstract timing: {| startTime: float; endTime: float |} option

    /// A notebook range represents an ordered pair of two cell indices.
    /// It is guaranteed that start is less than or equal to end.
    type [<AllowNullLiteral>] NotebookRange =
        /// The zero-based start index of this range.
        abstract start: float
        /// The exclusive end index of this range (zero-based).
        abstract ``end``: float
        /// <summary><c>true</c> if <c>start</c> and <c>end</c> are equal.</summary>
        abstract isEmpty: bool
        /// <summary>Derive a new range for this range.</summary>
        /// <param name="change">An object that describes a change to this range.</param>
        /// <returns>
        /// A range that reflects the given change. Will return <c>this</c> range if the change
        /// is not changing anything.
        /// </returns>
        abstract ``with``: change: {| start: float option; ``end``: float option |} -> NotebookRange

    /// A notebook range represents an ordered pair of two cell indices.
    /// It is guaranteed that start is less than or equal to end.
    type [<AllowNullLiteral>] NotebookRangeStatic =
        /// <summary>
        /// Create a new notebook range. If <c>start</c> is not
        /// before or equal to <c>end</c>, the values will be swapped.
        /// </summary>
        /// <param name="start">start index</param>
        /// <param name="end">end index.</param>
        [<EmitConstructor>] abstract Create: start: float * ``end``: float -> NotebookRange

    /// <summary>One representation of a <see cref="NotebookCellOutput">notebook output</see>, defined by MIME type and data.</summary>
    type [<AllowNullLiteral>] NotebookCellOutputItem =
        /// The mime type which determines how the {@linkcode NotebookCellOutputItem.data data}-property
        /// is interpreted.
        ///
        /// Notebooks have built-in support for certain mime-types, extensions can add support for new
        /// types and override existing types.
        abstract mime: string with get, set
        /// The data of this output item. Must always be an array of unsigned 8-bit integers.
        abstract data: Uint8Array with get, set

    /// <summary>One representation of a <see cref="NotebookCellOutput">notebook output</see>, defined by MIME type and data.</summary>
    type [<AllowNullLiteral>] NotebookCellOutputItemStatic =
        /// <summary>
        /// Factory function to create a <c>NotebookCellOutputItem</c> from a string.
        ///
        /// *Note* that an UTF-8 encoder is used to create bytes for the string.
        /// </summary>
        /// <param name="value">A string.</param>
        /// <param name="mime">Optional MIME type, defaults to <c>text/plain</c>.</param>
        /// <returns>A new output item object.</returns>
        abstract text: value: string * ?mime: string -> NotebookCellOutputItem
        /// <summary>
        /// Factory function to create a <c>NotebookCellOutputItem</c> from
        /// a JSON object.
        ///
        /// *Note* that this function is not expecting "stringified JSON" but
        /// an object that can be stringified. This function will throw an error
        /// when the passed value cannot be JSON-stringified.
        /// </summary>
        /// <param name="value">A JSON-stringifyable value.</param>
        /// <param name="mime">Optional MIME type, defaults to <c>application/json</c></param>
        /// <returns>A new output item object.</returns>
        abstract json: value: obj option * ?mime: string -> NotebookCellOutputItem
        /// <summary>
        /// Factory function to create a <c>NotebookCellOutputItem</c> that uses
        /// uses the <c>application/vnd.code.notebook.stdout</c> mime type.
        /// </summary>
        /// <param name="value">A string.</param>
        /// <returns>A new output item object.</returns>
        abstract stdout: value: string -> NotebookCellOutputItem
        /// <summary>
        /// Factory function to create a <c>NotebookCellOutputItem</c> that uses
        /// uses the <c>application/vnd.code.notebook.stderr</c> mime type.
        /// </summary>
        /// <param name="value">A string.</param>
        /// <returns>A new output item object.</returns>
        abstract stderr: value: string -> NotebookCellOutputItem
        /// <summary>
        /// Factory function to create a <c>NotebookCellOutputItem</c> that uses
        /// uses the <c>application/vnd.code.notebook.error</c> mime type.
        /// </summary>
        /// <param name="value">An error object.</param>
        /// <returns>A new output item object.</returns>
        abstract error: value: Error -> NotebookCellOutputItem
        /// <summary>Create a new notebook cell output item.</summary>
        /// <param name="data">The value of the output item.</param>
        /// <param name="mime">The mime type of the output item.</param>
        [<EmitConstructor>] abstract Create: data: Uint8Array * mime: string -> NotebookCellOutputItem

    /// <summary>
    /// Notebook cell output represents a result of executing a cell. It is a container type for multiple
    /// <see cref="NotebookCellOutputItem">output items</see> where contained items represent the same result but
    /// use different MIME types.
    /// </summary>
    type [<AllowNullLiteral>] NotebookCellOutput =
        /// The output items of this output. Each item must represent the same result. _Note_ that repeated
        /// MIME types per output is invalid and that the editor will just pick one of them.
        ///
        /// <code lang="ts">
        /// new vscode.NotebookCellOutput([
        ///      vscode.NotebookCellOutputItem.text('Hello', 'text/plain'),
        ///      vscode.NotebookCellOutputItem.text('<i>Hello</i>', 'text/html'),
        ///      vscode.NotebookCellOutputItem.text('_Hello_', 'text/markdown'),
        ///      vscode.NotebookCellOutputItem.text('Hey', 'text/plain'), // INVALID: repeated type, editor will pick just one
        /// ])
        /// </code>
        abstract items: ResizeArray<NotebookCellOutputItem> with get, set
        /// Arbitrary metadata for this cell output. Can be anything but must be JSON-stringifyable.
        abstract metadata: NotebookCellMetadata option with get, set

    /// <summary>
    /// Notebook cell output represents a result of executing a cell. It is a container type for multiple
    /// <see cref="NotebookCellOutputItem">output items</see> where contained items represent the same result but
    /// use different MIME types.
    /// </summary>
    type [<AllowNullLiteral>] NotebookCellOutputStatic =
        /// <summary>Create new notebook output.</summary>
        /// <param name="items">Notebook output items.</param>
        /// <param name="metadata">Optional metadata.</param>
        [<EmitConstructor>] abstract Create: items: ResizeArray<NotebookCellOutputItem> * ?metadata: NotebookCellOutputStaticMetadata -> NotebookCellOutput

    /// <summary>
    /// Typescript interface contains an <see href="https://www.typescriptlang.org/docs/handbook/2/objects.html#index-signatures">index signature</see> (like <c>{ [key:string]: string }</c>).
    /// Unlike an indexer in F#, index signatures index over a type's members.
    ///
    /// As such an index signature cannot be implemented via regular F# Indexer (<c>Item</c> property),
    /// but instead by just specifying fields.
    ///
    /// Easiest way to declare such a type is with an Anonymous Record and force it into the function.
    /// For example:
    /// <code lang="fsharp">
    /// type I =
    ///     [&lt;EmitIndexer&gt;]
    ///     abstract Item: string -&gt; string
    /// let f (i: I) = jsNative
    ///
    /// let t = {| Value1 = "foo"; Value2 = "bar" |}
    /// f (!! t)
    /// </code>
    /// </summary>
    type [<AllowNullLiteral>] NotebookCellOutputStaticMetadata =
        [<EmitIndexer>] abstract Item: key: string -> obj option with get, set

    /// NotebookCellData is the raw representation of notebook cells. Its is part of {@linkcode NotebookData}.
    type [<AllowNullLiteral>] NotebookCellData =
        /// <summary>The <see cref="NotebookCellKind">kind</see> of this cell data.</summary>
        abstract kind: NotebookCellKind with get, set
        /// The source value of this cell data - either source code or formatted text.
        abstract value: string with get, set
        /// The language identifier of the source value of this cell data. Any value from
        /// {@linkcode languages.getLanguages getLanguages} is possible.
        abstract languageId: string with get, set
        /// The outputs of this cell data.
        abstract outputs: ResizeArray<NotebookCellOutput> option with get, set
        /// Arbitrary metadata of this cell data. Can be anything but must be JSON-stringifyable.
        abstract metadata: NotebookCellMetadata option with get, set
        /// The execution summary of this cell data.
        abstract executionSummary: NotebookCellExecutionSummary option with get, set

    /// NotebookCellData is the raw representation of notebook cells. Its is part of {@linkcode NotebookData}.
    type [<AllowNullLiteral>] NotebookCellDataStatic =
        /// <summary>
        /// Create new cell data. Minimal cell data specifies its kind, its source value, and the
        /// language identifier of its source.
        /// </summary>
        /// <param name="kind">The kind.</param>
        /// <param name="value">The source value.</param>
        /// <param name="languageId">The language identifier of the source value.</param>
        [<EmitConstructor>] abstract Create: kind: NotebookCellKind * value: string * languageId: string -> NotebookCellData

    /// <summary>
    /// Raw representation of a notebook.
    ///
    /// Extensions are responsible for creating {@linkcode NotebookData} so that the editor
    /// can create a {@linkcode NotebookDocument}.
    /// </summary>
    /// <seealso cref="NotebookSerializer" />
    type [<AllowNullLiteral>] NotebookData =
        /// The cell data of this notebook data.
        abstract cells: ResizeArray<NotebookCellData> with get, set
        /// Arbitrary metadata of notebook data.
        abstract metadata: NotebookCellMetadata option with get, set

    /// <summary>
    /// Raw representation of a notebook.
    ///
    /// Extensions are responsible for creating {@linkcode NotebookData} so that the editor
    /// can create a {@linkcode NotebookDocument}.
    /// </summary>
    /// <seealso cref="NotebookSerializer" />
    type [<AllowNullLiteral>] NotebookDataStatic =
        /// <summary>Create new notebook data.</summary>
        /// <param name="cells">An array of cell data.</param>
        [<EmitConstructor>] abstract Create: cells: ResizeArray<NotebookCellData> -> NotebookData

    /// <summary>
    /// The notebook serializer enables the editor to open notebook files.
    ///
    /// At its core the editor only knows a <see cref="NotebookData">notebook data structure</see> but not
    /// how that data structure is written to a file, nor how it is read from a file. The
    /// notebook serializer bridges this gap by deserializing bytes into notebook data and
    /// vice versa.
    /// </summary>
    type [<AllowNullLiteral>] NotebookSerializer =
        /// <summary>Deserialize contents of a notebook file into the notebook data structure.</summary>
        /// <param name="content">Contents of a notebook file.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>Notebook data or a thenable that resolves to such.</returns>
        abstract deserializeNotebook: content: Uint8Array * token: CancellationToken -> U2<NotebookData, Thenable<NotebookData>>
        /// <summary>Serialize notebook data into file contents.</summary>
        /// <param name="data">A notebook data structure.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>An array of bytes or a thenable that resolves to such.</returns>
        abstract serializeNotebook: data: NotebookData * token: CancellationToken -> U2<Uint8Array, Thenable<Uint8Array>>

    /// <summary>
    /// Notebook content options define what parts of a notebook are persisted. Note
    ///
    /// For instance, a notebook serializer can opt-out of saving outputs and in that case the editor doesn't mark a
    /// notebooks as <see cref="NotebookDocument.isDirty">dirty</see> when its output has changed.
    /// </summary>
    type [<AllowNullLiteral>] NotebookDocumentContentOptions =
        /// Controls if output change events will trigger notebook document content change events and
        /// if it will be used in the diff editor, defaults to false. If the content provider doesn't
        /// persist the outputs in the file document, this should be set to true.
        abstract transientOutputs: bool option with get, set
        /// Controls if a cell metadata property change event will trigger notebook document content
        /// change events and if it will be used in the diff editor, defaults to false. If the
        /// content provider doesn't persist a metadata property in the file document, it should be
        /// set to true.
        abstract transientCellMetadata: NotebookDocumentContentOptionsTransientCellMetadata option with get, set
        /// Controls if a document metadata property change event will trigger notebook document
        /// content change event and if it will be used in the diff editor, defaults to false. If the
        /// content provider doesn't persist a metadata property in the file document, it should be
        /// set to true.
        abstract transientDocumentMetadata: NotebookDocumentContentOptionsTransientCellMetadata option with get, set

    /// <summary>Notebook controller affinity for notebook documents.</summary>
    /// <seealso cref="NotebookController.updateNotebookAffinity" />
    type [<RequireQualifiedAccess>] NotebookControllerAffinity =
        /// Default affinity.
        | Default = 1
        /// A controller is preferred for a notebook.
        | Preferred = 2

    /// <summary>
    /// A notebook controller represents an entity that can execute notebook cells. This is often referred to as a kernel.
    ///
    /// There can be multiple controllers and the editor will let users choose which controller to use for a certain notebook. The
    /// {@linkcode NotebookController.notebookType notebookType}-property defines for what kind of notebooks a controller is for and
    /// the {@linkcode NotebookController.updateNotebookAffinity updateNotebookAffinity}-function allows controllers to set a preference
    /// for specific notebook documents. When a controller has been selected its
    /// <see cref="NotebookController.onDidChangeSelectedNotebooks">onDidChangeSelectedNotebooks</see>-event fires.
    ///
    /// When a cell is being run the editor will invoke the {@linkcode NotebookController.executeHandler executeHandler} and a controller
    /// is expected to create and finalize a <see cref="NotebookCellExecution">notebook cell execution</see>. However, controllers are also free
    /// to create executions by themselves.
    /// </summary>
    type [<AllowNullLiteral>] NotebookController =
        /// The identifier of this notebook controller.
        ///
        /// _Note_ that controllers are remembered by their identifier and that extensions should use
        /// stable identifiers across sessions.
        abstract id: string
        /// The notebook type this controller is for.
        abstract notebookType: string
        /// An array of language identifiers that are supported by this
        /// controller. Any language identifier from {@linkcode languages.getLanguages getLanguages}
        /// is possible. When falsy all languages are supported.
        ///
        /// Samples:
        /// <code lang="js">
        /// // support JavaScript and TypeScript
        /// myController.supportedLanguages = ['javascript', 'typescript']
        ///
        /// // support all languages
        /// myController.supportedLanguages = undefined; // falsy
        /// myController.supportedLanguages = []; // falsy
        /// </code>
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
        /// <summary>
        /// Create a cell execution task.
        ///
        /// _Note_ that there can only be one execution per cell at a time and that an error is thrown if
        /// a cell execution is created while another is still active.
        ///
        /// This should be used in response to the <see cref="NotebookController.executeHandler">execution handler</see>
        /// being called or when cell execution has been started else, e.g when a cell was already
        /// executing or when cell execution was triggered from another source.
        /// </summary>
        /// <param name="cell">The notebook cell for which to create the execution.</param>
        /// <returns>A notebook cell execution.</returns>
        abstract createNotebookCellExecution: cell: NotebookCell -> NotebookCellExecution
        /// <summary>
        /// The execute handler is invoked when the run gestures in the UI are selected, e.g Run Cell, Run All,
        /// Run Selection etc. The execute handler is responsible for creating and managing <see cref="NotebookCellExecution">execution</see>-objects.
        /// </summary>
        abstract executeHandler: (ResizeArray<NotebookCell> -> NotebookDocument -> NotebookController -> U2<unit, Thenable<unit>>) with get, set
        /// <summary>
        /// Optional interrupt handler.
        ///
        /// By default cell execution is canceled via <see cref="NotebookCellExecution.token">tokens</see>. Cancellation
        /// tokens require that a controller can keep track of its execution so that it can cancel a specific execution at a later
        /// point. Not all scenarios allow for that, eg. REPL-style controllers often work by interrupting whatever is currently
        /// running. For those cases the interrupt handler exists - it can be thought of as the equivalent of <c>SIGINT</c>
        /// or <c>Control+C</c> in terminals.
        ///
        /// _Note_ that supporting <see cref="NotebookCellExecution.token">cancellation tokens</see> is preferred and that interrupt handlers should
        /// only be used when tokens cannot be supported.
        /// </summary>
        abstract interruptHandler: (NotebookDocument -> U2<unit, Thenable<unit>>) option with get, set
        /// <summary>
        /// An event that fires whenever a controller has been selected or un-selected for a notebook document.
        ///
        /// There can be multiple controllers for a notebook and in that case a controllers needs to be _selected_. This is a user gesture
        /// and happens either explicitly or implicitly when interacting with a notebook for which a controller was _suggested_. When possible,
        /// the editor _suggests_ a controller that is most likely to be _selected_.
        ///
        /// _Note_ that controller selection is persisted (by the controllers <see cref="NotebookController.id">id</see>) and restored as soon as a
        /// controller is re-created or as a notebook is <see cref="workspace.onDidOpenNotebookDocument">opened</see>.
        /// </summary>
        abstract onDidChangeSelectedNotebooks: Event<{| notebook: NotebookDocument; selected: bool |}>
        /// <summary>
        /// A controller can set affinities for specific notebook documents. This allows a controller
        /// to be presented more prominent for some notebooks.
        /// </summary>
        /// <param name="notebook">The notebook for which a priority is set.</param>
        /// <param name="affinity">A controller affinity</param>
        abstract updateNotebookAffinity: notebook: NotebookDocument * affinity: NotebookControllerAffinity -> unit
        /// Dispose and free associated resources.
        abstract dispose: unit -> unit

    /// <summary>
    /// A NotebookCellExecution is how <see cref="NotebookController">notebook controller</see> modify a notebook cell as
    /// it is executing.
    ///
    /// When a cell execution object is created, the cell enters the {@linkcode NotebookCellExecutionState.Pending Pending} state.
    /// When {@linkcode NotebookCellExecution.start start(...)} is called on the execution task, it enters the {@linkcode NotebookCellExecutionState.Executing Executing} state. When
    /// {@linkcode NotebookCellExecution.end end(...)} is called, it enters the {@linkcode NotebookCellExecutionState.Idle Idle} state.
    /// </summary>
    type [<AllowNullLiteral>] NotebookCellExecution =
        /// <summary>The <see cref="NotebookCell">cell</see> for which this execution has been created.</summary>
        abstract cell: NotebookCell
        /// <summary>
        /// A cancellation token which will be triggered when the cell execution is canceled
        /// from the UI.
        ///
        /// _Note_ that the cancellation token will not be triggered when the <see cref="NotebookController">controller</see>
        /// that created this execution uses an <see cref="NotebookController.interruptHandler">interrupt-handler</see>.
        /// </summary>
        abstract token: CancellationToken
        /// Set and unset the order of this cell execution.
        abstract executionOrder: float option with get, set
        /// <summary>Signal that the execution has begun.</summary>
        /// <param name="startTime">
        /// The time that execution began, in milliseconds in the Unix epoch. Used to drive the clock
        /// that shows for how long a cell has been running. If not given, the clock won't be shown.
        /// </param>
        abstract start: ?startTime: float -> unit
        /// <summary>Signal that execution has ended.</summary>
        /// <param name="success">
        /// If true, a green check is shown on the cell status bar.
        /// If false, a red X is shown.
        /// If undefined, no check or X icon is shown.
        /// </param>
        /// <param name="endTime">The time that execution finished, in milliseconds in the Unix epoch.</param>
        abstract ``end``: success: bool option * ?endTime: float -> unit
        /// <summary>Clears the output of the cell that is executing or of another cell that is affected by this execution.</summary>
        /// <param name="cell">
        /// Cell for which output is cleared. Defaults to the <see cref="NotebookCellExecution.cell">cell</see> of
        /// this execution.
        /// </param>
        /// <returns>A thenable that resolves when the operation finished.</returns>
        abstract clearOutput: ?cell: NotebookCell -> Thenable<unit>
        /// <summary>Replace the output of the cell that is executing or of another cell that is affected by this execution.</summary>
        /// <param name="out">Output that replaces the current output.</param>
        /// <param name="cell">
        /// Cell for which output is cleared. Defaults to the <see cref="NotebookCellExecution.cell">cell</see> of
        /// this execution.
        /// </param>
        /// <returns>A thenable that resolves when the operation finished.</returns>
        abstract replaceOutput: out: U2<NotebookCellOutput, ResizeArray<NotebookCellOutput>> * ?cell: NotebookCell -> Thenable<unit>
        /// <summary>Append to the output of the cell that is executing or to another cell that is affected by this execution.</summary>
        /// <param name="out">Output that is appended to the current output.</param>
        /// <param name="cell">
        /// Cell for which output is cleared. Defaults to the <see cref="NotebookCellExecution.cell">cell</see> of
        /// this execution.
        /// </param>
        /// <returns>A thenable that resolves when the operation finished.</returns>
        abstract appendOutput: out: U2<NotebookCellOutput, ResizeArray<NotebookCellOutput>> * ?cell: NotebookCell -> Thenable<unit>
        /// <summary>Replace all output items of existing cell output.</summary>
        /// <param name="items">Output items that replace the items of existing output.</param>
        /// <param name="output">Output object that already exists.</param>
        /// <returns>A thenable that resolves when the operation finished.</returns>
        abstract replaceOutputItems: items: U2<NotebookCellOutputItem, ResizeArray<NotebookCellOutputItem>> * output: NotebookCellOutput -> Thenable<unit>
        /// <summary>Append output items to existing cell output.</summary>
        /// <param name="items">Output items that are append to existing output.</param>
        /// <param name="output">Output object that already exists.</param>
        /// <returns>A thenable that resolves when the operation finished.</returns>
        abstract appendOutputItems: items: U2<NotebookCellOutputItem, ResizeArray<NotebookCellOutputItem>> * output: NotebookCellOutput -> Thenable<unit>

    /// Represents the alignment of status bar items.
    type [<RequireQualifiedAccess>] NotebookCellStatusBarAlignment =
        /// Aligned to the left side.
        | Left = 1
        /// Aligned to the right side.
        | Right = 2

    /// A contribution to a cell's status bar
    type [<AllowNullLiteral>] NotebookCellStatusBarItem =
        /// The text to show for the item.
        abstract text: string with get, set
        /// Whether the item is aligned to the left or right.
        abstract alignment: NotebookCellStatusBarAlignment with get, set
        /// <summary>
        /// An optional {@linkcode Command} or identifier of a command to run on click.
        ///
        /// The command must be <see cref="commands.getCommands">known</see>.
        ///
        /// Note that if this is a {@linkcode Command} object, only the {@linkcode Command.command command} and {@linkcode Command.arguments arguments}
        /// are used by the editor.
        /// </summary>
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
        [<EmitConstructor>] abstract Create: text: string * alignment: NotebookCellStatusBarAlignment -> NotebookCellStatusBarItem

    /// A provider that can contribute items to the status bar that appears below a cell's editor.
    type [<AllowNullLiteral>] NotebookCellStatusBarItemProvider =
        /// An optional event to signal that statusbar items have changed. The provide method will be called again.
        abstract onDidChangeCellStatusBarItems: Event<unit> option with get, set
        /// <summary>The provider will be called when the cell scrolls into view, when its content, outputs, language, or metadata change, and when it changes execution state.</summary>
        /// <param name="cell">The cell for which to return items.</param>
        /// <param name="token">A token triggered if this request should be cancelled.</param>
        /// <returns>One or more <see cref="NotebookCellStatusBarItem">cell statusbar items</see></returns>
        abstract provideCellStatusBarItems: cell: NotebookCell * token: CancellationToken -> ProviderResult<U2<NotebookCellStatusBarItem, ResizeArray<NotebookCellStatusBarItem>>>

    /// <summary>
    /// Namespace for notebooks.
    ///
    /// The notebooks functionality is composed of three loosely coupled components:
    ///
    /// 1. <see cref="NotebookSerializer" /> enable the editor to open, show, and save notebooks
    /// 2. <see cref="NotebookController" /> own the execution of notebooks, e.g they create output from code cells.
    /// 3. NotebookRenderer present notebook output in the editor. They run in a separate context.
    /// </summary>
    module Notebooks =

        type [<AllowNullLiteral>] IExports =
            /// <summary>Creates a new notebook controller.</summary>
            /// <param name="id">Identifier of the controller. Must be unique per extension.</param>
            /// <param name="notebookType">A notebook type for which this controller is for.</param>
            /// <param name="label">The label of the controller.</param>
            /// <param name="handler">The execute-handler of the controller.</param>
            abstract createNotebookController: id: string * notebookType: string * label: string * ?handler: (ResizeArray<NotebookCell> -> NotebookDocument -> NotebookController -> U2<unit, Thenable<unit>>) -> NotebookController
            /// <summary>Register a <see cref="NotebookCellStatusBarItemProvider">cell statusbar item provider</see> for the given notebook type.</summary>
            /// <param name="notebookType">The notebook type to register for.</param>
            /// <param name="provider">A cell status bar provider.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            abstract registerNotebookCellStatusBarItemProvider: notebookType: string * provider: NotebookCellStatusBarItemProvider -> Disposable
            /// <summary>
            /// Creates a new messaging instance used to communicate with a specific renderer.
            ///
            /// * *Note 1:* Extensions can only create renderer that they have defined in their <c>package.json</c>-file
            /// * *Note 2:* A renderer only has access to messaging if <c>requiresMessaging</c> is set to <c>always</c> or <c>optional</c> in
            /// its <c>notebookRenderer</c> contribution.
            /// </summary>
            /// <param name="rendererId">The renderer ID to communicate with</param>
            /// <returns>A new notebook renderer messaging object.</returns>
            abstract createRendererMessaging: rendererId: string -> NotebookRendererMessaging

    /// Represents the input box in the Source Control viewlet.
    type [<AllowNullLiteral>] SourceControlInputBox =
        /// Setter and getter for the contents of the input box.
        abstract value: string with get, set
        /// A string to show as placeholder in the input box to guide the user.
        abstract placeholder: string with get, set
        /// <summary>Controls whether the input box is visible (default is <c>true</c>).</summary>
        abstract visible: bool with get, set

    type [<AllowNullLiteral>] QuickDiffProvider =
        /// <summary>Provide a <see cref="Uri" /> to the original resource of any given resource uri.</summary>
        /// <param name="uri">The uri of the resource open in a text editor.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>A thenable that resolves to uri of the matching original resource.</returns>
        abstract provideOriginalResource: uri: Uri * token: CancellationToken -> ProviderResult<Uri>

    /// <summary>
    /// The theme-aware decorations for a
    /// <see cref="SourceControlResourceState">source control resource state</see>.
    /// </summary>
    type [<AllowNullLiteral>] SourceControlResourceThemableDecorations =
        /// <summary>
        /// The icon path for a specific
        /// <see cref="SourceControlResourceState">source control resource state</see>.
        /// </summary>
        abstract iconPath: U3<string, Uri, ThemeIcon> option

    /// <summary>
    /// The decorations for a <see cref="SourceControlResourceState">source control resource state</see>.
    /// Can be independently specified for light and dark themes.
    /// </summary>
    type [<AllowNullLiteral>] SourceControlResourceDecorations =
        inherit SourceControlResourceThemableDecorations
        /// <summary>
        /// Whether the <see cref="SourceControlResourceState">source control resource state</see> should
        /// be striked-through in the UI.
        /// </summary>
        abstract strikeThrough: bool option
        /// <summary>
        /// Whether the <see cref="SourceControlResourceState">source control resource state</see> should
        /// be faded in the UI.
        /// </summary>
        abstract faded: bool option
        /// <summary>
        /// The title for a specific
        /// <see cref="SourceControlResourceState">source control resource state</see>.
        /// </summary>
        abstract tooltip: string option
        /// The light theme decorations.
        abstract light: SourceControlResourceThemableDecorations option
        /// The dark theme decorations.
        abstract dark: SourceControlResourceThemableDecorations option

    /// <summary>
    /// An source control resource state represents the state of an underlying workspace
    /// resource within a certain <see cref="SourceControlResourceGroup">source control group</see>.
    /// </summary>
    type [<AllowNullLiteral>] SourceControlResourceState =
        /// <summary>The <see cref="Uri" /> of the underlying resource inside the workspace.</summary>
        abstract resourceUri: Uri
        /// <summary>
        /// The <see cref="Command" /> which should be run when the resource
        /// state is open in the Source Control viewlet.
        /// </summary>
        abstract command: Command option
        /// <summary>
        /// The <see cref="SourceControlResourceDecorations">decorations</see> for this source control
        /// resource state.
        /// </summary>
        abstract decorations: SourceControlResourceDecorations option
        /// <summary>
        /// Context value of the resource state. This can be used to contribute resource specific actions.
        /// For example, if a resource is given a context value as <c>diffable</c>. When contributing actions to <c>scm/resourceState/context</c>
        /// using <c>menus</c> extension point, you can specify context value for key <c>scmResourceState</c> in <c>when</c> expressions, like <c>scmResourceState == diffable</c>.
        /// <code lang="json">
        /// "contributes": {
        ///    "menus": {
        ///      "scm/resourceState/context": [
        ///        {
        ///          "command": "extension.diff",
        ///          "when": "scmResourceState == diffable"
        ///        }
        ///      ]
        ///    }
        /// }
        /// </code>
        /// This will show action <c>extension.diff</c> only for resources with <c>contextValue</c> is <c>diffable</c>.
        /// </summary>
        abstract contextValue: string option

    /// <summary>
    /// A source control resource group is a collection of
    /// <see cref="SourceControlResourceState">source control resource states</see>.
    /// </summary>
    type [<AllowNullLiteral>] SourceControlResourceGroup =
        /// The id of this source control resource group.
        abstract id: string
        /// The label of this source control resource group.
        abstract label: string with get, set
        /// <summary>
        /// Whether this source control resource group is hidden when it contains
        /// no <see cref="SourceControlResourceState">source control resource states</see>.
        /// </summary>
        abstract hideWhenEmpty: bool option with get, set
        /// <summary>
        /// This group's collection of
        /// <see cref="SourceControlResourceState">source control resource states</see>.
        /// </summary>
        abstract resourceStates: ResizeArray<SourceControlResourceState> with get, set
        /// Dispose this source control resource group.
        abstract dispose: unit -> unit

    /// <summary>
    /// An source control is able to provide <see cref="SourceControlResourceState">resource states</see>
    /// to the editor and interact with the editor in several source control related ways.
    /// </summary>
    type [<AllowNullLiteral>] SourceControl =
        /// The id of this source control.
        abstract id: string
        /// The human-readable label of this source control.
        abstract label: string
        /// The (optional) Uri of the root of this source control.
        abstract rootUri: Uri option
        /// <summary>The <see cref="SourceControlInputBox">input box</see> for this source control.</summary>
        abstract inputBox: SourceControlInputBox
        /// <summary>
        /// The UI-visible count of <see cref="SourceControlResourceState">resource states</see> of
        /// this source control.
        ///
        /// If undefined, this source control will
        /// - display its UI-visible count as zero, and
        /// - contribute the count of its <see cref="SourceControlResourceState">resource states</see> to the UI-visible aggregated count for all source controls
        /// </summary>
        abstract count: float option with get, set
        /// <summary>An optional <see cref="QuickDiffProvider">quick diff provider</see>.</summary>
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
        /// <summary>Create a new <see cref="SourceControlResourceGroup">resource group</see>.</summary>
        abstract createResourceGroup: id: string * label: string -> SourceControlResourceGroup
        /// Dispose this source control.
        abstract dispose: unit -> unit

    module Scm =

        type [<AllowNullLiteral>] IExports =
            /// <summary>
            /// The <see cref="SourceControlInputBox">input box</see> for the last source control
            /// created by the extension.
            /// </summary>
            [<Obsolete("Use SourceControl.inputBox instead")>]
            abstract inputBox: SourceControlInputBox
            /// <summary>Creates a new <see cref="SourceControl">source control</see> instance.</summary>
            /// <param name="id">An <c>id</c> for the source control. Something short, e.g.: <c>git</c>.</param>
            /// <param name="label">A human-readable string for the source control. E.g.: <c>Git</c>.</param>
            /// <param name="rootUri">An optional Uri of the root of the source control. E.g.: <c>Uri.parse(workspaceRoot)</c>.</param>
            /// <returns>An instance of <see cref="SourceControl">source control</see>.</returns>
            abstract createSourceControl: id: string * label: string * ?rootUri: Uri -> SourceControl

    /// <summary>A DebugProtocolMessage is an opaque stand-in type for the <see href="https://microsoft.github.io/debug-adapter-protocol/specification#Base_Protocol_ProtocolMessage">ProtocolMessage</see> type defined in the Debug Adapter Protocol.</summary>
    type [<AllowNullLiteral>] DebugProtocolMessage =
        interface end

    /// <summary>A DebugProtocolSource is an opaque stand-in type for the <see href="https://microsoft.github.io/debug-adapter-protocol/specification#Types_Source">Source</see> type defined in the Debug Adapter Protocol.</summary>
    type [<AllowNullLiteral>] DebugProtocolSource =
        interface end

    /// <summary>A DebugProtocolBreakpoint is an opaque stand-in type for the <see href="https://microsoft.github.io/debug-adapter-protocol/specification#Types_Breakpoint">Breakpoint</see> type defined in the Debug Adapter Protocol.</summary>
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
        [<EmitIndexer>] abstract Item: key: string -> obj option with get, set

    /// A debug session.
    type [<AllowNullLiteral>] DebugSession =
        /// The unique ID of this debug session.
        abstract id: string
        /// <summary>The debug session's type from the <see cref="DebugConfiguration">debug configuration</see>.</summary>
        abstract ``type``: string
        /// <summary>The parent session of this debug session, if it was created as a child.</summary>
        /// <seealso cref="DebugSessionOptions.parentSession" />
        abstract parentSession: DebugSession option
        /// <summary>
        /// The debug session's name is initially taken from the <see cref="DebugConfiguration">debug configuration</see>.
        /// Any changes will be properly reflected in the UI.
        /// </summary>
        abstract name: string with get, set
        /// <summary>The workspace folder of this session or <c>undefined</c> for a folderless setup.</summary>
        abstract workspaceFolder: WorkspaceFolder option
        /// <summary>
        /// The "resolved" <see cref="DebugConfiguration">debug configuration</see> of this session.
        /// "Resolved" means that
        /// - all variables have been substituted and
        /// - platform specific attribute sections have been "flattened" for the matching platform and removed for non-matching platforms.
        /// </summary>
        abstract configuration: DebugConfiguration
        /// Send a custom request to the debug adapter.
        abstract customRequest: command: string * ?args: obj -> Thenable<obj option>
        /// <summary>
        /// Maps a breakpoint in the editor to the corresponding Debug Adapter Protocol (DAP) breakpoint that is managed by the debug adapter of the debug session.
        /// If no DAP breakpoint exists (either because the editor breakpoint was not yet registered or because the debug adapter is not interested in the breakpoint), the value <c>undefined</c> is returned.
        /// </summary>
        /// <param name="breakpoint">A <see cref="Breakpoint" /> in the editor.</param>
        /// <returns>A promise that resolves to the Debug Adapter Protocol breakpoint or <c>undefined</c>.</returns>
        abstract getDebugProtocolBreakpoint: breakpoint: Breakpoint -> Thenable<DebugProtocolBreakpoint option>

    /// <summary>A custom Debug Adapter Protocol event received from a <see cref="DebugSession">debug session</see>.</summary>
    type [<AllowNullLiteral>] DebugSessionCustomEvent =
        /// <summary>The <see cref="DebugSession">debug session</see> for which the custom event was received.</summary>
        abstract session: DebugSession
        /// Type of event.
        abstract ``event``: string
        /// Event specific information.
        abstract body: obj option

    /// <summary>
    /// A debug configuration provider allows to add debug configurations to the debug service
    /// and to resolve launch configurations before they are used to start a debug session.
    /// A debug configuration provider is registered via <see cref="debug.registerDebugConfigurationProvider" />.
    /// </summary>
    type [<AllowNullLiteral>] DebugConfigurationProvider =
        /// <summary>
        /// Provides <see cref="DebugConfiguration">debug configuration</see> to the debug service. If more than one debug configuration provider is
        /// registered for the same type, debug configurations are concatenated in arbitrary order.
        /// </summary>
        /// <param name="folder">The workspace folder for which the configurations are used or <c>undefined</c> for a folderless setup.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>An array of <see cref="DebugConfiguration">debug configurations</see>.</returns>
        abstract provideDebugConfigurations: folder: WorkspaceFolder option * ?token: CancellationToken -> ProviderResult<ResizeArray<DebugConfiguration>>
        /// <summary>
        /// Resolves a <see cref="DebugConfiguration">debug configuration</see> by filling in missing values or by adding/changing/removing attributes.
        /// If more than one debug configuration provider is registered for the same type, the resolveDebugConfiguration calls are chained
        /// in arbitrary order and the initial debug configuration is piped through the chain.
        /// Returning the value 'undefined' prevents the debug session from starting.
        /// Returning the value 'null' prevents the debug session from starting and opens the underlying debug configuration instead.
        /// </summary>
        /// <param name="folder">The workspace folder from which the configuration originates from or <c>undefined</c> for a folderless setup.</param>
        /// <param name="debugConfiguration">The <see cref="DebugConfiguration">debug configuration</see> to resolve.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>The resolved debug configuration or undefined or null.</returns>
        abstract resolveDebugConfiguration: folder: WorkspaceFolder option * debugConfiguration: DebugConfiguration * ?token: CancellationToken -> ProviderResult<DebugConfiguration>
        /// <summary>
        /// This hook is directly called after 'resolveDebugConfiguration' but with all variables substituted.
        /// It can be used to resolve or verify a <see cref="DebugConfiguration">debug configuration</see> by filling in missing values or by adding/changing/removing attributes.
        /// If more than one debug configuration provider is registered for the same type, the 'resolveDebugConfigurationWithSubstitutedVariables' calls are chained
        /// in arbitrary order and the initial debug configuration is piped through the chain.
        /// Returning the value 'undefined' prevents the debug session from starting.
        /// Returning the value 'null' prevents the debug session from starting and opens the underlying debug configuration instead.
        /// </summary>
        /// <param name="folder">The workspace folder from which the configuration originates from or <c>undefined</c> for a folderless setup.</param>
        /// <param name="debugConfiguration">The <see cref="DebugConfiguration">debug configuration</see> to resolve.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>The resolved debug configuration or undefined or null.</returns>
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
        [<EmitConstructor>] abstract Create: command: string * ?args: ResizeArray<string> * ?options: DebugAdapterExecutableOptions -> DebugAdapterExecutable

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
        [<EmitConstructor>] abstract Create: port: float * ?host: string -> DebugAdapterServer

    /// Represents a debug adapter running as a Named Pipe (on Windows)/UNIX Domain Socket (on non-Windows) based server.
    type [<AllowNullLiteral>] DebugAdapterNamedPipeServer =
        /// The path to the NamedPipe/UNIX Domain Socket.
        abstract path: string

    /// Represents a debug adapter running as a Named Pipe (on Windows)/UNIX Domain Socket (on non-Windows) based server.
    type [<AllowNullLiteral>] DebugAdapterNamedPipeServerStatic =
        /// Create a description for a debug adapter running as a Named Pipe (on Windows)/UNIX Domain Socket (on non-Windows) based server.
        [<EmitConstructor>] abstract Create: path: string -> DebugAdapterNamedPipeServer

    /// A debug adapter that implements the Debug Adapter Protocol can be registered with the editor if it implements the DebugAdapter interface.
    type [<AllowNullLiteral>] DebugAdapter =
        inherit Disposable
        /// An event which fires after the debug adapter has sent a Debug Adapter Protocol message to the editor.
        /// Messages can be requests, responses, or events.
        abstract onDidSendMessage: Event<DebugProtocolMessage>
        /// <summary>
        /// Handle a Debug Adapter Protocol message.
        /// Messages can be requests, responses, or events.
        /// Results or errors are returned via onSendMessage events.
        /// </summary>
        /// <param name="message">A Debug Adapter Protocol message</param>
        abstract handleMessage: message: DebugProtocolMessage -> unit

    /// A debug adapter descriptor for an inline implementation.
    type [<AllowNullLiteral>] DebugAdapterInlineImplementation =
        interface end

    /// A debug adapter descriptor for an inline implementation.
    type [<AllowNullLiteral>] DebugAdapterInlineImplementationStatic =
        /// Create a descriptor for an inline implementation of a debug adapter.
        [<EmitConstructor>] abstract Create: implementation: DebugAdapter -> DebugAdapterInlineImplementation

    type DebugAdapterDescriptor =
        U4<DebugAdapterExecutable, DebugAdapterServer, DebugAdapterNamedPipeServer, DebugAdapterInlineImplementation>

    type [<AllowNullLiteral>] DebugAdapterDescriptorFactory =
        /// <summary>
        /// 'createDebugAdapterDescriptor' is called at the start of a debug session to provide details about the debug adapter to use.
        /// These details must be returned as objects of type <see cref="DebugAdapterDescriptor" />.
        /// Currently two types of debug adapters are supported:
        /// - a debug adapter executable is specified as a command path and arguments (see <see cref="DebugAdapterExecutable" />),
        /// - a debug adapter server reachable via a communication port (see <see cref="DebugAdapterServer" />).
        /// If the method is not implemented the default behavior is this:
        ///    createDebugAdapter(session: DebugSession, executable: DebugAdapterExecutable) {
        ///       if (typeof session.configuration.debugServer === 'number') {
        ///          return new DebugAdapterServer(session.configuration.debugServer);
        ///       }
        ///       return executable;
        ///    }
        /// </summary>
        /// <param name="session">The <see cref="DebugSession">debug session</see> for which the debug adapter will be used.</param>
        /// <param name="executable">The debug adapter's executable information as specified in the package.json (or undefined if no such information exists).</param>
        /// <returns>a <see cref="DebugAdapterDescriptor">debug adapter descriptor</see> or undefined.</returns>
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
        /// <summary>
        /// The method 'createDebugAdapterTracker' is called at the start of a debug session in order
        /// to return a "tracker" object that provides read-access to the communication between the editor and a debug adapter.
        /// </summary>
        /// <param name="session">The <see cref="DebugSession">debug session</see> for which the debug adapter tracker will be used.</param>
        /// <returns>A <see cref="DebugAdapterTracker">debug adapter tracker</see> or undefined.</returns>
        abstract createDebugAdapterTracker: session: DebugSession -> ProviderResult<DebugAdapterTracker>

    /// Represents the debug console.
    type [<AllowNullLiteral>] DebugConsole =
        /// <summary>Append the given value to the debug console.</summary>
        /// <param name="value">A string, falsy values will not be printed.</param>
        abstract append: value: string -> unit
        /// <summary>
        /// Append the given value and a line feed character
        /// to the debug console.
        /// </summary>
        /// <param name="value">A string, falsy values will be printed.</param>
        abstract appendLine: value: string -> unit

    /// <summary>An event describing the changes to the set of <see cref="Breakpoint">breakpoints</see>.</summary>
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
        [<EmitConstructor>] abstract Create: ?enabled: bool * ?condition: string * ?hitCondition: string * ?logMessage: string -> Breakpoint

    /// A breakpoint specified by a source location.
    type [<AllowNullLiteral>] SourceBreakpoint =
        inherit Breakpoint
        /// The source and line position of this breakpoint.
        abstract location: Location

    /// A breakpoint specified by a source location.
    type [<AllowNullLiteral>] SourceBreakpointStatic =
        /// Create a new breakpoint for a source location.
        [<EmitConstructor>] abstract Create: location: Location * ?enabled: bool * ?condition: string * ?hitCondition: string * ?logMessage: string -> SourceBreakpoint

    /// A breakpoint specified by a function name.
    type [<AllowNullLiteral>] FunctionBreakpoint =
        inherit Breakpoint
        /// The name of the function to which this breakpoint is attached.
        abstract functionName: string

    /// A breakpoint specified by a function name.
    type [<AllowNullLiteral>] FunctionBreakpointStatic =
        /// Create a new function breakpoint.
        [<EmitConstructor>] abstract Create: functionName: string * ?enabled: bool * ?condition: string * ?hitCondition: string * ?logMessage: string -> FunctionBreakpoint

    /// <summary>Debug console mode used by debug session, see <see cref="DebugSessionOptions">options</see>.</summary>
    type [<RequireQualifiedAccess>] DebugConsoleMode =
        /// Debug session should have a separate debug console.
        | Separate = 0
        /// Debug session should share debug console with its parent session.
        /// This value has no effect for sessions which do not have a parent session.
        | MergeWithParent = 1

    /// <summary>Options for <see cref="debug.startDebugging">starting a debug session</see>.</summary>
    type [<AllowNullLiteral>] DebugSessionOptions =
        /// When specified the newly created debug session is registered as a "child" session of this
        /// "parent" debug session.
        abstract parentSession: DebugSession option with get, set
        /// Controls whether lifecycle requests like 'restart' are sent to the newly created session or its parent session.
        /// By default (if the property is false or missing), lifecycle requests are sent to the new session.
        /// This property is ignored if the session has no parent session.
        abstract lifecycleManagedByParent: bool option with get, set
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

    /// <summary>
    /// A DebugConfigurationProviderTriggerKind specifies when the <c>provideDebugConfigurations</c> method of a <c>DebugConfigurationProvider</c> is triggered.
    /// Currently there are two situations: to provide the initial debug configurations for a newly created launch.json or
    /// to provide dynamically generated debug configurations when the user asks for them through the UI (e.g. via the "Select and Start Debugging" command).
    /// A trigger kind is used when registering a <c>DebugConfigurationProvider</c> with <see cref="debug.registerDebugConfigurationProvider" />.
    /// </summary>
    type [<RequireQualifiedAccess>] DebugConfigurationProviderTriggerKind =
        /// <summary><c>DebugConfigurationProvider.provideDebugConfigurations</c> is called to provide the initial debug configurations for a newly created launch.json.</summary>
        | Initial = 1
        /// <summary><c>DebugConfigurationProvider.provideDebugConfigurations</c> is called to provide dynamically generated debug configurations when the user asks for them through the UI (e.g. via the "Select and Start Debugging" command).</summary>
        | Dynamic = 2

    /// Namespace for debug functionality.
    module Debug =

        type [<AllowNullLiteral>] IExports =
            /// <summary>
            /// The currently active <see cref="DebugSession">debug session</see> or <c>undefined</c>. The active debug session is the one
            /// represented by the debug action floating window or the one currently shown in the drop down menu of the debug action floating window.
            /// If no debug session is active, the value is <c>undefined</c>.
            /// </summary>
            abstract activeDebugSession: DebugSession option with get, set
            /// <summary>
            /// The currently active <see cref="DebugConsole">debug console</see>.
            /// If no debug session is active, output sent to the debug console is not shown.
            /// </summary>
            abstract activeDebugConsole: DebugConsole with get, set
            /// List of breakpoints.
            abstract breakpoints: ResizeArray<Breakpoint> with get, set
            /// <summary>
            /// An <see cref="Event" /> which fires when the <see cref="debug.activeDebugSession">active debug session</see>
            /// has changed. *Note* that the event also fires when the active debug session changes
            /// to <c>undefined</c>.
            /// </summary>
            abstract onDidChangeActiveDebugSession: Event<DebugSession option>
            /// <summary>An <see cref="Event" /> which fires when a new <see cref="DebugSession">debug session</see> has been started.</summary>
            abstract onDidStartDebugSession: Event<DebugSession>
            /// <summary>An <see cref="Event" /> which fires when a custom DAP event is received from the <see cref="DebugSession">debug session</see>.</summary>
            abstract onDidReceiveDebugSessionCustomEvent: Event<DebugSessionCustomEvent>
            /// <summary>An <see cref="Event" /> which fires when a <see cref="DebugSession">debug session</see> has terminated.</summary>
            abstract onDidTerminateDebugSession: Event<DebugSession>
            /// <summary>An <see cref="Event" /> that is emitted when the set of breakpoints is added, removed, or changed.</summary>
            abstract onDidChangeBreakpoints: Event<BreakpointsChangeEvent>
            /// <summary>
            /// Register a <see cref="DebugConfigurationProvider">debug configuration provider</see> for a specific debug type.
            /// The optional <see cref="DebugConfigurationProviderTriggerKind">triggerKind</see> can be used to specify when the <c>provideDebugConfigurations</c> method of the provider is triggered.
            /// Currently two trigger kinds are possible: with the value <c>Initial</c> (or if no trigger kind argument is given) the <c>provideDebugConfigurations</c> method is used to provide the initial debug configurations to be copied into a newly created launch.json.
            /// With the trigger kind <c>Dynamic</c> the <c>provideDebugConfigurations</c> method is used to dynamically determine debug configurations to be presented to the user (in addition to the static configurations from the launch.json).
            /// Please note that the <c>triggerKind</c> argument only applies to the <c>provideDebugConfigurations</c> method: so the <c>resolveDebugConfiguration</c> methods are not affected at all.
            /// Registering a single provider with resolve methods for different trigger kinds, results in the same resolve methods called multiple times.
            /// More than one provider can be registered for the same type.
            /// </summary>
            /// <param name="debugType">The debug type for which the provider is registered.</param>
            /// <param name="provider">The <see cref="DebugConfigurationProvider">debug configuration provider</see> to register.</param>
            /// <param name="triggerKind">The <see cref="DebugConfigurationProviderTrigger">trigger</see> for which the 'provideDebugConfiguration' method of the provider is registered. If <c>triggerKind</c> is missing, the value <c>DebugConfigurationProviderTriggerKind.Initial</c> is assumed.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            abstract registerDebugConfigurationProvider: debugType: string * provider: DebugConfigurationProvider * ?triggerKind: DebugConfigurationProviderTriggerKind -> Disposable
            /// <summary>
            /// Register a <see cref="DebugAdapterDescriptorFactory">debug adapter descriptor factory</see> for a specific debug type.
            /// An extension is only allowed to register a DebugAdapterDescriptorFactory for the debug type(s) defined by the extension. Otherwise an error is thrown.
            /// Registering more than one DebugAdapterDescriptorFactory for a debug type results in an error.
            /// </summary>
            /// <param name="debugType">The debug type for which the factory is registered.</param>
            /// <param name="factory">The <see cref="DebugAdapterDescriptorFactory">debug adapter descriptor factory</see> to register.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this factory when being disposed.</returns>
            abstract registerDebugAdapterDescriptorFactory: debugType: string * factory: DebugAdapterDescriptorFactory -> Disposable
            /// <summary>Register a debug adapter tracker factory for the given debug type.</summary>
            /// <param name="debugType">The debug type for which the factory is registered or '*' for matching all debug types.</param>
            /// <param name="factory">The <see cref="DebugAdapterTrackerFactory">debug adapter tracker factory</see> to register.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this factory when being disposed.</returns>
            abstract registerDebugAdapterTrackerFactory: debugType: string * factory: DebugAdapterTrackerFactory -> Disposable
            /// <summary>
            /// Start debugging by using either a named launch or named compound configuration,
            /// or by directly passing a <see cref="DebugConfiguration" />.
            /// The named configurations are looked up in '.vscode/launch.json' found in the given folder.
            /// Before debugging starts, all unsaved files are saved and the launch configurations are brought up-to-date.
            /// Folder specific variables used in the configuration (e.g. '${workspaceFolder}') are resolved against the given folder.
            /// </summary>
            /// <param name="folder">The <see cref="WorkspaceFolder">workspace folder</see> for looking up named configurations and resolving variables or <c>undefined</c> for a non-folder setup.</param>
            /// <param name="nameOrConfiguration">Either the name of a debug or compound configuration or a <see cref="DebugConfiguration" /> object.</param>
            /// <param name="parentSessionOrOptions">Debug session options. When passed a parent <see cref="DebugSession">debug session</see>, assumes options with just this parent session.</param>
            /// <returns>A thenable that resolves when debugging could be successfully started.</returns>
            abstract startDebugging: folder: WorkspaceFolder option * nameOrConfiguration: U2<string, DebugConfiguration> * ?parentSessionOrOptions: U2<DebugSession, DebugSessionOptions> -> Thenable<bool>
            /// <summary>Stop the given debug session or stop all debug sessions if session is omitted.</summary>
            /// <param name="session">The <see cref="DebugSession">debug session</see> to stop; if omitted all sessions are stopped.</param>
            abstract stopDebugging: ?session: DebugSession -> Thenable<unit>
            /// <summary>Add breakpoints.</summary>
            /// <param name="breakpoints">The breakpoints to add.</param>
            abstract addBreakpoints: breakpoints: ResizeArray<Breakpoint> -> unit
            /// <summary>Remove breakpoints.</summary>
            /// <param name="breakpoints">The breakpoints to remove.</param>
            abstract removeBreakpoints: breakpoints: ResizeArray<Breakpoint> -> unit
            /// <summary>
            /// Converts a "Source" descriptor object received via the Debug Adapter Protocol into a Uri that can be used to load its contents.
            /// If the source descriptor is based on a path, a file Uri is returned.
            /// If the source descriptor uses a reference number, a specific debug Uri (scheme 'debug') is constructed that requires a corresponding ContentProvider and a running debug session
            ///
            /// If the "Source" descriptor has insufficient information for creating the Uri, an error is thrown.
            /// </summary>
            /// <param name="source">An object conforming to the <see href="https://microsoft.github.io/debug-adapter-protocol/specification#Types_Source">Source</see> type defined in the Debug Adapter Protocol.</param>
            /// <param name="session">An optional debug session that will be used when the source descriptor uses a reference number to load the contents from an active debug session.</param>
            /// <returns>A uri that can be used to load the contents of the source.</returns>
            abstract asDebugSourceUri: source: DebugProtocolSource * ?session: DebugSession -> Uri

    /// <summary>
    /// Namespace for dealing with installed extensions. Extensions are represented
    /// by an <see cref="Extension" />-interface which enables reflection on them.
    ///
    /// Extension writers can provide APIs to other extensions by returning their API public
    /// surface from the <c>activate</c>-call.
    ///
    /// <code lang="javascript">
    /// export function activate(context: vscode.ExtensionContext) {
    ///      let api = {
    ///          sum(a, b) {
    ///              return a + b;
    ///          },
    ///          mul(a, b) {
    ///              return a * b;
    ///          }
    ///      };
    ///      // 'export' public api-surface
    ///      return api;
    /// }
    /// </code>
    /// When depending on the API of another extension add an <c>extensionDependencies</c>-entry
    /// to <c>package.json</c>, and use the <see cref="extensions.getExtension">getExtension</see>-function
    /// and the <see cref="Extension.exports">exports</see>-property, like below:
    ///
    /// <code lang="javascript">
    /// let mathExt = extensions.getExtension('genius.math');
    /// let importedApi = mathExt.exports;
    ///
    /// console.log(importedApi.mul(42, 1));
    /// </code>
    /// </summary>
    module Extensions =

        type [<AllowNullLiteral>] IExports =
            /// <summary>Get an extension by its full identifier in the form of: <c>publisher.name</c>.</summary>
            /// <param name="extensionId">An extension identifier.</param>
            /// <returns>An extension or <c>undefined</c>.</returns>
            abstract getExtension: extensionId: string -> Extension<'T> option
            /// All extensions currently known to the system.
            abstract all: ResizeArray<Extension<obj option>>
            /// <summary>
            /// An event which fires when <c>extensions.all</c> changes. This can happen when extensions are
            /// installed, uninstalled, enabled or disabled.
            /// </summary>
            abstract onDidChange: Event<unit>

    /// <summary>Collapsible state of a <see cref="CommentThread">comment thread</see></summary>
    type [<RequireQualifiedAccess>] CommentThreadCollapsibleState =
        /// Determines an item is collapsed
        | Collapsed = 0
        /// Determines an item is expanded
        | Expanded = 1

    /// <summary>Comment mode of a <see cref="Comment" /></summary>
    type [<RequireQualifiedAccess>] CommentMode =
        /// Displays the comment editor
        | Editing = 0
        /// Displays the preview of the comment
        | Preview = 1

    /// <summary>A collection of <see cref="Comment">comments</see> representing a conversation at a particular range in a document.</summary>
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
        /// <summary>
        /// Context value of the comment thread. This can be used to contribute thread specific actions.
        /// For example, a comment thread is given a context value as <c>editable</c>. When contributing actions to <c>comments/commentThread/title</c>
        /// using <c>menus</c> extension point, you can specify context value for key <c>commentThread</c> in <c>when</c> expression like <c>commentThread == editable</c>.
        /// <code lang="json">
        /// "contributes": {
        ///    "menus": {
        ///      "comments/commentThread/title": [
        ///        {
        ///          "command": "extension.deleteCommentThread",
        ///          "when": "commentThread == editable"
        ///        }
        ///      ]
        ///    }
        /// }
        /// </code>
        /// This will show action <c>extension.deleteCommentThread</c> only for comment threads with <c>contextValue</c> is <c>editable</c>.
        /// </summary>
        abstract contextValue: string option with get, set
        /// <summary>The optional human-readable label describing the <see cref="CommentThread">Comment Thread</see></summary>
        abstract label: string option with get, set
        /// Dispose this comment thread.
        ///
        /// Once disposed, this comment thread will be removed from visible editors and Comment Panel when appropriate.
        abstract dispose: unit -> unit

    /// <summary>Author information of a <see cref="Comment" /></summary>
    type [<AllowNullLiteral>] CommentAuthorInformation =
        /// The display name of the author of the comment
        abstract name: string with get, set
        /// The optional icon path for the author
        abstract iconPath: Uri option with get, set

    /// <summary>Reactions of a <see cref="Comment" /></summary>
    type [<AllowNullLiteral>] CommentReaction =
        /// The human-readable label for the reaction
        abstract label: string
        /// Icon for the reaction shown in UI.
        abstract iconPath: U2<string, Uri>
        /// The number of users who have reacted to this reaction
        abstract count: float
        /// <summary>Whether the <see cref="CommentAuthorInformation">author</see> of the comment has reacted to this reaction</summary>
        abstract authorHasReacted: bool

    /// A comment is displayed within the editor or the Comments Panel, depending on how it is provided.
    type [<AllowNullLiteral>] Comment =
        /// The human-readable comment body
        abstract body: U2<string, MarkdownString> with get, set
        /// <summary><see cref="CommentMode">Comment mode</see> of the comment</summary>
        abstract mode: CommentMode with get, set
        /// <summary>The <see cref="CommentAuthorInformation">author information</see> of the comment</summary>
        abstract author: CommentAuthorInformation with get, set
        /// <summary>
        /// Context value of the comment. This can be used to contribute comment specific actions.
        /// For example, a comment is given a context value as <c>editable</c>. When contributing actions to <c>comments/comment/title</c>
        /// using <c>menus</c> extension point, you can specify context value for key <c>comment</c> in <c>when</c> expression like <c>comment == editable</c>.
        /// <code lang="json">
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
        /// </code>
        /// This will show action <c>extension.deleteComment</c> only for comments with <c>contextValue</c> is <c>editable</c>.
        /// </summary>
        abstract contextValue: string option with get, set
        /// <summary>Optional reactions of the <see cref="Comment" /></summary>
        abstract reactions: ResizeArray<CommentReaction> option with get, set
        /// <summary>
        /// Optional label describing the <see cref="Comment" />
        /// Label will be rendered next to authorName if exists.
        /// </summary>
        abstract label: string option with get, set
        /// Optional timestamp that will be displayed in comments.
        /// The date will be formatted according to the user's locale and settings.
        abstract timestamp: DateTime option with get, set

    /// <summary>Command argument for actions registered in <c>comments/commentThread/context</c>.</summary>
    type [<AllowNullLiteral>] CommentReply =
        /// <summary>The active <see cref="CommentThread">comment thread</see></summary>
        abstract thread: CommentThread with get, set
        /// The value in the comment editor
        abstract text: string with get, set

    /// <summary>Commenting range provider for a <see cref="CommentController">comment controller</see>.</summary>
    type [<AllowNullLiteral>] CommentingRangeProvider =
        /// Provide a list of ranges which allow new comment threads creation or null for a given document
        abstract provideCommentingRanges: document: TextDocument * token: CancellationToken -> ProviderResult<ResizeArray<Range>>

    /// <summary>Represents a <see cref="CommentController">comment controller</see>'s <see cref="CommentController.options">options</see>.</summary>
    type [<AllowNullLiteral>] CommentOptions =
        /// An optional string to show on the comment input box when it's collapsed.
        abstract prompt: string option with get, set
        /// An optional string to show as placeholder in the comment input box when it's focused.
        abstract placeHolder: string option with get, set

    /// <summary>
    /// A comment controller is able to provide <see cref="CommentThread">comments</see> support to the editor and
    /// provide users various ways to interact with comments.
    /// </summary>
    type [<AllowNullLiteral>] CommentController =
        /// The id of this comment controller.
        abstract id: string
        /// The human-readable label of this comment controller.
        abstract label: string
        /// Comment controller options
        abstract options: CommentOptions option with get, set
        /// <summary>
        /// Optional commenting range provider. Provide a list <see cref="Range">ranges</see> which support commenting to any given resource uri.
        ///
        /// If not provided, users can leave comments in any document opened in the editor.
        /// </summary>
        abstract commentingRangeProvider: CommentingRangeProvider option with get, set
        /// <summary>
        /// Create a <see cref="CommentThread">comment thread</see>. The comment thread will be displayed in visible text editors (if the resource matches)
        /// and Comments Panel once created.
        /// </summary>
        /// <param name="uri">The uri of the document the thread has been created on.</param>
        /// <param name="range">The range the comment thread is located within the document.</param>
        /// <param name="comments">The ordered comments of the thread.</param>
        abstract createCommentThread: uri: Uri * range: Range * comments: ResizeArray<Comment> -> CommentThread
        /// <summary>Optional reaction handler for creating and deleting reactions on a <see cref="Comment" />.</summary>
        abstract reactionHandler: (Comment -> CommentReaction -> Thenable<unit>) option with get, set
        /// <summary>
        /// Dispose this comment controller.
        ///
        /// Once disposed, all <see cref="CommentThread">comment threads</see> created by this comment controller will also be removed from the editor
        /// and Comments Panel.
        /// </summary>
        abstract dispose: unit -> unit

    module Comments =

        type [<AllowNullLiteral>] IExports =
            /// <summary>Creates a new <see cref="CommentController">comment controller</see> instance.</summary>
            /// <param name="id">An <c>id</c> for the comment controller.</param>
            /// <param name="label">A human-readable string for the comment controller.</param>
            /// <returns>An instance of <see cref="CommentController">comment controller</see>.</returns>
            abstract createCommentController: id: string * label: string -> CommentController

    /// Represents a session of a currently logged in user.
    type [<AllowNullLiteral>] AuthenticationSession =
        /// The identifier of the authentication session.
        abstract id: string
        /// The access token.
        abstract accessToken: string
        /// The account associated with the session.
        abstract account: AuthenticationSessionAccountInformation
        /// <summary>
        /// The permissions granted by the session's access token. Available scopes
        /// are defined by the <see cref="AuthenticationProvider" />.
        /// </summary>
        abstract scopes: ResizeArray<string>

    /// <summary>The information of an account associated with an <see cref="AuthenticationSession" />.</summary>
    type [<AllowNullLiteral>] AuthenticationSessionAccountInformation =
        /// The unique identifier of the account.
        abstract id: string
        /// The human-readable name of the account.
        abstract label: string

    /// <summary>Options to be used when getting an <see cref="AuthenticationSession" /> from an <see cref="AuthenticationProvider" />.</summary>
    type [<AllowNullLiteral>] AuthenticationGetSessionOptions =
        /// <summary>
        /// Whether the existing user session preference should be cleared.
        ///
        /// For authentication providers that support being signed into multiple accounts at once, the user will be
        /// prompted to select an account to use when <see cref="authentication.getSession">getSession</see> is called. This preference
        /// is remembered until <see cref="authentication.getSession">getSession</see> is called with this flag.
        ///
        /// Defaults to false.
        /// </summary>
        abstract clearSessionPreference: bool option with get, set
        /// <summary>
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
        ///
        /// Note: you cannot use this option with <see cref="AuthenticationGetSessionOptions.silent">silent</see>.
        /// </summary>
        abstract createIfNone: bool option with get, set
        /// Whether we should attempt to reauthenticate even if there is already a session available.
        ///
        /// If true, a modal dialog will be shown asking the user to sign in again. This is mostly used for scenarios
        /// where the token needs to be re minted because it has lost some authorization.
        ///
        /// Defaults to false.
        abstract forceNewSession: U2<bool, {| detail: string |}> option with get, set
        /// <summary>
        /// Whether we should show the indication to sign in in the Accounts menu.
        ///
        /// If false, the user will be shown a badge on the Accounts menu with an option to sign in for the extension.
        /// If true, no indication will be shown.
        ///
        /// Defaults to false.
        ///
        /// Note: you cannot use this option with any other options that prompt the user like <see cref="AuthenticationGetSessionOptions.createIfNone">createIfNone</see>.
        /// </summary>
        abstract silent: bool option with get, set

    /// <summary>Basic information about an <see cref="AuthenticationProvider" /></summary>
    type [<AllowNullLiteral>] AuthenticationProviderInformation =
        /// The unique identifier of the authentication provider.
        abstract id: string
        /// The human-readable name of the authentication provider.
        abstract label: string

    /// <summary>An <see cref="Event" /> which fires when an <see cref="AuthenticationSession" /> is added, removed, or changed.</summary>
    type [<AllowNullLiteral>] AuthenticationSessionsChangeEvent =
        /// <summary>The <see cref="AuthenticationProvider" /> that has had its sessions change.</summary>
        abstract provider: AuthenticationProviderInformation

    /// <summary>Options for creating an <see cref="AuthenticationProvider" />.</summary>
    type [<AllowNullLiteral>] AuthenticationProviderOptions =
        /// Whether it is possible to be signed into multiple accounts at once with this provider.
        /// If not specified, will default to false.
        abstract supportsMultipleAccounts: bool option

    /// <summary>An <see cref="Event" /> which fires when an <see cref="AuthenticationSession" /> is added, removed, or changed.</summary>
    type [<AllowNullLiteral>] AuthenticationProviderAuthenticationSessionsChangeEvent =
        /// <summary>The <see cref="AuthenticationSession">AuthenticationSessions</see> of the <see cref="AuthenticationProvider" /> that have been added.</summary>
        abstract added: ResizeArray<AuthenticationSession> option
        /// <summary>The <see cref="AuthenticationSession">AuthenticationSessions</see> of the <see cref="AuthenticationProvider" /> that have been removed.</summary>
        abstract removed: ResizeArray<AuthenticationSession> option
        /// <summary>
        /// The <see cref="AuthenticationSession">AuthenticationSessions</see> of the <see cref="AuthenticationProvider" /> that have been changed.
        /// A session changes when its data excluding the id are updated. An example of this is a session refresh that results in a new
        /// access token being set for the session.
        /// </summary>
        abstract changed: ResizeArray<AuthenticationSession> option

    /// A provider for performing authentication to a service.
    type [<AllowNullLiteral>] AuthenticationProvider =
        /// <summary>
        /// An <see cref="Event" /> which fires when the array of sessions has changed, or data
        /// within a session has changed.
        /// </summary>
        abstract onDidChangeSessions: Event<AuthenticationProviderAuthenticationSessionsChangeEvent>
        /// <summary>Get a list of sessions.</summary>
        /// <param name="scopes">
        /// An optional list of scopes. If provided, the sessions returned should match
        /// these permissions, otherwise all sessions should be returned.
        /// </param>
        /// <returns>A promise that resolves to an array of authentication sessions.</returns>
        abstract getSessions: ?scopes: ResizeArray<string> -> Thenable<ResizeArray<AuthenticationSession>>
        /// <summary>
        /// Prompts a user to login.
        ///
        /// If login is successful, the onDidChangeSessions event should be fired.
        ///
        /// If login fails, a rejected promise should be returned.
        ///
        /// If the provider has specified that it does not support multiple accounts,
        /// then this should never be called if there is already an existing session matching these
        /// scopes.
        /// </summary>
        /// <param name="scopes">A list of scopes, permissions, that the new session should be created with.</param>
        /// <returns>A promise that resolves to an authentication session.</returns>
        abstract createSession: scopes: ResizeArray<string> -> Thenable<AuthenticationSession>
        /// <summary>
        /// Removes the session corresponding to session id.
        ///
        /// If the removal is successful, the onDidChangeSessions event should be fired.
        ///
        /// If a session cannot be removed, the provider should reject with an error message.
        /// </summary>
        /// <param name="sessionId">The id of the session to remove.</param>
        abstract removeSession: sessionId: string -> Thenable<unit>

    /// Namespace for authentication.
    module Authentication =

        type [<AllowNullLiteral>] IExports =
            /// <summary>
            /// Get an authentication session matching the desired scopes. Rejects if a provider with providerId is not
            /// registered, or if the user does not consent to sharing authentication information with
            /// the extension. If there are multiple sessions with the same scopes, the user will be shown a
            /// quickpick to select which account they would like to use.
            ///
            /// Currently, there are only two authentication providers that are contributed from built in extensions
            /// to the editor that implement GitHub and Microsoft authentication: their providerId's are 'github' and 'microsoft'.
            /// </summary>
            /// <param name="providerId">The id of the provider to use</param>
            /// <param name="scopes">A list of scopes representing the permissions requested. These are dependent on the authentication provider</param>
            /// <param name="options">The <see cref="AuthenticationGetSessionOptions" /> to use</param>
            /// <returns>A thenable that resolves to an authentication session</returns>
            abstract getSession: providerId: string * scopes: ResizeArray<string> * options: obj -> Thenable<AuthenticationSession>
            /// <summary>
            /// Get an authentication session matching the desired scopes. Rejects if a provider with providerId is not
            /// registered, or if the user does not consent to sharing authentication information with
            /// the extension. If there are multiple sessions with the same scopes, the user will be shown a
            /// quickpick to select which account they would like to use.
            ///
            /// Currently, there are only two authentication providers that are contributed from built in extensions
            /// to the editor that implement GitHub and Microsoft authentication: their providerId's are 'github' and 'microsoft'.
            /// </summary>
            /// <param name="providerId">The id of the provider to use</param>
            /// <param name="scopes">A list of scopes representing the permissions requested. These are dependent on the authentication provider</param>
            /// <param name="options">The <see cref="AuthenticationGetSessionOptions" /> to use</param>
            /// <returns>A thenable that resolves to an authentication session if available, or undefined if there are no sessions</returns>
            abstract getSession: providerId: string * scopes: ResizeArray<string> * ?options: AuthenticationGetSessionOptions -> Thenable<AuthenticationSession option>
            /// <summary>
            /// An <see cref="Event" /> which fires when the authentication sessions of an authentication provider have
            /// been added, removed, or changed.
            /// </summary>
            abstract onDidChangeSessions: Event<AuthenticationSessionsChangeEvent>
            /// <summary>
            /// Register an authentication provider.
            ///
            /// There can only be one provider per id and an error is being thrown when an id
            /// has already been used by another provider. Ids are case-sensitive.
            /// </summary>
            /// <param name="id">The unique identifier of the provider.</param>
            /// <param name="label">The human-readable name of the provider.</param>
            /// <param name="provider">The authentication provider provider.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            abstract registerAuthenticationProvider: id: string * label: string * provider: AuthenticationProvider * ?options: AuthenticationProviderOptions -> Disposable

    /// <summary>
    /// Namespace for testing functionality. Tests are published by registering
    /// <see cref="TestController" /> instances, then adding <see cref="TestItem">TestItems</see>.
    /// Controllers may also describe how to run tests by creating one or more
    /// <see cref="TestRunProfile" /> instances.
    /// </summary>
    module Tests =

        type [<AllowNullLiteral>] IExports =
            /// <summary>Creates a new test controller.</summary>
            /// <param name="id">Identifier for the controller, must be globally unique.</param>
            /// <param name="label">A human-readable label for the controller.</param>
            /// <returns>An instance of the <see cref="TestController" />.</returns>
            abstract createTestController: id: string * label: string -> TestController

    /// <summary>The kind of executions that <see cref="TestRunProfile">TestRunProfiles</see> control.</summary>
    type [<RequireQualifiedAccess>] TestRunProfileKind =
        | Run = 1
        | Debug = 2
        | Coverage = 3

    /// <summary>
    /// Tags can be associated with <see cref="TestItem">TestItems</see> and
    /// <see cref="TestRunProfile">TestRunProfiles</see>. A profile with a tag can only
    /// execute tests that include that tag in their <see cref="TestItem.tags" /> array.
    /// </summary>
    type [<AllowNullLiteral>] TestTag =
        /// <summary>
        /// ID of the test tag. <c>TestTag</c> instances with the same ID are considered
        /// to be identical.
        /// </summary>
        abstract id: string

    /// <summary>
    /// Tags can be associated with <see cref="TestItem">TestItems</see> and
    /// <see cref="TestRunProfile">TestRunProfiles</see>. A profile with a tag can only
    /// execute tests that include that tag in their <see cref="TestItem.tags" /> array.
    /// </summary>
    type [<AllowNullLiteral>] TestTagStatic =
        /// <summary>Creates a new TestTag instance.</summary>
        /// <param name="id">ID of the test tag.</param>
        [<EmitConstructor>] abstract Create: id: string -> TestTag

    /// <summary>A TestRunProfile describes one way to execute tests in a <see cref="TestController" />.</summary>
    type [<AllowNullLiteral>] TestRunProfile =
        /// <summary>
        /// Label shown to the user in the UI.
        ///
        /// Note that the label has some significance if the user requests that
        /// tests be re-run in a certain way. For example, if tests were run
        /// normally and the user requests to re-run them in debug mode, the editor
        /// will attempt use a configuration with the same label of the <c>Debug</c>
        /// kind. If there is no such configuration, the default will be used.
        /// </summary>
        abstract label: string with get, set
        /// Configures what kind of execution this profile controls. If there
        /// are no profiles for a kind, it will not be available in the UI.
        abstract kind: TestRunProfileKind
        /// <summary>
        /// Controls whether this profile is the default action that will
        /// be taken when its kind is actioned. For example, if the user clicks
        /// the generic "run all" button, then the default profile for
        /// <see cref="TestRunProfileKind.Run" /> will be executed, although the
        /// user can configure this.
        /// </summary>
        abstract isDefault: bool with get, set
        /// <summary>
        /// Associated tag for the profile. If this is set, only <see cref="TestItem" />
        /// instances with the same tag will be eligible to execute in this profile.
        /// </summary>
        abstract tag: TestTag option with get, set
        /// If this method is present, a configuration gear will be present in the
        /// UI, and this method will be invoked when it's clicked. When called,
        /// you can take other editor actions, such as showing a quick pick or
        /// opening a configuration file.
        abstract configureHandler: (unit -> unit) option with get, set
        /// <summary>
        /// Handler called to start a test run. When invoked, the function should call
        /// <see cref="TestController.createTestRun" /> at least once, and all test runs
        /// associated with the request should be created before the function returns
        /// or the returned promise is resolved.
        /// </summary>
        /// <param name="request">Request information for the test run.</param>
        /// <param name="cancellationToken">
        /// Token that signals the used asked to abort the
        /// test run. If cancellation is requested on this token, all <see cref="TestRun" />
        /// instances associated with the request will be
        /// automatically cancelled as well.
        /// </param>
        abstract runHandler: (TestRunRequest -> CancellationToken -> U2<Thenable<unit>, unit>) with get, set
        /// Deletes the run profile.
        abstract dispose: unit -> unit

    /// <summary>
    /// Entry point to discover and execute tests. It contains <see cref="TestController.items" /> which
    /// are used to populate the editor UI, and is associated with
    /// <see cref="TestController.createRunProfile">run profiles</see> to allow
    /// for tests to be executed.
    /// </summary>
    type [<AllowNullLiteral>] TestController =
        /// <summary>
        /// The id of the controller passed in <see cref="vscode.tests.createTestController" />.
        /// This must be globally unique.
        /// </summary>
        abstract id: string
        /// Human-readable label for the test controller.
        abstract label: string with get, set
        /// <summary>
        /// A collection of "top-level" <see cref="TestItem" /> instances, which can in
        /// turn have their own <see cref="TestItem.children">children</see> to form the
        /// "test tree."
        ///
        /// The extension controls when to add tests. For example, extensions should
        /// add tests for a file when <see cref="vscode.workspace.onDidOpenTextDocument" />
        /// fires in order for decorations for tests within a file to be visible.
        ///
        /// However, the editor may sometimes explicitly request children using the
        /// <see cref="resolveHandler" /> See the documentation on that method for more details.
        /// </summary>
        abstract items: TestItemCollection
        /// <summary>
        /// Creates a profile used for running tests. Extensions must create
        /// at least one profile in order for tests to be run.
        /// </summary>
        /// <param name="label">A human-readable label for this profile.</param>
        /// <param name="kind">Configures what kind of execution this profile manages.</param>
        /// <param name="runHandler">Function called to start a test run.</param>
        /// <param name="isDefault">Whether this is the default action for its kind.</param>
        /// <param name="tag">Profile test tag.</param>
        /// <returns>
        /// An instance of a <see cref="TestRunProfile" />, which is automatically
        /// associated with this controller.
        /// </returns>
        abstract createRunProfile: label: string * kind: TestRunProfileKind * runHandler: (TestRunRequest -> CancellationToken -> U2<Thenable<unit>, unit>) * ?isDefault: bool * ?tag: TestTag -> TestRunProfile
        /// <summary>
        /// A function provided by the extension that the editor may call to request
        /// children of a test item, if the <see cref="TestItem.canResolveChildren" /> is
        /// <c>true</c>. When called, the item should discover children and call
        /// <see cref="vscode.tests.createTestItem" /> as children are discovered.
        ///
        /// Generally the extension manages the lifecycle of test items, but under
        /// certain conditions the editor may request the children of a specific
        /// item to be loaded. For example, if the user requests to re-run tests
        /// after reloading the editor, the editor may need to call this method
        /// to resolve the previously-run tests.
        ///
        /// The item in the explorer will automatically be marked as "busy" until
        /// the function returns or the returned thenable resolves.
        /// </summary>
        /// <param name="item">
        /// An unresolved test item for which children are being
        /// requested, or <c>undefined</c> to resolve the controller's initial <see cref="TestController.items">items</see>.
        /// </param>
        abstract resolveHandler: (TestItem option -> U2<Thenable<unit>, unit>) option with get, set
        /// <summary>
        /// If this method is present, a refresh button will be present in the
        /// UI, and this method will be invoked when it's clicked. When called,
        /// the extension should scan the workspace for any new, changed, or
        /// removed tests.
        ///
        /// It's recommended that extensions try to update tests in realtime, using
        /// a <see cref="FileSystemWatcher" /> for example, and use this method as a fallback.
        /// </summary>
        /// <returns>A thenable that resolves when tests have been refreshed.</returns>
        abstract refreshHandler: (CancellationToken -> U2<Thenable<unit>, unit>) option with get, set
        /// <summary>
        /// Creates a <see cref="TestRun" />. This should be called by the
        /// <see cref="TestRunProfile" /> when a request is made to execute tests, and may
        /// also be called if a test run is detected externally. Once created, tests
        /// that are included in the request will be moved into the queued state.
        ///
        /// All runs created using the same <c>request</c> instance will be grouped
        /// together. This is useful if, for example, a single suite of tests is
        /// run on multiple platforms.
        /// </summary>
        /// <param name="request">
        /// Test run request. Only tests inside the <c>include</c> may be
        /// modified, and tests in its <c>exclude</c> are ignored.
        /// </param>
        /// <param name="name">
        /// The human-readable name of the run. This can be used to
        /// disambiguate multiple sets of results in a test run. It is useful if
        /// tests are run across multiple platforms, for example.
        /// </param>
        /// <param name="persist">
        /// Whether the results created by the run should be
        /// persisted in the editor. This may be false if the results are coming from
        /// a file already saved externally, such as a coverage information file.
        /// </param>
        /// <returns>
        /// An instance of the <see cref="TestRun" />. It will be considered "running"
        /// from the moment this method is invoked until <see cref="TestRun.end" /> is called.
        /// </returns>
        abstract createTestRun: request: TestRunRequest * ?name: string * ?persist: bool -> TestRun
        /// <summary>
        /// Creates a new managed <see cref="TestItem" /> instance. It can be added into
        /// the <see cref="TestItem.children" /> of an existing item, or into the
        /// <see cref="TestController.items" />.
        /// </summary>
        /// <param name="id">
        /// Identifier for the TestItem. The test item's ID must be unique
        /// in the <see cref="TestItemCollection" /> it's added to.
        /// </param>
        /// <param name="label">Human-readable label of the test item.</param>
        /// <param name="uri">URI this TestItem is associated with. May be a file or directory.</param>
        abstract createTestItem: id: string * label: string * ?uri: Uri -> TestItem
        /// Unregisters the test controller, disposing of its associated tests
        /// and unpersisted results.
        abstract dispose: unit -> unit

    /// <summary>
    /// A TestRunRequest is a precursor to a <see cref="TestRun" />, which in turn is
    /// created by passing a request to <see cref="tests.runTests" />. The TestRunRequest
    /// contains information about which tests should be run, which should not be
    /// run, and how they are run (via the <see cref="TestRunRequest.profile">profile</see>).
    ///
    /// In general, TestRunRequests are created by the editor and pass to
    /// <see cref="TestRunProfile.runHandler" />, however you can also create test
    /// requests and runs outside of the <c>runHandler</c>.
    /// </summary>
    type [<AllowNullLiteral>] TestRunRequest =
        /// <summary>
        /// A filter for specific tests to run. If given, the extension should run
        /// all of the included tests and all their children, excluding any tests
        /// that appear in <see cref="TestRunRequest.exclude" />. If this property is
        /// undefined, then the extension should simply run all tests.
        ///
        /// The process of running tests should resolve the children of any test
        /// items who have not yet been resolved.
        /// </summary>
        abstract ``include``: ResizeArray<TestItem> option
        /// An array of tests the user has marked as excluded from the test included
        /// in this run; exclusions should apply after inclusions.
        ///
        /// May be omitted if no exclusions were requested. Test controllers should
        /// not run excluded tests or any children of excluded tests.
        abstract exclude: ResizeArray<TestItem> option
        /// The profile used for this request. This will always be defined
        /// for requests issued from the editor UI, though extensions may
        /// programmatically create requests not associated with any profile.
        abstract profile: TestRunProfile option

    /// <summary>
    /// A TestRunRequest is a precursor to a <see cref="TestRun" />, which in turn is
    /// created by passing a request to <see cref="tests.runTests" />. The TestRunRequest
    /// contains information about which tests should be run, which should not be
    /// run, and how they are run (via the <see cref="TestRunRequest.profile">profile</see>).
    ///
    /// In general, TestRunRequests are created by the editor and pass to
    /// <see cref="TestRunProfile.runHandler" />, however you can also create test
    /// requests and runs outside of the <c>runHandler</c>.
    /// </summary>
    type [<AllowNullLiteral>] TestRunRequestStatic =
        /// <param name="include">Array of specific tests to run, or undefined to run all tests</param>
        /// <param name="exclude">An array of tests to exclude from the run.</param>
        /// <param name="profile">The run profile used for this request.</param>
        [<EmitConstructor>] abstract Create: ?``include``: ResizeArray<TestItem> * ?exclude: ResizeArray<TestItem> * ?profile: TestRunProfile -> TestRunRequest

    /// <summary>Options given to <see cref="TestController.runTests" /></summary>
    type [<AllowNullLiteral>] TestRun =
        /// The human-readable name of the run. This can be used to
        /// disambiguate multiple sets of results in a test run. It is useful if
        /// tests are run across multiple platforms, for example.
        abstract name: string option
        /// A cancellation token which will be triggered when the test run is
        /// canceled from the UI.
        abstract token: CancellationToken
        /// Whether the test run will be persisted across reloads by the editor.
        abstract isPersisted: bool
        /// <summary>Indicates a test is queued for later execution.</summary>
        /// <param name="test">Test item to update.</param>
        abstract enqueued: test: TestItem -> unit
        /// <summary>Indicates a test has started running.</summary>
        /// <param name="test">Test item to update.</param>
        abstract started: test: TestItem -> unit
        /// <summary>Indicates a test has been skipped.</summary>
        /// <param name="test">Test item to update.</param>
        abstract skipped: test: TestItem -> unit
        /// <summary>
        /// Indicates a test has failed. You should pass one or more
        /// <see cref="TestMessage">TestMessages</see> to describe the failure.
        /// </summary>
        /// <param name="test">Test item to update.</param>
        /// <param name="message">Messages associated with the test failure.</param>
        /// <param name="duration">How long the test took to execute, in milliseconds.</param>
        abstract failed: test: TestItem * message: U2<TestMessage, ResizeArray<TestMessage>> * ?duration: float -> unit
        /// <summary>
        /// Indicates a test has errored. You should pass one or more
        /// <see cref="TestMessage">TestMessages</see> to describe the failure. This differs
        /// from the "failed" state in that it indicates a test that couldn't be
        /// executed at all, from a compilation error for example.
        /// </summary>
        /// <param name="test">Test item to update.</param>
        /// <param name="message">Messages associated with the test failure.</param>
        /// <param name="duration">How long the test took to execute, in milliseconds.</param>
        abstract errored: test: TestItem * message: U2<TestMessage, ResizeArray<TestMessage>> * ?duration: float -> unit
        /// <summary>Indicates a test has passed.</summary>
        /// <param name="test">Test item to update.</param>
        /// <param name="duration">How long the test took to execute, in milliseconds.</param>
        abstract passed: test: TestItem * ?duration: float -> unit
        /// <summary>
        /// Appends raw output from the test runner. On the user's request, the
        /// output will be displayed in a terminal. ANSI escape sequences,
        /// such as colors and text styles, are supported.
        /// </summary>
        /// <param name="output">Output text to append.</param>
        /// <param name="location">
        /// Indicate that the output was logged at the given
        /// location.
        /// </param>
        /// <param name="test">Test item to associate the output with.</param>
        abstract appendOutput: output: string * ?location: Location * ?test: TestItem -> unit
        /// Signals that the end of the test run. Any tests included in the run whose
        /// states have not been updated will have their state reset.
        abstract ``end``: unit -> unit

    /// <summary>
    /// Collection of test items, found in <see cref="TestItem.children" /> and
    /// <see cref="TestController.items" />.
    /// </summary>
    type [<AllowNullLiteral>] TestItemCollection =
        /// Gets the number of items in the collection.
        abstract size: float
        /// <summary>Replaces the items stored by the collection.</summary>
        /// <param name="items">Items to store.</param>
        abstract replace: items: ResizeArray<TestItem> -> unit
        /// <summary>Iterate over each entry in this collection.</summary>
        /// <param name="callback">Function to execute for each entry.</param>
        /// <param name="thisArg">The <c>this</c> context used when invoking the handler function.</param>
        abstract forEach: callback: (TestItem -> TestItemCollection -> obj) * ?thisArg: obj -> unit
        /// <summary>
        /// Adds the test item to the children. If an item with the same ID already
        /// exists, it'll be replaced.
        /// </summary>
        /// <param name="item">Item to add.</param>
        abstract add: item: TestItem -> unit
        /// <summary>Removes a single test item from the collection.</summary>
        /// <param name="itemId">Item ID to delete.</param>
        abstract delete: itemId: string -> unit
        /// <summary>Efficiently gets a test item by ID, if it exists, in the children.</summary>
        /// <param name="itemId">Item ID to get.</param>
        /// <returns>The found item or undefined if it does not exist.</returns>
        abstract get: itemId: string -> TestItem option

    /// <summary>
    /// An item shown in the "test explorer" view.
    ///
    /// A <c>TestItem</c> can represent either a test suite or a test itself, since
    /// they both have similar capabilities.
    /// </summary>
    type [<AllowNullLiteral>] TestItem =
        /// <summary>
        /// Identifier for the <c>TestItem</c>. This is used to correlate
        /// test results and tests in the document with those in the workspace
        /// (test explorer). This cannot change for the lifetime of the <c>TestItem</c>,
        /// and must be unique among its parent's direct children.
        /// </summary>
        abstract id: string
        /// <summary>URI this <c>TestItem</c> is associated with. May be a file or directory.</summary>
        abstract uri: Uri option
        /// The children of this test item. For a test suite, this may contain the
        /// individual test cases or nested suites.
        abstract children: TestItemCollection
        /// <summary>
        /// The parent of this item. It's set automatically, and is undefined
        /// top-level items in the <see cref="TestController.items" /> and for items that
        /// aren't yet included in another item's <see cref="TestItem.children">children</see>.
        /// </summary>
        abstract parent: TestItem option
        /// <summary>
        /// Tags associated with this test item. May be used in combination with
        /// <see cref="TestRunProfile.tags" />, or simply as an organizational feature.
        /// </summary>
        abstract tags: ResizeArray<TestTag> with get, set
        /// <summary>
        /// Indicates whether this test item may have children discovered by resolving.
        ///
        /// If true, this item is shown as expandable in the Test Explorer view and
        /// expanding the item will cause <see cref="TestController.resolveHandler" />
        /// to be invoked with the item.
        ///
        /// Default to <c>false</c>.
        /// </summary>
        abstract canResolveChildren: bool with get, set
        /// <summary>
        /// Controls whether the item is shown as "busy" in the Test Explorer view.
        /// This is useful for showing status while discovering children.
        ///
        /// Defaults to <c>false</c>.
        /// </summary>
        abstract busy: bool with get, set
        /// Display name describing the test case.
        abstract label: string with get, set
        /// Optional description that appears next to the label.
        abstract description: string option with get, set
        /// <summary>
        /// A string that should be used when comparing this item
        /// with other items. When <c>falsy</c> the <see cref="TestItem.label">label</see>
        /// is used.
        /// </summary>
        abstract sortText: string option with get, set
        /// <summary>
        /// Location of the test item in its <see cref="TestItem.uri">uri</see>.
        ///
        /// This is only meaningful if the <c>uri</c> points to a file.
        /// </summary>
        abstract range: Range option with get, set
        /// Optional error encountered while loading the test.
        ///
        /// Note that this is not a test result and should only be used to represent errors in
        /// test discovery, such as syntax errors.
        abstract error: U2<string, MarkdownString> option with get, set

    /// Message associated with the test state. Can be linked to a specific
    /// source range -- useful for assertion failures, for example.
    type [<AllowNullLiteral>] TestMessage =
        /// Human-readable message text to display.
        abstract message: U2<string, MarkdownString> with get, set
        /// <summary>Expected test output. If given with <see cref="TestMessage.actualOutput">actualOutput </see>, a diff view will be shown.</summary>
        abstract expectedOutput: string option with get, set
        /// <summary>Actual test output. If given with <see cref="TestMessage.expectedOutput">expectedOutput </see>, a diff view will be shown.</summary>
        abstract actualOutput: string option with get, set
        /// Associated file location.
        abstract location: Location option with get, set

    /// Message associated with the test state. Can be linked to a specific
    /// source range -- useful for assertion failures, for example.
    type [<AllowNullLiteral>] TestMessageStatic =
        /// <summary>Creates a new TestMessage that will present as a diff in the editor.</summary>
        /// <param name="message">Message to display to the user.</param>
        /// <param name="expected">Expected output.</param>
        /// <param name="actual">Actual output.</param>
        abstract diff: message: U2<string, MarkdownString> * expected: string * actual: string -> TestMessage
        /// <summary>Creates a new TestMessage instance.</summary>
        /// <param name="message">The message to show to the user.</param>
        [<EmitConstructor>] abstract Create: message: U2<string, MarkdownString> -> TestMessage

    type [<AllowNullLiteral>] OpenDialogOptionsFilters =
        [<EmitIndexer>] abstract Item: name: string -> ResizeArray<string> with get, set

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

    type [<AllowNullLiteral>] ProcessExecutionOptionsEnv =
        [<EmitIndexer>] abstract Item: key: string -> string with get, set

    type [<AllowNullLiteral>] TerminalOptionsEnv =
        [<EmitIndexer>] abstract Item: key: string -> string option with get, set

    type [<AllowNullLiteral>] NotebookCellMetadata =
        [<EmitIndexer>] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] NotebookDocumentContentOptionsTransientCellMetadata =
        [<EmitIndexer>] abstract Item: key: string -> bool option with get, set

/// Thenable is a common denominator between ES6 promises, Q, jquery.Deferred, WinJS.Promise,
/// and others. This API makes no assumption about what promise library is being used which
/// enables reusing existing code without migrating to a specific promise implementation. Still,
/// we recommend the use of native promises which are available in this editor.
type [<AllowNullLiteral>] Thenable<'T> =
    /// <summary>Attaches callbacks for the resolution and/or rejection of the Promise.</summary>
    /// <param name="onfulfilled">The callback to execute when the Promise is resolved.</param>
    /// <param name="onrejected">The callback to execute when the Promise is rejected.</param>
    /// <returns>A Promise for the completion of which ever callback is executed.</returns>
    abstract ``then``: ?onfulfilled: ('T -> U2<'TResult, Thenable<'TResult>>) * ?onrejected: (obj option -> U2<'TResult, Thenable<'TResult>>) -> Thenable<'TResult>
    abstract ``then``: ?onfulfilled: ('T -> U2<'TResult, Thenable<'TResult>>) * ?onrejected: (obj option -> unit) -> Thenable<'TResult>
