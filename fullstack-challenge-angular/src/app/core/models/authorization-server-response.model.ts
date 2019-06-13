export interface Json {
    access_token: string;
    expires_in: number;
    token_type: string;
}

export interface AuthorizationServerResponse {
    accessToken: string;
    identityToken?: any;
    tokenType: string;
    refreshToken?: any;
    errorDescription?: any;
    expiresIn: number;
    raw: string;
    json: Json;
    exception?: any;
    isError: boolean;
    errorType: number;
    httpStatusCode: number;
    httpErrorReason?: any;
    error?: any;
}