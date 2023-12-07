import { RequestBase } from "./request-base";

export interface LoginRequest extends RequestBase {
    username: string;
    password: string;
}
