import * as httpClient from "./http-client.js";

export const getById = (id) => httpClient.MakeRequest(`/api/forms/${id}`)