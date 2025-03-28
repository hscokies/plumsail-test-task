FROM bitnami/nginx:1.27.4 as base

WORKDIR /app
FROM bitnami/node:22.14.0 as build

WORKDIR /src
COPY package*.json ./
RUN npm install
COPY ./ .
RUN npm run build

FROM base as final
COPY --from=build /src/dist /app

COPY nginx.conf /opt/bitnami/nginx/conf/server_blocks/plumsail.conf
