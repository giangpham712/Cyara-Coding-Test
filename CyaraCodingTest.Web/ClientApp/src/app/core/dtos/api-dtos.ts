export interface GenerateApiTokenRequest {
  appUrl: string
}

export interface ApiTokenGenerationResponse {
  apiToken: string
  validTo: Date
}

export interface AuthenticationResponse {
  accessToken: string
}