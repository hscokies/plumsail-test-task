import {createApp} from 'vue'
import '@/app/styles/global.css'
import App from './app'
import {router} from "@/app/router/index.js";
import { VueQueryPlugin } from '@tanstack/vue-query'


createApp(App)
    .use(router)
    .use(VueQueryPlugin)
    .mount('#app')
