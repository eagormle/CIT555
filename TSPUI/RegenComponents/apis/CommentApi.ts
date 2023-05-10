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
  Comment,
  CreateCommentRequest,
} from '../models';
import {
    CommentFromJSON,
    CommentToJSON,
    CreateCommentRequestFromJSON,
    CreateCommentRequestToJSON,
} from '../models';

export interface ApiCommentIdDeleteRequest {
    id: string;
}

export interface ApiCommentIdGetRequest {
    id: string;
}

export interface ApiCommentIdPutRequest {
    id: string;
    comment?: Comment;
}

export interface ApiCommentListListIdGetRequest {
    listId: string;
}

export interface ApiCommentPostRequest {
    createCommentRequest?: CreateCommentRequest;
}

/**
 * 
 */
export class CommentApi extends runtime.BaseAPI {

    /**
     */
    async apiCommentIdDeleteRaw(requestParameters: ApiCommentIdDeleteRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<void>> {
        if (requestParameters.id === null || requestParameters.id === undefined) {
            throw new runtime.RequiredError('id','Required parameter requestParameters.id was null or undefined when calling apiCommentIdDelete.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        const response = await this.request({
            path: `/api/Comment/{id}`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters.id))),
            method: 'DELETE',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.VoidApiResponse(response);
    }

    /**
     */
    async apiCommentIdDelete(requestParameters: ApiCommentIdDeleteRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<void> {
        await this.apiCommentIdDeleteRaw(requestParameters, initOverrides);
    }

    /**
     */
    async apiCommentIdGetRaw(requestParameters: ApiCommentIdGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<Comment>> {
        if (requestParameters.id === null || requestParameters.id === undefined) {
            throw new runtime.RequiredError('id','Required parameter requestParameters.id was null or undefined when calling apiCommentIdGet.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        const response = await this.request({
            path: `/api/Comment/{id}`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters.id))),
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => CommentFromJSON(jsonValue));
    }

    /**
     */
    async apiCommentIdGet(requestParameters: ApiCommentIdGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<Comment> {
        const response = await this.apiCommentIdGetRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiCommentIdPutRaw(requestParameters: ApiCommentIdPutRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<void>> {
        if (requestParameters.id === null || requestParameters.id === undefined) {
            throw new runtime.RequiredError('id','Required parameter requestParameters.id was null or undefined when calling apiCommentIdPut.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        headerParameters['Content-Type'] = 'application/json';

        const response = await this.request({
            path: `/api/Comment/{id}`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters.id))),
            method: 'PUT',
            headers: headerParameters,
            query: queryParameters,
            body: CommentToJSON(requestParameters.comment),
        }, initOverrides);

        return new runtime.VoidApiResponse(response);
    }

    /**
     */
    async apiCommentIdPut(requestParameters: ApiCommentIdPutRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<void> {
        await this.apiCommentIdPutRaw(requestParameters, initOverrides);
    }

    /**
     */
    async apiCommentListListIdGetRaw(requestParameters: ApiCommentListListIdGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<Array<Comment>>> {
        if (requestParameters.listId === null || requestParameters.listId === undefined) {
            throw new runtime.RequiredError('listId','Required parameter requestParameters.listId was null or undefined when calling apiCommentListListIdGet.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        const response = await this.request({
            path: `/api/Comment/list/{listId}`.replace(`{${"listId"}}`, encodeURIComponent(String(requestParameters.listId))),
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => jsonValue.map(CommentFromJSON));
    }

    /**
     */
    async apiCommentListListIdGet(requestParameters: ApiCommentListListIdGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<Array<Comment>> {
        const response = await this.apiCommentListListIdGetRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiCommentPostRaw(requestParameters: ApiCommentPostRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<Comment>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        headerParameters['Content-Type'] = 'application/json';

        const response = await this.request({
            path: `/api/Comment`,
            method: 'POST',
            headers: headerParameters,
            query: queryParameters,
            body: CreateCommentRequestToJSON(requestParameters.createCommentRequest),
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => CommentFromJSON(jsonValue));
    }

    /**
     */
    async apiCommentPost(requestParameters: ApiCommentPostRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<Comment> {
        const response = await this.apiCommentPostRaw(requestParameters, initOverrides);
        return await response.value();
    }

}
