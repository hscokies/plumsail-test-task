import * as httpClient from "@/shared/api/http-client.js";
import {CONTENT_TYPE, HTTP} from "@/shared/api/http-client.js";

export const submit = (data) => httpClient.MakeRequest('/api/submissions', HTTP.POST, CONTENT_TYPE.JSON, data);