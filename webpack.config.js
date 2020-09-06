var path = require("path");
var nodeExternals = require('webpack-node-externals');

function resolve(filePath) {
  return path.join(__dirname, filePath)
}

var babelOptions = {
  presets: [
    ["@babel/preset-env", {
      "modules": false
    }]
  ],
  plugins: ["@babel/plugin-transform-runtime"]
}

module.exports = function(env, argv) {

  var isProduction = argv.mode == "production"
  console.log("Bundling for " + (isProduction ? "production" : "development") + "...");
  
  return {
    target: 'node',
    mode: isProduction ? "production" : "development",
    devtool: "source-map",
    entry: resolve('./src/Fable.Ionide.VSCode.Helpers.fsproj'),
    output: {
      filename: 'bundle.js',
      path: resolve('./release'),
    },
    resolve: {
      modules: [resolve("./node_modules/")]
    },
    // externals: [nodeExternals()],
    externals: {
    // Who came first the host or the plugin ?
    "vscode": "commonjs vscode",

    // Optional dependencies of ws
    "utf-8-validate": "commonjs utf-8-validate",
    "bufferutil": "commonjs bufferutil"
  },
    module: {
      rules: [
        {
          test: /\.fs(x|proj)?$/,
          use: {
            loader: "fable-loader",
            options: {
              babel: babelOptions,
              define: isProduction ? [] : ["DEBUG"]
            }
          }
        },
        {
          test: /\.js$/,
          exclude: /node_modules/,
          use: {
            loader: 'babel-loader',
            options: babelOptions
          },
        }
      ]
    }
  };
}
