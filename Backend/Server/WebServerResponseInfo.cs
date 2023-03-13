namespace Dawn.Server;

public record WebServerResponseInfo(byte[] data, SolverContentCtx ctx, int code);
public record SolverContentCtx(string contenttype, int buildertype);