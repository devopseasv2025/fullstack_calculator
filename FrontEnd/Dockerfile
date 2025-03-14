# Step 1: Use an official Node.js image as the base image
FROM node:18 AS build

# Step 2: Set the working directory inside the container
WORKDIR /app

# Step 3: Copy package.json and package-lock.json (or yarn.lock) before installing dependencies
COPY package.json package-lock.json ./

# Step 4: Install dependencies
RUN npm ci

# Step 5: Copy the rest of the project files
COPY . .

# Step 6: Ensure dependencies are installed again (to avoid missing packages)


# Step 7: Build the app using Vite (production build)
RUN npm run build

# Step 8: Use a smaller Nginx image to serve the built app
FROM nginx:alpine

# Step 9: Copy the built assets from the previous step to the Nginx container
COPY --from=build /app/dist /usr/share/nginx/html

# Step 10: Expose port 80 (default for HTTP)
EXPOSE 80

# Step 11: Start Nginx server
CMD ["nginx", "-g", "daemon off;"]
