export const AuthenticationConstants={
    USERNAME_MIN_LENGTH:6,
    PASSWORD_MIN_LENGTH:8,
    EMAIL_REGEX:`.+\@.+\..+`,
}

export const AuthenticationMessage={
    USERNAME_TOO_SHORT:'Your username must be atleast 6 symbols',
    PASSWORD_TOO_SHORT:`Your password must contain atleast 8 symbols`,
    EMAIL_INVALID:`Invalid email`,
}