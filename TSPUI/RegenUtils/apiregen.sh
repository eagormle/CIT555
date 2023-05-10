#!/bin/bash

# Set the URL of the Swagger data
SWAGGER_URL="http://localhost:7283/swagger/v1/swagger.json"

# Set the output directory
OUTPUT_DIR="./RegenUtils"

# Generate TypeScript-fetch code using the OpenAPI code generator
openapi-generator-cli generate -i $SWAGGER_URL --skip-validate-spec --generator-name typescript-fetch --type-mappings DateTimeOffset=string --additional-properties=typescriptThreePlus=true -o $OUTPUT_DIR

# All of this should be stored in current running directory
# Use these values insead of direct fetch api calls
# This script is broken, please run the floowing command in cli in proper directory: api-generator-cli generate -i http://localhost:5264/swagger/v1/swagger.json --skip-validate-spec --generator-name typescript-fetch --type-mappings DateTimeOffset=string --additional-properties=typescriptThreePlus=true
