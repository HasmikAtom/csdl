namespace csdl.Enums;

public enum PerformanceWarningType : byte
{
    OutstandingDiskBufferLimitReached = 0,
    OutstandingRequestLimitReached = 1,
    UploadLimitTooLow = 2,
    DownloadLimitTooLow = 3,
    SendBufferWatermarkTooLow = 4,
    TooManyOptimisticUnchokeSlots = 5,
    TooHighDiskQueueLimit = 6,
    AioLimitReached = 7,
    DeprecatedBittyrantWithNoUplimit = 8,
    TooFewOutgoingPorts = 9,
    TooFewFileDescriptors = 10
}