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

import { exists, mapValues } from '../runtime';
/**
 * 
 * @export
 * @interface CreateCommentLikeRequest
 */
export interface CreateCommentLikeRequest {
    /**
     * 
     * @type {string}
     * @memberof CreateCommentLikeRequest
     */
    commentId?: string;
    /**
     * 
     * @type {string}
     * @memberof CreateCommentLikeRequest
     */
    userId?: string;
}

/**
 * Check if a given object implements the CreateCommentLikeRequest interface.
 */
export function instanceOfCreateCommentLikeRequest(value: object): boolean {
    let isInstance = true;

    return isInstance;
}

export function CreateCommentLikeRequestFromJSON(json: any): CreateCommentLikeRequest {
    return CreateCommentLikeRequestFromJSONTyped(json, false);
}

export function CreateCommentLikeRequestFromJSONTyped(json: any, ignoreDiscriminator: boolean): CreateCommentLikeRequest {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'commentId': !exists(json, 'commentId') ? undefined : json['commentId'],
        'userId': !exists(json, 'userId') ? undefined : json['userId'],
    };
}

export function CreateCommentLikeRequestToJSON(value?: CreateCommentLikeRequest | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'commentId': value.commentId,
        'userId': value.userId,
    };
}

