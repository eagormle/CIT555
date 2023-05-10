#!/bin/bash

# Set the URL of the Swagger data
SWAGGER_URL="https://localhost:7283/swagger/v1/swagger.json"

# Set the output directory
OUTPUT_DIR="./RegenUtils"

# Generate TypeScript-fetch code using the OpenAPI code generator
openapi-generator-cli generate \
  -i "${SWAGGER_URL}" \
  -g typescript-fetch \
  -o "${OUTPUT_DIR}"
