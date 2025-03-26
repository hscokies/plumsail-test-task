import {defineConfig} from 'vite'
import path from 'path';
import vue from '@vitejs/plugin-vue'

// https://vite.dev/config/
export default defineConfig({
    plugins: [
        vue()
    ],
    resolve: {
        alias: {
            '@': path.resolve(__dirname, './src/'),
        },
    },
    server: {
        cors: false,
        port: process.env.API_URL || 3000,
        proxy: {
            '/api/': {
                target: process.env.API_URL || 'https://localhost:5001',
                changeOrigin: true,
                secure: true,
            },
        },
    },
})
