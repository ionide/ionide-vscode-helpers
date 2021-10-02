// ts2fable 0.8.0-build.616
module rec Fable.Import.VSCode.Proposed

#nowarn "3390" // disable warnings for invalid XML comments
#nowarn "0044" // disable warnings for `Obsolete` usage

open System
open Fable.Core
open Fable.Core.JS
open Fable.Import.VSCode.Vscode

type Error = System.Exception
type ReadonlyArray<'T> = System.Collections.Generic.IReadOnlyList<'T>
type RegExp = System.Text.RegularExpressions.Regex

/// <summary>
/// This is the place for API experiments and proposals.
/// These API are NOT stable and subject to change. They are only available in the Insiders
/// distribution and CANNOT be used in published extensions.
/// 
/// To test these API in local environment:
/// - Use Insiders release of 'VS Code'.
/// - Add <c>"enableProposedApi": true</c> to your package.json.
/// - Copy this file to your project.
/// </summary>
let [<Import("*","vscode")>] vscode: Vscode.IExports = jsNative

/// <summary>
/// This is the place for API experiments and proposals.
/// These API are NOT stable and subject to change. They are only available in the Insiders
/// distribution and CANNOT be used in published extensions.
/// 
/// To test these API in local environment:
/// - Use Insiders release of 'VS Code'.
/// - Add <c>"enableProposedApi": true</c> to your package.json.
/// - Copy this file to your project.
/// </summary>
module Vscode =
    let [<Import("authentication","vscode")>] authentication: Authentication.IExports = jsNative
    let [<Import("workspace","vscode")>] workspace: Workspace.IExports = jsNative
    let [<Import("env","vscode")>] env: Env.IExports = jsNative
    /// Be aware that this API will not ever be finalized.
    let [<Import("window","vscode")>] window: Window.IExports = jsNative
    let [<Import("commands","vscode")>] commands: Commands.IExports = jsNative
    let [<Import("notebooks","vscode")>] notebooks: Notebooks.IExports = jsNative
    let [<Import("languages","vscode")>] languages: Languages.IExports = jsNative
    let [<Import("tests","vscode")>] tests: Tests.IExports = jsNative

    type [<AllowNullLiteral>] IExports =
        abstract ResolvedAuthority: ResolvedAuthorityStatic
        abstract RemoteAuthorityResolverError: RemoteAuthorityResolverErrorStatic
        /// Represents a script that is loaded into the notebook renderer before rendering output. This allows
        /// to provide and share functionality for notebook markup and notebook output renderers.
        abstract NotebookRendererScript: NotebookRendererScriptStatic
        abstract TimelineItem: TimelineItemStatic
        /// Inlay hint information.
        abstract InlayHint: InlayHintStatic
        abstract PortAttributes: PortAttributesStatic
        abstract InlineCompletionList: InlineCompletionListStatic
        abstract InlineCompletionItem: InlineCompletionItemStatic
        /// A class that contains information about a covered resource. A count can
        /// be give for lines, branches, and functions in a file.
        abstract CoveredCount: CoveredCountStatic
        /// Contains coverage metadata for a file.
        abstract FileCoverage: FileCoverageStatic
        /// Contains coverage information for a single statement or line.
        abstract StatementCoverage: StatementCoverageStatic
        /// <summary>Contains coverage information for a branch of a <see cref="StatementCoverage" />.</summary>
        abstract BranchCoverage: BranchCoverageStatic
        /// Contains coverage information for a function or method.
        abstract FunctionCoverage: FunctionCoverageStatic

    type [<AllowNullLiteral>] MessageOptions =
        /// Do not render a native message box.
        abstract useCustom: bool option with get, set

    type [<AllowNullLiteral>] RemoteAuthorityResolverContext =
        abstract resolveAttempt: float with get, set

    type [<AllowNullLiteral>] ResolvedAuthority =
        abstract host: string
        abstract port: float
        abstract connectionToken: string option

    type [<AllowNullLiteral>] ResolvedAuthorityStatic =
        [<EmitConstructor>] abstract Create: host: string * port: float * ?connectionToken: string -> ResolvedAuthority

    type [<AllowNullLiteral>] ResolvedOptions =
        abstract extensionHostEnv: ResolvedOptionsExtensionHostEnv option with get, set
        abstract isTrusted: bool option with get, set

    type [<AllowNullLiteral>] TunnelPrivacy =
        abstract themeIcon: string with get, set
        abstract id: string with get, set
        abstract label: string with get, set

    type [<AllowNullLiteral>] TunnelOptions =
        abstract remoteAddress: TunnelOptionsRemoteAddress with get, set
        abstract localAddressPort: float option with get, set
        abstract label: string option with get, set
        [<Obsolete("Use privacy instead")>]
        abstract ``public``: bool option with get, set
        abstract privacy: string option with get, set
        abstract protocol: string option with get, set

    type [<AllowNullLiteral>] TunnelDescription =
        abstract remoteAddress: TunnelOptionsRemoteAddress with get, set
        abstract localAddress: U2<TunnelOptionsRemoteAddress, string> with get, set
        [<Obsolete("Use privacy instead")>]
        abstract ``public``: bool option with get, set
        abstract privacy: string option with get, set
        abstract protocol: string option with get, set

    type [<AllowNullLiteral>] Tunnel =
        inherit TunnelDescription
        abstract onDidDispose: Event<unit> with get, set
        abstract dispose: unit -> U2<unit, Thenable<unit>>

    /// Used as part of the ResolverResult if the extension has any candidate,
    /// published, or forwarded ports.
    type [<AllowNullLiteral>] TunnelInformation =
        /// Tunnels that are detected by the extension. The remotePort is used for display purposes.
        /// The localAddress should be the complete local address (ex. localhost:1234) for connecting to the port. Tunnels provided through
        /// detected are read-only from the forwarded ports UI.
        abstract environmentTunnels: ResizeArray<TunnelDescription> option with get, set

    type [<AllowNullLiteral>] TunnelCreationOptions =
        /// True when the local operating system will require elevation to use the requested local port.
        abstract elevationRequired: bool option with get, set

    type [<RequireQualifiedAccess>] CandidatePortSource =
        | None = 0
        | Process = 1
        | Output = 2

    type [<AllowNullLiteral>] ResolverResult =
        interface end

    type [<ImportMember("vscode"); AllowNullLiteral; AbstractClass>] RemoteAuthorityResolverError =
        inherit Error

    type [<AllowNullLiteral>] RemoteAuthorityResolverErrorStatic =
        abstract NotAvailable: ?message: string * ?handled: bool -> RemoteAuthorityResolverError
        abstract TemporarilyNotAvailable: ?message: string -> RemoteAuthorityResolverError
        [<EmitConstructor>] abstract Create: ?message: string -> RemoteAuthorityResolverError

    type [<AllowNullLiteral>] RemoteAuthorityResolver =
        /// <summary>
        /// Resolve the authority part of the current opened <c>vscode-remote://</c> URI.
        /// 
        /// This method will be invoked once during the startup of the editor and again each time
        /// the editor detects a disconnection.
        /// </summary>
        /// <param name="authority">The authority part of the current opened <c>vscode-remote://</c> URI.</param>
        /// <param name="context">A context indicating if this is the first call or a subsequent call.</param>
        abstract resolve: authority: string * context: RemoteAuthorityResolverContext -> U2<ResolverResult, Thenable<ResolverResult>>
        /// <summary>Get the canonical URI (if applicable) for a <c>vscode-remote://</c> URI.</summary>
        /// <returns>The canonical URI or undefined if the uri is already canonical.</returns>
        abstract getCanonicalURI: uri: Uri -> ProviderResult<Uri>
        /// <summary>
        /// Can be optionally implemented if the extension can forward ports better than the core.
        /// When not implemented, the core will use its default forwarding logic.
        /// When implemented, the core will use this to forward ports.
        /// 
        /// To enable the "Change Local Port" action on forwarded ports, make sure to set the <c>localAddress</c> of
        /// the returned <c>Tunnel</c> to a <c>{ port: number, host: string; }</c> and not a string.
        /// </summary>
        abstract tunnelFactory: (TunnelOptions -> TunnelCreationOptions -> Thenable<Tunnel> option) option with get, set
        /// p
        /// Provides filtering for candidate ports.
        abstract showCandidatePort: (string -> float -> string -> Thenable<bool>) option with get, set
        /// Lets the resolver declare which tunnel factory features it supports.
        /// UNDER DISCUSSION! MAY CHANGE SOON.
        abstract tunnelFeatures: RemoteAuthorityResolverTunnelFeatures option with get, set
        abstract candidatePortSource: CandidatePortSource option with get, set

    /// <summary>More options to be used when getting an <see cref="AuthenticationSession" /> from an <see cref="AuthenticationProvider" />.</summary>
    type [<AllowNullLiteral>] AuthenticationGetSessionOptions =
        /// Whether we should attempt to reauthenticate even if there is already a session available.
        /// 
        /// If true, a modal dialog will be shown asking the user to sign in again. This is mostly used for scenarios
        /// where the token needs to be re minted because it has lost some authorization.
        /// 
        /// Defaults to false.
        abstract forceNewSession: U2<bool, AuthenticationGetSessionOptionsForceNewSession> option with get, set

    module Authentication =

        type [<AllowNullLiteral>] IExports =
            inherit Fable.Import.VSCode.Vscode.Authentication.IExports
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

    module Workspace =

        type [<AllowNullLiteral>] IExports =
            inherit Fable.Import.VSCode.Vscode.Workspace.IExports
            /// <summary>
            /// Forwards a port. If the current resolver implements RemoteAuthorityResolver:forwardPort then that will be used to make the tunnel.
            /// By default, openTunnel only support localhost; however, RemoteAuthorityResolver:tunnelFactory can be used to support other ips.
            /// </summary>
            /// <exception cref="">When run in an environment without a remote.</exception>
            /// <param name="tunnelOptions">The <c>localPort</c> is a suggestion only. If that port is not available another will be chosen.</param>
            abstract openTunnel: tunnelOptions: TunnelOptions -> Thenable<Tunnel>
            /// Gets an array of the currently available tunnels. This does not include environment tunnels, only tunnels that have been created by the user.
            /// Note that these are of type TunnelDescription and cannot be disposed.
            abstract tunnels: Thenable<ResizeArray<TunnelDescription>> with get, set
            /// Fired when the list of tunnels has changed.
            abstract onDidChangeTunnels: Event<unit>
            abstract registerRemoteAuthorityResolver: authorityPrefix: string * resolver: RemoteAuthorityResolver -> Disposable
            abstract registerResourceLabelFormatter: formatter: ResourceLabelFormatter -> Disposable
            /// <summary>
            /// Register a search provider.
            /// 
            /// Only one provider can be registered per scheme.
            /// </summary>
            /// <param name="scheme">The provider will be invoked for workspace folders that have this file scheme.</param>
            /// <param name="provider">The provider.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            abstract registerFileSearchProvider: scheme: string * provider: FileSearchProvider -> Disposable
            /// <summary>
            /// Register a text search provider.
            /// 
            /// Only one provider can be registered per scheme.
            /// </summary>
            /// <param name="scheme">The provider will be invoked for workspace folders that have this file scheme.</param>
            /// <param name="provider">The provider.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            abstract registerTextSearchProvider: scheme: string * provider: TextSearchProvider -> Disposable
            /// <summary>Search text in files across all <see cref="workspace.workspaceFolders">workspace folders</see> in the workspace.</summary>
            /// <param name="query">The query parameters for the search - the search string, whether it's case-sensitive, or a regex, or matches whole words.</param>
            /// <param name="callback">A callback, called for each result</param>
            /// <param name="token">A token that can be used to signal cancellation to the underlying search engine.</param>
            /// <returns>A thenable that resolves when the search is complete.</returns>
            abstract findTextInFiles: query: TextSearchQuery * callback: (TextSearchResult -> unit) * ?token: CancellationToken -> Thenable<TextSearchComplete>
            /// <summary>Search text in files across all <see cref="workspace.workspaceFolders">workspace folders</see> in the workspace.</summary>
            /// <param name="query">The query parameters for the search - the search string, whether it's case-sensitive, or a regex, or matches whole words.</param>
            /// <param name="options">An optional set of query options. Include and exclude patterns, maxResults, etc.</param>
            /// <param name="callback">A callback, called for each result</param>
            /// <param name="token">A token that can be used to signal cancellation to the underlying search engine.</param>
            /// <returns>A thenable that resolves when the search is complete.</returns>
            abstract findTextInFiles: query: TextSearchQuery * options: FindTextInFilesOptions * callback: (TextSearchResult -> unit) * ?token: CancellationToken -> Thenable<TextSearchComplete>
            abstract registerNotebookContentProvider: notebookType: string * provider: NotebookContentProvider * ?options: NotebookDocumentContentOptions -> Disposable
            abstract registerNotebookContentProvider: notebookType: string * provider: NotebookContentProvider * ?options: NotebookDocumentContentOptions * ?registrationData: NotebookRegistrationData -> Disposable
            abstract registerNotebookSerializer: notebookType: string * serializer: NotebookSerializer * ?options: NotebookDocumentContentOptions * ?registration: NotebookRegistrationData -> Disposable
            /// <summary>
            /// Register a timeline provider.
            /// 
            /// Multiple providers can be registered. In that case, providers are asked in
            /// parallel and the results are merged. A failing provider (rejected promise or exception) will
            /// not cause a failure of the whole operation.
            /// </summary>
            /// <param name="scheme">A scheme or schemes that defines which documents this provider is applicable to. Can be <c>*</c> to target all documents.</param>
            /// <param name="provider">A timeline provider.</param>
            /// <returns>A <see cref="Disposable" /> that unregisters this provider when being disposed.</returns>
            abstract registerTimelineProvider: scheme: U2<string, ResizeArray<string>> * provider: TimelineProvider -> Disposable
            /// <summary>Prompt the user to chose whether to trust the current workspace</summary>
            /// <param name="options">
            /// Optional object describing the properties of the
            /// workspace trust request.
            /// </param>
            abstract requestWorkspaceTrust: ?options: WorkspaceTrustRequestOptions -> Thenable<bool option>
            /// <summary>
            /// If your extension listens on ports, consider registering a PortAttributesProvider to provide information
            /// about the ports. For example, a debug extension may know about debug ports in it's debuggee. By providing
            /// this information with a PortAttributesProvider the extension can tell the editor that these ports should be
            /// ignored, since they don't need to be user facing.
            /// </summary>
            /// <param name="portSelector">
            /// If registerPortAttributesProvider is called after you start your process then you may already
            /// know the range of ports or the pid of your process. All properties of a the portSelector must be true for your
            /// provider to get called.
            /// The <c>portRange</c> is start inclusive and end exclusive.
            /// </param>
            /// <param name="provider">The PortAttributesProvider</param>
            abstract registerPortAttributesProvider: portSelector: RegisterPortAttributesProviderPortSelector * provider: PortAttributesProvider -> Disposable

        type [<AllowNullLiteral>] RegisterPortAttributesProviderPortSelector =
            abstract pid: float option with get, set
            abstract portRange: (float * float) option with get, set
            abstract commandMatcher: RegExp option with get, set

    type [<AllowNullLiteral>] ResourceLabelFormatter =
        abstract scheme: string with get, set
        abstract authority: string option with get, set
        abstract formatting: ResourceLabelFormatting with get, set

    type [<AllowNullLiteral>] ResourceLabelFormatting =
        abstract label: string with get, set
        abstract separator: ResourceLabelFormattingSeparator with get, set
        abstract tildify: bool option with get, set
        abstract normalizeDriveLetter: bool option with get, set
        abstract workspaceSuffix: string option with get, set
        abstract workspaceTooltip: string option with get, set
        abstract authorityPrefix: string option with get, set
        abstract stripPathStartingSeparator: bool option with get, set

    module Env =

        type [<AllowNullLiteral>] IExports =
            inherit Fable.Import.VSCode.Vscode.Env.IExports
            /// <summary>
            /// The authority part of the current opened <c>vscode-remote://</c> URI.
            /// Defined by extensions, e.g. <c>ssh-remote+${host}</c> for remotes using a secure shell.
            /// 
            /// *Note* that the value is <c>undefined</c> when there is no remote extension host but that the
            /// value is defined in all extension hosts (local and remote) in case a remote extension host
            /// exists. Use <see cref="Extension.extensionKind" /> to know if
            /// a specific extension runs remote or not.
            /// </summary>
            abstract remoteAuthority: string option
            abstract openExternal: target: Uri * ?options: OpenExternalOptions -> Thenable<bool>

    type [<AllowNullLiteral>] WebviewEditorInset =
        abstract editor: TextEditor
        abstract line: float
        abstract height: float
        abstract webview: Webview
        abstract onDidDispose: Event<unit>
        abstract dispose: unit -> unit

    /// Be aware that this API will not ever be finalized.
    module Window =

        type [<AllowNullLiteral>] IExports =
            inherit Fable.Import.VSCode.Vscode.Window.IExports
            abstract createWebviewTextEditorInset: editor: TextEditor * line: float * height: float * ?options: WebviewOptions -> WebviewEditorInset
            /// An event which fires when the terminal's child pseudo-device is written to (the shell).
            /// In other words, this provides access to the raw data stream from the process running
            /// within the terminal, including VT sequences.
            abstract onDidWriteTerminalData: Event<TerminalDataWriteEvent>
            /// <summary>An event which fires when the <see cref="Terminal.dimensions">dimensions</see> of the terminal change.</summary>
            abstract onDidChangeTerminalDimensions: Event<TerminalDimensionsChangeEvent>
            abstract visibleNotebookEditors: ResizeArray<NotebookEditor>
            abstract onDidChangeVisibleNotebookEditors: Event<ResizeArray<NotebookEditor>>
            abstract activeNotebookEditor: NotebookEditor option
            abstract onDidChangeActiveNotebookEditor: Event<NotebookEditor option>
            abstract onDidChangeNotebookEditorSelection: Event<NotebookEditorSelectionChangeEvent>
            abstract onDidChangeNotebookEditorVisibleRanges: Event<NotebookEditorVisibleRangesChangeEvent>
            abstract showNotebookDocument: uri: Uri * ?options: NotebookDocumentShowOptions -> Thenable<NotebookEditor>
            abstract showNotebookDocument: document: NotebookDocument * ?options: NotebookDocumentShowOptions -> Thenable<NotebookEditor>
            /// <summary>
            /// Register a new <c>ExternalUriOpener</c>.
            /// 
            /// When a uri is about to be opened, an <c>onOpenExternalUri:SCHEME</c> activation event is fired.
            /// </summary>
            /// <param name="id">
            /// Unique id of the opener, such as <c>myExtension.browserPreview</c>. This is used in settings
            /// and commands to identify the opener.
            /// </param>
            /// <param name="opener">Opener to register.</param>
            /// <param name="metadata">Additional information about the opener.</param>
            /// <returns>Disposable that unregisters the opener.</returns>
            abstract registerExternalUriOpener: id: string * opener: ExternalUriOpener * metadata: ExternalUriOpenerMetadata -> Disposable
            /// A list of all opened tabs
            /// Ordered from left to right
            abstract tabs: ResizeArray<Tab>
            /// The currently active tab
            /// Undefined if no tabs are currently opened
            abstract activeTab: Tab option
            /// <summary>
            /// An <see cref="Event" /> which fires when the array of <see cref="window.tabs">tabs</see>
            /// has changed.
            /// </summary>
            abstract onDidChangeTabs: Event<ResizeArray<Tab>>
            /// <summary>
            /// An <see cref="Event" /> which fires when the <see cref="window.activeTab">activeTab</see>
            /// has changed.
            /// </summary>
            abstract onDidChangeActiveTab: Event<Tab option>
            abstract getInlineCompletionItemController: provider: InlineCompletionItemProvider<'T> -> InlineCompletionController<'T> when 'T :> InlineCompletionItem

    type [<AllowNullLiteral>] FileSystemProvider =
        abstract ``open``: resource: Uri * options: FileSystemProviderOpenOptions -> U2<float, Thenable<float>>
        abstract close: fd: float -> U2<unit, Thenable<unit>>
        abstract read: fd: float * pos: float * data: Uint8Array * offset: float * length: float -> U2<float, Thenable<float>>
        abstract write: fd: float * pos: float * data: Uint8Array * offset: float * length: float -> U2<float, Thenable<float>>

    type [<AllowNullLiteral>] FileSystemProviderOpenOptions =
        abstract create: bool with get, set

    /// The parameters of a query for text search.
    type [<AllowNullLiteral>] TextSearchQuery =
        /// The text pattern to search for.
        abstract pattern: string with get, set
        /// <summary>Whether or not <c>pattern</c> should match multiple lines of text.</summary>
        abstract isMultiline: bool option with get, set
        /// <summary>Whether or not <c>pattern</c> should be interpreted as a regular expression.</summary>
        abstract isRegExp: bool option with get, set
        /// Whether or not the search should be case-sensitive.
        abstract isCaseSensitive: bool option with get, set
        /// Whether or not to search for whole word matches only.
        abstract isWordMatch: bool option with get, set

    /// <summary>
    /// A file glob pattern to match file paths against.
    /// TODO@roblourens merge this with the GlobPattern docs/definition in vscode.d.ts.
    /// </summary>
    /// <seealso cref="GlobPattern" />
    type GlobString =
        string

    /// Options common to file and text search
    type [<AllowNullLiteral>] SearchOptions =
        /// The root folder to search within.
        abstract folder: Uri with get, set
        /// <summary>Files that match an <c>includes</c> glob pattern should be included in the search.</summary>
        abstract includes: ResizeArray<GlobString> with get, set
        /// <summary>Files that match an <c>excludes</c> glob pattern should be excluded from the search.</summary>
        abstract excludes: ResizeArray<GlobString> with get, set
        /// <summary>
        /// Whether external files that exclude files, like .gitignore, should be respected.
        /// See the vscode setting <c>"search.useIgnoreFiles"</c>.
        /// </summary>
        abstract useIgnoreFiles: bool with get, set
        /// <summary>
        /// Whether symlinks should be followed while searching.
        /// See the vscode setting <c>"search.followSymlinks"</c>.
        /// </summary>
        abstract followSymlinks: bool with get, set
        /// <summary>
        /// Whether global files that exclude files, like .gitignore, should be respected.
        /// See the vscode setting <c>"search.useGlobalIgnoreFiles"</c>.
        /// </summary>
        abstract useGlobalIgnoreFiles: bool with get, set

    /// Options to specify the size of the result text preview.
    /// These options don't affect the size of the match itself, just the amount of preview text.
    type [<AllowNullLiteral>] TextSearchPreviewOptions =
        /// The maximum number of lines in the preview.
        /// Only search providers that support multiline search will ever return more than one line in the match.
        abstract matchLines: float with get, set
        /// The maximum number of characters included per line.
        abstract charsPerLine: float with get, set

    /// Options that apply to text search.
    type [<AllowNullLiteral>] TextSearchOptions =
        inherit SearchOptions
        /// The maximum number of results to be returned.
        abstract maxResults: float with get, set
        /// Options to specify the size of the result text preview.
        abstract previewOptions: TextSearchPreviewOptions option with get, set
        /// <summary>Exclude files larger than <c>maxFileSize</c> in bytes.</summary>
        abstract maxFileSize: float option with get, set
        /// <summary>
        /// Interpret files using this encoding.
        /// See the vscode setting <c>"files.encoding"</c>
        /// </summary>
        abstract encoding: string option with get, set
        /// Number of lines of context to include before each match.
        abstract beforeContext: float option with get, set
        /// Number of lines of context to include after each match.
        abstract afterContext: float option with get, set

    /// Represents the severiry of a TextSearchComplete message.
    type [<RequireQualifiedAccess>] TextSearchCompleteMessageType =
        | Information = 1
        | Warning = 2

    /// A message regarding a completed search.
    type [<AllowNullLiteral>] TextSearchCompleteMessage =
        /// Markdown text of the message.
        abstract text: string with get, set
        /// Whether the source of the message is trusted, command links are disabled for untrusted message sources.
        /// Messaged are untrusted by default.
        abstract trusted: bool option with get, set
        /// The message type, this affects how the message will be rendered.
        abstract ``type``: TextSearchCompleteMessageType with get, set

    /// Information collected when text search is complete.
    type [<AllowNullLiteral>] TextSearchComplete =
        /// <summary>
        /// Whether the search hit the limit on the maximum number of search results.
        /// <c>maxResults</c> on {@linkcode TextSearchOptions} specifies the max number of results.
        /// - If exactly that number of matches exist, this should be false.
        /// - If <c>maxResults</c> matches are returned and more exist, this should be true.
        /// - If search hits an internal limit which is less than <c>maxResults</c>, this should be true.
        /// </summary>
        abstract limitHit: bool option with get, set
        /// <summary>
        /// Additional information regarding the state of the completed search.
        /// 
        /// Messages with "Information" style support links in markdown syntax:
        /// - Click to <see cref="command:workbench.action.OpenQuickPick">run a command</see>
        /// - Click to <see href="https://aka.ms">open a website</see>
        /// 
        /// Commands may optionally return { triggerSearch: true } to signal to the editor that the original search should run be again.
        /// </summary>
        abstract message: U2<TextSearchCompleteMessage, ResizeArray<TextSearchCompleteMessage>> option with get, set

    /// A preview of the text result.
    type [<AllowNullLiteral>] TextSearchMatchPreview =
        /// The matching lines of text, or a portion of the matching line that contains the match.
        abstract text: string with get, set
        /// <summary>
        /// The Range within <c>text</c> corresponding to the text of the match.
        /// The number of matches must match the TextSearchMatch's range property.
        /// </summary>
        abstract matches: U2<Range, ResizeArray<Range>> with get, set

    /// A match from a text search
    type [<AllowNullLiteral>] TextSearchMatch =
        /// The uri for the matching document.
        abstract uri: Uri with get, set
        /// The range of the match within the document, or multiple ranges for multiple matches.
        abstract ranges: U2<Range, ResizeArray<Range>> with get, set
        /// A preview of the text match.
        abstract preview: TextSearchMatchPreview with get, set

    /// A line of context surrounding a TextSearchMatch.
    type [<AllowNullLiteral>] TextSearchContext =
        /// The uri for the matching document.
        abstract uri: Uri with get, set
        /// One line of text.
        /// previewOptions.charsPerLine applies to this
        abstract text: string with get, set
        /// The line number of this line of context.
        abstract lineNumber: float with get, set

    type TextSearchResult =
        U2<TextSearchMatch, TextSearchContext>

    /// A TextSearchProvider provides search results for text results inside files in the workspace.
    type [<AllowNullLiteral>] TextSearchProvider =
        /// <summary>Provide results that match the given text pattern.</summary>
        /// <param name="query">The parameters for this query.</param>
        /// <param name="options">A set of options to consider while searching.</param>
        /// <param name="progress">A progress callback that must be invoked for all results.</param>
        /// <param name="token">A cancellation token.</param>
        abstract provideTextSearchResults: query: TextSearchQuery * options: TextSearchOptions * progress: Progress<TextSearchResult> * token: CancellationToken -> ProviderResult<TextSearchComplete>

    /// The parameters of a query for file search.
    type [<AllowNullLiteral>] FileSearchQuery =
        /// The search pattern to match against file paths.
        abstract pattern: string with get, set

    /// Options that apply to file search.
    type [<AllowNullLiteral>] FileSearchOptions =
        inherit SearchOptions
        /// The maximum number of results to be returned.
        abstract maxResults: float option with get, set
        /// A CancellationToken that represents the session for this search query. If the provider chooses to, this object can be used as the key for a cache,
        /// and searches with the same session object can search the same cache. When the token is cancelled, the session is complete and the cache can be cleared.
        abstract session: CancellationToken option with get, set

    /// <summary>
    /// A FileSearchProvider provides search results for files in the given folder that match a query string. It can be invoked by quickopen or other extensions.
    /// 
    /// A FileSearchProvider is the more powerful of two ways to implement file search in the editor. Use a FileSearchProvider if you wish to search within a folder for
    /// all files that match the user's query.
    /// 
    /// The FileSearchProvider will be invoked on every keypress in quickopen. When <c>workspace.findFiles</c> is called, it will be invoked with an empty query string,
    /// and in that case, every file in the folder should be returned.
    /// </summary>
    type [<AllowNullLiteral>] FileSearchProvider =
        /// <summary>Provide the set of files that match a certain file path pattern.</summary>
        /// <param name="query">The parameters for this query.</param>
        /// <param name="options">A set of options to consider while searching files.</param>
        /// <param name="token">A cancellation token.</param>
        abstract provideFileSearchResults: query: FileSearchQuery * options: FileSearchOptions * token: CancellationToken -> ProviderResult<ResizeArray<Uri>>

    /// Options that can be set on a findTextInFiles search.
    type [<AllowNullLiteral>] FindTextInFilesOptions =
        /// <summary>
        /// A <see cref="GlobPattern">glob pattern</see> that defines the files to search for. The glob pattern
        /// will be matched against the file paths of files relative to their workspace. Use a <see cref="RelativePattern">relative pattern</see>
        /// to restrict the search results to a <see cref="WorkspaceFolder">workspace folder</see>.
        /// </summary>
        abstract ``include``: GlobPattern option with get, set
        /// <summary>
        /// A <see cref="GlobPattern">glob pattern</see> that defines files and folders to exclude. The glob pattern
        /// will be matched against the file paths of resulting matches relative to their workspace. When <c>undefined</c>, default excludes will
        /// apply.
        /// </summary>
        abstract exclude: GlobPattern option with get, set
        /// Whether to use the default and user-configured excludes. Defaults to true.
        abstract useDefaultExcludes: bool option with get, set
        /// The maximum number of results to search for
        abstract maxResults: float option with get, set
        /// <summary>
        /// Whether external files that exclude files, like .gitignore, should be respected.
        /// See the vscode setting <c>"search.useIgnoreFiles"</c>.
        /// </summary>
        abstract useIgnoreFiles: bool option with get, set
        /// <summary>
        /// Whether global files that exclude files, like .gitignore, should be respected.
        /// See the vscode setting <c>"search.useGlobalIgnoreFiles"</c>.
        /// </summary>
        abstract useGlobalIgnoreFiles: bool option with get, set
        /// <summary>
        /// Whether symlinks should be followed while searching.
        /// See the vscode setting <c>"search.followSymlinks"</c>.
        /// </summary>
        abstract followSymlinks: bool option with get, set
        /// <summary>
        /// Interpret files using this encoding.
        /// See the vscode setting <c>"files.encoding"</c>
        /// </summary>
        abstract encoding: string option with get, set
        /// Options to specify the size of the result text preview.
        abstract previewOptions: TextSearchPreviewOptions option with get, set
        /// Number of lines of context to include before each match.
        abstract beforeContext: float option with get, set
        /// Number of lines of context to include after each match.
        abstract afterContext: float option with get, set

    /// The contiguous set of modified lines in a diff.
    type [<AllowNullLiteral>] LineChange =
        abstract originalStartLineNumber: float
        abstract originalEndLineNumber: float
        abstract modifiedStartLineNumber: float
        abstract modifiedEndLineNumber: float

    module Commands =

        type [<AllowNullLiteral>] IExports =
            inherit Fable.Import.VSCode.Vscode.Commands.IExports
            /// <summary>
            /// Registers a diff information command that can be invoked via a keyboard shortcut,
            /// a menu item, an action, or directly.
            /// 
            /// Diff information commands are different from ordinary <see cref="commands.registerCommand">commands</see> as
            /// they only execute when there is an active diff editor when the command is called, and the diff
            /// information has been computed. Also, the command handler of an editor command has access to
            /// the diff information.
            /// </summary>
            /// <param name="command">A unique identifier for the command.</param>
            /// <param name="callback">A command handler function with access to the <see cref="LineChange">diff information</see>.</param>
            /// <param name="thisArg">The <c>this</c> context used when invoking the handler function.</param>
            /// <returns>Disposable which unregisters this command on disposal.</returns>
            abstract registerDiffInformationCommand: command: string * callback: (ResizeArray<LineChange> -> ResizeArray<obj option> -> obj option) * ?thisArg: obj -> Disposable

    /// <summary>Options for <see cref="debug.startDebugging">starting a debug session</see>.</summary>
    type [<AllowNullLiteral>] DebugSessionOptions =
        abstract debugUI: DebugSessionOptionsDebugUI option with get, set
        /// <summary>When true, a save will not be triggered for open editors when starting a debug session, regardless of the value of the <c>debug.saveBeforeStart</c> setting.</summary>
        abstract suppressSaveBeforeStart: bool option with get, set

    /// <summary>
    /// A DebugProtocolVariableContainer is an opaque stand-in type for the intersection of the Scope and Variable types defined in the Debug Adapter Protocol.
    /// See <see href="https://microsoft.github.io/debug-adapter-protocol/specification#Types_Scope" /> and <see href="https://microsoft.github.io/debug-adapter-protocol/specification#Types_Variable." />
    /// </summary>
    type [<AllowNullLiteral>] DebugProtocolVariableContainer =
        interface end

    /// <summary>
    /// A DebugProtocolVariable is an opaque stand-in type for the Variable type defined in the Debug Adapter Protocol.
    /// See <see href="https://microsoft.github.io/debug-adapter-protocol/specification#Types_Variable." />
    /// </summary>
    type [<AllowNullLiteral>] DebugProtocolVariable =
        interface end

    /// Represents the validation type of the Source Control input.
    type [<RequireQualifiedAccess>] SourceControlInputBoxValidationType =
        /// Something not allowed by the rules of a language or other means.
        | Error = 0
        /// Something suspicious but allowed.
        | Warning = 1
        /// Something to inform about but not a problem.
        | Information = 2

    type [<AllowNullLiteral>] SourceControlInputBoxValidation =
        /// The validation message to display.
        abstract message: U2<string, MarkdownString>
        /// The validation type.
        abstract ``type``: SourceControlInputBoxValidationType

    /// Represents the input box in the Source Control viewlet.
    type [<AllowNullLiteral>] SourceControlInputBox =
        /// Shows a transient contextual message on the input.
        abstract showValidationMessage: message: U2<string, MarkdownString> * ``type``: SourceControlInputBoxValidationType -> unit
        /// A validation function for the input box. It's possible to change
        /// the validation provider simply by setting this property to a different function.
        abstract validateInput: value: string * cursorPosition: float -> ProviderResult<SourceControlInputBoxValidation>
        /// Sets focus to the input.
        abstract focus: unit -> unit

    type [<AllowNullLiteral>] SourceControl =
        /// Whether the source control is selected.
        abstract selected: bool
        /// An event signaling when the selection state changes.
        abstract onDidChangeSelection: Event<bool>
        abstract actionButton: Command option with get, set

    type [<AllowNullLiteral>] TerminalDataWriteEvent =
        /// <summary>The <see cref="Terminal" /> for which the data was written.</summary>
        abstract terminal: Terminal
        /// The data being written.
        abstract data: string

    /// <summary>An <see cref="Event" /> which fires when a <see cref="Terminal" />'s dimensions change.</summary>
    type [<AllowNullLiteral>] TerminalDimensionsChangeEvent =
        /// <summary>The <see cref="Terminal" /> for which the dimensions have changed.</summary>
        abstract terminal: Terminal
        /// <summary>The new value for the <see cref="Terminal.dimensions">terminal's dimensions</see>.</summary>
        abstract dimensions: TerminalDimensions

    type [<AllowNullLiteral>] Terminal =
        /// <summary>
        /// The current dimensions of the terminal. This will be <c>undefined</c> immediately after the
        /// terminal is created as the dimensions are not known until shortly after the terminal is
        /// created.
        /// </summary>
        abstract dimensions: TerminalDimensions option

    type [<AllowNullLiteral>] TerminalOptions =
        abstract location: U3<TerminalLocation, TerminalEditorLocationOptions, TerminalSplitLocationOptions> option with get, set

    type [<AllowNullLiteral>] ExtensionTerminalOptions =
        abstract location: U3<TerminalLocation, TerminalEditorLocationOptions, TerminalSplitLocationOptions> option with get, set

    type [<RequireQualifiedAccess>] TerminalLocation =
        | Panel = 1
        | Editor = 2

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

    type [<AllowNullLiteral>] TerminalSplitLocationOptions =
        /// The parent terminal to split this terminal beside. This works whether the parent terminal
        /// is in the panel or the editor area.
        abstract parentTerminal: Terminal with get, set

    type [<AllowNullLiteral>] Pseudoterminal =
        /// An event that when fired allows changing the name of the terminal.
        /// 
        /// **Example:** Change the terminal name to "My new terminal".
        /// <code language="typescript">
        /// const writeEmitter = new vscode.EventEmitter<string>();
        /// const changeNameEmitter = new vscode.EventEmitter<string>();
        /// const pty: vscode.Pseudoterminal = {
        ///    onDidWrite: writeEmitter.event,
        ///    onDidChangeName: changeNameEmitter.event,
        ///    open: () => changeNameEmitter.fire('My new terminal'),
        ///    close: () => {}
        /// };
        /// vscode.window.createTerminal({ name: 'My terminal', pty });
        /// </code>
        abstract onDidChangeName: Event<string> option with get, set

    type [<AllowNullLiteral>] DocumentFilter =
        abstract exclusive: bool option

    type [<AllowNullLiteral>] TreeView<'T> =
        inherit Disposable
        abstract reveal: element: 'T option * ?options: TreeViewRevealOptions -> Thenable<unit>

    type [<AllowNullLiteral>] TreeViewRevealOptions =
        abstract select: bool option with get, set
        abstract focus: bool option with get, set
        abstract expand: U2<bool, float> option with get, set

    /// A data provider that provides tree data
    type [<AllowNullLiteral>] TreeDataProvider<'T> =
        /// <summary>
        /// An optional event to signal that an element or root has changed.
        /// This will trigger the view to update the changed element/root and its children recursively (if shown).
        /// To signal that root has changed, do not pass any argument or pass <c>undefined</c> or <c>null</c>.
        /// </summary>
        abstract onDidChangeTreeData2: Event<U3<'T, ResizeArray<'T>, unit> option> option with get, set

    type [<AllowNullLiteral>] TreeViewOptions<'T> =
        /// An optional interface to implement drag and drop in the tree view.
        abstract dragAndDropController: DragAndDropController<'T> option with get, set

    type [<AllowNullLiteral>] TreeDataTransferItem =
        abstract asString: unit -> Thenable<string>

    type [<AllowNullLiteral>] TreeDataTransfer =
        /// A map containing a mapping of the mime type of the corresponding data.
        /// The type for tree elements is text/treeitem.
        /// For example, you can reconstruct the your tree elements:
        /// <code language="ts">
        /// JSON.parse(await (items.get('text/treeitem')!.asString()))
        /// </code>
        abstract items: TreeDataTransferItems with get, set

    type [<AllowNullLiteral>] DragAndDropController<'T> =
        inherit Disposable
        abstract supportedTypes: ResizeArray<string>
        /// <summary>Extensions should fire <c>TreeDataProvider.onDidChangeTreeData</c> for any elements that need to be refreshed.</summary>
        /// <param name="source" />
        /// <param name="target" />
        abstract onDrop: source: TreeDataTransfer * target: 'T -> Thenable<unit>

    type [<AllowNullLiteral>] TaskPresentationOptions =
        /// Controls whether the task is executed in a specific terminal group using split panes.
        abstract group: string option with get, set
        /// Controls whether the terminal is closed after executing the task.
        abstract close: bool option with get, set

    type [<AllowNullLiteral>] CustomTextEditorProvider =
        /// <summary>
        /// Handle when the underlying resource for a custom editor is renamed.
        /// 
        /// This allows the webview for the editor be preserved throughout the rename. If this method is not implemented,
        /// the editor will destroy the previous custom editor and create a replacement one.
        /// </summary>
        /// <param name="newDocument">New text document to use for the custom editor.</param>
        /// <param name="existingWebviewPanel">Webview panel for the custom editor.</param>
        /// <param name="token">A cancellation token that indicates the result is no longer needed.</param>
        /// <returns>Thenable indicating that the webview editor has been moved.</returns>
        abstract moveCustomTextEditor: newDocument: TextDocument * existingWebviewPanel: WebviewPanel * token: CancellationToken -> Thenable<unit>

    type [<AllowNullLiteral>] QuickPick<'T when 'T :> QuickPickItem> =
        inherit QuickInput
        /// An optional flag to sort the final results by index of first query match in label. Defaults to true.
        abstract sortByLabel: bool with get, set
        abstract keepScrollPosition: bool option with get, set
        abstract onDidTriggerItemButton: Event<QuickPickItemButtonEvent<'T>>

    /// The execution state of a notebook cell.
    type [<RequireQualifiedAccess>] NotebookCellExecutionState =
        /// The cell is idle.
        | Idle = 1
        /// Execution for the cell is pending.
        | Pending = 2
        /// The cell is currently executing.
        | Executing = 3

    /// An event describing a cell execution state change.
    type [<AllowNullLiteral>] NotebookCellExecutionStateChangeEvent =
        /// <summary>The <see cref="NotebookCell">cell</see> for which the execution state has changed.</summary>
        abstract cell: NotebookCell
        /// The new execution state of the cell.
        abstract state: NotebookCellExecutionState

    module Notebooks =

        type [<AllowNullLiteral>] IExports =
            inherit Fable.Import.VSCode.Vscode.Notebooks.IExports
            /// <summary>An <see cref="Event" /> which fires when the execution state of a cell has changed.</summary>
            abstract onDidChangeNotebookCellExecutionState: Event<NotebookCellExecutionStateChangeEvent>
            abstract onDidSaveNotebookDocument: Event<NotebookDocument>
            abstract onDidChangeNotebookDocumentMetadata: Event<NotebookDocumentMetadataChangeEvent>
            abstract onDidChangeNotebookCells: Event<NotebookCellsChangeEvent>
            abstract onDidChangeCellOutputs: Event<NotebookCellOutputsChangeEvent>
            abstract onDidChangeCellMetadata: Event<NotebookCellMetadataChangeEvent>
            abstract createNotebookEditorDecorationType: options: NotebookDecorationRenderOptions -> NotebookEditorDecorationType
            /// <summary>
            /// Create a document that is the concatenation of all  notebook cells. By default all code-cells are included
            /// but a selector can be provided to narrow to down the set of cells.
            /// </summary>
            /// <param name="notebook" />
            /// <param name="selector" />
            abstract createConcatTextDocument: notebook: NotebookDocument * ?selector: DocumentSelector -> NotebookConcatTextDocument
            abstract createNotebookController: id: string * viewType: string * label: string * ?handler: (ResizeArray<NotebookCell> -> NotebookDocument -> NotebookController -> U2<unit, Thenable<unit>>) * ?rendererScripts: ResizeArray<NotebookRendererScript> -> NotebookController

    type [<AllowNullLiteral>] NotebookCellOutput =
        abstract id: string with get, set

    /// <summary>Represents a notebook editor that is attached to a <see cref="NotebookDocument">notebook</see>.</summary>
    type [<RequireQualifiedAccess>] NotebookEditorRevealType =
        /// The range will be revealed with as little scrolling as possible.
        | Default = 0
        /// The range will always be revealed in the center of the viewport.
        | InCenter = 1
        /// If the range is outside the viewport, it will be revealed in the center of the viewport.
        /// Otherwise, it will be revealed with as little scrolling as possible.
        | InCenterIfOutsideViewport = 2
        /// The range will always be revealed at the top of the viewport.
        | AtTop = 3

    /// <summary>Represents a notebook editor that is attached to a <see cref="NotebookDocument">notebook</see>.</summary>
    type [<AllowNullLiteral>] NotebookEditor =
        /// The document associated with this notebook editor.
        abstract document: NotebookDocument
        /// <summary>
        /// The selections on this notebook editor.
        /// 
        /// The primary selection (or focused range) is <c>selections[0]</c>. When the document has no cells, the primary selection is empty <c>{ start: 0, end: 0 }</c>;
        /// </summary>
        abstract selections: ResizeArray<NotebookRange> with get, set
        /// The current visible ranges in the editor (vertically).
        abstract visibleRanges: ResizeArray<NotebookRange>
        /// <summary>Scroll as indicated by <c>revealType</c> in order to reveal the given range.</summary>
        /// <param name="range">A range.</param>
        /// <param name="revealType">The scrolling strategy for revealing <c>range</c>.</param>
        abstract revealRange: range: NotebookRange * ?revealType: NotebookEditorRevealType -> unit
        /// The column in which this editor shows.
        abstract viewColumn: ViewColumn option
        /// <summary>
        /// Perform an edit on the notebook associated with this notebook editor.
        /// 
        /// The given callback-function is invoked with an <see cref="NotebookEditorEdit">edit-builder</see> which must
        /// be used to make edits. Note that the edit-builder is only valid while the
        /// callback executes.
        /// </summary>
        /// <param name="callback">A function which can create edits using an <see cref="NotebookEditorEdit">edit-builder</see>.</param>
        /// <returns>A promise that resolves with a value indicating if the edits could be applied.</returns>
        abstract edit: callback: (NotebookEditorEdit -> unit) -> Thenable<bool>
        abstract setDecorations: decorationType: NotebookEditorDecorationType * range: NotebookRange -> unit

    type [<AllowNullLiteral>] NotebookDocumentMetadataChangeEvent =
        /// <summary>The <see cref="NotebookDocument">notebook document</see> for which the document metadata have changed.</summary>
        abstract document: NotebookDocument

    type [<AllowNullLiteral>] NotebookCellsChangeData =
        abstract start: float
        abstract deletedCount: float
        abstract deletedItems: ResizeArray<NotebookCell>
        abstract items: ResizeArray<NotebookCell>

    type [<AllowNullLiteral>] NotebookCellsChangeEvent =
        /// <summary>The <see cref="NotebookDocument">notebook document</see> for which the cells have changed.</summary>
        abstract document: NotebookDocument
        abstract changes: ReadonlyArray<NotebookCellsChangeData>

    type [<AllowNullLiteral>] NotebookCellOutputsChangeEvent =
        /// <summary>The <see cref="NotebookDocument">notebook document</see> for which the cell outputs have changed.</summary>
        abstract document: NotebookDocument
        abstract cells: ResizeArray<NotebookCell>

    type [<AllowNullLiteral>] NotebookCellMetadataChangeEvent =
        /// <summary>The <see cref="NotebookDocument">notebook document</see> for which the cell metadata have changed.</summary>
        abstract document: NotebookDocument
        abstract cell: NotebookCell

    type [<AllowNullLiteral>] NotebookEditorSelectionChangeEvent =
        /// <summary>The <see cref="NotebookEditor">notebook editor</see> for which the selections have changed.</summary>
        abstract notebookEditor: NotebookEditor
        abstract selections: ReadonlyArray<NotebookRange>

    type [<AllowNullLiteral>] NotebookEditorVisibleRangesChangeEvent =
        /// <summary>The <see cref="NotebookEditor">notebook editor</see> for which the visible ranges have changed.</summary>
        abstract notebookEditor: NotebookEditor
        abstract visibleRanges: ReadonlyArray<NotebookRange>

    type [<AllowNullLiteral>] NotebookDocumentShowOptions =
        abstract viewColumn: ViewColumn option with get, set
        abstract preserveFocus: bool option with get, set
        abstract preview: bool option with get, set
        abstract selections: ResizeArray<NotebookRange> option with get, set

    type [<AllowNullLiteral>] WorkspaceEdit =
        abstract replaceNotebookMetadata: uri: Uri * value: WorkspaceEditReplaceNotebookMetadataValue -> unit
        abstract replaceNotebookCells: uri: Uri * range: NotebookRange * cells: ResizeArray<NotebookCellData> * ?metadata: WorkspaceEditEntryMetadata -> unit
        abstract replaceNotebookCellMetadata: uri: Uri * index: float * cellMetadata: WorkspaceEditReplaceNotebookCellMetadataCellMetadata * ?metadata: WorkspaceEditEntryMetadata -> unit

    type [<AllowNullLiteral>] WorkspaceEditReplaceNotebookMetadataValue =
        [<EmitIndexer>] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] WorkspaceEditReplaceNotebookCellMetadataCellMetadata =
        [<EmitIndexer>] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] NotebookEditorEdit =
        abstract replaceMetadata: value: NotebookEditorEditReplaceMetadataValue -> unit
        abstract replaceCells: start: float * ``end``: float * cells: ResizeArray<NotebookCellData> -> unit
        abstract replaceCellMetadata: index: float * metadata: NotebookEditorEditReplaceCellMetadataMetadata -> unit

    type [<AllowNullLiteral>] NotebookEditorEditReplaceMetadataValue =
        [<EmitIndexer>] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] NotebookEditorEditReplaceCellMetadataMetadata =
        [<EmitIndexer>] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] NotebookDecorationRenderOptions =
        abstract backgroundColor: U2<string, ThemeColor> option with get, set
        abstract borderColor: U2<string, ThemeColor> option with get, set
        abstract top: ThemableDecorationAttachmentRenderOptions option with get, set

    type [<AllowNullLiteral>] NotebookEditorDecorationType =
        abstract key: string
        abstract dispose: unit -> unit

    type [<AllowNullLiteral>] NotebookConcatTextDocument =
        abstract uri: Uri
        abstract isClosed: bool
        abstract dispose: unit -> unit
        abstract onDidChange: Event<unit>
        abstract version: float
        abstract getText: unit -> string
        abstract getText: range: Range -> string
        abstract offsetAt: position: Position -> float
        abstract positionAt: offset: float -> Position
        abstract validateRange: range: Range -> Range
        abstract validatePosition: position: Position -> Position
        abstract locationAt: positionOrRange: U2<Position, Range> -> Location
        abstract positionAt: location: Location -> Position
        abstract contains: uri: Uri -> bool

    type [<AllowNullLiteral>] NotebookDocumentBackup =
        /// <summary>
        /// Unique identifier for the backup.
        /// 
        /// This id is passed back to your extension in <c>openNotebook</c> when opening a notebook editor from a backup.
        /// </summary>
        abstract id: string
        /// Delete the current backup.
        /// 
        /// This is called by the editor when it is clear the current backup is no longer needed, such as when a new backup
        /// is made or when the file is saved.
        abstract delete: unit -> unit

    type [<AllowNullLiteral>] NotebookDocumentBackupContext =
        abstract destination: Uri

    type [<AllowNullLiteral>] NotebookDocumentOpenContext =
        abstract backupId: string option
        abstract untitledDocumentData: Uint8Array option

    type [<AllowNullLiteral>] NotebookContentProvider =
        abstract options: NotebookDocumentContentOptions option
        abstract onDidChangeNotebookContentOptions: Event<NotebookDocumentContentOptions> option
        /// <summary>
        /// Content providers should always use <see cref="FileSystemProvider">file system providers</see> to
        /// resolve the raw content for <c>uri</c> as the resouce is not necessarily a file on disk.
        /// </summary>
        abstract openNotebook: uri: Uri * openContext: NotebookDocumentOpenContext * token: CancellationToken -> U2<NotebookData, Thenable<NotebookData>>
        abstract saveNotebook: document: NotebookDocument * token: CancellationToken -> Thenable<unit>
        abstract saveNotebookAs: targetResource: Uri * document: NotebookDocument * token: CancellationToken -> Thenable<unit>
        abstract backupNotebook: document: NotebookDocument * context: NotebookDocumentBackupContext * token: CancellationToken -> Thenable<NotebookDocumentBackup>

    type [<AllowNullLiteral>] NotebookRegistrationData =
        abstract displayName: string with get, set
        abstract filenamePattern: ResizeArray<U2<GlobPattern, NotebookRegistrationDataFilenamePattern>> with get, set
        abstract exclusive: bool option with get, set

    /// Represents a script that is loaded into the notebook renderer before rendering output. This allows
    /// to provide and share functionality for notebook markup and notebook output renderers.
    type [<AllowNullLiteral>] NotebookRendererScript =
        /// <summary>
        /// APIs that the preload provides to the renderer. These are matched
        /// against the <c>dependencies</c> and <c>optionalDependencies</c> arrays in the
        /// notebook renderer contribution point.
        /// </summary>
        abstract provides: ResizeArray<string> with get, set
        /// <summary>
        /// URI of the JavaScript module to preload.
        /// 
        /// This module must export an <c>activate</c> function that takes a context object that contains the notebook API.
        /// </summary>
        abstract uri: Uri with get, set

    /// Represents a script that is loaded into the notebook renderer before rendering output. This allows
    /// to provide and share functionality for notebook markup and notebook output renderers.
    type [<AllowNullLiteral>] NotebookRendererScriptStatic =
        /// <param name="uri">URI of the JavaScript module to preload</param>
        /// <param name="provides">Value for the <c>provides</c> property</param>
        [<EmitConstructor>] abstract Create: uri: Uri * ?provides: U2<string, ResizeArray<string>> -> NotebookRendererScript

    type [<AllowNullLiteral>] NotebookController =
        abstract rendererScripts: ResizeArray<NotebookRendererScript>
        /// <summary>
        /// An event that fires when a <see cref="NotebookController.rendererScripts">renderer script</see> has send a message to
        /// the controller.
        /// </summary>
        abstract onDidReceiveMessage: Event<NotebookControllerOnDidReceiveMessageEvent>
        /// <summary>
        /// Send a message to the renderer of notebook editors.
        /// 
        /// Note that only editors showing documents that are bound to this controller
        /// are receiving the message.
        /// </summary>
        /// <param name="message">The message to send.</param>
        /// <param name="editor">A specific editor to send the message to. When <c>undefined</c> all applicable editors are receiving the message.</param>
        /// <returns>A promise that resolves to a boolean indicating if the message has been send or not.</returns>
        abstract postMessage: message: obj option * ?editor: NotebookEditor -> Thenable<bool>
        abstract asWebviewUri: localResource: Uri -> Uri

    type [<AllowNullLiteral>] TimelineItem =
        /// A timestamp (in milliseconds since 1 January 1970 00:00:00) for when the timeline item occurred.
        abstract timestamp: float with get, set
        /// A human-readable string describing the timeline item.
        abstract label: string with get, set
        /// Optional id for the timeline item. It must be unique across all the timeline items provided by this source.
        /// 
        /// If not provided, an id is generated using the timeline item's timestamp.
        abstract id: string option with get, set
        /// <summary>The icon path or <see cref="ThemeIcon" /> for the timeline item.</summary>
        abstract iconPath: U3<Uri, TimelineItemIconPath, ThemeIcon> option with get, set
        /// A human readable string describing less prominent details of the timeline item.
        abstract description: string option with get, set
        /// The tooltip text when you hover over the timeline item.
        abstract detail: string option with get, set
        /// <summary>The <see cref="Command" /> that should be executed when the timeline item is selected.</summary>
        abstract command: Command option with get, set
        /// <summary>
        /// Context value of the timeline item. This can be used to contribute specific actions to the item.
        /// For example, a timeline item is given a context value as <c>commit</c>. When contributing actions to <c>timeline/item/context</c>
        /// using <c>menus</c> extension point, you can specify context value for key <c>timelineItem</c> in <c>when</c> expression like <c>timelineItem == commit</c>.
        /// <code>
        /// "contributes": {
        /// 		"menus": {
        /// 			"timeline/item/context": [
        /// 				{
        /// 					"command": "extension.copyCommitId",
        /// 					"when": "timelineItem == commit"
        /// 				}
        /// 			]
        /// 		}
        /// }
        /// </code>
        /// This will show the <c>extension.copyCommitId</c> action only for items where <c>contextValue</c> is <c>commit</c>.
        /// </summary>
        abstract contextValue: string option with get, set
        /// Accessibility information used when screen reader interacts with this timeline item.
        abstract accessibilityInformation: AccessibilityInformation option with get, set

    type [<AllowNullLiteral>] TimelineItemStatic =
        /// <param name="label">A human-readable string describing the timeline item</param>
        /// <param name="timestamp">A timestamp (in milliseconds since 1 January 1970 00:00:00) for when the timeline item occurred</param>
        [<EmitConstructor>] abstract Create: label: string * timestamp: float -> TimelineItem

    type [<AllowNullLiteral>] TimelineChangeEvent =
        /// <summary>The <see cref="Uri" /> of the resource for which the timeline changed.</summary>
        abstract uri: Uri with get, set
        /// A flag which indicates whether the entire timeline should be reset.
        abstract reset: bool option with get, set

    type [<AllowNullLiteral>] Timeline =
        abstract paging: TimelinePaging option
        /// <summary>An array of <see cref="TimelineItem">timeline items</see>.</summary>
        abstract items: ResizeArray<TimelineItem>

    type [<AllowNullLiteral>] TimelineOptions =
        /// A provider-defined cursor specifying the starting point of the timeline items that should be returned.
        abstract cursor: string option with get, set
        /// <summary>
        /// An optional maximum number timeline items or the all timeline items newer (inclusive) than the timestamp or id that should be returned.
        /// If <c>undefined</c> all timeline items should be returned.
        /// </summary>
        abstract limit: U2<float, TimelineOptionsLimit> option with get, set

    type [<AllowNullLiteral>] TimelineProvider =
        /// <summary>
        /// An optional event to signal that the timeline for a source has changed.
        /// To signal that the timeline for all resources (uris) has changed, do not pass any argument or pass <c>undefined</c>.
        /// </summary>
        abstract onDidChange: Event<TimelineChangeEvent option> option with get, set
        /// An identifier of the source of the timeline items. This can be used to filter sources.
        abstract id: string
        /// A human-readable string describing the source of the timeline items. This can be used as the display label when filtering sources.
        abstract label: string
        /// <summary>Provide <see cref="TimelineItem">timeline items</see> for a <see cref="Uri" />.</summary>
        /// <param name="uri">The <see cref="Uri" /> of the file to provide the timeline for.</param>
        /// <param name="options">A set of options to determine how results should be returned.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>
        /// The <see cref="TimelineResult">timeline result</see> or a thenable that resolves to such. The lack of a result
        /// can be signaled by returning <c>undefined</c>, <c>null</c>, or an empty array.
        /// </returns>
        abstract provideTimeline: uri: Uri * options: TimelineOptions * token: CancellationToken -> ProviderResult<Timeline>

    type [<RequireQualifiedAccess>] StandardTokenType =
        | Other = 0
        | Comment = 1
        | String = 2
        | RegEx = 4

    type [<AllowNullLiteral>] TokenInformation =
        abstract ``type``: StandardTokenType with get, set
        abstract range: Range with get, set

    module Languages =

        type [<AllowNullLiteral>] IExports =
            inherit Fable.Import.VSCode.Vscode.Languages.IExports
            abstract getTokenInformationAtPosition: document: TextDocument * position: Position -> Thenable<TokenInformation>
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
            /// Registers an inline completion provider.
            abstract registerInlineCompletionItemProvider: selector: DocumentSelector * provider: InlineCompletionItemProvider -> Disposable
            abstract createLanguageStatusItem: id: string * selector: DocumentSelector -> LanguageStatusItem

    type [<RequireQualifiedAccess>] InlayHintKind =
        | Other = 0
        | Type = 1
        | Parameter = 2

    /// Inlay hint information.
    type [<AllowNullLiteral>] InlayHint =
        /// The text of the hint.
        abstract text: string with get, set
        /// The position of this hint.
        abstract position: Position with get, set
        /// The kind of this hint.
        abstract kind: InlayHintKind option with get, set
        /// Whitespace before the hint.
        abstract whitespaceBefore: bool option with get, set
        /// Whitespace after the hint.
        abstract whitespaceAfter: bool option with get, set

    /// Inlay hint information.
    type [<AllowNullLiteral>] InlayHintStatic =
        [<EmitConstructor>] abstract Create: text: string * position: Position * ?kind: InlayHintKind -> InlayHint

    /// The inlay hints provider interface defines the contract between extensions and
    /// the inlay hints feature.
    type [<AllowNullLiteral>] InlayHintsProvider =
        /// <summary>An optional event to signal that inlay hints have changed.</summary>
        /// <seealso cref="EventEmitter" />
        abstract onDidChangeInlayHints: Event<unit> option with get, set
        /// <param name="model">The document in which the command was invoked.</param>
        /// <param name="range">The range for which inlay hints should be computed.</param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>A list of inlay hints or a thenable that resolves to such.</returns>
        abstract provideInlayHints: model: TextDocument * range: Range * token: CancellationToken -> ProviderResult<ResizeArray<InlayHint>>

    type [<RequireQualifiedAccess>] ExtensionRuntime =
        /// The extension is running in a NodeJS extension host. Runtime access to NodeJS APIs is available.
        | Node = 1
        /// The extension is running in a Webworker extension host. Runtime access is limited to Webworker APIs.
        | Webworker = 2

    type [<AllowNullLiteral>] ExtensionContext =
        abstract extensionRuntime: ExtensionRuntime

    type [<AllowNullLiteral>] TextDocument =
        /// <summary>
        /// The <see cref="NotebookDocument">notebook</see> that contains this document as a notebook cell or <c>undefined</c> when
        /// the document is not contained by a notebook (this should be the more frequent case).
        /// </summary>
        abstract notebook: NotebookDocument option with get, set

    module Tests =

        type [<AllowNullLiteral>] IExports =
            /// <summary>Requests that tests be run by their controller.</summary>
            /// <param name="run">Run options to use.</param>
            /// <param name="token">Cancellation token for the test run</param>
            abstract runTests: run: obj * ?token: CancellationToken -> Thenable<unit>
            /// Returns an observer that watches and can request tests.
            abstract createTestObserver: unit -> TestObserver
            /// <summary>
            /// List of test results stored by the editor, sorted in descending
            /// order by their <c>completedAt</c> time.
            /// </summary>
            abstract testResults: ReadonlyArray<TestRunResult>
            /// <summary>Event that fires when the <see cref="testResults" /> array is updated.</summary>
            abstract onDidChangeTestResults: Event<unit>

    type [<AllowNullLiteral>] TestObserver =
        /// List of tests returned by test provider for files in the workspace.
        abstract tests: ReadonlyArray<TestItem>
        /// An event that fires when an existing test in the collection changes, or
        /// null if a top-level test was added or removed. When fired, the consumer
        /// should check the test item and all its children for changes.
        abstract onDidChangeTest: Event<TestsChangeEvent>
        /// Dispose of the observer, allowing the editor to eventually tell test
        /// providers that they no longer need to update tests.
        abstract dispose: unit -> unit

    type [<AllowNullLiteral>] TestsChangeEvent =
        /// List of all tests that are newly added.
        abstract added: ReadonlyArray<TestItem>
        /// List of existing tests that have updated.
        abstract updated: ReadonlyArray<TestItem>
        /// List of existing tests that have been removed.
        abstract removed: ReadonlyArray<TestItem>

    /// A test item is an item shown in the "test explorer" view. It encompasses
    /// both a suite and a test, since they have almost or identical capabilities.
    type [<AllowNullLiteral>] TestItem =
        /// Marks the test as outdated. This can happen as a result of file changes,
        /// for example. In "auto run" mode, tests that are outdated will be
        /// automatically rerun after a short delay. Invoking this on a
        /// test with children will mark the entire subtree as outdated.
        /// 
        /// Extensions should generally not override this method.
        abstract invalidateResults: unit -> unit

    /// <summary>
    /// TestResults can be provided to the editor in <see cref="tests.publishTestResult" />,
    /// or read from it in <see cref="tests.testResults" />.
    /// 
    /// The results contain a 'snapshot' of the tests at the point when the test
    /// run is complete. Therefore, information such as its <see cref="Range" /> may be
    /// out of date. If the test still exists in the workspace, consumers can use
    /// its <c>id</c> to correlate the result instance with the living test.
    /// </summary>
    type [<AllowNullLiteral>] TestRunResult =
        /// Unix milliseconds timestamp at which the test run was completed.
        abstract completedAt: float
        /// Optional raw output from the test run.
        abstract output: string option
        /// <summary>
        /// List of test results. The items in this array are the items that
        /// were passed in the <see cref="tests.runTests" /> method.
        /// </summary>
        abstract results: ReadonlyArray<obj>

    /// <summary>
    /// A <see cref="TestItem" />-like interface with an associated result, which appear
    /// or can be provided in <see cref="TestResult" /> interfaces.
    /// </summary>
    type [<AllowNullLiteral>] TestResultSnapshot =
        /// Unique identifier that matches that of the associated TestItem.
        /// This is used to correlate test results and tests in the document with
        /// those in the workspace (test explorer).
        abstract id: string
        /// Parent of this item.
        abstract parent: TestResultSnapshot option
        /// URI this TestItem is associated with. May be a file or file.
        abstract uri: Uri option
        /// Display name describing the test case.
        abstract label: string
        /// Optional description that appears next to the label.
        abstract description: string option
        /// <summary>
        /// Location of the test item in its <c>uri</c>. This is only meaningful if the
        /// <c>uri</c> points to a file.
        /// </summary>
        abstract range: Range option
        /// State of the test in each task. In the common case, a test will only
        /// be executed in a single task and the length of this array will be 1.
        abstract taskStates: ReadonlyArray<TestSnapshotTaskState>
        /// Optional list of nested tests for this item.
        abstract children: ResizeArray<obj>

    type [<AllowNullLiteral>] TestSnapshotTaskState =
        /// Current result of the test.
        abstract state: TestResultState
        /// <summary>
        /// The number of milliseconds the test took to run. This is set once the
        /// <c>state</c> is <c>Passed</c>, <c>Failed</c>, or <c>Errored</c>.
        /// </summary>
        abstract duration: float option
        /// Associated test run message. Can, for example, contain assertion
        /// failure information if the test fails.
        abstract messages: ReadonlyArray<obj>

    /// Possible states of tests in a test run.
    type [<RequireQualifiedAccess>] TestResultState =
        | Queued = 1
        | Running = 2
        | Passed = 3
        | Failed = 4
        | Skipped = 5
        | Errored = 6

    /// <summary>
    /// Details if an <c>ExternalUriOpener</c> can open a uri.
    /// 
    /// The priority is also used to rank multiple openers against each other and determine
    /// if an opener should be selected automatically or if the user should be prompted to
    /// select an opener.
    /// 
    /// The editor will try to use the best available opener, as sorted by <c>ExternalUriOpenerPriority</c>.
    /// If there are multiple potential "best" openers for a URI, then the user will be prompted
    /// to select an opener.
    /// </summary>
    type [<RequireQualifiedAccess>] ExternalUriOpenerPriority =
        /// The opener is disabled and will never be shown to users.
        /// 
        /// Note that the opener can still be used if the user specifically
        /// configures it in their settings.
        | None = 0
        /// <summary>
        /// The opener can open the uri but will not cause a prompt on its own
        /// since the editor always contributes a built-in <c>Default</c> opener.
        /// </summary>
        | Option = 1
        /// <summary>
        /// The opener can open the uri.
        /// 
        /// The editor's built-in opener has <c>Default</c> priority. This means that any additional <c>Default</c>
        /// openers will cause the user to be prompted to select from a list of all potential openers.
        /// </summary>
        | Default = 2
        /// The opener can open the uri and should be automatically selected over any
        /// default openers, include the built-in one from the editor.
        /// 
        /// A preferred opener will be automatically selected if no other preferred openers
        /// are available. If multiple preferred openers are available, then the user
        /// is shown a prompt with all potential openers (not just preferred openers).
        | Preferred = 3

    /// <summary>
    /// Handles opening uris to external resources, such as http(s) links.
    /// 
    /// Extensions can implement an <c>ExternalUriOpener</c> to open <c>http</c> links to a webserver
    /// inside of the editor instead of having the link be opened by the web browser.
    /// 
    /// Currently openers may only be registered for <c>http</c> and <c>https</c> uris.
    /// </summary>
    type [<AllowNullLiteral>] ExternalUriOpener =
        /// <summary>Check if the opener can open a uri.</summary>
        /// <param name="uri">
        /// The uri being opened. This is the uri that the user clicked on. It has
        /// not yet gone through port forwarding.
        /// </param>
        /// <param name="token">Cancellation token indicating that the result is no longer needed.</param>
        /// <returns>Priority indicating if the opener can open the external uri.</returns>
        abstract canOpenExternalUri: uri: Uri * token: CancellationToken -> U2<ExternalUriOpenerPriority, Thenable<ExternalUriOpenerPriority>>
        /// <summary>
        /// Open a uri.
        /// 
        /// This is invoked when:
        /// 
        /// - The user clicks a link which does not have an assigned opener. In this case, first <c>canOpenExternalUri</c>
        ///    is called and if the user selects this opener, then <c>openExternalUri</c> is called.
        /// - The user sets the default opener for a link in their settings and then visits a link.
        /// </summary>
        /// <param name="resolvedUri">
        /// The uri to open. This uri may have been transformed by port forwarding, so it
        /// may not match the original uri passed to <c>canOpenExternalUri</c>. Use <c>ctx.originalUri</c> to check the
        /// original uri.
        /// </param>
        /// <param name="ctx">Additional information about the uri being opened.</param>
        /// <param name="token">Cancellation token indicating that opening has been canceled.</param>
        /// <returns>Thenable indicating that the opening has completed.</returns>
        abstract openExternalUri: resolvedUri: Uri * ctx: OpenExternalUriContext * token: CancellationToken -> U2<Thenable<unit>, unit>

    /// Additional information about the uri being opened.
    type [<AllowNullLiteral>] OpenExternalUriContext =
        /// <summary>
        /// The uri that triggered the open.
        /// 
        /// This is the original uri that the user clicked on or that was passed to <c>openExternal.</c>
        /// Due to port forwarding, this may not match the <c>resolvedUri</c> passed to <c>openExternalUri</c>.
        /// </summary>
        abstract sourceUri: Uri

    /// <summary>Additional metadata about a registered <c>ExternalUriOpener</c>.</summary>
    type [<AllowNullLiteral>] ExternalUriOpenerMetadata =
        /// <summary>
        /// List of uri schemes the opener is triggered for.
        /// 
        /// Currently only <c>http</c> and <c>https</c> are supported.
        /// </summary>
        abstract schemes: ResizeArray<string>
        /// Text displayed to the user that explains what the opener does.
        /// 
        /// For example, 'Open in browser preview'
        abstract label: string

    type [<AllowNullLiteral>] OpenExternalOptions =
        /// <summary>
        /// Allows using openers contributed by extensions through  <c>registerExternalUriOpener</c>
        /// when opening the resource.
        /// 
        /// If <c>true</c>, the editor will check if any contributed openers can handle the
        /// uri, and fallback to the default opener behavior.
        /// 
        /// If it is string, this specifies the id of the <c>ExternalUriOpener</c>
        /// that should be used if it is available. Use <c>'default'</c> to force the editor's
        /// standard external opener to be used.
        /// </summary>
        abstract allowContributedOpeners: U2<bool, string> option

    /// Represents a tab within the window
    type [<AllowNullLiteral>] Tab =
        /// The text displayed on the tab
        abstract label: string
        /// The index of the tab within the column
        abstract index: float
        /// The column which the tab belongs to
        abstract viewColumn: ViewColumn
        /// The resource represented by the tab if availble.
        /// Note: Not all tabs have a resource associated with them.
        abstract resource: Uri option
        /// <summary>
        /// The identifier of the view contained in the tab
        /// This is equivalent to <c>viewType</c> for custom editors and <c>notebookType</c> for notebooks.
        /// The built-in text editor has an id of 'default' for all configurations.
        /// </summary>
        abstract viewId: string option
        /// <summary>
        /// All the resources and viewIds represented by a tab
        /// <see cref="Tab.resource">resource</see> and <see cref="Tab.viewId">viewId</see> will
        /// always be at index 0.
        /// </summary>
        abstract additionalResourcesAndViewIds: ResizeArray<TabAdditionalResourcesAndViewIds> with get, set
        /// Whether or not the tab is currently active
        /// Dictated by being the selected tab in the active group
        abstract isActive: bool
        /// <summary>
        /// Moves a tab to the given index within the column.
        /// If the index is out of range, the tab will be moved to the end of the column.
        /// If the column is out of range, a new one will be created after the last existing column.
        /// </summary>
        /// <param name="index">The index to move the tab to</param>
        /// <param name="viewColumn">The column to move the tab into</param>
        abstract move: index: float * viewColumn: ViewColumn -> Thenable<unit>
        /// Closes the tab. This makes the tab object invalid and the tab
        /// should no longer be used for further actions.
        abstract close: unit -> Thenable<unit>

    /// The object describing the properties of the workspace trust request
    type [<AllowNullLiteral>] WorkspaceTrustRequestOptions =
        /// Custom message describing the user action that requires workspace
        /// trust. If omitted, a generic message will be displayed in the workspace
        /// trust request dialog.
        abstract message: string option

    type [<RequireQualifiedAccess>] PortAutoForwardAction =
        | Notify = 1
        | OpenBrowser = 2
        | OpenPreview = 3
        | Silent = 4
        | Ignore = 5
        | OpenBrowserOnce = 6

    type [<AllowNullLiteral>] PortAttributes =
        /// The port number associated with this this set of attributes.
        abstract port: float with get, set
        /// The action to be taken when this port is detected for auto forwarding.
        abstract autoForwardAction: PortAutoForwardAction with get, set

    type [<AllowNullLiteral>] PortAttributesStatic =
        /// <summary>Creates a new PortAttributes object</summary>
        /// <param name="port">the port number</param>
        /// <param name="autoForwardAction">the action to take when this port is detected</param>
        [<EmitConstructor>] abstract Create: port: float * autoForwardAction: PortAutoForwardAction -> PortAttributes

    type [<AllowNullLiteral>] PortAttributesProvider =
        /// <summary>
        /// Provides attributes for the given port. For ports that your extension doesn't know about, simply
        /// return undefined. For example, if <c>providePortAttributes</c> is called with ports 3000 but your
        /// extension doesn't know anything about 3000 you should return undefined.
        /// </summary>
        abstract providePortAttributes: port: float * pid: float option * commandLine: string option * token: CancellationToken -> ProviderResult<PortAttributes>

    type InlineCompletionItemProvider =
        InlineCompletionItemProvider<InlineCompletionItem>

    type [<AllowNullLiteral>] InlineCompletionItemProvider<'T when 'T :> InlineCompletionItem> =
        /// <summary>
        /// Provides inline completion items for the given position and document.
        /// If inline completions are enabled, this method will be called whenever the user stopped typing.
        /// It will also be called when the user explicitly triggers inline completions or asks for the next or previous inline completion.
        /// Use <c>context.triggerKind</c> to distinguish between these scenarios.
        /// </summary>
        abstract provideInlineCompletionItems: document: TextDocument * position: Position * context: InlineCompletionContext * token: CancellationToken -> ProviderResult<U2<InlineCompletionList<'T>, ResizeArray<'T>>>

    type [<AllowNullLiteral>] InlineCompletionContext =
        /// How the completion was triggered.
        abstract triggerKind: InlineCompletionTriggerKind
        /// <summary>
        /// Provides information about the currently selected item in the autocomplete widget if it is visible.
        /// 
        /// If set, provided inline completions must extend the text of the selected item
        /// and use the same range, otherwise they are not shown as preview.
        /// As an example, if the document text is <c>console.</c> and the selected item is <c>.log</c> replacing the <c>.</c> in the document,
        /// the inline completion must also replace <c>.</c> and start with <c>.log</c>, for example <c>.log()</c>.
        /// 
        /// Inline completion providers are requested again whenever the selected item changes.
        /// 
        /// The user must configure <c>"editor.suggest.preview": true</c> for this feature.
        /// </summary>
        abstract selectedCompletionInfo: SelectedCompletionInfo option

    type [<AllowNullLiteral>] SelectedCompletionInfo =
        abstract range: Range with get, set
        abstract text: string with get, set

    /// <summary>How an <see cref="InlineCompletionItemProvider">inline completion provider</see> was triggered.</summary>
    type [<RequireQualifiedAccess>] InlineCompletionTriggerKind =
        /// Completion was triggered automatically while editing.
        /// It is sufficient to return a single completion item in this case.
        | Automatic = 0
        /// Completion was triggered explicitly by a user gesture.
        /// Return multiple completion items to enable cycling through them.
        | Explicit = 1

    type InlineCompletionList =
        InlineCompletionList<InlineCompletionItem>

    type [<AllowNullLiteral>] InlineCompletionList<'T when 'T :> InlineCompletionItem> =
        abstract items: ResizeArray<'T> with get, set

    type [<AllowNullLiteral>] InlineCompletionListStatic =
        [<EmitConstructor>] abstract Create: items: ResizeArray<'T> -> InlineCompletionList<'T>

    type [<AllowNullLiteral>] InlineCompletionItem =
        /// <summary>
        /// The text to replace the range with.
        /// 
        /// The text the range refers to should be a prefix of this value and must be a subword (<c>AB</c> and <c>BEF</c> are subwords of <c>ABCDEF</c>, but <c>Ab</c> is not).
        /// </summary>
        abstract text: string with get, set
        /// The range to replace.
        /// Must begin and end on the same line.
        /// 
        /// Prefer replacements over insertions to avoid cache invalidation:
        /// Instead of reporting a completion that inserts an extension at the end of a word,
        /// the whole word should be replaced with the extended word.
        abstract range: Range option with get, set
        /// <summary>An optional <see cref="Command" /> that is executed *after* inserting this completion.</summary>
        abstract command: Command option with get, set

    type [<AllowNullLiteral>] InlineCompletionItemStatic =
        [<EmitConstructor>] abstract Create: text: string * ?range: Range * ?command: Command -> InlineCompletionItem

    /// Be aware that this API will not ever be finalized.
    type [<AllowNullLiteral>] InlineCompletionController<'T when 'T :> InlineCompletionItem> =
        /// Is fired when an inline completion item is shown to the user.
        abstract onDidShowCompletionItem: Event<InlineCompletionItemDidShowEvent<'T>>

    /// Be aware that this API will not ever be finalized.
    type [<AllowNullLiteral>] InlineCompletionItemDidShowEvent<'T when 'T :> InlineCompletionItem> =
        abstract completionItem: 'T with get, set

    type [<AllowNullLiteral>] NotebookCellData =
        /// <summary>
        /// Mime type determines how the cell's <c>value</c> is interpreted.
        /// 
        /// The mime selects which notebook renders is used to render the cell.
        /// 
        /// If not set, internally the cell is treated as having a mime type of <c>text/plain</c>.
        /// Cells that set <c>language</c> to <c>markdown</c> instead are treated as <c>text/markdown</c>.
        /// </summary>
        abstract mime: string option with get, set

    type [<AllowNullLiteral>] NotebookCell =
        /// <summary>
        /// Mime type determines how the markup cell's <c>value</c> is interpreted.
        /// 
        /// The mime selects which notebook renders is used to render the cell.
        /// 
        /// If not set, internally the cell is treated as having a mime type of <c>text/plain</c>.
        /// Cells that set <c>language</c> to <c>markdown</c> instead are treated as <c>text/markdown</c>.
        /// </summary>
        abstract mime: string option with get, set

    type [<AllowNullLiteral>] TestRun =
        /// Test coverage provider for this result. An extension can defer setting
        /// this until after a run is complete and coverage is available.
        abstract coverageProvider: TestCoverageProvider option with get, set

    /// Provides information about test coverage for a test result.
    /// Methods on the provider will not be called until the test run is complete
    type TestCoverageProvider =
        TestCoverageProvider<FileCoverage>

    /// Provides information about test coverage for a test result.
    /// Methods on the provider will not be called until the test run is complete
    type [<AllowNullLiteral>] TestCoverageProvider<'T when 'T :> FileCoverage> =
        /// <summary>Returns coverage information for all files involved in the test run.</summary>
        /// <param name="token">A cancellation token.</param>
        /// <returns>Coverage metadata for all files involved in the test.</returns>
        abstract provideFileCoverage: token: CancellationToken -> ProviderResult<ResizeArray<'T>>
        /// <summary>
        /// Give a FileCoverage to fill in more data, namely <see cref="FileCoverage.detailedCoverage" />.
        /// The editor will only resolve a FileCoverage once, and onyl if detailedCoverage
        /// is undefined.
        /// </summary>
        /// <param name="coverage">A coverage object obtained from <see cref="provideFileCoverage" /></param>
        /// <param name="token">A cancellation token.</param>
        /// <returns>
        /// The resolved file coverage, or a thenable that resolves to one. It
        /// is OK to return the given <c>coverage</c>. When no result is returned, the
        /// given <c>coverage</c> will be used.
        /// </returns>
        abstract resolveFileCoverage: coverage: 'T * token: CancellationToken -> ProviderResult<'T>

    /// A class that contains information about a covered resource. A count can
    /// be give for lines, branches, and functions in a file.
    type [<AllowNullLiteral>] CoveredCount =
        /// Number of items covered in the file.
        abstract covered: float with get, set
        /// Total number of covered items in the file.
        abstract total: float with get, set

    /// A class that contains information about a covered resource. A count can
    /// be give for lines, branches, and functions in a file.
    type [<AllowNullLiteral>] CoveredCountStatic =
        /// <param name="covered">Value for <see cref="CovereredCount.covered" /></param>
        /// <param name="total">Value for <see cref="CovereredCount.total" /></param>
        [<EmitConstructor>] abstract Create: covered: float * total: float -> CoveredCount

    /// Contains coverage metadata for a file.
    type [<AllowNullLiteral>] FileCoverage =
        /// File URI.
        abstract uri: Uri
        /// Statement coverage information. If the reporter does not provide statement
        /// coverage information, this can instead be used to represent line coverage.
        abstract statementCoverage: CoveredCount with get, set
        /// Branch coverage information.
        abstract branchCoverage: CoveredCount option with get, set
        /// Function coverage information.
        abstract functionCoverage: CoveredCount option with get, set
        /// <summary>
        /// Detailed, per-statement coverage. If this is undefined, the editor will
        /// call <see cref="TestCoverageProvider.resolveFileCoverage" /> when necessary.
        /// </summary>
        abstract detailedCoverage: ResizeArray<DetailedCoverage> option with get, set

    /// Contains coverage metadata for a file.
    type [<AllowNullLiteral>] FileCoverageStatic =
        /// <summary>
        /// Creates a <see cref="FileCoverage" /> instance with counts filled in from
        /// the coverage details.
        /// </summary>
        /// <param name="uri">Covered file URI</param>
        /// <param name="detailed">Detailed coverage information</param>
        abstract fromDetails: uri: Uri * details: ResizeArray<DetailedCoverage> -> FileCoverage
        /// <param name="uri">Covered file URI</param>
        /// <param name="statementCoverage">
        /// Statement coverage information. If the reporter
        /// does not provide statement coverage information, this can instead be
        /// used to represent line coverage.
        /// </param>
        /// <param name="branchCoverage">Branch coverage information</param>
        /// <param name="functionCoverage">Function coverage information</param>
        [<EmitConstructor>] abstract Create: uri: Uri * statementCoverage: CoveredCount * ?branchCoverage: CoveredCount * ?functionCoverage: CoveredCount -> FileCoverage

    /// Contains coverage information for a single statement or line.
    type [<AllowNullLiteral>] StatementCoverage =
        /// The number of times this statement was executed. If zero, the
        /// statement will be marked as un-covered.
        abstract executionCount: float with get, set
        /// Statement location.
        abstract location: U2<Position, Range> with get, set
        /// Coverage from branches of this line or statement. If it's not a
        /// conditional, this will be empty.
        abstract branches: ResizeArray<BranchCoverage> with get, set

    /// Contains coverage information for a single statement or line.
    type [<AllowNullLiteral>] StatementCoverageStatic =
        /// <param name="location">The statement position.</param>
        /// <param name="executionCount">
        /// The number of times this statement was
        /// executed. If zero, the statement will be marked as un-covered.
        /// </param>
        /// <param name="branches">
        /// Coverage from branches of this line.  If it's not a
        /// conditional, this should be omitted.
        /// </param>
        [<EmitConstructor>] abstract Create: executionCount: float * location: U2<Position, Range> * ?branches: ResizeArray<BranchCoverage> -> StatementCoverage

    /// <summary>Contains coverage information for a branch of a <see cref="StatementCoverage" />.</summary>
    type [<AllowNullLiteral>] BranchCoverage =
        /// The number of times this branch was executed. If zero, the
        /// branch will be marked as un-covered.
        abstract executionCount: float with get, set
        /// Branch location.
        abstract location: U2<Position, Range> option with get, set

    /// <summary>Contains coverage information for a branch of a <see cref="StatementCoverage" />.</summary>
    type [<AllowNullLiteral>] BranchCoverageStatic =
        /// <param name="executionCount">The number of times this branch was executed.</param>
        /// <param name="location">The branch position.</param>
        [<EmitConstructor>] abstract Create: executionCount: float * ?location: U2<Position, Range> -> BranchCoverage

    /// Contains coverage information for a function or method.
    type [<AllowNullLiteral>] FunctionCoverage =
        /// The number of times this function was executed. If zero, the
        /// function will be marked as un-covered.
        abstract executionCount: float with get, set
        /// Function location.
        abstract location: U2<Position, Range> with get, set

    /// Contains coverage information for a function or method.
    type [<AllowNullLiteral>] FunctionCoverageStatic =
        /// <param name="executionCount">The number of times this function was executed.</param>
        /// <param name="location">The function position.</param>
        [<EmitConstructor>] abstract Create: executionCount: float * location: U2<Position, Range> -> FunctionCoverage

    type DetailedCoverage =
        U2<StatementCoverage, FunctionCoverage>

    type [<RequireQualifiedAccess>] LanguageStatusSeverity =
        | Information = 0
        | Warning = 1
        | Error = 2

    type [<AllowNullLiteral>] LanguageStatusItem =
        abstract id: string
        abstract selector: DocumentSelector with get, set
        abstract severity: LanguageStatusSeverity with get, set
        abstract name: string option with get, set
        abstract text: string with get, set
        abstract detail: string option with get, set
        abstract command: Command option with get, set
        abstract accessibilityInformation: AccessibilityInformation option with get, set
        abstract dispose: unit -> unit

    type [<AllowNullLiteral>] QuickPickItem =
        inherit Fable.Import.VSCode.Vscode.QuickPickItem
        abstract buttons: ResizeArray<QuickInputButton> option with get, set

    type [<AllowNullLiteral>] QuickPickItemButtonEvent<'T when 'T :> QuickPickItem> =
        abstract button: QuickInputButton with get, set
        abstract item: 'T with get, set

    type [<AllowNullLiteral>] MarkdownString =
        inherit Fable.Import.VSCode.Vscode.MarkdownString
        /// <summary>
        /// Indicates that this markdown string can contain raw html tags. Default to false.
        /// 
        /// When <c>supportHtml</c> is false, the markdown renderer will strip out any raw html tags
        /// that appear in the markdown text. This means you can only use markdown syntax for rendering.
        /// 
        /// When <c>supportHtml</c> is true, the markdown render will also allow a safe subset of html tags
        /// and attributes to be rendered. See <see href="https://github.com/microsoft/vscode/blob/6d2920473c6f13759c978dd89104c4270a83422d/src/vs/base/browser/markdownRenderer.ts#L296" />
        /// for a list of all supported tags and attributes.
        /// </summary>
        abstract supportHtml: bool option with get, set

    type [<AllowNullLiteral>] ResolvedOptionsExtensionHostEnv =
        [<EmitIndexer>] abstract Item: key: string -> string option with get, set

    type [<AllowNullLiteral>] TunnelOptionsRemoteAddress =
        abstract port: float with get, set
        abstract host: string with get, set

    type [<AllowNullLiteral>] RemoteAuthorityResolverTunnelFeatures =
        abstract elevation: bool with get, set
        [<Obsolete("Use privacy instead")>]
        abstract ``public``: bool with get, set
        /// One of the the options must have the ID "private".
        abstract privacyOptions: ResizeArray<TunnelPrivacy> with get, set

    type [<AllowNullLiteral>] AuthenticationGetSessionOptionsForceNewSession =
        abstract detail: string with get, set

    type [<StringEnum>] [<RequireQualifiedAccess>] ResourceLabelFormattingSeparator =
        | [<CompiledName "/">] ForwardSlash
        | [<CompiledName "\\">] Backslash
        | [<CompiledName "">] Empty

    type [<AllowNullLiteral>] DebugSessionOptionsDebugUI =
        /// When true, the debug toolbar will not be shown for this session, the window statusbar color will not be changed, and the debug viewlet will not be automatically revealed.
        abstract simple: bool option with get, set

    type [<AllowNullLiteral>] TreeDataTransferItems =
        abstract get: (string -> TreeDataTransferItem option) with get, set

    type [<AllowNullLiteral>] NotebookRegistrationDataFilenamePattern =
        abstract ``include``: GlobPattern with get, set
        abstract exclude: GlobPattern with get, set

    type [<AllowNullLiteral>] NotebookControllerOnDidReceiveMessageEvent =
        abstract editor: NotebookEditor with get, set
        abstract message: obj option with get, set

    type [<AllowNullLiteral>] TimelineItemIconPath =
        abstract light: Uri with get, set
        abstract dark: Uri with get, set

    type [<AllowNullLiteral>] TimelinePaging =
        /// <summary>
        /// A provider-defined cursor specifying the starting point of timeline items which are after the ones returned.
        /// Use <c>undefined</c> to signal that there are no more items to be returned.
        /// </summary>
        abstract cursor: string option

    type [<AllowNullLiteral>] TimelineOptionsLimit =
        abstract timestamp: float with get, set
        abstract id: string option with get, set

    type [<AllowNullLiteral>] TabAdditionalResourcesAndViewIds =
        abstract resource: Uri option with get, set
        abstract viewId: string option with get, set
