export const HTTP = {
    GET: 'GET',
    POST: 'POST',
}

export const CONTENT_TYPE = {
    JSON: 'application/json',
}


export const MakeRequest = async (
    path,
    method = HTTP.GET,
    contentType = CONTENT_TYPE.JSON,
    body) => {
    const options = {
        method,
        headers: {
            'Content-Type': contentType,
        },
        body: null
    };

    const query = new URLSearchParams();

    if (body && method === HTTP.GET) {
        Object.keys(body).forEach(key => {
            query.append(key, body[key]);
        })
    } else if (body && method === HTTP.POST) {
        {
            options.body = JSON.stringify(body);
        }
    }

    const requestUrl = query.size > 0
        ? `${path}?${query}`
        : `${path}`;

    const response = await fetch(requestUrl, options);
    const json = await response.json();
    if (!response.ok) {
        throw json;
    }
    return json;
};

