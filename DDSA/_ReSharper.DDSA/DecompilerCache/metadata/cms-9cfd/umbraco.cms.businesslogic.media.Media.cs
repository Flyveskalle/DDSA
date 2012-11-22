// Type: umbraco.cms.businesslogic.media.Media
// Assembly: cms, Version=1.0.4695.30696, Culture=neutral
// Assembly location: C:\Projects\DDSA\DDSA\ExternalDependencies\Umbraco4.10\cms.dll

using System;
using System.Collections;
using System.Collections.Generic;
using umbraco.BusinessLogic;
using umbraco.cms.businesslogic;
using umbraco.DataLayer;

namespace umbraco.cms.businesslogic.media
{
    public class Media : Content
    {
        #region Delegates

        public delegate void DeleteEventHandler(Media sender, DeleteEventArgs e);

        public delegate void MoveToTrashEventHandler(Media sender, MoveToTrashEventArgs e);

        public delegate void NewEventHandler(Media sender, NewEventArgs e);

        public delegate void SaveEventHandler(Media sender, SaveEventArgs e);

        #endregion

        public static Guid _objectType;
        public Media(int id);
        public Media(Guid id);
        public Media(int id, bool noSetup);
        public Media(Guid id, bool noSetup);
        public new Media[] Children { get; }
        public static Media MakeNew(string Name, MediaType dct, User u, int ParentId);
        public static Media[] GetRootMedias();
        public static List<Media> GetChildrenForTree(int nodeId);
        public static IEnumerable<Media> GetMediaOfMediaType(int mediaTypeId);
        public static void DeleteFromType(MediaType dt);
        public override void Save();
        public override void delete();
        public void delete(bool deletePermanently);
        public override IEnumerable GetDescendants();
        protected void PopulateMediaFromReader(IRecordsReader dr);
        protected new virtual void FireBeforeSave(SaveEventArgs e);
        protected new virtual void FireAfterSave(SaveEventArgs e);
        protected virtual void OnNew(NewEventArgs e);
        protected new virtual void FireBeforeDelete(DeleteEventArgs e);
        protected new virtual void FireAfterDelete(DeleteEventArgs e);
        protected virtual void FireBeforeMoveToTrash(MoveToTrashEventArgs e);
        protected virtual void FireAfterMoveToTrash(MoveToTrashEventArgs e);
        public new static event Media.SaveEventHandler BeforeSave;
        public new static event Media.SaveEventHandler AfterSave;
        public static event Media.NewEventHandler New;
        public new static event Media.DeleteEventHandler BeforeDelete;
        public new static event Media.DeleteEventHandler AfterDelete;
        public static event Media.MoveToTrashEventHandler BeforeMoveToTrash;
        public static event Media.MoveToTrashEventHandler AfterMoveToTrash;
    }
}
