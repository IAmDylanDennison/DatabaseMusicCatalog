"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.AuthInterceptor = void 0;
var AuthInterceptor = /** @class */ (function () {
    function AuthInterceptor(authService) {
        this.authService = authService;
    }
    AuthInterceptor.prototype.intercept = function (req, next) {
        var token = this.authService.getToken();
        if (token) {
            var header = "Bearer " + token;
            var reqWithAuth = req.clone({ headers: req.headers.set("Authorization", header) });
            return next.handle(reqWithAuth);
        }
        return next.handle(req);
    };
    return AuthInterceptor;
}());
exports.AuthInterceptor = AuthInterceptor;
//# sourceMappingURL=auth-interceptor.js.map