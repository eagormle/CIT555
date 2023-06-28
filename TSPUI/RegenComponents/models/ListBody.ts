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
 * @interface ListBody
 */
export interface ListBody {
    /**
     * 
     * @type {string}
     * @memberof ListBody
     */
    listBodyId?: string;
    /**
     * 
     * @type {string}
     * @memberof ListBody
     */
    listId?: string;
    /**
     * 
     * @type {string}
     * @memberof ListBody
     */
    userId?: string;
    /**
     * 
     * @type {string}
     * @memberof ListBody
     */
    listBodyText?: string | null;
    /**
     * 
     * @type {Date}
     * @memberof ListBody
     */
    createdAt?: Date;
}

/**
 * Check if a given object implements the ListBody interface.
 */
export function instanceOfListBody(value: object): boolean {
    let isInstance = true;

    return isInstance;
}

export function ListBodyFromJSON(json: any): ListBody {
    return ListBodyFromJSONTyped(json, false);
}

export function ListBodyFromJSONTyped(json: any, ignoreDiscriminator: boolean): ListBody {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'listBodyId': !exists(json, 'listBodyId') ? undefined : json['listBodyId'],
        'listId': !exists(json, 'listId') ? undefined : json['listId'],
        'userId': !exists(json, 'userId') ? undefined : json['userId'],
        'listBodyText': !exists(json, 'listBodyText') ? undefined : json['listBodyText'],
        'createdAt': !exists(json, 'createdAt') ? undefined : (new Date(json['createdAt'])),
    };
}

export function ListBodyToJSON(value?: ListBody | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'listBodyId': value.listBodyId,
        'listId': value.listId,
        'userId': value.userId,
        'listBodyText': value.listBodyText,
        'createdAt': value.createdAt === undefined ? undefined : (value.createdAt.toISOString()),
    };
}
