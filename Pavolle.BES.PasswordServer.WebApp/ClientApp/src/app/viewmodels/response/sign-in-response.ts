import { SingInUserDetailViewData } from "../viewdata/sign-in-user-detail-view-data";
import { UserAuthorizationViewData } from "../viewdata/user-authorization-view-data";
import { ResponseBase } from "./response-base";

export interface SignInResponse extends ResponseBase {
    token: string;
    authorizations: UserAuthorizationViewData[];
    userDetail: SingInUserDetailViewData;
}
