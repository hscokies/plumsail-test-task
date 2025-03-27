import * as httpClient from "./http-client.js";
import {CONTENT_TYPE, HTTP} from "./http-client.js";

export const getById = (id) => httpClient.MakeRequest(`/api/forms/${id}`)

export const getAll = (query = '') => httpClient.MakeRequest('/api/forms', HTTP.GET, CONTENT_TYPE.JSON, {Search: query});