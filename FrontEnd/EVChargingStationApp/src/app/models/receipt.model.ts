export interface Receipt {
    transactionId: number
    username: string
    chargingSocketId: number
    siteName: string
    chargesPerHr: number
    startTime: string
    endTime: string
    duration: number
    totalAmount: number
}