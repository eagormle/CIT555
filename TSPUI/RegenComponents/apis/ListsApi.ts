/* tslint:disable */
/* eslint-disable */
/**
 * PackAPI
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 1.0
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


import * as runtime from '../runtime';
import type {
  CreateListRequest,
  List,
} from '../models';
import {
    CreateListRequestFromJSON,
    CreateListRequestToJSON,
    ListFromJSON,
    ListToJSON,
} from '../models';

export interface ApiListsIdDeleteRequest {
    id: string;
}

export interface ApiListsIdGetRequest {
    id: string;
}

export interface ApiListsIdPutRequest {
    id: string;
    list?: List;
}

export interface ApiListsPostRequest {
    createListRequest?: CreateListRequest;
}

export interface ApiListsUserUsernameGetRequest {
    username: string;
}

/**
 * 
 */
export class ListsApi extends runtime.BaseAPI {

    /**
     */
    async apiListsIdDeleteRaw(requestParameters: ApiListsIdDeleteRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<void>> {
        if (requestParameters.id === null || requestParameters.id === undefined) {
            throw new runtime.RequiredError('id','Required parameter requestParameters.id was null or undefined when calling apiListsIdDelete.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        const response = await this.request({
            path: `/api/lists/{id}`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters.id))),
            method: 'DELETE',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.VoidApiResponse(response);
    }

    /**
     */
    async apiListsIdDelete(requestParameters: ApiListsIdDeleteRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<void> {
        await this.apiListsIdDeleteRaw(requestParameters, initOverrides);
    }

    /**
     */
    async apiListsIdGetRaw(requestParameters: ApiListsIdGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<List>> {
        if (requestParameters.id === null || requestParameters.id === undefined) {
            throw new runtime.RequiredError('id','Required parameter requestParameters.id was null or undefined when calling apiListsIdGet.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        const response = await this.request({
            path: `/api/lists/{id}`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters.id))),
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => ListFromJSON(jsonValue));
    }

    /**
     */
    async apiListsIdGet(requestParameters: ApiListsIdGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<List> {
        const response = await this.apiListsIdGetRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiListsIdPutRaw(requestParameters: ApiListsIdPutRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<void>> {
        if (requestParameters.id === null || requestParameters.id === undefined) {
            throw new runtime.RequiredError('id','Required parameter requestParameters.id was null or undefined when calling apiListsIdPut.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        headerParameters['Content-Type'] = 'application/json';

        const response = await this.request({
            path: `/api/lists/{id}`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters.id))),
            method: 'PUT',
            headers: headerParameters,
            query: queryParameters,
            body: ListToJSON(requestParameters.list),
        }, initOverrides);

        return new runtime.VoidApiResponse(response);
    }

    /**
     */
    async apiListsIdPut(requestParameters: ApiListsIdPutRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<void> {
        await this.apiListsIdPutRaw(requestParameters, initOverrides);
    }

    /**
     */
    async apiListsPostRaw(requestParameters: ApiListsPostRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<void>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        headerParameters['Content-Type'] = 'application/json';

        const response = await this.request({
            path: `/api/lists`,
            method: 'POST',
            headers: headerParameters,
            query: queryParameters,
            body: CreateListRequestToJSON(requestParameters.createListRequest),
        }, initOverrides);

        return new runtime.VoidApiResponse(response);
    }

    /**
     */
    async apiListsPost(requestParameters: ApiListsPostRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<void> {
        await this.apiListsPostRaw(requestParameters, initOverrides);
    }

    /**
     */
    async apiListsUserUsernameGetRaw(requestParameters: ApiListsUserUsernameGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<void>> {
        if (requestParameters.username === null || requestParameters.username === undefined) {
            throw new runtime.RequiredError('username','Required parameter requestParameters.username was null or undefined when calling apiListsUserUsernameGet.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        const response = await this.request({
            path: `/api/lists/user/{username}`.replace(`{${"username"}}`, encodeURIComponent(String(requestParameters.username))),
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.VoidApiResponse(response);
    }

    /**
     */
    async apiListsUserUsernameGet(requestParameters: ApiListsUserUsernameGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<void> {
        await this.apiListsUserUsernameGetRaw(requestParameters, initOverrides);
    }

}
