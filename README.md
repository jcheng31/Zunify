Zunify
======

A tool to parse Zune playlists (.zpl) and export them to a more human-readable format. That's what it does now, at least - the ultimate goal here is to allow them to be imported into Spotify.

Right now, it converts Zune playlists to text listings of all the songs within. These can be specified using a custom string, with the following format specifiers:

	$Title - Track title
	$Artist - Track artist
	$AlbumTitle - Album name
	$AlbumArtist - Album artist

For instance, `$Title - $Artist`. (At the moment, strings like `$Title, $AlbumTitle, $AlbumArtist` don't work.)