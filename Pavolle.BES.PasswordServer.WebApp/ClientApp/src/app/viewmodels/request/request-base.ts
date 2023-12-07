import { ELanguage } from "../enums/e-language.enum";

export interface RequestBase {
    language: ELanguage | null;
}
