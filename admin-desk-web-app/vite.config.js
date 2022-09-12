import {
  defineConfig
} from 'vite'
import vue from '@vitejs/plugin-vue'

const path = require('path')

export default {
  plugins: [vue()],
  root: path.resolve(__dirname, 'src'),
  resolve: {
    alias: {
      '~bootstrap': path.resolve(__dirname, 'node_modules/bootstrap'),
    }
  },
  server: {
    port: 8080,
    hot: true
  }
}