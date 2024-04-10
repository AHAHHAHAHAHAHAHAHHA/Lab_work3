using System;
using System.Collections.Generic;

class Photo
{
    public string Title { get; set; }

    public Photo(string title)
    {
        Title = title;
    }

    public override string ToString()
    {
        return Title;
    }
}

class Page
{
    private List<Photo> photos;

    public Page()
    {
        photos = new List<Photo>();
    }

    public void AddPhoto(Photo photo)
    {
        photos.Add(photo);
    }

    public override string ToString()
    {
        return $"Number of photos on the page: {photos.Count}";
    }
}

class PhotoAlbum
{
    private List<Page> pages;

    public PhotoAlbum()
    {
        pages = new List<Page>();
    }

    public void AddPage(Page page)
    {
        pages.Add(page);
    }

    public override string ToString()
    {
        return $"Number of pages in the photo album: {pages.Count}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Photo photo1 = new Photo("Family Vacation");
        Photo photo2 = new Photo("Nature Scenery");

        Page page1 = new Page();
        page1.AddPhoto(photo1);
        page1.AddPhoto(photo2);

        PhotoAlbum album = new PhotoAlbum();
        album.AddPage(page1);
        
        Console.WriteLine(page1);
        
        Console.WriteLine(album);
    }
}
