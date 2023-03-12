namespace Dawn.Server;

public record WebServerResponseInfo(byte[] data, SolverContentCtx ctx);
public record SolverContentCtx(string contenttype, int buildertype);