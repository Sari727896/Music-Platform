ALTER TABLE SingerSongs
ADD CONSTRAINT FK_SingerSongs_Singer
FOREIGN KEY (SingerId) REFERENCES Singer(Id)

ALTER TABLE SingerSongs
ADD CONSTRAINT FK_SingerSongs_Song
FOREIGN KEY (SongId) REFERENCES Song(Id)

ALTER TABLE SubscriberSongs
ADD CONSTRAINT FK_SubscriberSongs_Subscriber
FOREIGN KEY (SubscriberId) REFERENCES Subscriber(Code)

ALTER TABLE SubscriberSongs
ADD CONSTRAINT FK_SubscriberSongs_Song
FOREIGN KEY (SongId) REFERENCES Song(Id)