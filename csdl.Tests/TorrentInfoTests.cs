// csdl - a cross-platform libtorrent wrapper for .NET
// Licensed under Apache-2.0 - see the license file for more information

using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace csdl.Tests;

public class TorrentInfoTests
{
    [Theory]
    [InlineData("big-buck-bunny.torrent", "Big Buck Bunny", 3)]
    [InlineData("ubuntu-20.04.6-live-server-amd64.iso.torrent", "ubuntu-20.04.6-live-server-amd64.iso", 1)]
    [InlineData("magnet:?xt=urn:btih:dd8255ecdc7ca55fb0bbf81323d87062db1f6d1c&dn=Big%20Buck%20Bunny&tr=udp%3A%2F%2Ftracker.leechers-paradise.org%3A6969&tr=udp%3A%2F%2Ftracker.coppersurfer.tk%3A6969&tr=udp%3A%2F%2Ftracker.opentrackr.org%3A1337&tr=udp%3A%2F%2Fexplodie.org%3A6969&tr=udp%3A%2F%2Ftracker.empire-js.us%3A1337&tr=wss%3A%2F%2Ftracker.btorrent.xyz&tr=wss%3A%2F%2Ftracker.openwebtorrent.com&tr=wss%3A%2F%2Ftracker.fastcast.nz&ws=https://webtorrent.io/torrents/", "Big Buck Bunny", 3)]
    public async Task TestTorrentParsing(string fileName, string expectedName, int expectedFileCount)
    {
        var file = Path.GetFullPath(Path.Combine("files", fileName));
        var torrentBytes = await File.ReadAllBytesAsync(file);
        var torrentMagnet = "magnet:?xt=urn:btih:dd8255ecdc7ca55fb0bbf81323d87062db1f6d1c&dn=Big%20Buck%20Bunny&tr=udp%3A%2F%2Ftracker.leechers-paradise.org%3A6969&tr=udp%3A%2F%2Ftracker.coppersurfer.tk%3A6969&tr=udp%3A%2F%2Ftracker.opentrackr.org%3A1337&tr=udp%3A%2F%2Fexplodie.org%3A6969&tr=udp%3A%2F%2Ftracker.empire-js.us%3A1337&tr=wss%3A%2F%2Ftracker.btorrent.xyz&tr=wss%3A%2F%2Ftracker.openwebtorrent.com&tr=wss%3A%2F%2Ftracker.fastcast.nz&ws=https://webtorrent.io/torrents/";

        var torrentFromFile = new TorrentInfo(file);
        var torrentFromBytes = new TorrentInfo(torrentBytes);
        var torrentFromMagnet = new TorrentInfo(torrentMagnet);

        // name check
        Assert.Equal(expectedName, torrentFromFile.Metadata.Name);
        Assert.Equal(expectedName, torrentFromMagnet.Metadata.Name);

        // metadata check
        Assert.Equal(torrentFromFile.Metadata, torrentFromBytes.Metadata);

        // file count
        Assert.Equal(expectedFileCount, torrentFromFile.Files.Count);

        // file equality
        var fromFileNames = torrentFromFile.Files.Select(x => x.Path).ToHashSet();
        var fromBytesNames = torrentFromBytes.Files.Select(x => x.Path).ToHashSet();

        Assert.True(fromFileNames.SetEquals(fromBytesNames));
    }
}