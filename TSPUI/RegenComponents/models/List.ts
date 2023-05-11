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
 * @interface List
 */
export interface List {
    /**
     * 
     * @type {string}
     * @memberof List
     */
    listId?: string;
    /**
     * 
     * @type {string}
     * @memberof List
     */
    userId?: string;
    /**
     * 
     * @type {string}
     * @memberof List
     */
    listName?: string | null;
    /**
     * 
     * @type {Date}
     * @memberof List
     */
    createdAt?: Date;
}

/**
 * Check if a given object implements the List interface.
 */
export function instanceOfList(value: object): boolean {
    let isInstance = true;

    return isInstance;
}

export function ListFromJSON(json: any): List {
    return ListFromJSONTyped(json, false);
}

export function ListFromJSONTyped(json: any, ignoreDiscriminator: boolean): List {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'listId': !exists(json, 'listId') ? undefined : json['listId'],
        'userId': !exists(json, 'userId') ? undefined : json['userId'],
        'listName': !exists(json, 'listName') ? undefined : json['listName'],
        'createdAt': !exists(json, 'createdAt') ? undefined : (new Date(json['createdAt'])),
    };
}

export function ListToJSON(value?: List | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'listId': value.listId,
        'userId': value.userId,
        'listName': value.listName,
        'createdAt': value.createdAt === undefined ? undefined : (value.createdAt.toISOString()),
    };
}

