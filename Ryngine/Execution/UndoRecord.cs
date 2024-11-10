namespace Ryngine.Execution
{
    public class UndoRecord(
        UndoRecordId previousUndoRecordId,
        UndoRecordId currentUndoRecordId,
        UndoPacket undoPacket)
    {
        public static UndoRecord RootRecord => new(0, 0, []);

        // TODO: We can probably get away with using 64 bit hashes instead.
        //       For 64 bits, birthday paradox puts 50% chance at ~2^32.
        public UndoRecordId PreviousUndoRecordId { get; } = previousUndoRecordId;
        public UndoRecordId Hash { get; } = currentUndoRecordId;
        public UndoPacket UndoPacket { get; set; } = undoPacket;
    }
}
