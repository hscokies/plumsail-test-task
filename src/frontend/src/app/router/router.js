import {createRouter, createWebHistory} from 'vue-router'
import {FormPage, FormsDashboardPage, SubmissionsPage} from '@/pages';
import {ROUTES} from "@/app/router/routes.js";

export const router = createRouter({
    history: createWebHistory(),
    routes: [
        {
            path: ROUTES.Dashboard,
            component: FormsDashboardPage,
        },
        {
            path: ROUTES.Form + '/:id',
            component: FormPage,
        },
        {
            path: ROUTES.Submissions,
            component: SubmissionsPage,
        }
    ]
})