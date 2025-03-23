import {createRouter, createWebHistory} from 'vue-router'
import {FormPage} from '@/pages';
import {ROUTES} from "@/app/router/routes.js";

export const router = createRouter({
    history: createWebHistory(),
    routes: [
        {
            path: ROUTES.Form + '/:id',
            component: FormPage,
            name: 'Form',
        }
    ]
})