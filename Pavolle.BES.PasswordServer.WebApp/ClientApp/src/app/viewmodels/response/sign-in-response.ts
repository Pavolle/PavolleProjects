import { UserAuthorizationViewData } from "../viewdata/user-authorization-view-data";
import { ResponseBase } from "./response-base";

export interface SignInResponse extends ResponseBase {
  token: string;
  name: string;
  surname: string;
  authorizations: UserAuthorizationViewData[];
}
