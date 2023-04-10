import commonjs from '@rollup/plugin-commonjs';
import resolve from '@rollup/plugin-node-resolve';

export default {
  input: 'es6-polyfills-source.js',
  output: {
    file: 'Resources/es6-polyfills.js',
    format: 'iife',
    indent: '  ',
    generatedCode: 'es5'
  },
  plugins: [
    commonjs({
      include: ['node_modules/**'],
      ignoreGlobal: true,
      transformMixedEsModules: true
    }),
    resolve()
  ]
};