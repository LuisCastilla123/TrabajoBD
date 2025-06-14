export interface loginResponse{
    UsarNmae : string;
    email : string;
    token : string;
}

export interface SignInRequest
{
userName : string;
email : string;
phoneNumber: string;
location : string;
about? : string;
password : string;
}
 