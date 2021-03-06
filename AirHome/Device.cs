﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;

namespace ThisCoder.AirHome
{
    /// <summary>
    /// 设备类
    /// </summary>
    public class Device
    {
        /// <summary>
        /// 设备ID
        ///     <para>UInt64类型，长度为8个字节</para>
        /// </summary>
        public UInt64 DevId { get; set; }

        /// <summary>
        /// 设备名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 设备描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 设备MAC地址
        /// </summary>
        public UInt64 MacAddress { get; set; }

        /// <summary>
        /// 设备分区
        ///     <para>键为分区代码，值为分区名称</para>
        /// </summary>
        public KeyValuePair<UInt32, string> Partition { get; set; }

        /// <summary>
        /// 设备IP地址
        /// </summary>
        public IPAddress IPAddress { get; set; }

        /// <summary>
        /// 通过UInt64类型的设备ID初始化设备对象
        /// </summary>
        /// <param name="devId">
        /// 设备ID
        ///     <para>UInt64类型，长度为8个字节</para>
        /// </param>
        public Device(UInt64 devId)
        {
            DevId = devId;
            Name = devId.ToString("X8");
            Partition = new KeyValuePair<uint, string>(0X00000000, "all");
        }

        /// <summary>
        /// 通过字符串类型的设备ID初始化设备对象
        /// </summary>
        /// <param name="devId">
        /// 设备ID
        ///     <para>字符串类型，长度为8个字符</para>
        /// </param>
        public Device(string devId)
        {
            byte[] byteArray = devId.ToByteArray();
            DevId = 0X0000000000000000;

            for (int i = 0; i < byteArray.Length && i < 8; i++)
            {
                DevId += (((UInt64)(byteArray[byteArray.Length - (i + 1)])) << (8 * i));
            }

            Name = DevId.ToString("X8");
            Partition = new KeyValuePair<uint, string>(0X00000000, "all");
        }
    }

    /// <summary>
    /// 模块或通道信息
    /// </summary>
    public struct ModuleOrChannelInfo
    {
        /// <summary>
        /// 分区代码
        /// </summary>
        public UInt32 PartitionCode { get; set; }

        /// <summary>
        /// 分区名称
        /// </summary>
        public string PartitionName { get; set; }

        /// <summary>
        /// 模块或通道名称
        /// </summary>
        public string ModuleOrChannelName { get; set; }

        /// <summary>
        /// 模块或通道描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 图片名称或地址
        /// </summary>
        public string ImageName { get; set; }

        /// <summary>
        /// 获取模块或通道信息对象实例
        /// </summary>
        /// <param name="partitionCode">分区代码</param>
        /// <param name="partitionName">分区名称</param>
        /// <param name="moduleOrChannelName">模块或通道名称</param>
        /// <param name="description">模块或通道描述</param>
        /// <param name="imageName">图片名称或地址</param>
        public ModuleOrChannelInfo(UInt32 partitionCode, string partitionName, string moduleOrChannelName, string description, string imageName)
            : this()
        {
            PartitionCode = partitionCode;
            PartitionName = partitionName;
            ModuleOrChannelName = moduleOrChannelName;
            Description = description;
            ImageName = imageName;
        }
    }
}