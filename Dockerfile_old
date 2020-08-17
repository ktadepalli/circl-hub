FROM node:10.20.1-alpine as builder
WORKDIR /app
COPY package.json ./
RUN npm install 
COPY . .
EXPOSE 3000
#CMD ["npm","start"]
