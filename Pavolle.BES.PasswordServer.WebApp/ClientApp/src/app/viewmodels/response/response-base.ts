export interface ResponseBase {
  success: boolean;
  errorMessage: string | null;
  successMessage: string | null;
  infoMessage: string | null;
  warningMessage: string | null;
  statusCode: number;
}
