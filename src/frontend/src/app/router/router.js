import {createRouter, createWebHistory} from 'vue-router'
import {FormPage, FormsDashboard} from '@/pages';
import {ROUTES} from "@/app/router/routes.js";

export const router = createRouter({
    history: createWebHistory(),
    routes: [
        {
            path: ROUTES.Dashboard,
            component: FormsDashboard,
        },
        {
            path: ROUTES.Form + '/:id',
            component: FormPage,
        }
    ]
})